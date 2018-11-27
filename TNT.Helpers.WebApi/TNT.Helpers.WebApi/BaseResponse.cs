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
        [JsonProperty("sucess")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public dynamic Message { get; set; }
        [JsonProperty("data")]
        public dynamic Data { get; set; }
        private BaseResponse() { }

        public static BaseResponse From<T>(
            T data = default(T), bool success = true, dynamic message = null)
        {
            return new BaseResponse()
            {
                Success = success,
                Data = data,
                Message = message
            };
        }

        public static BaseResponse From(
            dynamic data = null, bool success = true, dynamic message = null)
        {
            return new BaseResponse()
            {
                Success = success,
                Data = data,
                Message = message
            };
        }

        public static BaseResponse Response<T>(
            T data = default(T), dynamic message = null)
        {
            return new BaseResponse()
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static BaseResponse Response(
            dynamic data = null, dynamic message = null)
        {
            return new BaseResponse()
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static BaseResponse Error<T>(
             T data = default(T), dynamic message = null)
        {
            return new BaseResponse()
            {
                Success = false,
                Data = data,
                Message = message
            };
        }

        public static BaseResponse Error(
            dynamic data = null, dynamic message = null)
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
        [JsonProperty("sucess")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public dynamic Message { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
        private BaseResponse() { }

        public static BaseResponse<T> From(
            T data = default(T), bool success = true, dynamic message = null)
        {
            return new BaseResponse<T>()
            {
                Success = success,
                Data = data,
                Message = message
            };
        }

        public static BaseResponse<T> Response(
            T data = default(T), dynamic message = null)
        {
            return new BaseResponse<T>()
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static BaseResponse<T> Error(
            T data = default(T), dynamic message = null)
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
