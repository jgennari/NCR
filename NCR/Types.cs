using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace NCR
{
    public class Types
    {
        [Serializable]
        public class Settings
        {
            private string mode;
            public string Mode
            {
                get { return mode; }
                set { mode = value; }
            }

            private string lookuptype;
            public string LookupType
            {
                get { return lookuptype; }
                set { lookuptype = value; }
            }

            private string dvdid;
            public string DVDID
            {
                get { return dvdid; }
                set { dvdid = value; }
            }

            private string dvdxmlusername;
            public string DVDXMLUsername
            {
                get { return dvdxmlusername; }
                set { dvdxmlusername = value; }
            }

            private string dvdxmlpassword;
            public string DVDXMLPassword
            {
                get { return dvdxmlpassword; }
                set { dvdxmlpassword = value; }
            }

            private string registration;
            public string Registration
            {
                get { return registration; }
                set { registration = value; }
            }

            private string registereduser;
            public string RegisteredUser
            {
                get { return registereduser; }
                set { registereduser = value; }
            }

            private bool supresserrors;
            public bool SupressErrors
            {
                get { return supresserrors; }
                set { supresserrors = value; }
            }

            private bool openwithwindows;
            public bool OpenWithWindows
            {
                get { return openwithwindows; }
                set { openwithwindows = value; }
            }

            private bool asknotfound;
            public bool AskNotFound
            {
                get { return asknotfound; }
                set { asknotfound = value; }
            }

            private bool disableanydvd;
            public bool DisableAnyDVD
            {
                get { return disableanydvd; }
                set { disableanydvd = value; }
            }

            private bool protectncr;
            public bool ProtechNCR
            {
                get { return protectncr; }
                set { protectncr = value; }
            }

            private bool hideonstart;
            public bool HideOnStart
            {
                get { return hideonstart; }
                set { hideonstart = value; }
            }

            private bool emptyworking;
            public bool EmptyWorking
            {
                get { return emptyworking; }
                set { emptyworking = value; }
            }

            private bool ncrrunning;
            public bool NCRRunning
            {
                get { return ncrrunning; }
                set { ncrrunning = value; }
            }

            private bool ejectduplicates;
            public bool EjectDuplicates
            {
                get { return ejectduplicates; }
                set { ejectduplicates = value; }
            }

            private bool removedvdxmlextra;
            public bool RemoveDVDXMLExtra
            {
                get { return removedvdxmlextra; }
                set { removedvdxmlextra = value; }
            }

            private bool movetofinal;
            public bool MoveToFinal
            {
                get { return movetofinal; }
                set { movetofinal = value; }
            }

            private bool exportdvdxml;
            public bool ExportDVDXML
            {
                get { return exportdvdxml; }
                set { exportdvdxml = value; }
            }

            private bool exportcover;
            public bool ExportCover
            {
                get { return exportcover; }
                set { exportcover = value; }
            }

            private int concurrentrips;
            public int ConcurrentRips
            {
                get { return concurrentrips; }
                set { concurrentrips = value; }
            }

            private string covername;
            public string CoverName
            {
                get { return covername; }
                set { covername = value; }
            }

            private string workingdir;
            public string WorkingDir
            {
                get { return workingdir; }
                set { workingdir = value; }
            }
            private string handbrakedir;
            public string HandBrakeDir
            {
                get { return handbrakedir; }
                set { handbrakedir = value; }
            }
            private bool opencd;
            public bool OpenCD
            {
                get { return opencd; }
                set { opencd = value; }
            }
            private string finaldir;
            public string FinalDir
            {
                get { return finaldir; }
                set { finaldir = value; }
            }
            private string processpath;
            public string ProcessPath
            {
                get { return processpath; }
                set { processpath = value; }
            }

            private string container;
            public string Container
            {
                get { return container; }
                set { container = value; }
            }

            private string quality;
            public string Quality
            {
                get { return quality; }
                set { quality = value; }
            }

            private string arguments;
            public string Arguments
            {
                get { return arguments; }
                set { arguments = value; }
            }

        }

        public class DVDRip
        {
            private Process ripprocess;
            public Process RipProcess
            {
                get { return ripprocess; }
                set { ripprocess = value; }
            }

            private string ripdrive;
            public string RipDrive
            {
                get { return ripdrive; }
                set { ripdrive = value; }
            }

            private string volumename;
            public string VolumeName
            {
                get { return volumename; }
                set { volumename = value; }
            }

            private Types.Settings settings;
            public Types.Settings Settings
            {
                get { return settings; }
                set { settings = value; }
            }

            public DVDRip(string RipDrive, string VolumeName, Types.Settings Settings, Process RipProcess)
            {
                this.RipProcess = RipProcess;
                this.RipDrive = RipDrive;
                this.VolumeName = VolumeName;
                this.Settings = Settings;
            }
        }


        /// <summary>
        /// Deserializes an xml document back into an object
        /// </summary>
        /// <param name="xml">The xml data to deserialize</param>
        /// <param name="type">The type of the object being deserialized</param>
        /// <returns>A deserialized object</returns>
        public static object Deserialize(XmlDocument xml, Type type)
        {
            XmlSerializer s = new XmlSerializer(type);
            string xmlString = xml.OuterXml.ToString();
            byte[] buffer = ASCIIEncoding.UTF8.GetBytes(xmlString);
            MemoryStream ms = new MemoryStream(buffer);
            XmlReader reader = new XmlTextReader(ms);
            Exception caught = null;

            try
            {
                object o = s.Deserialize(reader);
                return o;
            }

            catch (Exception e)
            {
                caught = e;
            }
            finally
            {
                reader.Close();

                if (caught != null)
                    throw caught;
            }
            return null;
        }

        /// <summary>
        /// Serializes an object into an Xml Document
        /// </summary>
        /// <param name="o">The object to serialize</param>
        /// <returns>An Xml Document consisting of said object's data</returns>
        public static XmlDocument Serialize(object o)
        {
            XmlSerializer s = new XmlSerializer(o.GetType());

            MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, new UTF8Encoding());
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = ' ';
            writer.Indentation = 5;
            Exception caught = null;

            try
            {
                s.Serialize(writer, o);
                XmlDocument xml = new XmlDocument();
                string xmlString = ASCIIEncoding.UTF8.GetString(ms.ToArray());
                xml.LoadXml(xmlString);
                return xml;
            }
            catch (Exception e)
            {
                caught = e;
            }
            finally
            {
                writer.Close();
                ms.Close();

                if (caught != null)
                    throw caught;
            }
            return null;
        }
    }
}
