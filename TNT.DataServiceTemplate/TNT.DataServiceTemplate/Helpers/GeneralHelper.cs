using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.DataServiceTemplate.Helpers
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

        public static string ToJsonPropertyFormat(string noun)
        {
            return noun[0].ToString().ToLower() + noun.Substring(1);
        }

    }
}
