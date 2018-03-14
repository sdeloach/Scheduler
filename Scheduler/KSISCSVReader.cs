using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler
{
    public class KSISCSVReader
    {
        IGui gui;

        public KSISCSVReader(IGui gui)
        {
            this.gui = gui;
        }

        public Semester read(string filename)
        {
            Semester semester = new Semester(gui);
            Section section;

            if (!filename.ToLower().EndsWith(".csv"))
            {
                gui.printMessage("Filename " + filename + " is not a valid .csv file.");
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

            string line = readFile.ReadLine(); // skip first line
            while ((line = readFile.ReadLine()) != null)
            {
                List<string> data = Utility.ParseLine(line);

                // skip lines without instructors
                if (data.ElementAt(51).Equals(" ") || !data.ElementAt(51).Any())
                {
                    continue;
                }
                
                // Create a new section with current line
                section = new Section(data.ElementAt(00), data.ElementAt(01), data.ElementAt(02), data.ElementAt(03), data.ElementAt(04), data.ElementAt(05), data.ElementAt(06), data.ElementAt(07), data.ElementAt(8), data.ElementAt(9), data.ElementAt(10), data.ElementAt(11), data.ElementAt(12), data.ElementAt(13), data.ElementAt(14), data.ElementAt(15), data.ElementAt(16), data.ElementAt(17), data.ElementAt(18), data.ElementAt(19), data.ElementAt(20), data.ElementAt(21), data.ElementAt(22), data.ElementAt(23), data.ElementAt(24), data.ElementAt(25), data.ElementAt(26), data.ElementAt(27), data.ElementAt(28), data.ElementAt(29), data.ElementAt(30), data.ElementAt(31), data.ElementAt(32), data.ElementAt(33), data.ElementAt(34), data.ElementAt(35), data.ElementAt(36), data.ElementAt(37), data.ElementAt(38), data.ElementAt(39), data.ElementAt(40), data.ElementAt(41), data.ElementAt(42), data.ElementAt(43), data.ElementAt(44), data.ElementAt(45), data.ElementAt(46), data.ElementAt(47), data.ElementAt(48), data.ElementAt(49), data.ElementAt(50), data.ElementAt(51), data.ElementAt(52), data.ElementAt(53), data.ElementAt(54), data.ElementAt(55), data.ElementAt(56), data.ElementAt(57), data.ElementAt(58), data.ElementAt(59), data.ElementAt(60), data.ElementAt(61), data.ElementAt(62), data.ElementAt(63), data.ElementAt(64), data.ElementAt(65), data.ElementAt(66), data.ElementAt(67), data.ElementAt(68), data.ElementAt(69), data.ElementAt(70), data.ElementAt(71), data.ElementAt(72), data.ElementAt(73), data.ElementAt(74), data.ElementAt(75), data.ElementAt(76), data.ElementAt(77), data.ElementAt(78), data.ElementAt(79), data.ElementAt(80), data.ElementAt(81), data.ElementAt(82), data.ElementAt(83), data.ElementAt(84), data.ElementAt(85), data.ElementAt(86), data.ElementAt(87), data.ElementAt(88), data.ElementAt(89), data.ElementAt(90), data.ElementAt(91));

                // add section to semester
                semester.Add(section);
            }
            readFile.Close();

            // return semester sorted by CatalogNbr
            return semester.sortByCatalogNbr();
        }
    }
}