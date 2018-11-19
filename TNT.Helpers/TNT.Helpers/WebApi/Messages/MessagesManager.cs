using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Helpers.WebApi
{
    public abstract class Message<MessCode>
    {
        [JsonProperty("detail")]
        public string Detail { get; set; }
        [JsonProperty("code")]
        public MessCode Code { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; } = "message";
        [JsonProperty("inner")]
        public dynamic InnerObject { get; set; }
    }

    public abstract class ErrorMessage<MessCode> : Exception
    {
        public string Detail { get; private set; }
        public MessCode Code { get; private set; }
        public string Type { get; private set; } = "error";
        public dynamic InnerObject { get; set; }
    }

}
