using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler
{
    class ConfigurationReader
    {
        private Dictionary<string, string> list = new Dictionary<string, string>();

        public ConfigurationReader()
        {
            string configFilename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Scheduler\\bin\\config.properties";
            loadFromFile(configFilename);
        }

        private void loadFromFile(string file)
        {
            if (System.IO.File.Exists(file))
            {
                foreach (string line in System.IO.File.ReadAllLines(file))
                {
                    if ((!String.IsNullOrEmpty(line)) &&
                        (!line.StartsWith(";")) &&
                        (!line.StartsWith("#")) &&
                        (!line.StartsWith("'")) &&
                        (line.Contains('=')))
                    {
                        int index = line.IndexOf('=');
                        string key = line.Substring(0, index).Trim();
                        string value = line.Substring(index + 1).Trim();

                        if ((value.StartsWith("\"") && value.EndsWith("\"")) ||
                            (value.StartsWith("'") && value.EndsWith("'")))
                        {
                            value = value.Substring(1, value.Length - 2);
                        }

                        try
                        {
                            //ignore dublicates
                            list.Add(key, value);
                        }
                        catch { }
                    }
                }

                // store values in Configuration utility class
                Configuration.ICSDIRECTORY = ValueFor("icsdirectory");
                Configuration.MSWORD = ValueFor("msword");
                Configuration.WEBBROWSER = ValueFor("webbrowser");
            }
        }

        private string ValueFor(string field)
        {
            return (list.ContainsKey(field)) ? (list[field]) : (null);
        }

    }
}
