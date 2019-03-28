using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace TNT.Core.WebApi
{
    public static class GeneralExtensions
    {

        public static string ToQueryString(this IDictionary<string, object> dict)
        {
            var query = "";
            foreach (var kvp in dict)
            {
                if (kvp.Value != null)
                    query += HttpUtility.UrlEncode(kvp.Key) + "=" + HttpUtility.UrlEncode(kvp.Value.ToString()) + "&";
            }
            return query;
        }

        public static string ToQueryString(this Dictionary<string, object> dict)
        {
            var query = "";
            foreach (var kvp in dict)
            {
                if (kvp.Value != null)
                    query += HttpUtility.UrlEncode(kvp.Key) + "=" + HttpUtility.UrlEncode(kvp.Value.ToString()) + "&";
            }
            return query;
        }

    }
}
