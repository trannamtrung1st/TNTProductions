using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace WindowHelper.Search
{
    public class SearchManager
    {
        private static int found = 0;
        private static void Search(DirectoryInfo directory, string keyword)
        {
            try
            {
                var subFiles = directory.GetFiles();
                //var subFilesFound = subFiles
                //    .Where(f => f.Name.Contains(keyword) || f.Extension.Contains(keyword)).ToArray();
                //foreach (var f in subFilesFound)
                //{
                //    Console.WriteLine(f.FullName);
                //    found++;
                //}
                foreach (var f in subFiles)
                {
                    if (f.Name.Contains(keyword) || f.Extension.Contains(keyword))
                    {
                        Console.WriteLine(f.FullName);
                        found++;
                    }
                }
                var subDirs = directory.GetDirectories();
                //var subDirsFound = subDirs
                //    .Where(d => d.Name.Contains(keyword)).ToArray();
                //foreach (var d in subDirsFound)
                //{
                //    Console.WriteLine(d.FullName);
                //    found++;
                //}
                foreach (var d in subDirs)
                {
                    if (d.Name.Contains(keyword))
                    {
                        Console.WriteLine(d.FullName);
                        found++;
                    }
                    Search(d, keyword);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static int Search(string standFrom, string keyword)
        {
            found = 0;
            var directory = new DirectoryInfo(standFrom);
            Search(directory, keyword);
            return found;
        }

    }
}
