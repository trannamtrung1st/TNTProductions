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

        public static void DeleteDataServiceStructure(string projectPath)
        {
            if (!projectPath.EndsWith("\\") && !projectPath.EndsWith("/"))
                projectPath = projectPath + '/';
            string gFile = projectPath + "Global/GlobalTemplate.tt";
            string hFile = projectPath + "Helpers/HelpersTemplate.tt";
            string dFile = projectPath + "Models/Domains/BaseDomainGen.cs";
            string eFile = projectPath + "Models/Extensions/ExtensionTemplate.tt";
            string rFile = projectPath + "Models/Repositories/RepositoryTemplate.tt";
            string uowFile = projectPath + "Models/UnitOfWorkGen.cs";
            string tFile = projectPath + "Templates/TTManager.ttinclude";
            string vmFile = projectPath + "ViewModels/ViewModelTemplate.tt";

            var list = new List<string>() { gFile, hFile, dFile, eFile, rFile, uowFile, tFile, vmFile };
            foreach (var f in list)
            {
                if (File.Exists(f))
                    File.Delete(f);
            }

        }

        public static void ChangeTextToCsFile(string fromFolder, string toFolder, string removeStr)
        {
            var from = new DirectoryInfo(fromFolder);
            var files = from.GetFiles("*.txt");
            var lastChar = toFolder[toFolder.Length - 1];
            if (lastChar != '/' && lastChar != '\\')
                toFolder += '/';
            foreach (var f in files)
            {
                var str = File.ReadAllText(f.FullName);
                File.WriteAllText(toFolder + f.Name.Replace(".txt", "").Replace(removeStr, "") + ".cs", str);
            }
        }

    }
}
