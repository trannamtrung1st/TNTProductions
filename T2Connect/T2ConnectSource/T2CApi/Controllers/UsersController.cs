using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using T2CApi.Models;
using T2CDataService.APIs;
using T2CDataService.ViewModels;
using T2CDataService.ViewModels.Client;

namespace T2CApi.Controllers
{

    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [Route("login")]
        [HttpPost]
        public BaseResponse Login(FormDataCollection data)
        {
            var user = UsersApi.Login(data["u"], data["p"]);
            if (user != null)
                return new BaseResponse()
                {
                    Data = user,
                    StatusCode = (int)HttpStatusCode.OK
                };

            return new BaseResponse()
            {
                Message = UsersMsg.NotFound,
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

        [Route("find/{id}")]
        [HttpGet]
        public BaseResponse GetUserById(int id)
        {
            var user = UsersApi.GetUserById(id);
            if (user != null)
                return new BaseResponse()
                {
                    Data = user,
                    StatusCode = (int)HttpStatusCode.OK
                };

            return new BaseResponse()
            {
                Message = UsersMsg.NotFound,
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

        [Route("create")]
        [HttpPost]
        public BaseResponse CreateUser(CreateUserViewModel createUser)
        {
            var user = UsersApi.CreateUser(createUser);
            try
            {
                return new BaseResponse()
                {
                    Data = user,
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                return new BaseResponse()
                {
                    Message = e.Message,
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        [Route("new-users")]
        [HttpGet]
        public BaseResponse GetNewUsers()
        {
            return new BaseResponse()
            {
                Data = UsersApi.GetNewUsers(),
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        [Route("deactivate/{userId}")]
        [HttpGet]
        public BaseResponse Deactivate(int userId)
        {
            return new BaseResponse()
            {
                Data = UsersApi.Deactivate(userId),
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        [Route("remove/{userId}")]
        [HttpGet]
        public BaseResponse Remove(int userId)
        {
            return new BaseResponse()
            {
                Data = UsersApi.Delete(userId),
                StatusCode = (int)HttpStatusCode.OK
            };
        }

    }
}
