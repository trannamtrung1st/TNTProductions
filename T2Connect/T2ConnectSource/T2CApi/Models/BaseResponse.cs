using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T2CApi.Models
{
    public class BaseResponse
    {
        /// <summary>
        /// HttpStatusCode
        /// </summary>
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
    }
}