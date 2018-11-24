using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Helpers.WebApi;

namespace Promoter.DataService.APIs.Models
{
    public class Message : GenericMessage<MessageCode>
    {

        public static Message Success(dynamic inner = null)
        {
            return new Message()
            {
                Code = MessageCode.General_Success,
                Detail = MessageCode.General_Success.ToReadableString(),
                InnerObject = inner
            };
        }

        public static Message Error(Exception e)
        {
            return new Message()
            {
                Code = MessageCode.General_Fail,
                Detail = JsonConvert.SerializeObject(e)
            };
        }

    }

    public class ErrorMessage : GenericErrorMessage<MessageCode>
    {
    }
}
