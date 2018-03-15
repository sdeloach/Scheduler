using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler
{
    public class LocalCSVReader
    {
        private IGui gui;

        public LocalCSVReader(IGui gui)
        {
            this.gui = gui;
        }

        public Semester Read(string filename)
        {
            Semester semester = new Semester(gui);
            Section section;

            if (!filename.ToLower().EndsWith(".csv"))
            {
                MessageBox.Show("Filename " + filename + " is not a valid .csv file.");
                return semester;
            }

            StreamReader readFile;
            try
            {
                readFile = new StreamReader(filename);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return semester;
            }

            List<string> data = Utility.ParseLine(readFile.ReadLine()); //get first line with semester name
            semester.Name = data.ElementAt(0); // save name of semester

            readFile.ReadLine(); // skip the next line - data headers

            string line;
            while ((line = readFile.ReadLine()) != null)
            {
                data = Utility.ParseLine(line);

                // create a new section with current line
                section = new Section(data.ElementAt(00), data.ElementAt(01), data.ElementAt(02), data.ElementAt(03), data.ElementAt(04),
                        data.ElementAt(05), data.ElementAt(06), data.ElementAt(07), data.ElementAt(8), data.ElementAt(9), data.ElementAt(10),
                        data.ElementAt(11), data.ElementAt(12), data.ElementAt(13), data.ElementAt(14), data.ElementAt(15), data.ElementAt(16),
                        data.ElementAt(17), data.ElementAt(18), data.ElementAt(19), data.ElementAt(20), data.ElementAt(21), data.ElementAt(22),
                        data.ElementAt(23), data.ElementAt(24));

                // add section to semester
                semester.Add(section);
            }
            readFile.Close();

            // return the semester sorted by catalog number

            semester.sortByCatalogNbr();
            return semester;
        }
    }
}