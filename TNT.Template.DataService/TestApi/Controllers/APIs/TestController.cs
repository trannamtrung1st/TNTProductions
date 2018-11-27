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
using TNT.Helpers.Data;
using TNT.Helpers.WebApi;

namespace TestApi.Controllers.APIs
{
    public class TestController : ApiController
    {
        [Route("test")]
        [HttpGet]
        public HttpResponseMessage Test(string arr)
        {
            var sw = Stopwatch.StartNew();
            using (var u = new passioTestEntities())
            {
                var v = u.Promotions.ToList();
                return Http.OkBase(null, sw.ElapsedMilliseconds);
            }
        }

    }
}
