using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Helpers.WebApi
{
    public abstract class GenericMessage<MessCode>
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

    public abstract class GenericErrorMessage<MessCode> : Exception
    {
        public string Detail { get; set; }
        public MessCode Code { get; set; }
        public string Type { get; set; } = "error";
        public dynamic InnerObject { get; set; }
    }

}
