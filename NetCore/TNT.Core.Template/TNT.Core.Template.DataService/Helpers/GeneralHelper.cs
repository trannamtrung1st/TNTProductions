using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TNT.Core.Template.DataService.Helpers
{
    public static class GeneralHelper
    {
        public static Process ExecuteScaffoldFromCmd(string projectPath,
            string server, string database, string user, string password, string output, string context, bool trustedConnection = false)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("cd " + projectPath);
            cmd.StandardInput.WriteLine(String.Format(
                "dotnet ef dbcontext scaffold \"Server={0}; Database={1}; Trusted_Connection = {6};User Id={2};Password={3};\" " +
                "Microsoft.EntityFrameworkCore.SqlServer -o {4} -c {5} -f",
                server, database, user, password, output, context, trustedConnection ? "True" : "False"));
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            return cmd;
        }

        public static Process ExecuteBuildProjectCmd(string solutionPath, string projectName)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("cd " + solutionPath);
            cmd.StandardInput.WriteLine(String.Format("dotnet build {0}", projectName));
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            return cmd;
        }

        public static Process ExecuteRunDllCmd(string parent, string dllFile)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("cd " + parent);
            cmd.StandardInput.WriteLine(String.Format("dotnet {0}", dllFile));
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            return cmd;
        }

        public enum JsonPropertyFormatEnum
        {
            CamelCase,
            JsonStyle
        }

        public static string ToJsonPropertyFormat(string noun, JsonPropertyFormatEnum style)
        {
            if (style == JsonPropertyFormatEnum.CamelCase)
                return char.ToLower(noun[0]) + noun.Substring(1);
            else if (style == JsonPropertyFormatEnum.JsonStyle)
            {
                noun = noun[0].ToString().ToLower() + noun.Substring(1);
                var i = 1;
                var isLastUpper = true;
                while (i < noun.Length)
                {
                    while (i < noun.Length && (char.IsLower(noun[i]) || char.IsDigit(noun[i])))
                    {
                        isLastUpper = false;
                        i++;
                    }
                    if (i < noun.Length)
                    {
                        if (!isLastUpper)
                        {
                            noun = noun.Substring(0, i) + "_" + char.ToLower(noun[i]) + noun.Substring(i + 1);
                            i++;
                            isLastUpper = true;
                        }
                        else noun = noun.Substring(0, i) + noun[i].ToString().ToLower() + noun.Substring(i + 1);
                    }
                    i++;
                }
                return noun;
            }
            return null;
        }
    }
}
