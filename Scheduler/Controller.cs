using System;
using System.Windows.Forms;

namespace Scheduler
{
    class Controller
    {
        private Semester localSemester;

        public void OpenLocalFile(IGui gui)
        {
            localSemester = new Semester(gui);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open local file";
            ofd.Filter = "CSV Files|*.csv";
            try
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    localSemester.LocalRead(ofd.FileName);
                    localSemester.FileName = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void VerifyLocalFile(IGui gui)
        {
            if (localSemester == null)
            {
                MessageBox.Show("No semester loaded.");
            }
            else
            {

                Semester KSISsemester = new Semester(gui);
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Verify against KSIS file";
                ofd.Filter = "CSV Files|*.csv";

                try
                {
                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        KSISsemester.KSISread(ofd.FileName);
                        localSemester.VerifyAgainst(KSISsemester);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void ConvertToKSISFile(IGui gui)
        {
            Semester KSISsemester = new Semester(gui);
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
                    if (sfd.FileName != "") KSISsemester.Save(sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Exit()
        {
            Application.Exit();
        }

        // Produce submenu

        public void ProduceLineSchedule(IGui gui)
        {
            if (localSemester == null)
            {
                MessageBox.Show("No semester loaded.");
            }
            else
            {
                HTMLLineSchedulePrinter schedulePrinter = new HTMLLineSchedulePrinter(gui);
                string outputFilename = schedulePrinter.Print(localSemester);
                ViewInWebbrowser(outputFilename);
            }
        }

        public void ProduceInstructorSchedule(IGui gui)
        {
            if (localSemester == null)
            {
                MessageBox.Show("No semester loaded.");
            }
            else
            {
                HTMLInstructorSchedulePrinter schedulePrinter = new HTMLInstructorSchedulePrinter(gui);
                string outputFilename = schedulePrinter.Print(localSemester);
                ViewInWebbrowser(outputFilename);
            }
        }

        public void ProduceCalendarEvents(IGui gui)
        {
            CalendarPrinter calendarPrinter = new CalendarPrinter(gui);
            calendarPrinter.Print(localSemester);
        }

        // Open Submenu

        public void OpenInWord()
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

        public void OpenInWebbrowser()
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

        public void OpenDataFolder()
        {
            Utility.RunProcess("explorer.exe", "/ select," + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Scheduler");
        }

        // Helper methods

        public void ViewInWebbrowser(string document)
        {
            Utility.RunProcess(Configuration.WEBBROWSER, document);
        }
    }
}
