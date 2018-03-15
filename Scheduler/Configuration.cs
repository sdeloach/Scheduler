namespace Scheduler
{
    static class Configuration
    {
        static public string ICSDIRECTORY { get; set; }
        static public string MSWORD { get; set; }
        static public string WEBBROWSER { get; set; }

        internal static IConfiguration IConfiguration
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}