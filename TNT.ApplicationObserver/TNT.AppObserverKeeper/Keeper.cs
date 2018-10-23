using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TNT.AppObserver;

namespace TNT.AppObserverKeeper
{
    public class Keeper
    {
        internal static void Start()
        {
            Program.Logger.LogFolder = ConfigurationManager.AppSettings["LogFolder"];
            var sleepMin = int.Parse(ConfigurationManager.AppSettings["SleepMin"]);
            while (true)
            {
                Thread.Sleep(sleepMin * 60 * 1000);
                if (!ProcessManager.IsProcessRunning("AppObserver"))
                {
                    try
                    {
                        if (ProcessManager.StartProcess("AppObserver", "AppObserver.exe"))
                            Program.Logger.Log("Restart AppObserver.exe", true);
                    }
                    catch (Exception e)
                    {
                        Program.Logger.Log("Cannot restart AppObserver.exe: " + e.Message + " - " + e.InnerException, true);
                    }
                }
            }
        }
    }
}
