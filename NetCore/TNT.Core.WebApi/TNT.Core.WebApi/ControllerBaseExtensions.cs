using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TNT.Core.WebApi
{
    public abstract class BaseController : ControllerBase
    {
        [NonAction]
        public virtual OkObjectResult OkBase<T>(
            T obj = default(T), dynamic message = null)
        {
            return Ok(BaseResponse<T>.Ok(obj, message));
        }

        [NonAction]
        public virtual OkObjectResult OkBase(
            dynamic obj = null, dynamic message = null)
        {
            return Ok(BaseResponse.Ok(obj, message));
        }

        [NonAction]
        public virtual NotFoundObjectResult NotFoundBase<T>(
            dynamic message = null, T obj = default(T))
        {
            return NotFound(BaseResponse<T>.Ok(obj, message));
        }

        [NonAction]
        public virtual NotFoundObjectResult NotFoundBase(
            dynamic message = null, object obj = null)
        {
            return NotFound(BaseResponse.Ok(obj, message));
        }

        [NonAction]
        public virtual ObjectResult ErrorBase<T>(
            dynamic message = null, T obj = default(T))
        {
            return StatusCode((int)HttpStatusCode.InternalServerError,
                BaseResponse<T>.Fail(message, obj));
        }

        [NonAction]
        public virtual ObjectResult ErrorBase(
            dynamic message = null, object obj = null)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError,
             BaseResponse.Fail(message, obj));
        }

        [NonAction]
        public virtual UnauthorizedObjectResult UnauthorizedBase<T>(
            dynamic message = null, T obj = default(T))
        {
            return Unauthorized(BaseResponse<T>.Fail(message, obj));
        }

        [NonAction]
        public virtual UnauthorizedObjectResult UnauthorizedBase(
            dynamic message = null, object obj = null,
            string reasonPhrase = null)
        {
            return Unauthorized(BaseResponse.Fail(message, obj));
        }

        [NonAction]
        public virtual BadRequestObjectResult BadRequestBase<T>(
            dynamic message = null, T obj = default(T))
        {
            return BadRequest(BaseResponse<T>.Fail(message, obj));
        }

        [NonAction]
        public virtual BadRequestObjectResult BadRequestBase(
            dynamic message = null, object obj = null)
        {
            return BadRequest(BaseResponse.Fail(message, obj));
        }
    }
}
