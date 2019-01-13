using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Template.DataService.Helpers
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

        //public static void ChangeTextToCsFile(string fromFolder, string toFolder)
        //{
        //    var from = new DirectoryInfo(fromFolder);
        //    var files = from.GetFiles("*.txt");
        //    var lastChar = toFolder[toFolder.Length - 1];
        //    if (lastChar != '/' && lastChar != '\\')
        //        toFolder += '/';
        //    foreach (var f in files)
        //    {
        //        var str = File.ReadAllText(f.FullName);
        //        File.WriteAllText(toFolder + f.Name.Replace(".txt", "") + ".cs", str);
        //    }
        //}

    }
}
