using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Helpers.WebApi;

namespace Promoter.DataService.Enums
{
    public class AppMessage : GenericMessage<MessageCode>
    {
        public static AppMessage From(MessageCode code, dynamic inner = null)
        {
            return new AppMessage()
            {
                Code = code,
                Detail = code.ToReadable(),
                InnerObject = inner
            };
        }

        public static AppMessage From(AppErrorMessage error)
        {
            return new AppMessage()
            {
                Code = error.Code,
                Detail = error.Detail,
                InnerObject = error.InnerObject,
                Type = error.Type
            };
        }

        public static AppMessage From(Exception e)
        {
            return new AppMessage()
            {
                Code = MessageCode.General_Error,
                Detail = MessageCode.General_Error.ToReadable(),
                InnerObject = JsonConvert.SerializeObject(e),
                Type = "error"
            };
        }
    }

    public class AppErrorMessage : GenericErrorMessage<MessageCode>
    {
        public static AppErrorMessage Get(MessageCode code, dynamic inner = null)
        {
            return new AppErrorMessage()
            {
                Code = code,
                Detail = code.ToReadable(),
                InnerObject = inner
            };
        }
    }

}
