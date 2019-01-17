﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TestDataService.Models;
using TNT.Core.Template.DataService;
using TNT.Core.Template.DataService.Data;
using TNT.Core.Template.DataService.Helpers;

namespace TestDataService
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileHelper.DeleteDataServiceStructure(@"T:\Workspace\TNTProductions\NetCore\TNT.Core.Template\TestDataService");
            //GeneralHelper.ExecuteScaffoldFromCmd(
            //    @"T:\Workspace\TNTProductions\NetCore\TNT.Core.Template\TestDataService",
            //    "localhost", "FushariEx", "sa", "123456", "Models", "FushariContext");
            using (var dbContext = new FushariContext())
            {
                var generator = dbContext.GetDataServiceGenerator(
                    @"T:\Workspace\TNTProductions\NetCore\TNT.Core.Template\TestDataService",
                    "TestDataService",
                    GeneralHelper.JsonPropertyFormatEnum.CamelCase,
                    DIContainer.TContainer, true, true);
                generator.Generate();
            }
        }

    }
}