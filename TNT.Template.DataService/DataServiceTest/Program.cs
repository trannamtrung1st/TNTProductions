using DataServiceTest.Global;
using DataServiceTest.Managers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Auto;
using TNT.DataServiceTemplate.Data;
using TNT.DataServiceTemplate.Helpers;
using static TNT.DataServiceTemplate.Helpers.GeneralHelper;

namespace DataServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var autoGen = new AutoDataServiceGen(
            //    @"T:\TNT\Workspace\TNTProductions\TNT.DataServiceTemplate\DataServiceTest",
            //    "DataServiceTest",
            //    @"bin\Debug\TNT.TemplateAPI.dll",
            //    @"bin\Debug\TNT.DataServiceTemplate.dll",
            //    @"Models\MyEntities.edmx",
            //    JsonPropertyFormatEnum.JsonStyle, true, false, true);
            //autoGen.Generate();
            
            G.Configure();
            var a = G.TContainer.ResolveSingleton<IUnitOfWork>();
        }
    }
}
