using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TNT.AppObserver
{
    public class Observer
    {
        private static IDictionary<string, string> ProcessPathMapping { get; set; }

        static Observer()
        {
            LoadSettings();
        }

        //Settings
        private static void LoadSettings()
        {
            Program.Logger.LogFolder = ConfigurationManager.AppSettings["LogFolder"];
            ProcessPathMapping = new Dictionary<string, string>();
            var processes = ConfigurationManager.AppSettings.AllKeys;
            if (processes != null)
            {
                foreach (var p in processes)
                {
                    if (p.EndsWith(".exe"))
                        ProcessPathMapping.Add(p.Replace(".exe", ""), ConfigurationManager.AppSettings[p]);
                }
            }
        }

        private static void Check()
        {
            int started = 0;
            int unstarted = 0;
            foreach (var kvp in ProcessPathMapping)
            {
                if (!ProcessManager.IsProcessRunning(kvp.Key))
                {
                    if (ProcessManager.StartProcess(kvp.Key, kvp.Value))
                        started++;
                    else unstarted++;
                }
            }
            if (started != 0 || unstarted != 0)
                Program.Logger.Log("Started: " + started + " | Unstarted: " + unstarted, true);
        }

        internal static void Start()
        {
            var sleepMin = int.Parse(ConfigurationManager.AppSettings["SleepMin"]);
            while (true)
            {
                if (!ProcessManager.IsProcessRunning("AppObserverKeeper"))
                    ProcessManager.StartProcess("AppObserverKeeper", "AppObserverKeeper.exe");
                Check();
                Thread.Sleep(sleepMin * 60 * 1000);
            }
        }

    }
}
