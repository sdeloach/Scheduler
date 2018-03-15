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

        private const string version = "1.2";
        private const string verdate = "March 15, 2018";

        // The viewer only calls controller methods directly
        Controller controller = new Controller();

        public Viewer()
        {
            InitializeComponent();
            printMessage("Scheduler version " + version + "  " + verdate);
        }

        public void printMessage(string s)
        {
            textBox1.AppendText(s + '\n');
        }

        // File Submenu

        private void OpenLocalFile(object sender, EventArgs e)
        {
            controller.OpenLocalFile(this);
        }

        private void VerifyLocalFile(object sender, EventArgs e)
        {
            controller.VerifyLocalFile(this);
        }

        private void ConvertToKSISFile(object sender, EventArgs e)
        {
            controller.ConvertToKSISFile(this);
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
            printMessage("Scheduler version " + version + "  " + verdate);
        }
    }
}
