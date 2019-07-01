using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using TNT.Core.Template.DataService.MongoDB.Data;
using TNT.Core.Template.DataService.MongoDB.Helpers;

namespace TNT.Core.Template.DataService.MongoDB.Models
{
    public static class EntitiesGen
    {

        public static void CopyEntities(string fromFolder, string toFolder, Info info)
        {
            var files = FileHelper.ListFiles(fromFolder);
            foreach (var f in files)
            {
                var fileInfo = new FileInfo(f);
                var content = FileHelper.Read(f);
                content = Regex.Replace(content, "namespace .+", $"namespace {info.ProjectName}.Models", RegexOptions.Multiline);
                content = content.Replace("\r\n", "\n");
                FileHelper.Write(toFolder, fileInfo.Name, content);
            }

        }

    }
}
