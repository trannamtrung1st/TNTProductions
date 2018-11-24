using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promoter.DataService.APIs
{
    public enum MessageCode
    {
        General_Success = 1,
        General_Fail = 2,
    }

    public static class EnumExtension
    {
        public static string ToReadableString(this MessageCode code)
        {
            switch (code)
            {
                case MessageCode.General_Success: return "Thành công";
                case MessageCode.General_Fail: return "Thất bại";
            }
            return null;
        }
    }

}
