using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNT.Core.WebApi.Postman
{
    [Serializable]
    public class RequestItemBuilder
    {
        protected RequestItem _item;
        public RequestItemBuilder()
        {
            _item = new RequestItem();
            _item.Request = new Request();
            _item.Response = new List<object>();
        }

        public RequestItemBuilder OAuth2(string accessToken, OAuth2AddTokenToEnum addTokenTo)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            item.Request.Auth = new Auth();
            item.Request.Auth.Type = AuthType.OAuth2.DisplayName();
            //override
            item.Request.Auth.OAuth2 = new List<OAuth2>();
            var listOAuth2 = new ListOAuth2Builder()
                .From(accessToken, addTokenTo)
                .Build();
            item.Request.Auth.OAuth2.AddRange(listOAuth2);
            return builder;
        }

        public RequestItemBuilder Description(string desc)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            item.Request.Description = desc;
            return builder;
        }

        public RequestItemBuilder Method(string method)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            item.Request.Method = method;
            return builder;
        }

        public RequestItemBuilder AddHeaders(params Header[] headers)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            if (item.Request.Header == null)
                item.Request.Header = new List<Header>();
            item.Request.Header.AddRange(headers);
            return builder;
        }

        public RequestItemBuilder JsonBody(string json)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            item.Request.Body = new Body();
            item.Request.Body.Mode = BodyMode.Raw.DisplayName();
            item.Request.Body.Raw = json;
            item.Request.Body.Options = new Options
            {
                Raw = new Raw
                {
                    Language = RawLanguage.Json.DisplayName()
                }
            };
            return builder;
        }

        public RequestItemBuilder Url(string raw, string host, string queryStr)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            var queries = queryStr.Split('&').Select(q =>
            {
                var parts = q.Split('=');
                return new Query
                {
                    Key = parts[0],
                    Value = parts[1]
                };
            }).ToList();
            item.Request.Url = GetUrl(raw, host, queries);
            return builder;
        }

        protected Url GetUrl(string raw, string host, List<Query> queries)
        {
            return new Url
            {
                Host = new List<string>()
                {
                    host
                },
                Query = queries,
                Raw = raw
            };
        }

        public RequestItemBuilder Url(string raw, string host, List<Query> queries)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            item.Request.Url = GetUrl(raw, host, queries);
            return builder;
        }

        public RequestItemBuilder Name(string name)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            item.Name = name;
            return builder;
        }

        public RequestItem Build()
        {
            return _item;
        }
    }
}
