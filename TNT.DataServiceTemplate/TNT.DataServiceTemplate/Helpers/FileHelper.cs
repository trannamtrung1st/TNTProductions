using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.DataServiceTemplate.Helpers
{
    public class FileHelper
    {
        public static void Write(string parent, string fileName, string text)
        {
            Create(parent);
            if (parent[parent.Length - 1] != '/' && parent[parent.Length - 1] != '\\')
                parent += "/";
            File.WriteAllText(parent + fileName, text);
        }

        private static void Create(string path)
        {
            Directory.CreateDirectory(path);
        }

    }
}
