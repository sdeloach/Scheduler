using System;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class Scheduler : Form, IGui
    {
        Semester localSemester;
        
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
        }

        public void printMessage(string s)
        {
            textBox1.AppendText(s + '\n');
        }

        // File Submenu

        private void OpenLocalFile(object sender, EventArgs e)
        {
            printMessage(Utility.test);
            localSemester = new Semester(this);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open local file";
            ofd.Filter = "CSV Files|*.csv";
            try
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    localSemester.localRead(ofd.FileName);
                    localSemester.filename = ofd.FileName;
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
            if (localSemester == null)
            {
                MessageBox.Show("No semester loaded.");
            }
            else
            {

                Semester KSISsemester = new Semester(this);
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Verify against KSIS file";
                ofd.Filter = "CSV Files|*.csv";

                try
                {
                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        KSISsemester.KSISread(ofd.FileName);
                        localSemester.verify(KSISsemester);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ConvertToKSISFile(object sender, EventArgs e)
        {
            Semester KSISsemester = new Semester(this);
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
            if (localSemester == null)
            {
                MessageBox.Show("No semester loaded.");
            }
            else
            {
                HTMLLineSchedulePrinter schedulePrinter = new HTMLLineSchedulePrinter(this);
                string outputFilename = localSemester.filename.Substring(0, localSemester.filename.Length - 4) + "_schedule.html";
                schedulePrinter.print(localSemester, outputFilename, false);
                ViewInWebbrowser(outputFilename);
            }
        }

        private void ProduceInstructorSchedule(object sender, EventArgs e)
        {
            if (localSemester == null)
            {
                MessageBox.Show("No semester loaded.");
            }
            else
            {
                HTMLInstructorSchedulePrinter schedulePrinter = new HTMLInstructorSchedulePrinter(this);
                string outputFilename = localSemester.filename.Substring(0, localSemester.filename.Length - 4) + "_instructor.html";
                schedulePrinter.print(localSemester, outputFilename, false);
                ViewInWebbrowser(outputFilename);
            }
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
                    Utility.RunProcess(Configuration.MSWORD, ofd.FileName);
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
        }
        // About Menu Item

        private void ShowAbout(object sender, EventArgs e)
        {
            printMessage("Scheduler version " + version + "  " + verdate);
        }

        // Helper methods

        public void ViewInWebbrowser(string document)
        {
            Utility.RunProcess(Configuration.WEBBROWSER, document);
        }

        private void calendarEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalendarPrinter calendarPrinter = new CalendarPrinter(this);
            calendarPrinter.print(localSemester);
        }
    }
}
