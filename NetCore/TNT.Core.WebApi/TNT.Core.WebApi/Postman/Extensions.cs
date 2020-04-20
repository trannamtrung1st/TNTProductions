using System;
using System.Collections.Generic;
using System.Text;

namespace TNT.Core.WebApi.Postman
{
    public static class Extensions
    {
        public static string ToPlaceholder(this string varName)
        {
            return "{{" + varName + "}}";
        }

        public static string ToVarName(this string placeholder)
        {
            if (placeholder.StartsWith("{{") && placeholder.EndsWith("}}"))
                return placeholder.Substring(2, placeholder.Length - 4);
            throw new Exception("Wrong placeholder format");
        }
    }
}
