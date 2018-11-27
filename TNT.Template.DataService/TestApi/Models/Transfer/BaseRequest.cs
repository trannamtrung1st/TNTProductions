using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApi.Models.Transfer
{
    public class BaseRequest<T> : Dictionary<string, dynamic>
    {
        [JsonProperty("data")]
        T Data { get; set; }
    }
}