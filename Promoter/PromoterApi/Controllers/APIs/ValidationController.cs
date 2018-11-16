using PromoterDataService.APIs.Messages;
using PromoterDataService.APIs.Models;
using PromoterDataService.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TNT.Helpers.WebApi;

namespace PromoterApi.Controllers.APIs
{
    [RoutePrefix("api/validation")]
    public class ValidationController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage Get([FromUri]ValidationRequest req)
        {
            try
            {
                var iDomain = new InformationDomain();
                var vRule = iDomain.GetValidationRule(req);
                return Http.OkBase(vRule, Message.Success);
            }
            catch (ErrorMessage e)
            {
                return Http.ErrorBase(null, Message.GetError(e));
            }
            catch (Exception e)
            {
                return Http.ErrorBase(null, Message.GetError(e));
            }
        }

    }
}
