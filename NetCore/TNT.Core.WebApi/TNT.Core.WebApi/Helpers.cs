using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TNT.Core.WebApi
{
    static class EnumExtensions
    {
        public static string DisplayName(this Enum enumVal)
        {
            var enumType = enumVal.GetType();
            var name = Enum.GetName(enumType, enumVal);
            var displayNameAttr = enumType.GetField(name).GetCustomAttributes(false)
                .OfType<DisplayAttribute>().SingleOrDefault();
            if (displayNameAttr != null)
                return displayNameAttr.Name;
            return null;
        }

        public static string DisplayName(this Type enumType, string enumName)
        {
            var displayNameAttr = enumType.GetField(enumName).GetCustomAttributes(false)
                .OfType<DisplayAttribute>().SingleOrDefault();
            if (displayNameAttr != null)
                return displayNameAttr.Name;
            return null;
        }
    }
}
