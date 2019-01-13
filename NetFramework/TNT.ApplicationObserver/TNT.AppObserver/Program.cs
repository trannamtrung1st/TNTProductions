using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Helpers.Logging;

namespace TNT.AppObserver
{
    class Program
    {
        public static ILoggerAdapter Logger { get; set; }
        static void Main(string[] args)
        {
            Logger = new LoggerBuilder(LogMode.ByDate)
                .LogFolder(ConfigurationManager.AppSettings["LogFolder"])
                .LogName("Log")
                .ErrorHandler((l, e) =>
                {
                    l.ClearBuffer();
                }).Build();
            Observer.Start();
        }

    }
}
