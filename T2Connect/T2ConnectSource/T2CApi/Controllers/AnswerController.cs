using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using T2CApi.Models;
using T2CDataService.APIs;
using T2CDataService.ViewModels;
using T2CDataService.ViewModels.Client;

namespace T2CApi.Controllers
{
    [RoutePrefix("api/answer")]
    public class AnswerController : ApiController
    {

        [Route("find/{id}")]
        [HttpGet]
        public BaseResponse GetAnswerById(int id)
        {
            var answer = AnswerApi.GetAnswerById(id);
            if (answer != null)
                return new BaseResponse()
                {
                    Data = answer,
                    StatusCode = (int)HttpStatusCode.OK
                };

            return new BaseResponse()
            {
                Message = AnswerMsg.NotFound,
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

        [Route("create")]
        [HttpPost]
        public BaseResponse CreateAnswer(ClientAnswerViewModel newAnswer)
        {
            newAnswer.PostedTime = DateTime.Now;
            var answer = AnswerApi.CreateAnswer(newAnswer);
            try
            {
                return new BaseResponse()
                {
                    Data = answer,
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

        [Route("all-of-user/{id}")]
        [HttpGet]
        public BaseResponse GetAllAnswersOfUserId(int id)
        {
            var answers = AnswerApi.GetAllAnswersOfUserId(id);
            if (answers != null)
                return new BaseResponse()
                {
                    Data = answers,
                    StatusCode = (int)HttpStatusCode.OK
                };

            return new BaseResponse()
            {
                Message = GlobalMsg.InternalError,
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        [Route("deactivate/{id}")]
        [HttpGet]
        public BaseResponse Deactivate(int id)
        {
            var answers = AnswerApi.Deactivate(id);
            if (answers != null)
                return new BaseResponse()
                {
                    Data = answers,
                    StatusCode = (int)HttpStatusCode.OK
                };

            return new BaseResponse()
            {
                Message = AnswerMsg.NotFound,
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

        [Route("remove/{id}")]
        [HttpGet]
        public BaseResponse Remove(int id)
        {
            var answers = AnswerApi.Delete(id);
            if (answers != null)
                return new BaseResponse()
                {
                    Data = answers,
                    StatusCode = (int)HttpStatusCode.OK
                };

            return new BaseResponse()
            {
                Message = AnswerMsg.NotFound,
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

    }
}
