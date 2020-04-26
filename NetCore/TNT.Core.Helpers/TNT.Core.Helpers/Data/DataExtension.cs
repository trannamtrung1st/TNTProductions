using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNT.Core.Helpers.Data
{

    public static class DataExtension
    {
        public static ListDataParameters GetDataParameters<E>(
            this IEnumerable<E> listValues, string prefix)
        {
            var list = new ListDataParameters();
            var sb = new StringBuilder();
            var listParams = listValues.Select((v, i) =>
            {
                var name = $"@{prefix}{i}";
                sb.Append($",{name}");
                return new DataParameter
                {
                    Name = name,
                    Value = v
                };
            }).ToList();
            list.Parameters = listParams;
            var placeholder = sb.ToString();
            if (placeholder?.Length == 0)
            {
                list.Placeholder = "";
                return list;
            }
            placeholder = placeholder.Substring(1);
            list.Placeholder = placeholder;
            return list;
        }
    }
}
