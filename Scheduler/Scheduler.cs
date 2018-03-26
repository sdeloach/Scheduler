using System;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class Viewer : Form, IGui
    {
        
        // 1.0 - initial version
        // 1.1 - added ics calendar output
        // 1.1.1 - bug fixes
        // 1.1.2 - added ability to configure where calendars are produced to and to open default data file folder
        // 1.1.3 - fixed bug that put deleted section randomly in the line schedule
        // 1.1.4 - added text decoration for "hidden" files so they show up in line schedule
        // 1.2   - converted to C#
        // 1.2.1 - bug fixes
        // 1.2.2 - bug fixes
        // 1.2.3 - fix sort of sections to sort 1) by catalog number and then 2) by section name

        private const string version = "1.2.3";
        private const string verdate = "March 26, 2018";

        // The viewer only calls controller methods directly
        private Controller controller = new Controller();

        public Viewer()
        {
            InitializeComponent();
            WriteLine("Scheduler version " + version + "  " + verdate);
        }

        public void WriteLine(string s)
        {
            OutputTextViewer.AppendText(s + '\n');
        }
        public void SetLocalFile(string s)
        {
            textBox1.AppendText(s);
        }
        public void SetKSISFile(string s)
        {
            textBox2.AppendText(s);
        }

        // File Submenu

        private void OpenLocalFile(object sender, EventArgs e)
        {
            controller.OpenLocalFile(this);
            SetLocalFile(controller.GetLocalFilename());
        }

        private void VerifyLocalFile(object sender, EventArgs e)
        {
            controller.VerifyLocalFile(this);
            SetKSISFile(controller.GetKSISFilename());
        }

        private void ConvertToKSISFile(object sender, EventArgs e)
        {
            controller.ConvertKSISFileToLocal(this);
            SetLocalFile(controller.GetLocalFilename());
            SetKSISFile(controller.GetKSISFilename());
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Produce submenu

        private void ProduceLineSchedule(object sender, EventArgs e)
        {
            controller.ProduceLineSchedule(this);
        }

        private void ProduceInstructorSchedule(object sender, EventArgs e)
        {
            controller.ProduceInstructorSchedule(this);
        }

        private void ProduceCalendarEvents(object sender, EventArgs e)
        {
            controller.ProduceCalendarEvents(this);
        }

        // Open Submenu

        private void OpenInWord(object sender, EventArgs e)
        {
            controller.OpenInWord();
        }

        private void OpenInWebbrowser(object sender, EventArgs e)
        {
            controller.OpenInWebbrowser();
        }

        private void OpenDataFolder(object sender, EventArgs e)
        {
            controller.OpenDataFolder();
        }

        // About Menu Item

        private void ShowAbout(object sender, EventArgs e)
        {
            WriteLine("Scheduler version " + version + "  " + verdate);
        }
    }
}
