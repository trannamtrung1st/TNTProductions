using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TNT.Core.Template.DataService.Data;
using TNT.Core.Template.DataService.Helpers;
using static TNT.Core.Template.DataService.Helpers.GeneralHelper;

namespace TNT.Core.Template.DataService
{
    public class SimpleGenerator
    {

        public SimpleGenerator(string projectName, string dbServer, string dbName, string username, string password, string outputFolder,
            string dbContextName, string projectPath)
        {
            this.projectName = projectName;
            this.dbServer = dbServer;
            this.dbName = dbName;
            this.username = username;
            this.password = password;
            this.outputFolder = outputFolder;
            this.dbContextName = dbContextName;
            this.projectPath = projectPath;

            modelNamespace = outputFolder.Replace('/', '.').Replace('\\', '.');
            if (modelNamespace.Last() != '.')
                modelNamespace += '.';
            generatorProjectName = Assembly.GetCallingAssembly().GetName().Name;
        }

        private string generatorProjectName;
        private string modelNamespace;
        private string projectName;
        private string dbServer;
        private string dbName;
        private string username;
        private string password;
        private string outputFolder;
        private string dbContextName;
        private string projectPath;

        public void Regen(string[] args)
        {
            if (args.Length > 0)
            {
                string dataTypeStr = $"{generatorProjectName}.{modelNamespace}" + dbContextName;
                var dataType = Assembly.GetCallingAssembly().GetType(dataTypeStr);
                if (dataType != null)
                {
                    var context = Activator.CreateInstance(dataType) as DbContext;
                    using (context)
                    {
                        FileHelper.DeleteDataServiceStructure(
                            projectPath);
                        var gen = context.GetDataServiceGenerator(
                            "../../../", projectPath, projectName,
                            JsonPropertyFormatEnum.JsonStyle, DIContainer.ServiceProvider, true, true);
                        gen.Generate();
                    }
                }
            }
            else
            {
                if (!Directory.Exists("../../../" + outputFolder))
                {
                    Console.WriteLine("After scaffolded. Run again");
                    var proc1 = GeneralHelper.ExecuteScaffoldFromCmd(
                    "../../../", dbServer, dbName, username, password, outputFolder, dbContextName);
                }
                else
                {
                    var proc2 = GeneralHelper.ExecuteScaffoldFromCmd(
                        projectPath, dbServer, dbName, username, password, outputFolder, dbContextName);
                    proc2.WaitForExit();

                    var proc3 = GeneralHelper.ExecuteBuildProjectCmd("../../../../", $"{generatorProjectName} -c Release");
                    proc3.WaitForExit();

                    var proc4 = GeneralHelper.ExecuteRunDllCmd("../../Release/netcoreapp2.2", $"{generatorProjectName}.dll true");
                    proc4.WaitForExit();

                    Directory.Delete("../../../" + outputFolder, true);
                }

            }
        }
    }
}
