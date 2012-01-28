using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Web;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using DirectShowLib;

namespace NCR
{
    class CD
    {

        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(String command, StringBuilder buffer, Int32 bufferSize, IntPtr hwndCallback);

        [DllImport("winmm.dll", EntryPoint = "mciSendString")]
        public static extern int mciSendStringA(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        public static Iso9660.Iso9660 cISO;
        public static string strIsoName;
        public static string strIsoFile;
        public static bool boolIsoDone;
        public static bool boolIsoError;

        public static void OpenCD(string strDrive)
        {
            bool ejected = false;
            int trys = 0;

            while (!ejected)
            {
                trys ++;
                string returnString = "";


                mciSendStringA("open " + strDrive + ": type CDAudio alias drive" + strDrive, returnString, 0, 0);
                mciSendStringA("set drive" + strDrive + " door open", returnString, 0, 0);
                mciSendStringA("close drive" + strDrive, returnString, 0, 0);

                Thread.Sleep(1000);
                
                DriveInfo di = new DriveInfo(strDrive);
                if (!di.IsReady || string.IsNullOrEmpty(di.VolumeLabel))
                    ejected = true;

                if (trys > 10)
                    ejected = true;

            }
        }


        public static XmlDocument CreateDVDID(string DVDID)
        {
            XmlDocument xmlDVDID = new XmlDocument();
            XmlDeclaration xmldecDVDID = xmlDVDID.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDVDID.AppendChild(xmldecDVDID);

            xmlDVDID.AppendChild(xmlDVDID.CreateElement("Disc"));
            xmlDVDID["Disc"].AppendChild(xmlDVDID.CreateElement("ID"));
            xmlDVDID["Disc"]["ID"].InnerText = DVDID;

            return xmlDVDID;
        }

        public static XmlDocument CreateDVDXMLRequest(string DVDID)
        {
            XmlDocument xmlDVDIDReq = new XmlDocument();
            xmlDVDIDReq.AppendChild(xmlDVDIDReq.CreateElement("dvdXml"));

            XmlElement nodeAuthentication = xmlDVDIDReq.CreateElement("Authentication");
            XmlElement nodeRequests = xmlDVDIDReq.CreateElement("requests");

            XmlElement nodeUser = xmlDVDIDReq.CreateElement("user");
            nodeUser.InnerText = "jgennari";
            XmlElement nodePassword = xmlDVDIDReq.CreateElement("password");
            nodePassword.InnerText = "delphi6";

            nodeAuthentication.AppendChild(nodeUser);
            nodeAuthentication.AppendChild(nodePassword);

            XmlElement nodeRequest = xmlDVDIDReq.CreateElement("request");
            nodeRequest.Attributes.Append(xmlDVDIDReq.CreateAttribute("type"));
            nodeRequest.Attributes["type"].Value = "information";

            XmlElement nodeDvdID = xmlDVDIDReq.CreateElement("dvdId");
            nodeDvdID.InnerText = DVDID;
            nodeRequest.AppendChild(nodeDvdID);
            nodeRequests.AppendChild(nodeRequest);

            xmlDVDIDReq.DocumentElement.AppendChild(nodeAuthentication);
            xmlDVDIDReq.DocumentElement.AppendChild(nodeRequests);

            return xmlDVDIDReq;
        }

        private static string RunExec(string ExecName, string ExecArgs, bool WaitForExit)
        {
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = ExecName;
            p.StartInfo.Arguments = ExecArgs;
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string output = "";

            if (WaitForExit)
            {
                output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }

            return output;
        }

        public static string GetDVDID(string Drive)
        {
            long id = 0;
            int hr;
            object comobj = null;
            DirectShowLib.Dvd.AMDvdRenderStatus status;
            DirectShowLib.Dvd.IDvdGraphBuilder dvdGraph = (DirectShowLib.Dvd.IDvdGraphBuilder)new DirectShowLib.DvdGraphBuilder();
            hr = dvdGraph.RenderDvdVideoVolume(null, DirectShowLib.Dvd.AMDvdGraphFlags.None, out status);
            DsError.ThrowExceptionForHR(hr);
            hr = dvdGraph.GetDvdInterface(typeof(DirectShowLib.Dvd.IDvdInfo2).GUID, out comobj);
            DsError.ThrowExceptionForHR(hr);

            DirectShowLib.Dvd.IDvdInfo2 dvdInfo = (DirectShowLib.Dvd.IDvdInfo2)comobj;
            //comobj = null;
            dvdInfo.GetDiscID(Drive + ":\\VIDEO_TS", out id);
            const int HEXADECIMAL = 16;
            String HexID = Convert.ToString(id, HEXADECIMAL);
            return HexID;
        }


        private static string RunExec(string ExecName, string ExecArgs, bool WaitForExit, Process p, string VolumeName, out int ExitCode)
        {
            // Start the child process.
            //Process p = new Process();
            // Redirect the output stream of the child process.
            ExitCode = 0;

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = ExecName;
            p.StartInfo.Arguments = ExecArgs;
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string output = "";

            if (WaitForExit)
            {
                p.BeginOutputReadLine();
                frmMain.UpdateQueueStatus(VolumeName, "Ripping");
                p.WaitForExit();
            }

            ExitCode = p.ExitCode;

            return output;
        }

        public static void RipDVD(Object o)
        {
            Types.DVDRip dvdrip = (Types.DVDRip)o;
            string XmlDvdID = "";

            String strDVDTitle = "";
            String strDVDID = "";
            String strDVDCover = "";

            // Check for Video TS folder
            DirectoryInfo diVTS = new DirectoryInfo(dvdrip.RipDrive + ":\\VIDEO_TS");
            if (!diVTS.Exists)
            {
                MessageBox.Show("Drive " + dvdrip.RipDrive + " does not contain a DVD!");
                return;
            }

            // Read DVDID from unencryted DVD
            switch (dvdrip.Settings.DVDID)
            {
                case "None":
                    break;
                case "DVDID.exe":
                    frmMain.UpdateQueueStatus(dvdrip.VolumeName, "Reading DVDID");
                    RunExec(dvdrip.Settings.ProcessPath + "\\AnyTool.exe", "-d", true);
                    XmlDvdID = RunExec(dvdrip.Settings.ProcessPath + "\\DVDID.exe", dvdrip.RipDrive + ":\\", true);
                    RunExec(dvdrip.Settings.ProcessPath + "\\AnyTool.exe", "-e", true);
                    break;
                case "DirectX":
                    frmMain.UpdateQueueStatus(dvdrip.VolumeName, "Reading DVDID");
                    XmlDvdID = GetDVDID(dvdrip.RipDrive);
                    break;
                default:
                    break;
            }

            // Get DVD information from webservice, DVD or user
            ReadDVD:
            if (dvdrip.Settings.LookupType == "DVDXML" && XmlDvdID != "")
            {
                try
                {
                    frmMain.UpdateQueueStatus(dvdrip.VolumeName, "Getting DVDXML");
                    XmlDocument xmlRequest = CreateDVDXMLRequest(XmlDvdID.Replace("|", ""));
                    XmlDocument xmlReturn = PostXMLTransaction("http://api.dvdxml.com", xmlRequest);
                    strDVDTitle = xmlReturn["dvdXml"]["dvd"]["title"].InnerText;
                    strDVDID = xmlReturn["dvdXml"]["dvd"]["dvdId"].InnerText;
                    strDVDCover = xmlReturn["dvdXml"]["dvd"]["dvdCover"].InnerText;
                    if (dvdrip.Settings.RemoveDVDXMLExtra && strDVDTitle.IndexOf("[") > -1)
                        strDVDTitle = strDVDTitle.Remove(strDVDTitle.IndexOf("[") - 1);

                    if (strDVDTitle == "")
                    {
                        if (dvdrip.Settings.AskNotFound)
                            dvdrip.Settings.LookupType = "USER";
                        else
                            dvdrip.Settings.LookupType = "DVD";
                        goto ReadDVD;
                    }
                }
                catch
                {
                    //DialogResult dr = MessageBox.Show("DVDXML information is unavailable. Click abort to enter the information or ignore to use the information from the DVD.", "DVDXML Unavailable", MessageBoxButtons.AbortRetryIgnore);
                    //if (dr == DialogResult.Abort)
                    //    dvdrip.Settings.LookupType = "USER";
                    //else if (dr == DialogResult.Ignore)
                    dvdrip.Settings.LookupType = "DVD";
                    goto ReadDVD;
                }
            }
            else if (dvdrip.Settings.LookupType == "DVD")
            {
                strDVDTitle = dvdrip.VolumeName;
            }
            else if (dvdrip.Settings.LookupType == "USER")
            {
                frmQueryDVD fq = new frmQueryDVD();
                fq.btnDVDID.Text = XmlDvdID;
                fq.ShowDialog();
                strDVDTitle = fq.btnName.Text;
                strDVDID = fq.btnDVDID.Text;
                strDVDCover = fq.btnCover.Text;
                if (strDVDTitle == "")
                {
                    DialogResult dr = MessageBox.Show("No DVD information entered. Press OK to use DVD-provided information or cancel to stop the rip.", "No DVD Information Provided", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        dvdrip.Settings.LookupType = "DVD";
                        goto ReadDVD;
                    }
                    else
                    {
                        frmMain.UpdateQueueStatus(dvdrip.VolumeName, "Delete");
                        return;
                    }
                }
            }

            string strDVDFile = FilenameFromTitle(strDVDTitle);
            string strWorkingDir = dvdrip.Settings.WorkingDir + "\\" + strDVDFile;
            string strFinalDir = dvdrip.Settings.FinalDir + "\\" + strDVDFile;

            DirectoryInfo dirDVD = new DirectoryInfo(strWorkingDir);
            DirectoryInfo dirFinalDVD = new DirectoryInfo(strFinalDir);

            if (dirDVD.Exists || dirFinalDVD.Exists)
            {
                MessageBox.Show("This DVD has already been ripped!");
                frmMain.UpdateQueueStatus(dvdrip.VolumeName, "Delete");
                CD.OpenCD(dvdrip.RipDrive);
                return;
            }
            else
                dirDVD = Directory.CreateDirectory(strWorkingDir);

            if (strDVDCover != "" && dvdrip.Settings.ExportCover)
            {
                try
                {
                    frmMain.UpdateQueueStatus(dvdrip.VolumeName, "Getting Cover");
                    WebClient wcImageDownload = new WebClient();
                    wcImageDownload.DownloadFile(strDVDCover, strWorkingDir + "\\folder.jpg");
                    wcImageDownload = null;
                }
                catch
                {
                    MessageBox.Show("Error downloading cover.");
                }
            }

            if (dvdrip.Settings.ExportDVDXML && strDVDID != "")
            {
                frmMain.UpdateQueueStatus(dvdrip.VolumeName, "Creating DVDID");
                CreateDVDID(XmlDvdID).Save(strWorkingDir + "\\" + strDVDFile + ".dvdid.xml");
            }

            string strHandBrakeCLI = dvdrip.Settings.Arguments;
            strHandBrakeCLI = strHandBrakeCLI.Replace("%s", dvdrip.RipDrive + ":\\VIDEO_TS");
            strHandBrakeCLI = strHandBrakeCLI.Replace("%d", strDVDFile);
            if (dvdrip.Settings.Container != "None")
                strHandBrakeCLI = strHandBrakeCLI.Replace("%c", dvdrip.Settings.Container);
            strHandBrakeCLI = strHandBrakeCLI.Replace("%w", dvdrip.Settings.WorkingDir);
            strHandBrakeCLI = strHandBrakeCLI.Replace("%f", dvdrip.Settings.FinalDir);

            string qual = "";
            if (dvdrip.Settings.Quality == "High")
                qual = "-q 0.62";
            else if (dvdrip.Settings.Quality == "Medium")
                qual = "-q 0.45";
            else if (dvdrip.Settings.Quality == "Low")
                qual = "-q 0.20";
            else if (dvdrip.Settings.Quality == "Ultra High")
                qual = "-q 0.75";

            strHandBrakeCLI = strHandBrakeCLI.Replace("%q", qual);

            DriveInfo diWorkingDrive = new DriveInfo(dvdrip.RipDrive);
            while (!diWorkingDrive.IsReady)
            {
                System.Threading.Thread.Sleep(200);
            }

            int ExitCode = 0;

            if (dvdrip.Settings.Mode == "HandBrake Encode")
            {
                try
                {
                    frmMain.UpdateQueueStatus(dvdrip.VolumeName, "Scanning");
                    RunExec(dvdrip.Settings.HandBrakeDir + "\\HandBrakeCLI.exe", strHandBrakeCLI, true, dvdrip.RipProcess, dvdrip.VolumeName, out ExitCode);
                }
                catch
                {
                    MessageBox.Show("Error during ripping process.");
                }
            }

            if (dvdrip.Settings.Mode == "ISO")
            {
                frmMain.UpdateQueueStatus(dvdrip.VolumeName, "Ripping ISO");
                strIsoName = dvdrip.VolumeName;
                strIsoFile = dvdrip.RipDrive+ ":\\" + dvdrip.VolumeName;
                cISO = new Iso9660.Iso9660();
                boolIsoDone = false;
                boolIsoError = false;
                cISO.OnProgress += new Iso9660.Iso9660EventHandler(cISO_OnProgress);
                cISO.OnFinish += new Iso9660.Iso9660EventHandler(cISO_OnFinish);
                cISO.OnMessage += new Iso9660.Iso9660EventHandler(cISO_OnMessage);
                cISO.MakeIsoFromCD(dvdrip.RipDrive + ":\\", dvdrip.Settings.WorkingDir + "\\" + strDVDFile + "\\" + strDVDFile + ".iso");

                while (!boolIsoDone)
                {
                    Thread.Sleep(500);
                }
                
                if (boolIsoError)
                    ExitCode = -1;                
            }

            if (dvdrip.Settings.Mode == "Direct to Folder")
            {
                frmMain.UpdateQueueStatus(dvdrip.VolumeName, "Copying Folder");
                CopyFolder(dvdrip.RipDrive + ":\\", strWorkingDir);
            }
            
            if (ExitCode == -1)
            {
                foreach (FileInfo fi in dirDVD.GetFiles())
                    fi.Delete();

                dirDVD.Delete();
            }

            if (dvdrip.Settings.MoveToFinal)
            {
                try
                {
                    frmMain.UpdateQueueStatus(dvdrip.VolumeName, "Copying");
                    CopyFolder(strWorkingDir, strFinalDir);

                    if (dvdrip.Settings.EmptyWorking)
                        DeleteFileSystemInfo(dirDVD);
                }
                catch
                {
                    frmMain.LogError("Error moving to final directory.");
                }
            }

            try
            {
                frmMain.UpdateQueueStatus(dvdrip.VolumeName, "Ejecting");
                if (dvdrip.Settings.OpenCD)
                    CD.OpenCD(dvdrip.RipDrive);
            }
            catch
            {
                MessageBox.Show("Error ejecting DVD.");
            }


            frmMain.UpdateQueueStatus(dvdrip.VolumeName, "Delete");
        }

        private static void DeleteFileSystemInfo(FileSystemInfo fsi)
        {
            fsi.Attributes = FileAttributes.Normal;
            var di = fsi as DirectoryInfo;

            if (di != null)
            {
                foreach (var dirInfo in di.GetFileSystemInfos())
                    DeleteFileSystemInfo(dirInfo);
            }

            fsi.Delete();
        }

        static void cISO_OnMessage(Iso9660.EventIso9660 e)
        {
            string strError = e.ErrorMessage;
            boolIsoError = true;
        }

        static void cISO_OnFinish(Iso9660.EventIso9660 e)
        {
            boolIsoDone = true;

            frmMain mf = (frmMain)Application.OpenForms["frmMain"];
            MethodInvoker action = delegate
            {
                foreach (ListViewItem lvi in mf.lvRips.Items)
                {
                    if (lvi.SubItems[0].Text == "ISO")
                        lvi.Remove();
                }
            };

            mf.BeginInvoke(action);
        }

        static public void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }

        public static bool RecursiveDelete(string dir, bool recursive)
        {
            bool status = false;
            try
            {
                if (!System.IO.Directory.Exists(dir))
                {
                    status = false;
                }
                else
                {
                    string[] dirs = Directory.GetDirectories(dir);
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        string[] subFiles = Directory.GetFiles(dirs[i]);
                        string[] names = Directory.GetFiles(dir);
                        foreach (string file in names)
                            File.Delete(file);

                        if (recursive == true)
                        {
                            foreach (string file in subFiles)
                                File.Delete(file);

                            foreach (string sub in dirs)
                                RecursiveDelete(sub, recursive);
                        }
                    }
                    status = true;
                }
            }
            catch (Exception ex)
            {
                status = false;
                MessageBox.Show(ex.Message);
            }
            return status;
        }

        static void cISO_OnProgress(Iso9660.EventIso9660 e)
        {
            frmMain mf = (frmMain)Application.OpenForms["frmMain"];
            bool update = false;

            MethodInvoker action = delegate
            {
                foreach (ListViewItem lvi in mf.lvRips.Items)
                {
                    
                    float fPercent = e.WrittenSize / float.Parse(cISO.SizeOfCD.ToString());

                    if (lvi.SubItems[0].Text == "ISO" && lvi.SubItems[2].Text != fPercent.ToString("0.0%"))
                    {
                        lvi.SubItems[1].Text = strIsoFile;
                        lvi.SubItems[2].Text = fPercent.ToString("0.0%");

                        if (fPercent == 1)
                            lvi.Remove();
                    }

                    update = true;
                }


                if (!update)
                {
                    ListViewItem lvitem = new ListViewItem(new string[] { "ISO", strIsoFile, "0%" });
                    mf.lvRips.Items.Add(lvitem);
                }
            };

            mf.BeginInvoke(action);
        }


        public static XmlDocument PostXMLTransaction(string v_strURL, XmlDocument v_objXMLDoc)
        {
            //Declare XMLResponse document
            XmlDocument XMLResponse = null;

            //Declare an HTTP-specific implementation of the WebRequest class.
            HttpWebRequest objHttpWebRequest;

            //Declare an HTTP-specific implementation of the WebResponse class
            HttpWebResponse objHttpWebResponse = null;

            //Declare a generic view of a sequence of bytes
            Stream objRequestStream = null;
            Stream objResponseStream = null;

            //Declare XMLReader
            XmlTextReader objXMLReader;

            //Creates an HttpWebRequest for the specified URL.
            objHttpWebRequest = (HttpWebRequest)WebRequest.Create(v_strURL);

            try
            {
                //---------- Start HttpRequest 

                //Set HttpWebRequest properties
                byte[] bytes;
                bytes = System.Text.Encoding.ASCII.GetBytes(v_objXMLDoc.InnerXml);
                objHttpWebRequest.Method = "POST";
                objHttpWebRequest.ContentLength = bytes.Length;
                objHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";

                //Get Stream object 
                objRequestStream = objHttpWebRequest.GetRequestStream();

                //Writes a sequence of bytes to the current stream 
                objRequestStream.Write(bytes, 0, bytes.Length);

                //Close stream
                objRequestStream.Close();

                //---------- End HttpRequest

                //Sends the HttpWebRequest, and waits for a response.
                objHttpWebResponse = (HttpWebResponse)objHttpWebRequest.GetResponse();

                //---------- Start HttpResponse
                if (objHttpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Get response stream 
                    objResponseStream = objHttpWebResponse.GetResponseStream();

                    //Load response stream into XMLReader
                    objXMLReader = new XmlTextReader(objResponseStream);

                    //Declare XMLDocument
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(objXMLReader);

                    //Set XMLResponse object returned from XMLReader
                    XMLResponse = xmldoc;

                    //Close XMLReader
                    objXMLReader.Close();
                }

                //Close HttpWebResponse
                objHttpWebResponse.Close();
            }
            catch (WebException we)
            {
                //TODO: Add custom exception handling
                throw new Exception(we.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //Close connections
                objRequestStream.Close();
                objResponseStream.Close();
                objHttpWebResponse.Close();

                //Release objects
                objXMLReader = null;
                objRequestStream = null;
                objResponseStream = null;
                objHttpWebResponse = null;
                objHttpWebRequest = null;
            }

            //Return
            return XMLResponse;
        }

        public static string FilenameFromTitle(string name)
        {
            // first trim the raw string
            string safe = name.Trim();

            // replace any 'double spaces' with singles
            if (safe.IndexOf("  ") > -1)
                while (safe.IndexOf("  ") > -1)
                    safe = safe.Replace("  ", " ");

            foreach (var c in Path.GetInvalidFileNameChars())
                safe = safe.Replace(c, ' ');

            // trim the length
            if (safe.Length > 50)
                safe = safe.Substring(0, 49);

            // clean the beginning and end of the filename
            safe = safe.TrimStart();
            safe = safe.TrimEnd();

            return safe;
        }



    }
}
