using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class Scheduler : Form, IGui
    {
        string localFilename;
        string KSISfilename;
        Semester localSemester;
        Semester KSISsemester;

        private readonly Configuration config;

        // 1.0 - initial version
        // 1.1 - added ics calendar output
        // 1.1.1 - bug fixes
        // 1.1.2 - added ability to configure where calendars are produced to and to open default data file folder
        // 1.1.3 - fixed bug that put deleted section randomly in the line schedule
        // 1.1.4 - added text decoration for "hidden" files so they show up in line schedule

        private const string version = "1.1.4";
        private const string verdate = "March 8, 2018";

        public Scheduler()
        {
            InitializeComponent();
            this.config = new Configuration();
        }

        public void printMessage(string s)
        {
            textBox1.AppendText(s + '\n');
        }

        // File Submenu

        private void OpenLocalFile(object sender, EventArgs e)
        {
            localSemester = new Semester(this);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open local file";
            ofd.Filter = "CSV Files|*.csv";
            try
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    localFilename = ofd.FileName;
                    localSemester.localRead(localFilename);
                }
            }
            catch (Exception ex)
            {
                printMessage(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }

        private void VerifyLocalFile(object sender, EventArgs e)
        {
            KSISsemester = new Semester(this);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Verify against KSIS file";
            ofd.Filter = "CSV Files|*.csv";

            try
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    KSISfilename = ofd.FileName;
                    KSISsemester.KSISread(KSISfilename);
                    localSemester.verify(KSISsemester);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConvertToKSISFile(object sender, EventArgs e)
        {
            KSISsemester = new Semester(this);
            var ofd = new OpenFileDialog();
            ofd.Title = "Open KSIS file";
            ofd.Filter = "CSV Files|*.csv";

            try
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {   // read KSIS file
                    KSISsemester.KSISread(ofd.FileName);

                    // save to local file
                    var sfd = new SaveFileDialog();
                    sfd.Title = "Save to new local file";
                    sfd.Filter = "CSV Files|*.csv";
                    sfd.ShowDialog();
                    if (sfd.FileName != "") KSISsemester.save(sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Produce submenu

        private void ProduceLineSchedule(object sender, EventArgs e)
        {
            if (localFilename == null)
            {
                MessageBox.Show("No semester loaded.");
                return;
            }

            HTMLLineSchedulePrinter schedulePrinter = new HTMLLineSchedulePrinter(this, config);
            string outputFilename = localFilename.Substring(0, localFilename.Length - 4) + "_schedule.html";
            schedulePrinter.print(localSemester, outputFilename, false);

            ViewInWebbrowser(outputFilename);
        }

        private void ProduceInstructorSchedule(object sender, EventArgs e)
        {
            if (localFilename == null)
            {
                MessageBox.Show("No semester loaded.");
                return;
            }

            HTMLInstructorSchedulePrinter schedulePrinter = new HTMLInstructorSchedulePrinter(this, config);
            string outputFilename = localFilename.Substring(0, localFilename.Length - 4) + "_instructor.html";
            schedulePrinter.print(localSemester, outputFilename, false);

            ViewInWebbrowser(outputFilename);
        }

        // Open Submenu

        private void OpenInWord(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open HTML file";
            ofd.Filter = "HTML Files|*.html";

            try
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Utility.RunProcess(config.getMSWORD(), ofd.FileName);
                    //string filename = ofd.FileName;
                    //// Prepare the process to run
                    //ProcessStartInfo start = new ProcessStartInfo();
                    //// Enter in the command line arguments, everything you would enter after the executable name itself
                    //start.Arguments = filename;
                    //// Enter the executable to run, including the complete path
                    //start.FileName = config.getMSWORD();
                    //// Do you want to show a console window?
                    //start.WindowStyle = ProcessWindowStyle.Normal;
                    //start.CreateNoWindow = true;
                    //Process proc = Process.Start(start);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenInWebbrowser(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open HTML file";
            ofd.Filter = "HTML Files|*.html";

            try
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    ViewInWebbrowser(ofd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenDataFolder(object sender, EventArgs e)
        {
            Utility.RunProcess("explorer.exe", "/ select," + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Scheduler");
            //// Prepare the process to run
            //ProcessStartInfo start = new ProcessStartInfo();
            //// Enter in the command line arguments, everything you would enter after the executable name itself
            //start.Arguments = "/ select," + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Scheduler";
            //// Enter the executable to run, including the complete path
            //start.FileName = "explorer.exe";
            //// Do you want to show a console window?
            //start.WindowStyle = ProcessWindowStyle.Normal;
            //start.CreateNoWindow = true;
            //Process proc = Process.Start(start);
        }
        // About Menu Item

        private void ShowAbout(object sender, EventArgs e)
        {
            printMessage("\nScheduler version " + version + "  " + verdate + "\n");
        }

        // Helper methods

        public void ViewInWebbrowser(string document)
        {
            Utility.RunProcess(config.getWEBBROWSER(), document);
            //// Prepare the process to run
            //ProcessStartInfo start = new ProcessStartInfo();
            //// Enter in the command line arguments, everything you would enter after the executable name itself
            //start.Arguments = document;
            //// Enter the executable to run, including the complete path
            //start.FileName = config.getWEBBROWSER();
            //// Do you want to show a console window?
            //start.WindowStyle = ProcessWindowStyle.Hidden;
            //start.CreateNoWindow = true;
            //Process proc = Process.Start(start);
        }

        private void calendarEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalendarPrinter calendarPrinter = new CalendarPrinter(this, config);
            calendarPrinter.print(localSemester);
        }
    }
}
