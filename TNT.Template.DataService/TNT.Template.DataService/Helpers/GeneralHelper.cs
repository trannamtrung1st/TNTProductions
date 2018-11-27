using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TNT.Template.DataService.Helpers
{
    public class GeneralHelper
    {
        public static string PluralizeNoun(string noun)
        {
            PluralizationService service = PluralizationService.CreateService(CultureInfo.CurrentCulture);
            return service.Pluralize(noun);
        }

        public static string SingularizeNoun(string noun)
        {
            PluralizationService service = PluralizationService.CreateService(CultureInfo.CurrentCulture);
            return service.Singularize(noun);
        }

        public enum JsonPropertyFormatEnum
        {
            CamelCase,
            JsonStyle
        }

        public static string ToJsonPropertyFormat(string noun, JsonPropertyFormatEnum style)
        {
            if (style == JsonPropertyFormatEnum.CamelCase)
                return char.ToLower(noun[0]) + noun.Substring(1);
            else if (style == JsonPropertyFormatEnum.JsonStyle)
            {
                noun = noun[0].ToString().ToLower() + noun.Substring(1);
                var i = 1;
                var isLastUpper = true;
                while (i < noun.Length)
                {
                    while (i < noun.Length && (char.IsLower(noun[i]) || char.IsDigit(noun[i])))
                    {
                        isLastUpper = false;
                        i++;
                    }
                    if (i < noun.Length)
                    {
                        if (!isLastUpper)
                        {
                            noun = noun.Substring(0, i) + "_" + char.ToLower(noun[i]) + noun.Substring(i + 1);
                            i++;
                            isLastUpper = true;
                        }
                        else noun = noun.Substring(0, i) + noun[i].ToString().ToLower() + noun.Substring(i + 1);
                    }
                    i++;
                }
                return noun;
            }
            return null;
        }
    }
}
