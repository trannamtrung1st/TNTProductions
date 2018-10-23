using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.AppObserver
{
    public class ProcessManager
    {

        public static bool StartProcess(string pName, string pPath)
        {
            try
            {
                Process p = Process.Start(pPath);
                if (p != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Program.Logger.Log(pName + " exception: " + e.Message + " - " + e.InnerException);
                return false;
            }
        }

        public static bool IsProcessRunning(string pName)
        {
            Process[] processes = Process.GetProcessesByName(pName);
            if (processes.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
