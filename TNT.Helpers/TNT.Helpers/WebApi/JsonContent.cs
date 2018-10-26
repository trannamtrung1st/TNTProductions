using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Helpers.WebApi
{
    public class JsonContent : ObjectContent
    {
        public JsonContent(object obj) : base(obj.GetType(), obj, new JsonMediaTypeFormatter())
        {
        }
    }

    public class JsonContent<T> : ObjectContent<T>
    {
        public JsonContent(T obj) : base(obj, new JsonMediaTypeFormatter())
        {
        }
    }
}
