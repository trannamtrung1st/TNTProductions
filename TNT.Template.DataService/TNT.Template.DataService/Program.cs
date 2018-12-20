using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TNT.Template.DataService.Models.Domains;
using TNT.Template.DataService.Data;
using TNT.Template.DataService.Global;
using TNT.Template.DataService.Models;
using TNT.Template.DataService.Models.Extensions;
using TNT.Template.DataService.Models.Repositories;
using TNT.Template.DataService.ViewModels;

namespace TNT.DataService
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new EntityExtensionGen(new EntityInfo(new DataInfo()
            {
                ActiveCol = true,
                ContextName = "DataEntities",
                EdmxPath = @"T:\TNT\Workspace\SkyAdmin\Wisky.SkyAdmin.Manage\CrmApi\Models\DataEntities.edmx",
                Entities = new List<EntityInfo>(),
                ProjectName = "CrmApi",
                RequestScope = false,
            })).ENamespace.Generate());
        }
        
    }
}
