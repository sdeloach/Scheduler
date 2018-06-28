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
        // 1.3   - added filename text boxes to GUI
        // 1.3.1 - added ability to store and save previous file names
        // 1.4   - added professional and preprofessional calendar outputs
        // 1.4.1 - fixed overlap detection to be more robust
        // 1.4.2 - fixed highlighting on schedule and instructor printers
        // 1.4.3 - fixed criteria for skipping sections from KSIS file (checking instructor vs. monday);
        //         fixed bug for ending IsHidden highlighting in HTMLInstructorPrinter
        //1.5    - added Reload button

        private const string version = "1.5";
        private const string verdate = "June 28, 2018";

        // The viewer only calls controller methods directly
        private Controller controller;

        public Viewer()
        {
            InitializeComponent();
            controller = new Controller(this);
        }

        public void WriteLine(string s)
        {
            OutputTextViewer.AppendText(s + '\n');
        }
        public void SetLocalFile(string s)
        {
            textBox1.AppendText(s);
        }

        public void ClearLocalFile()
        {
            textBox1.Clear();
        }
        public void SetKSISFile(string s)
        {
            textBox2.AppendText(s);
        }

        public void ClearKSISFile()
        {
            textBox2.Clear();
        }

        public void ClearTextBox()
        {
            textBox2.Clear();
        }

        // File Submenu

        private void OpenLocalFile(object sender, EventArgs e)
        {
            controller.OpenLocalFile();
        }

        private void VerifyLocalFile(object sender, EventArgs e)
        {
            controller.VerifyLocalFile();
        }

        private void ConvertToKSISFile(object sender, EventArgs e)
        {
            controller.ConvertKSISFileToLocal();
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Produce submenu

        private void ProduceLineSchedule(object sender, EventArgs e)
        {
            controller.ProduceLineSchedule();
        }

        private void ProduceInstructorSchedule(object sender, EventArgs e)
        {
            controller.ProduceInstructorSchedule();
        }

        private void ProduceCalendarEvents(object sender, EventArgs e)
        {
            controller.ProduceCalendarEvents();
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

        private void Clear(object sender, EventArgs e)
        {
            controller.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.Reload();
        }
    }
}
