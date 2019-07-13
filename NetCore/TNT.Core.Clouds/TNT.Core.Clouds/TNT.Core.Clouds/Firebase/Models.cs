using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TNT.Core.Clouds.Firebase
{
    public class NotifcationResponse
    {
        [JsonProperty("notification_key")]
        public string NotificationKey { get; set; }
    }

    public class SendToDeviceGroupResponse
    {
        [JsonProperty("success")]
        public int Success { get; set; }
        [JsonProperty("failure")]
        public int Failure { get; set; }
        [JsonProperty("failed_registration_ids")]
        public IEnumerable<string> FailedRegistrationIds { get; set; }
    }

    public class SendToDeviceGroupRequest
    {
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("data")]
        public object Data { get; set; }
    }
}
