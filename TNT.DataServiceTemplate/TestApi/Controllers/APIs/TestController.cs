using DataServiceTest.Models.Domains;
using DataServiceTest.ViewModels;
using DataServiceTest.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataServiceTest.Models;
using TestApi.Models.Transfer;
using System.Web.Http.Results;
using System.Web;
using System.Dynamic;

namespace TestApi.Controllers.APIs
{
    public class TestController : ApiController
    {
        [Route("test")]
        [HttpGet]
        public JsonResult<long> Test()
        {
            var sw = Stopwatch.StartNew();
            var pDomain = new VoucherDomain();
            pDomain.FindById(2031);
            var a = pDomain.GetActive(v => v.VoucherCode.StartsWith("6231")).ToList();
            return Json(sw.ElapsedMilliseconds);
        }

    }
}
