using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TNT.Core.Helpers.General
{

    public static partial class EnumExtension
    {
        public static IEnumerable<Type> GetValues<Type>()
        {
            var type = typeof(Type);
            var enumType = typeof(Enum);
            var enums = type.GetFields().Where(f => f.FieldType.IsSubclassOf(enumType));
            return enums.Select(f => (Type)f.GetValue(null));
        }

        private static readonly IDictionary<Type, IDictionary<int, string>>
            enumCaches = new Dictionary<Type, IDictionary<int, string>>();

        public static IDictionary<int, string> Get<Type>()
        {
            var type = typeof(Type);
            if (enumCaches.ContainsKey(type))
                return enumCaches[type];
            var enumType = typeof(Enum);
            var enums = type.GetFields().Where(f => f.FieldType.IsSubclassOf(enumType));
            var dict = new Dictionary<int, string>();
            foreach (var e in enums)
            {
                dict[(int)e.GetRawConstantValue()] = e.FieldType.DisplayName(e.Name);
            }
            enumCaches[type] = dict;
            return dict;
        }

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

        public static String DisplayName(this Type enumType, string enumName)
        {
            var displayNameAttr = enumType.GetField(enumName).GetCustomAttributes(false)
                .OfType<DisplayAttribute>().SingleOrDefault();
            if (displayNameAttr != null)
                return displayNameAttr.Name;
            return null;
        }
    }
}
