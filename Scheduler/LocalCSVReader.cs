using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scheduler
{
    public class LocalCSVReader
    {
        private Scheduler gui;
        private const char DEFAULT_SEPARATOR = ',';
        private const char DEFAULT_QUOTE = '"';

        public LocalCSVReader(Scheduler gui)
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
                //gui.printMessage(e.Message);
                MessageBox.Show(e.Message);
                return semester;
            }

            List<string> data = ParseLine(readFile.ReadLine()); //get first line with semester name
            semester.SetName(data.ElementAt(0)); // save name of semester
             
            readFile.ReadLine(); // skip the next line - data headers

            string line;
            while ((line = readFile.ReadLine()) != null)
            {
                data = ParseLine(line);

                // instructor fields has a quote (") at beginning that must be stripped out
                if (data.ElementAt(4).Any()) data.Insert(4, data.ElementAt(4).Substring(1));

                // create a new section object with current line
                section = new Section(data.ElementAt(00), data.ElementAt(01), data.ElementAt(02), data.ElementAt(03), //data.ElementAt(04),
                        data.ElementAt(05), data.ElementAt(06), data.ElementAt(07), data.ElementAt(8), data.ElementAt(9), data.ElementAt(10), data.ElementAt(11),
                        data.ElementAt(12), data.ElementAt(13), data.ElementAt(14), data.ElementAt(15), data.ElementAt(16), data.ElementAt(17),
                        data.ElementAt(18), data.ElementAt(19), data.ElementAt(20), data.ElementAt(21), data.ElementAt(22), data.ElementAt(23), data.ElementAt(24), data.ElementAt(25));

                // add section to the list of sections
                int size = semester.Size();
                if (size == 0)
                    semester.Add(section);
                else
                {
                    for (int x = 0; x <= size; x++)
                    {
                        if (x == size)
                        {
                            semester.Add(section);
                            break;
                        }

                        if (int.Parse(section.GetCatalogNbr()) < int.Parse(semester.ElementAt(x).GetCatalogNbr()))
                        {
                            semester.Insert(x, section);
                            break;
                        }
                    }
                }
            }
            readFile.Close();
            return semester;
        }

        private List<string> ParseLine(string cvsLine)
        {
            return ParseLine(cvsLine, DEFAULT_SEPARATOR, DEFAULT_QUOTE);
        }

        private List<string> ParseLine(string cvsLine, char separators)
        {
            return ParseLine(cvsLine, separators, DEFAULT_QUOTE);
        }


        private List<string> ParseLine(string cvsLine, char separators, char customQuote)
        {

            List<string> result = new List<string>();

            // if empty, return!
            if (cvsLine == null && !cvsLine.Any())
            {
                return result;
            }

            if (customQuote == ' ')
            {
                customQuote = DEFAULT_QUOTE;
            }

            if (separators == ' ')
            {
                separators = DEFAULT_SEPARATOR;
            }

            StringBuilder curVal = new StringBuilder();
            bool inQuotes = false;
            bool startCollectChar = false;
            bool doubleQuotesInColumn = false;

            char[] chars = cvsLine.ToCharArray();

            foreach (char ch in chars)
            {

                if (inQuotes)
                {
                    startCollectChar = true;
                    if (ch == customQuote)
                    {
                        inQuotes = false;
                        doubleQuotesInColumn = false;
                    }
                    else
                    {
                        if (ch == '\"')
                        {
                            if (!doubleQuotesInColumn)
                            {
                                curVal.Append(ch);
                                doubleQuotesInColumn = true;
                            }
                        }
                        else
                        {
                            curVal.Append(ch);
                        }

                    }
                }
                else
                {
                    if (ch == customQuote)
                    {

                        inQuotes = true;

                        // Fixed : allow "" in empty quote enclosed
                        if (chars[0] != '"' && customQuote == '\"')
                        {
                            curVal.Append('"');
                        }

                        // double quotes in column will hit this!
                        if (startCollectChar)
                        {
                            curVal.Append('"');
                        }

                    }
                    else if (ch == separators)
                    {

                        result.Add(curVal.ToString());

                        curVal = new StringBuilder();
                        startCollectChar = false;

                    }
                    else if (ch == '\r')
                    {
                        // ignore LF characters
                        continue;
                    }
                    else if (ch == '\n')
                    {
                        // the end, break!
                        break;
                    }
                    else
                    {
                        curVal.Append(ch);
                    }
                }

            }

            result.Add(curVal.ToString());

            return result;
        }
    }

}