using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using T2CApi.Models;
using T2CDataService.APIs;
using T2CDataService.ViewModels.Client;

namespace T2CApi.Controllers
{
    [RoutePrefix("api/comment")]
    public class CommentController : ApiController
    {

        [Route("find/{id}")]
        [HttpGet]
        public BaseResponse GetCommentById(int id)
        {
            var comment = CommentApi.GetCommentById(id);
            if (comment != null)
                return new BaseResponse()
                {
                    Data = comment,
                    StatusCode = (int)HttpStatusCode.OK
                };

            return new BaseResponse()
            {
                Message = CommentMsg.NotFound,
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

        [Route("create")]
        [HttpPost]
        public BaseResponse CreateComment(ClientCommentViewModel newComment)
        {
            newComment.PostedTime = DateTime.Now;
            var comment = CommentApi.CreateComment(newComment);
            try
            {
                return new BaseResponse()
                {
                    Data = comment,
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

        [Route("all-of-post/{id}")]
        [HttpGet]
        public BaseResponse GetAllCommentsOfPostId(int id)
        {
            var comments = CommentApi.GetAllCommentsOfPostId(id);
            if (comments != null)
                return new BaseResponse()
                {
                    Data = comments,
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
            var comments = CommentApi.Deactivate(id);
            if (comments != null)
                return new BaseResponse()
                {
                    Data = comments,
                    StatusCode = (int)HttpStatusCode.OK
                };

            return new BaseResponse()
            {
                Message = CommentMsg.NotFound,
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

        [Route("remove/{id}")]
        [HttpGet]
        public BaseResponse Remove(int id)
        {
            var comments = CommentApi.Delete(id);
            if (comments != null)
                return new BaseResponse()
                {
                    Data = comments,
                    StatusCode = (int)HttpStatusCode.OK
                };

            return new BaseResponse()
            {
                Message = CommentMsg.NotFound,
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

    }
}
