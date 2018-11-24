using Promoter.DataService.APIs.Models;
using Promoter.DataService.Models;
using Promoter.DataService.Models.Domains;
using Promoter.DataService.Utilities;
using Promoter.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TNT.Helpers.WebApi;

namespace Promoter.WebApi.Controllers.APIs
{
    [RoutePrefix("api/brand")]
    public class BrandController : ApiController
    {

        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetBrand([FromUri] BrandRequest req)
        {
            try
            {
                var iDomain = new InformationDomain();
                var brand = iDomain.GetBrand(req);
                var brandVM = ToBrandViewModel(brand);
                return Http.OkBase(brandVM, Message.Success());
            }
            catch (Exception e)
            {
                return Http.ErrorBase(null, Message.Error(e));
            }
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage RegisterBrand(BrandViewModel brandVM)
        {
            try
            {
                var appDomain = new AppUserDomain();
                var entity = ToBrand(brandVM);
                appDomain.CreateBrand(entity);
                return Http.OkBase(null, Message.Success());
            }
            catch (Exception e)
            {
                return Http.ErrorBase(null, Message.Error(e));
            }
        }

        [Route("account")]
        [HttpPost]
        public HttpResponseMessage RegisterBrandAccount(BrandAccountViewModel brandAccVM)
        {
            try
            {
                var appDomain = new AppUserDomain();
                var entity = ToBrandAccount(brandAccVM);
                appDomain.CreateBrandAccount(entity);
                return Http.OkBase(null, Message.Success());
            }
            catch (Exception e)
            {
                return Http.ErrorBase(null, Message.Error(e));
            }
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage AcceptMembership(int customerId)
        {
            return null;
        }

        #region Mapping
        private Brand ToBrand(BrandViewModel vm)
        {
            return vm.ToEntity();
        }

        private BrandAccount ToBrandAccount(BrandAccountViewModel vm)
        {
            return vm.ToEntity();
        }

        private IEnumerable<BrandViewModel> ToBrandViewModel(IEnumerable<Brand> list)
        {
            return list.ToListVM<Brand, BrandViewModel>();
        }
        #endregion

    }
}
