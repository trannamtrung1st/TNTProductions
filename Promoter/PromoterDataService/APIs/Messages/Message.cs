using Newtonsoft.Json;
using PromoterDataService.APIs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoterDataService.APIs.Messages
{
    public class Message
    {
        [JsonProperty("code")]
        public MessageCode Code { get; }
        [JsonProperty("type")]
        public string Type { get; }
        [JsonProperty("detail")]
        public string Detail { get; }
        [JsonProperty("extra_detail")]
        public string ExtraDetail { get; }

        private Message(MessageCode code, string type = "message", string extraDetail = null)
        {
            this.Code = code;
            this.Type = type;
            this.Detail = detailsMapping[code];
            this.ExtraDetail = extraDetail;
        }

        public static Message Success
        {
            get
            {
                return new Message(MessageCode.General_Success);
            }
        }

        public static Message UnknownError
        {
            get
            {
                return new Message(MessageCode.General_UnknownError);
            }
        }

        public static Message GetMessage(MessageCode code, string customDetail = null)
        {
            return new Message(code, customDetail);
        }

        public static Message GetError(ErrorMessage e)
        {
            return new Message(e.Code, e.Type, e.ExtraDetail);
        }

        public static Message GetError(Exception e)
        {
            return new Message(MessageCode.General_UnknownError, JsonConvert.SerializeObject(e));
        }

        public static Message GetError(MessageCode code, string customDetail = null)
        {
            return GetError(new ErrorMessage(code, customDetail));
        }

        #region Message mappings
        private static IDictionary<MessageCode, string> detailsMapping =
            new Dictionary<MessageCode, string>()
            {
                { MessageCode.General_UnknownError, "Lỗi chưa xác định"},
                { MessageCode.General_Success, "Thành công"},
            };
        #endregion

    }
}
