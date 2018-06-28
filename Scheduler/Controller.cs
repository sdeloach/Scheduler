using System;
using System.IO;
using System.Windows.Forms;

namespace Scheduler
{
    class Controller
    {
        private Semester localSemester;
        private string localFileName = "";
        private string KSISFileName = "";
        private const string configFileName = "datafiles.config";
        private IGui gui;

        public Controller(IGui gui)
        {
            this.gui = gui;
            ReadFileNames();
            gui.SetLocalFile(localFileName);
            gui.SetKSISFile(KSISFileName);
            WriteFileNames();
        }

        private void ReadFileNames()
        {
            StreamReader readFile = null;
            try
            {
                // open configuration file
                readFile = new StreamReader(configFileName);

                // the first line is the local file name
                localFileName = readFile.ReadLine();
                // read in the semeseter from the file name
                if (!localFileName.Equals(""))
                {
                    localSemester = new Semester(gui);
                    localSemester.LocalRead(localFileName);
                    localSemester.FileName = localFileName;
                    gui.SetLocalFile(localFileName);
                }

                // the second line is the KSIS file name
                KSISFileName = readFile.ReadLine();
                if (!KSISFileName.Equals(""))
                {
                    Semester KSISsemester = new Semester(gui);
                    KSISsemester.KSISread(KSISFileName);
                    localSemester.VerifyAgainst(KSISsemester);
                    gui.SetKSISFile(KSISFileName);
                }

                // save filenames to file
                readFile.Close();
                WriteFileNames();
            }
            catch (Exception e)
            {
                localFileName = "";
                KSISFileName = "";
            }
        }
        private void WriteFileNames()
        {
            StreamWriter file = null;
            try
            {
                file = new StreamWriter(configFileName);
                file.WriteLine(localFileName);
                file.WriteLine(KSISFileName);
                file.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void OpenLocalFile()
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
                    gui.SetLocalFile(ofd.FileName);
                    localFileName = ofd.FileName;
                    KSISFileName = "";
                    gui.ClearKSISFile();
                    WriteFileNames();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void VerifyLocalFile()
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
                        gui.SetKSISFile(ofd.FileName);
                        KSISFileName = ofd.FileName;
                        WriteFileNames();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        internal void Clear()
        {
            localSemester = null;
            localFileName = "";
            KSISFileName = "";
            gui.ClearLocalFile();
            gui.ClearKSISFile();
            gui.ClearTextBox();
            WriteFileNames();
        }
        
        public void Reload()
        {
            if (!localFileName.Equals(""))
            {
                localSemester.LocalRead(localFileName);
                localSemester.FileName = localFileName;
                if (!KSISFileName.Equals(""))
                {
                    Semester KSISsemester = new Semester(gui);
                    KSISsemester.KSISread(KSISFileName);
                    localSemester.VerifyAgainst(KSISsemester);
                }
            }
        }

        public void ConvertKSISFileToLocal()
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
                    gui.SetKSISFile(ofd.FileName);
                    KSISFileName = ofd.FileName;
                    WriteFileNames();

                    // save to local file
                    var sfd = new SaveFileDialog();
                    sfd.Title = "Save to new local file";
                    sfd.Filter = "CSV Files|*.csv";
                    sfd.ShowDialog();
                    if (sfd.FileName != "")
                    {
                        gui.SetLocalFile(sfd.FileName);
                        localFileName = sfd.FileName;
                        WriteFileNames();
                        KSISsemester.Save(sfd.FileName);
                    }
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

        public void ProduceLineSchedule()
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

        public void ProduceInstructorSchedule()
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

        public void ProduceCalendarEvents()
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
