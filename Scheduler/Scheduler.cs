using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class Scheduler : Form
    {
        string localFilename;
        string KSISfilename;
        Semester localSemester;
        Semester KSISsemester;

        private Configuration config;

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

        private void openLocalToolStripMenuItem_Click(object sender, EventArgs e)
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
                MessageBox.Show(ex.Message);
            }
        }

        private void verifyLocalToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printMessage("Scheduler version " + version + "  " + verdate);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lineScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HTMLSchedulePrinter schedulePrinter = new HTMLSchedulePrinter(this, config);
            string outputFilename = localFilename.Substring(0, localFilename.Length - 4) + "_schedule.html";
            schedulePrinter.print(localSemester, outputFilename, false);
            try
            {
                schedulePrinter.View(outputFilename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void instructorScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HTMLInstructorSchedulePrinter schedulePrinter = new HTMLInstructorSchedulePrinter(this, config);
            string outputFilename = localFilename.Substring(0, localFilename.Length - 4) + "_instructor.html";
            schedulePrinter.print(localSemester, outputFilename, false);
            try
            {
                schedulePrinter.Open(outputFilename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void inBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open HTML file";
            ofd.Filter = "HTML Files|*.html";

            try
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filename = ofd.FileName;

                    // Prepare the process to run
                    ProcessStartInfo start = new ProcessStartInfo();
                    // Enter in the command line arguments, everything you would enter after the executable name itself
                    start.Arguments = filename;
                    // Enter the executable to run, including the complete path
                    start.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe ";
                    // Do you want to show a console window?
                    start.WindowStyle = ProcessWindowStyle.Hidden;
                    start.CreateNoWindow = true;
                    Process proc = Process.Start(start);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void convertKSISToLocalToolStripMenuItem_Click(object sender, EventArgs e)
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
                    if (sfd.FileName != "")  KSISsemester.save(sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
