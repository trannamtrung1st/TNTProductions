using PromoterDataService.APIs.Enums;
using PromoterDataService.APIs.Messages;
using PromoterDataService.Models;
using PromoterDataService.Models.Domains;
using PromoterDataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TNT.Helpers.WebApi;

namespace PromoterApi.Controllers.APIs
{
    public class VoucherController : ApiController
    {

        [Route("")]
        [HttpPost]
        public HttpResponseMessage CreateVoucher(VoucherViewModel model, int? quantity = null)
        {
            try
            {
                var valid = ValidateCreateVoucher(model, quantity);
                if (!valid.Success)
                    return Http.BadRequest(valid);

                var vDomain = new VoucherDomain();
                if (quantity != null)
                    vDomain.Add(model, quantity.Value);
                else
                    vDomain.Add(model);
                return Http.OkBase(null, Message.Success);
            }
            catch (ErrorMessage e)
            {
                return Http.ErrorBase(null, Message.GetError(e));
            }
            catch (Exception e)
            {
                return Http.ErrorBase(e, Message.UnknownError);
            }
        }

        #region Mapping models
        private Voucher MapToEntity(VoucherViewModel vm)
        {
            var entity = vm.ToEntity();
            return entity;
        }
        #endregion

        #region Validation
        private BaseResponse ValidateCreateVoucher(VoucherViewModel model, int? quantity = null)
        {
            return BaseResponse.Response();
        }
        #endregion

    }
}
