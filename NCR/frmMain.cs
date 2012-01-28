using System;   
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Net;
using System.Collections;
using System.Xml;
using Microsoft.Win32;
using System.IO;
using System.Configuration;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Runtime.InteropServices;


namespace NCR
{    
    public partial class frmMain : Form
    {
        public string ProcessPath = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\"));
        public static Queue DVDQueue = new Queue();
        public static List<string> ExcludedDrives = new List<string>();
        public static int ConcurrentRips = 1;
        public static int CurrentRips = 0;
        public static bool NCR = false;
        public static bool ApplicationRunning = true;
        public static List<String> listDrives = new List<string>();
        public static List<String> listLastDVDs = new List<string>(5);
        public static string strDatPath = Application.CommonAppDataPath.Substring(0, Application.CommonAppDataPath.LastIndexOf("\\"));
        public static string strDatFile = "\\settings.dat";
        public ParameterizedThreadStart tsWatchDrives = new ParameterizedThreadStart(WatchDrives);
        public Thread tWatchDrives;

        public frmMain()
        {
            InitializeComponent();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Version " + this.GetType().Assembly.GetName().Version.ToString().Substring(0, 5);
            this.Text = this.Text  + "v" + this.GetType().Assembly.GetName().Version.ToString().Substring(0,3);

            FileInfo fi = new FileInfo(strDatPath + strDatFile);

            if (fi.Exists)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(strDatPath + strDatFile, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    SetSettings((Types.Settings)formatter.Deserialize(stream));
                }
                
                EnablePro();

            }
            else
            {
                // First time running
                MessageBox.Show("It appears this is your first time running No Click Rip. Please set your final directory.");
                tbFinalDirectory.Text = "";

                DirectoryInfo diHandbrake = new DirectoryInfo(@"C:\Program Files\Handbrake");
                if (!diHandbrake.Exists)
                    diHandbrake = new DirectoryInfo(@"C:\Program Files (x86)\Handbrake");
                if (!diHandbrake.Exists)
                    MessageBox.Show("Handbrake not found! Please check the location and change on the import tab.");

                DirectoryInfo di = new DirectoryInfo(Application.UserAppDataPath);
                if (!di.Exists)
                    di.Create();

                EnableFree();
                tbWorkingDirectory.Text = ProcessPath;
                cbContainer.SelectedIndex = 0;
                lblProcessDir.Text = ProcessPath;
                tbHandBrakeDirectory.Text = diHandbrake.ToString();
                SaveSettings();
            }

            niTray.Visible = true;
            if (cbHideOnStart.Checked)
            {
                timerHide.Enabled = true;
            }

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo di in drives)
            {
                if (di.DriveType == DriveType.CDRom)
                {
                    string strVolumeLabel = "";
                    try
                    {
                        strVolumeLabel = di.VolumeLabel;
                    }
                    catch { }

                    cblDrives.Items.Add(di.Name+strVolumeLabel, false);
                    cbOCRDrives.Items.Add(di.Name + strVolumeLabel);

                    if (!String.IsNullOrEmpty(strVolumeLabel))
                        cbOCRDrives.SelectedIndex = cbOCRDrives.Items.Count - 1;
                }

            }

            tWatchDrives = new Thread(tsWatchDrives);
            tWatchDrives.Start(this);


            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (cbOpenWithWindows.Checked && rkApp == null)
                cbOpenWithWindows.Checked = false;

        }
        

        private void EnableFree()
        {
            cbQuality.Enabled = false;
            cbQuality.SelectedIndex = 1;
            cbMode.SelectedIndex = 0;
            cbDVDID.SelectedIndex = 0;
            tbHandbrakeArgs.Text = lblArgs.Text;
            tbHandbrakeArgs.Enabled = false;
            domConcurrent.Text = "1";
            domConcurrent.Enabled = false;
        }

        private void EnablePro()
        {
            cbQuality.Enabled = true;
            cbMode.Enabled = true;
            tbHandbrakeArgs.Enabled = true;
            domConcurrent.Enabled = true;
        }

        private static void WatchDrives(Object o)
        {
            frmMain mf = (frmMain) o;

            while (ApplicationRunning)
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo di in drives)
                {
                    if (di.DriveType == DriveType.CDRom)
                    {
                        string strVolumeLabel = "";
                        try
                        {
                            strVolumeLabel = di.VolumeLabel;
                        }
                        catch { }


                        if (listDrives.IndexOf(di.Name + strVolumeLabel) < 0)
                        {
                            bool found = false;
                            bool changed = false;

                            foreach (string strDi in listDrives)
                            {
                                try
                                {
                                    if (strDi.StartsWith(di.Name))
                                    {
                                        if (strDi != di.Name + strVolumeLabel)
                                            changed = true;

                                        listDrives[listDrives.IndexOf(strDi)] = di.Name + strVolumeLabel;
                                        found = true;
                                    }

                                    if (found)
                                        break;


                                }
                                catch { found = false; }
                            }

                            if (!found)
                            {
                                listDrives.Add(di.Name + strVolumeLabel);
                                found = true;
                                changed = true;
                            }

                            if (changed && (di.Name + strVolumeLabel).Length > 3 && mf.btnNCROn.Enabled == false && ExcludedDrives.IndexOf(di.Name) < 0)
                            {
                                string driveletter = di.Name.Substring(0, 1);
                                bool dup = false;

                                DirectoryInfo diVTS = new DirectoryInfo(di.Name + "VIDEO_TS");
                                if (!diVTS.Exists)
                                    break;

                                try
                                {
                                    // Don't enque if it's already in the queue
                                    foreach (Types.DVDRip erips in DVDQueue)
                                        if (erips.VolumeName == di.VolumeLabel)
                                            dup = true;

                                    foreach (string s in listLastDVDs)
                                        if (s == di.VolumeLabel && di.VolumeLabel.Length > 3)
                                            dup = true;
                                }
                                catch 
                                {
                                    LogError("Drive not ready. Error 198"); 
                                }

                                if (!dup)
                                {
                                    Process newripprocess = new Process();
                                    newripprocess.OutputDataReceived += new DataReceivedEventHandler(newripprocess_OutputDataReceived);

                                    newripprocess.StartInfo.Domain = driveletter + ":\\" + strVolumeLabel;

                                    Types.DVDRip dvdrip = new Types.DVDRip(
                                        driveletter,
                                        strVolumeLabel,
                                        GetSettings(),
                                        newripprocess);

                                    if (listLastDVDs.Count > 4)
                                        listLastDVDs.RemoveRange(0, 1);

                                    listLastDVDs.TrimExcess();
                                    listLastDVDs.Add(di.VolumeLabel);

                                    MethodInvoker actionAddQueue = delegate
                                    {
                                        mf.lvQueue.Items.Add(new ListViewItem(new string[] { driveletter, strVolumeLabel, "Queued" }));
                                    };

                                    mf.BeginInvoke(actionAddQueue);

                                    DVDQueue.Enqueue(dvdrip);
                                    CurrentRips++;
                                }
                            }


                        }
                    }
                }

                MethodInvoker action = delegate
                {
                    mf.cblDrives.Items.Clear();
                    mf.cbOCRDrives.Items.Clear();
                    foreach (string s in listDrives)
                    {
                        if (ExcludedDrives.IndexOf(s.Substring(0,3)) < 0)
                            mf.cblDrives.Items.Add(s, true);
                        else
                            mf.cblDrives.Items.Add(s, false);
                        mf.cbOCRDrives.Items.Add(s);

                        if (s.Length > 3)
                            mf.cbOCRDrives.SelectedIndex = mf.cbOCRDrives.Items.Count - 1;
                    }                    
                };

                mf.BeginInvoke(action);
                System.Threading.Thread.Sleep(5000);
            }
        }

        static void newripprocess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Process rip = (Process) sender;
            frmMain mf = (frmMain) Application.OpenForms["frmMain"];
            bool update = false;

            MethodInvoker action = delegate
            {
                foreach (ListViewItem lvi in mf.lvRips.Items)
                {
                    string percent = "";
                    try
                    {
                        //12345678912345
                        //aa, 100.0% aaa
                        //3
                        //11
                        //15
                        int comma = e.Data.IndexOf(",");
                        int perce = e.Data.IndexOf("%");
                        int lenth = e.Data.Length;

                        percent = e.Data.Substring(comma+1, perce-comma);
                    }
                    catch { }

                    if (lvi.SubItems[0].Text == rip.Id.ToString())
                    {
                        lvi.SubItems[1].Text = rip.StartInfo.Domain;
                        lvi.SubItems[2].Text = percent;

                        if (percent == "")
                            lvi.Remove();

                        update = true;
                    }
                }

                
                if (!update && !rip.HasExited)
                {
                    ListViewItem lvitem = new ListViewItem(new string[] { rip.Id.ToString(), "", "0%"});
                    mf.lvRips.Items.Add(lvitem);
                }
            };

            mf.BeginInvoke(action);
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

        private static void ProcessQueue()
        {
            while (DVDQueue.Count > 0 && CurrentRips <= ConcurrentRips)
            {
                Types.DVDRip rip = (Types.DVDRip) DVDQueue.Dequeue();

                frmMain mf = (frmMain) Application.OpenForms["frmMain"];

                ParameterizedThreadStart ts = new ParameterizedThreadStart(CD.RipDVD);
                Thread tRipDVD = new Thread(ts);
                tRipDVD.Start(rip);
            }
        }

        private void btnOCR_Click(object sender, EventArgs e)
        {
            if (cbOCRDrives.SelectedIndex > -1)
            {
                ParameterizedThreadStart ts = new ParameterizedThreadStart(CD.RipDVD);
                Thread tRipDVD = new Thread(ts);
                Process ripprocess = new Process();
                ripprocess.StartInfo.Domain = cbOCRDrives.SelectedItem.ToString();
                ripprocess.OutputDataReceived += new DataReceivedEventHandler(newripprocess_OutputDataReceived);
                tRipDVD.Start(new Types.DVDRip(cbOCRDrives.SelectedItem.ToString().Substring(0, 1), cbOCRDrives.SelectedItem.ToString().Substring(3), GetSettings(), ripprocess));
                lvQueue.Items.Add(new ListViewItem(new string[] { cbOCRDrives.SelectedItem.ToString().Substring(0, 1), cbOCRDrives.SelectedItem.ToString().Substring(3), "Queued" }));
                tabControl1.SelectedTab = tabPage5;
                CurrentRips++;

            }
        }

        public static Types.Settings GetSettings()
        {
            Types.Settings sett = new Types.Settings();

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(strDatPath + strDatFile, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                sett = (Types.Settings)formatter.Deserialize(stream);
            }

            return sett;   
        }

        public static void UpdateQueueStatus(string VolumeName, string NewStatus)
        {
            try
            {
                frmMain mf = (frmMain)Application.OpenForms["frmMain"];
                MethodInvoker action = delegate
                {
                    foreach (ListViewItem lvi in mf.lvQueue.Items)
                    {
                        if (lvi.SubItems[1].Text == VolumeName && NewStatus == "Delete")
                        {
                            CurrentRips--;
                            lvi.Remove();
                        }
                        else if (lvi.SubItems[1].Text == VolumeName)
                            lvi.SubItems[2].Text = NewStatus;
                    }
                };

                mf.BeginInvoke(action);
            }
            catch { }
        }
        
        public Types.Settings ScreenSettings()
        {
            Types.Settings sett = new Types.Settings();
            frmMain main = (frmMain) Application.OpenForms["frmMain"];

            sett.EmptyWorking = main.cbCleanUp.Checked;
            sett.HideOnStart = main.cbHideOnStart.Checked;
            sett.Arguments = main.tbHandbrakeArgs.Text;
            sett.ConcurrentRips = int.Parse(main.domConcurrent.Text);
            ConcurrentRips = sett.ConcurrentRips;
            sett.SupressErrors = cbSupress.Checked;
            
            sett.Container = main.cbContainer.Text;
            sett.Quality = main.cbQuality.Text;
            sett.DVDID = main.cbDVDID.Text;

            sett.AskNotFound = main.cbAskNotFound.Checked;
            sett.Mode = main.cbMode.Text;
            sett.ProtechNCR = main.cbProtect.Checked;
            sett.OpenWithWindows = main.cbOpenWithWindows.Checked;
            sett.DVDXMLUsername = main.tbXMLDVDUsername.Text;
            sett.DVDXMLPassword = main.tbXMLDVDPassword.Text;
            sett.CoverName = main.tbCoverName.Text;
            sett.EjectDuplicates = main.cbEjectDuplicates.Checked;
            sett.ExportCover = main.cbExportCover.Checked;
            sett.ExportDVDXML = main.cbExportDVDID.Checked;
            sett.FinalDir = main.tbFinalDirectory.Text;
            sett.HandBrakeDir = main.tbHandBrakeDirectory.Text;
            sett.MoveToFinal = main.cbMoveToFinal.Checked;
            sett.OpenCD = main.cbEjectOnCompletion.Checked;
            sett.ProcessPath = main.ProcessPath;
            sett.RemoveDVDXMLExtra = main.cbCleanDVDXML.Checked;
            sett.WorkingDir = main.tbWorkingDirectory.Text;
            sett.NCRRunning = main.btnNCROff.Enabled;

            if (main.rbDVDSupplied.Checked)
                sett.LookupType = "DVD";
            else if (main.rbDVDXML.Checked)
                sett.LookupType = "DVDXML";
            else if (main.rbUserSupplied.Checked)
                sett.LookupType = "USER";

            return sett; 

        }

        public static void SetSettings(Types.Settings sett)
        {
            frmMain main = (frmMain)Application.OpenForms["frmMain"];

            main.tbHandbrakeArgs.Text = sett.Arguments;
            main.domConcurrent.Text = sett.ConcurrentRips.ToString();

            if (sett.NCRRunning)
                main.btnNCROn_Click(null, null);

            // v0.2
            try
            {
                main.cbMode.SelectedIndex = main.cbMode.Items.IndexOf(sett.Mode);
                main.cbAskNotFound.Checked = sett.AskNotFound;
            }
            catch
            {
                main.cbMode.SelectedIndex = 0;
                main.cbAskNotFound.Checked = true;
            }

            // v0.1
            main.cbProtect.Checked = sett.ProtechNCR;
            main.cbCleanUp.Checked = sett.EmptyWorking;
            main.cbHideOnStart.Checked = sett.HideOnStart;
            main.cbContainer.SelectedIndex = main.cbContainer.Items.IndexOf(sett.Container);
            main.tbCoverName.Text = sett.CoverName;
            main.cbDVDID.SelectedIndex =  main.cbDVDID.Items.IndexOf(sett.DVDID);
            main.cbEjectDuplicates.Checked = sett.EjectDuplicates;
            main.cbExportCover.Checked = sett.ExportCover;
            main.cbExportDVDID.Checked = sett.ExportDVDXML;
            main.tbFinalDirectory.Text = sett.FinalDir;
            main.tbHandBrakeDirectory.Text = sett.HandBrakeDir;
            main.cbMoveToFinal.Checked = sett.MoveToFinal;
            main.cbEjectOnCompletion.Checked = sett.OpenCD;
            main.ProcessPath = sett.ProcessPath;
            main.cbQuality.SelectedIndex = main.cbQuality.Items.IndexOf(sett.Quality);
            main.cbCleanDVDXML.Checked = sett.RemoveDVDXMLExtra;
            main.tbWorkingDirectory.Text = sett.WorkingDir;
            main.tbXMLDVDUsername.Text = sett.DVDXMLUsername;
            main.tbXMLDVDPassword.Text = sett.DVDXMLPassword;
            main.cbOpenWithWindows.Checked = sett.OpenWithWindows;
            main.cbSupress.Checked = sett.SupressErrors;

            if (sett.LookupType == "DVD")
                main.rbDVDSupplied.Checked = true;
            else if (sett.LookupType == "DVDXML")
                main.rbDVDXML.Checked = true;
            else if (sett.LookupType == "USER")
                main.rbUserSupplied.Checked = true;
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


            

        //public int QueryCancelAutoPlay = 0;

        //protected override void WndProc(ref System.Windows.Forms.Message m)
        //{
        //    if (QueryCancelAutoPlay == 0)
        //    {
        //        QueryCancelAutoPlay = Util.RegisterWindowMessage("QueryCancelAutoPlay");
        //    }
        //    if (m.Msg == QueryCancelAutoPlay)
        //    {
        //        m.Result = (IntPtr)1;
        //        return;
        //    }
        //    base.WndProc(ref m);
        //}

        public class Util
        {
            [DllImport("user32", EntryPoint = "RegisterWindowMessage")]
            public static extern int RegisterWindowMessage(string msgString);

            public Util()
            {
            }

        }


        private void SaveSettings()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(strDatPath + strDatFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, ScreenSettings());
            }             
        }

        private void btnNCROn_Click(object sender, EventArgs e)
        {
            btnNCROn.Enabled = false;
            btnNCROff.Enabled = true;
            timerQueue.Start();
            startNoClickRipToolStripMenuItem.Text = "Stop No Click Rip";
        }

        private void btnNCROff_Click(object sender, EventArgs e)
        {
            btnNCROn.Enabled = true;
            btnNCROff.Enabled = false;
            timerQueue.Stop();
            startNoClickRipToolStripMenuItem.Text = "Start No Click Rip";
        }

        private void timerQueue_Tick(object sender, EventArgs e)
        {
            ProcessQueue();
        }

        private void rbDVDXML_Click(object sender, EventArgs e)
        {

        }

        private void rbDVDXML_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDVDXML.Checked)
            {
                lblUserName.Enabled = true;
                lblPassword.Enabled = true;
                cbCleanDVDXML.Enabled = true;
                tbXMLDVDPassword.Enabled = true;
                tbXMLDVDUsername.Enabled = true;
            }
            else
            {
                lblUserName.Enabled = false;
                lblPassword.Enabled = false;
                cbCleanDVDXML.Enabled = false;
                tbXMLDVDPassword.Enabled = false;
                tbXMLDVDUsername.Enabled = false;
            }
        }

        private void cblDrives_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
            {
                if (ExcludedDrives.IndexOf(cblDrives.Items[e.Index].ToString().Substring(0,3)) < 0)
                    ExcludedDrives.Add(cblDrives.Items[e.Index].ToString().Substring(0,3));
            }
            else if (e.NewValue == CheckState.Checked)
            {
                if (ExcludedDrives.IndexOf(cblDrives.Items[e.Index].ToString().Substring(0, 3)) > -1)
                    ExcludedDrives.Remove(cblDrives.Items[e.Index].ToString().Substring(0, 3));
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExitApp()
        {
            ApplicationRunning = false;
            tWatchDrives.Abort();
        }

        private void btnFinalDir_Click(object sender, EventArgs e)
        {
            fbdFinal.SelectedPath = tbFinalDirectory.Text;
            if (fbdFinal.ShowDialog() == DialogResult.OK)
                tbFinalDirectory.Text = fbdFinal.SelectedPath;

        }

        private void btnGetWorkingDirectory_Click(object sender, EventArgs e)
        {
            fbdWorking.SelectedPath = tbWorkingDirectory.Text;
            if (fbdWorking.ShowDialog() == DialogResult.OK)
                tbWorkingDirectory.Text = fbdWorking.SelectedPath;

        }

        private void btnHandbrakeDir_Click(object sender, EventArgs e)
        {
            fbdHandbrake.SelectedPath = tbHandBrakeDirectory.Text;
            if (fbdHandbrake.ShowDialog() == DialogResult.OK)
                tbHandBrakeDirectory.Text = fbdHandbrake.SelectedPath;

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm();        
        }

        private void startNoClickRipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnNCROff.Enabled)
                btnNCROff_Click(this, null);
            else
                btnNCROn_Click(this, null);
        }

        private void cmTray_DoubleClick(object sender, EventArgs e)
        {
            ShowForm();
        }
        
        private void HideForm()
        {
            //this.ShowInTaskbar = false;
            Hide();
        }

        private void ShowForm()
        {
            //this.WindowState = FormWindowState.Normal;
            //this.ShowInTaskbar = true;
            Show();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            SaveSettings();
            HideForm();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            ExitApp();
        }

        private void timerHide_Tick(object sender, EventArgs e)
        {
            this.HideForm();
            timerHide.Enabled = false;
        }

        private void cbOpenWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (cbOpenWithWindows.Checked)
                rkApp.SetValue("No Click Rip", Application.ExecutablePath.ToString());
            else
                rkApp.DeleteValue("No Click Rip", false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void lvRips_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRips.SelectedIndices.Count > 0)
                btnKillRip.Enabled = true;
            else
                btnKillRip.Enabled = false;

        }

        private void btnKillRip_Click(object sender, EventArgs e)
        {                
            ListView.SelectedListViewItemCollection lvic = lvRips.SelectedItems;

            foreach (ListViewItem lvi in lvic)
            {
                try
                {
                    if (lvi.SubItems[0].Text == "ISO")
                        CD.cISO.Stop();
                    else
                    {
                        Process ripprocess = Process.GetProcessById(int.Parse(lvi.SubItems[0].Text));
                        ripprocess.Kill();
                    }
                }
                finally
                {
                    lvi.Remove();
                }

            }

        }

        private void cbProtect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey rkApp = Registry.LocalMachine;
                RegistryKey rkApp2 = null;

                if (Application.ExecutablePath.Contains("(x86)"))
                {
                    rkApp = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\SlySoft\\AnyDVD\\ADvdDiscHlpProcesses", true);
                    rkApp2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\SlySoft\\AnyDVD\\ADvdDiscHlpProcesses64", true);
                }
                else
                    rkApp = Registry.LocalMachine.OpenSubKey("SOFTWARE\\SlySoft\\AnyDVD\\ADvdDiscHlpProcesses", true);

                if (cbProtect.Checked)
                {
                    rkApp.SetValue("NCR.exe", 1);
                    rkApp.SetValue("dvdid.exe", 1);
                    rkApp.SetValue("DirectShowLib-2005.dll", 1);

                    if (rkApp2 != null)
                    {
                        rkApp2.SetValue("NCR.exe", 1);
                        rkApp2.SetValue("dvdid.exe", 1);
                        rkApp2.SetValue("DirectShowLib-2005.dll", 1);
                    }

                    rkApp.Close();
                }
                else
                {
                    rkApp.DeleteValue("NCR.exe");
                    rkApp.DeleteValue("dvdid.exe");
                    rkApp.DeleteValue("DirectShowLib-2005.dll");
                    rkApp.Close();

                    if (rkApp2 != null)
                    {
                        rkApp2.DeleteValue("NCR.exe");
                        rkApp2.DeleteValue("dvdid.exe");
                        rkApp2.DeleteValue("DirectShowLib-2005.dll");
                        rkApp2.Close();
                    }
                }
            }
            catch 
            {
                LogError("There was an error changing the registry for AnyDVD protection.");
            
            }
        }

        public static void LogError(string ErrorMessage)
        {

            try
            {
                frmMain mf = (frmMain)Application.OpenForms["frmMain"];
                MethodInvoker action = delegate
                {
                    mf.lbConsole.Items.Add(ErrorMessage);

                    if (!mf.cbSupress.Checked)
                    {
                        MessageBox.Show(ErrorMessage);
                    }
                };

                mf.BeginInvoke(action);
            }
            catch { }
        }

        private void domConcurrent_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                ConcurrentRips = int.Parse(domConcurrent.Text);
            }
            catch
            {
                domConcurrent.Text = "1";
                ConcurrentRips = 1;
            }
        }
    }  

}
