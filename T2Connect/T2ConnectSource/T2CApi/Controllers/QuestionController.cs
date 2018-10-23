using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using T2CApi.Models;
using T2CDataService.APIs;
using T2CDataService.ViewModels;
using T2CDataService.ViewModels.Client;

namespace T2CApi.Controllers
{
    [RoutePrefix("api/question")]
    public class QuestionController : ApiController
    {
        [Route("find/{id}")]
        [HttpGet]
        public BaseResponse GetQuestionById(int id)
        {
            var quetion = QuestionApi.GetQuestionById(id);
            if (quetion != null)
                return new BaseResponse()
                {
                    Data = quetion,
                    StatusCode = (int)HttpStatusCode.OK
                };

            return new BaseResponse()
            {
                Message = QuestionMsg.NotFound,
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

        [Route("create")]
        [HttpPost]
        public BaseResponse CreateQuestion(ClientQuestionViewModel newQuestion)
        {
            newQuestion.PostedTime = DateTime.Now;
            var question = QuestionApi.CreateQuestion(newQuestion);
            try
            {
                return new BaseResponse()
                {
                    Data = question,
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
        public BaseResponse GetAllQuestionsOfUserId(int id)
        {
            var questions = QuestionApi.GetAllQuestionsOfUserId(id);
            if (questions != null)
                return new BaseResponse()
                {
                    Data = questions,
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
            var questions = QuestionApi.Deactivate(id);
            if (questions != null)
                return new BaseResponse()
                {
                    Data = questions,
                    StatusCode = (int)HttpStatusCode.OK
                };

            return new BaseResponse()
            {
                Message = QuestionMsg.NotFound,
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

        [Route("remove/{id}")]
        [HttpGet]
        public BaseResponse Remove(int id)
        {
            var questions = QuestionApi.Delete(id);
            if (questions != null)
                return new BaseResponse()
                {
                    Data = questions,
                    StatusCode = (int)HttpStatusCode.OK
                };

            return new BaseResponse()
            {
                Message = QuestionMsg.NotFound,
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

    }
}
