using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centerport
{
   
    static class Program
    {
       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
     
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {

                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show(Properties.Settings.Default.SystemName+" already running!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
        }

        private static string appGuid = "c0se56b5a-12ab-45c5-b9d9-d693fau6e7b9";
    }
}
