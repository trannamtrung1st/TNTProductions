//using DataServiceTest.Global;
//using DataServiceTest.Managers;
//using DataServiceTest.Global;
//using DataServiceTest.Managers;
using DataServiceTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.IoContainer.Container;
using TNT.Template.DataService.Auto;
using static TNT.Template.DataService.Helpers.GeneralHelper;

namespace DataServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var autoGen = new AutoDataServiceGen(
                @"T:\TNT\Workspace\TNTProductions\TNT.Template.DataService\DataServiceTest",
                "DataServiceTest",
                @"bin\Debug\TNT.TemplateAPI.dll",
                @"bin\Debug\TNT.Template.DataService.dll",
                @"Models\MyEntities.edmx",
                JsonPropertyFormatEnum.JsonStyle, true, false, false);
            autoGen.Generate();
        }
    }
}
