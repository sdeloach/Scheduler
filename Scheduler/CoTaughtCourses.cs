using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler
{
    class CoTaughtCourses
    {

        private string filename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Scheduler\\bin\\cotaughtCourses.csv";
        private IGui gui;

        public CoTaughtCourses(IGui gui)
        {
            this.gui = gui;
        }

        public string CoTaughtCourseOf(string course)
        {
            StreamReader readFile;
            try
            {
                readFile = new StreamReader(filename);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "";
            }

            List<string> data;
            string line;
            while ((line = readFile.ReadLine()) != null)
            {
                data = Utility.ParseLine(line);
                
                if (course.Equals(data.ElementAt(0)))
                {
                    readFile.Close();
                    return data.ElementAt(1);
                }
                else if (course.Equals(data.ElementAt(1)))
                {
                    readFile.Close();
                    return data.ElementAt(0);
                }
            }

            readFile.Close();
            return "";
        }

        public bool IsCotaught(string course1, string course2)
        {
            return CoTaughtCourseOf(course1.Trim()).Equals(course2.Trim());
        }
    }
}
