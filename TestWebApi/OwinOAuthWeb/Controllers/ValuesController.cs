using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TNT.Helpers.WebApi.Owin;

namespace OwinOAuthWeb.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HostAuthentication("ProviderBased")]
        [Authorize]
        public IEnumerable<string> Get()
        {
            var user = Request.GetOwinContext().Authentication.User;
            return new string[] { "value1", "value2" };
        }

        [Route("test")]
        [HttpGet]
        public HttpResponseMessage test()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
