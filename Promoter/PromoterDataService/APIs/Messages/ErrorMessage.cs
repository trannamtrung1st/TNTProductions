using PromoterDataService.APIs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoterDataService.APIs.Messages
{
    public class ErrorMessage : Exception
    {
        public MessageCode Code { get; set; }
        public string Type { get; } = "error";
        public string ExtraDetail { get; set; }

        public ErrorMessage(MessageCode code, string extraDetail = null)
        {
            this.Code = code;
            this.ExtraDetail = extraDetail;
        }
    }
}
