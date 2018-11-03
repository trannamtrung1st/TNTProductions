using DataServiceTest.Models.Domains;
using DataServiceTest.Global;
using DataServiceTest.Managers;
using DataServiceTest.Models;
using DataServiceTest.Utilities;
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
            //    JsonPropertyFormatEnum.JsonStyle, true, true, true);
            //autoGen.Generate();

            //Console.WriteLine(ToJsonPropertyFormat("AccountID", JsonPropertyFormatEnum.JsonStyle));

            //var a = new List<Voucher>();

            using (var s = new UnitOfWork())
            {
                var voucherDomain = new VoucherDomain(s);

                voucherDomain.GetActive();
                var sw = Stopwatch.StartNew();
                var vc = voucherDomain.FirstOrDefault(v => v.VoucherCode.StartsWith("6231")).ToViewModel();
                File.WriteAllText("test.json", JsonConvert.SerializeObject(null));
                Console.WriteLine(sw.ElapsedMilliseconds);
                sw.Stop();
            }

        }
    }
}
