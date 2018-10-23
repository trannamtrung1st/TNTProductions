using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Helpers.Logging;

namespace TNT.Helpers
{
    public class Program
    {
        static void Main(string[] args)
        {
            ILoggerAdapter logger = new LoggerBuilder(LogMode.ByDate)
                .LogFolder("./").LogName("test").FileExtension("txt").Build();
            logger.Log("asd", true);
        }
    }
}
