using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NCR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool freeToRun;
            string safeName = "Global\\StringUniquelyIdentifyingThisApplication";
            
            using (System.Threading.Mutex m = new System.Threading.Mutex(true, safeName, out freeToRun))
            {
                if (freeToRun)
                {
                    Application.Run(new frmMain());
                }
                else
                    MessageBox.Show("No Click Rip is already running!.", "Application Open");
            }
        }
    }
}
