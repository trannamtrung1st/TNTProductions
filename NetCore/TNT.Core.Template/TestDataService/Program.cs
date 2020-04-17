using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TestDataService.Models;
using TestDataService.Models.Repositories;
using TNT.Core.Template.DataService;
using TNT.Core.Template.DataService.Data;
using TNT.Core.Template.DataService.Helpers;

namespace TestDataService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new TemplateContext())
            {
                var seoRepo = new SeoKeywordsRepository(dbContext);
                var seoKws = dbContext.SeoKeywords.ToList();
                var result =  seoRepo.SqlRemoveAllAsync().Result;
            }
        }

    }
}
