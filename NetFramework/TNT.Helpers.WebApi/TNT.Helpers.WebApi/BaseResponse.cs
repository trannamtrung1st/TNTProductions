using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Helpers.WebApi
{
    public class BaseResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public object Message { get; set; }
        [JsonProperty("data")]
        public object Data { get; set; }

        public static BaseResponse From<T>(
            T data = default(T), bool success = true, object message = null)
        {
            return new BaseResponse()
            {
                Success = success,
                Data = data,
                Message = message
            };
        }

        public static BaseResponse From(
            object data = null, bool success = true, object message = null)
        {
            return new BaseResponse()
            {
                Success = success,
                Data = data,
                Message = message
            };
        }

        public static BaseResponse Ok<T>(
            T data = default(T), object message = null)
        {
            return new BaseResponse()
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static BaseResponse Ok(
            object data = null, object message = null)
        {
            return new BaseResponse()
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static BaseResponse Fail<T>(
             object message = null, T data = default(T))
        {
            return new BaseResponse()
            {
                Success = false,
                Data = data,
                Message = message
            };
        }

        public static BaseResponse Fail(
            object message = null, object data = null)
        {
            return new BaseResponse()
            {
                Success = false,
                Data = data,
                Message = message
            };
        }

    }

    public class BaseResponse<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public object Message { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }

        public static BaseResponse<T> From(
            T data = default(T), bool success = true, object message = null)
        {

            return new BaseResponse<T>()
            {
                Success = success,
                Data = data,
                Message = message
            };
        }

        public static BaseResponse<T> Ok(
            T data = default(T), object message = null)
        {
            return new BaseResponse<T>()
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static BaseResponse<T> Fail(
            object message = null, T data = default(T))
        {
            return new BaseResponse<T>()
            {
                Success = false,
                Data = data,
                Message = message
            };
        }

    }
}
