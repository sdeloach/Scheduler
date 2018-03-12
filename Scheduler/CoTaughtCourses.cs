using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class CoTaughtCourses
    {


        private String filename = "cotaughtCourses.csv";
        private Scheduler gui;
        private char DEFAULT_SEPARATOR = ',';
        private char DEFAULT_QUOTE = '"';

        public CoTaughtCourses(Scheduler gui)
        {
            this.gui = gui;
        }

        public String coTaughtCourse(String c1)
        {

            Scanner scanner;
            try
            {
                scanner = new Scanner(new File(filename));
            }
            catch (Exception e)
            {
                gui.printMessage(" File " + filename + " not found.");
                return "";
            }

            while (scanner.hasNext())
            {
                List<String> data = parseLine(scanner.nextLine());
                if (c1.contentEquals(data.get(0)))
                {
                    scanner.close();
                    return data.get(1);
                }
                else if (c1.contentEquals(data.get(1)))
                {
                    scanner.close();
                    return data.get(0);
                }
            }

            scanner.close();
            return "";
        }

        public bool isCotaught(String c1, String c2)
        {
            Scanner scanner;
            try
            {
                scanner = new Scanner(new File(filename));
            }
            catch (Exception e)
            {
                gui.printMessage(" File " + filename + " not found.");
                return false;
            }

            while (scanner.hasNext())
            {
                List<String> data = parseLine(scanner.nextLine());
                if ((c1.contentEquals(data.get(0)) && c2.contentEquals(data.get(1)))
                        || (c1.contentEquals(data.get(1)) && c2.contentEquals(data.get(0))))
                {
                    scanner.close();
                    return true;
                }

            }
            scanner.close();
            return false;
        }

        private List<String> parseLine(String cvsLine)
        {
            return parseLine(cvsLine, DEFAULT_SEPARATOR, DEFAULT_QUOTE);
        }

    private List<String> parseLine(String cvsLine, char separators, char customQuote)
        {

            List<String> result = new ArrayList<>();

            //if empty, return!
            if (cvsLine == null && cvsLine.isEmpty())
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

            StringBuffer curVal = new StringBuffer();
            boolean inQuotes = false;
            boolean startCollectChar = false;
            boolean doubleQuotesInColumn = false;

            char[] chars = cvsLine.toCharArray();

            for (char ch : chars)
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

                        //Fixed : allow "" in custom quote enclosed
                        if (ch == '\"')
                        {
                            if (!doubleQuotesInColumn)
                            {
                                curVal.append(ch);
                                doubleQuotesInColumn = true;
                            }
                        }
                        else
                        {
                            curVal.append(ch);
                        }

                    }
                }
                else
                {
                    if (ch == customQuote)
                    {

                        inQuotes = true;

                        //Fixed : allow "" in empty quote enclosed
                        if (chars[0] != '"' && customQuote == '\"')
                        {
                            curVal.append('"');
                        }

                        //double quotes in column will hit this!
                        if (startCollectChar)
                        {
                            curVal.append('"');
                        }

                    }
                    else if (ch == separators)
                    {

                        result.add(curVal.toString());

                        curVal = new StringBuffer();
                        startCollectChar = false;

                    }
                    else if (ch == '\r')
                    {
                        //ignore LF characters
                        continue;
                    }
                    else if (ch == '\n')
                    {
                        //the end, break!
                        break;
                    }
                    else
                    {
                        curVal.append(ch);
                    }
                }

            }

            result.Add(curVal.toString());

            return result;
        }

    }
}
