using System;
using System.Windows.Forms;

namespace Scheduler
{
    static class Program
    {
        /// The main entry point for Scheduler.

        [STAThread]
        static void Main()
        {
            // reads configuration and loads into Configuration class
            
            string configFilename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Scheduler\\bin\\config.properties";
            var c = new ConfigurationReader();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Viewer());
        }
    }
}
