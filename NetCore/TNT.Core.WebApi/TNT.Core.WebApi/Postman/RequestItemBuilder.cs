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
            _item.request = new Request();
            _item.response = new List<object>();
        }

        public RequestItemBuilder OAuth2(string accessToken, OAuth2AddTokenToEnum addTokenTo)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            item.request.auth = new Auth();
            item.request.auth.type = AuthType.OAuth2.DisplayName();
            //override
            item.request.auth.oauth2 = new List<OAuth2>();
            var listOAuth2 = new ListOAuth2Builder()
                .From(accessToken, addTokenTo)
                .Build();
            item.request.auth.oauth2.AddRange(listOAuth2);
            return builder;
        }

        public RequestItemBuilder Description(string desc)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            item.request.description = desc;
            return builder;
        }

        public RequestItemBuilder Method(string method)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            item.request.method = method;
            return builder;
        }

        public RequestItemBuilder AddHeaders(params Header[] headers)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            if (item.request.header == null)
                item.request.header = new List<Header>();
            item.request.header.AddRange(headers);
            return builder;
        }

        public RequestItemBuilder JsonBody(string json)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            item.request.body = new Body();
            item.request.body.mode = BodyMode.Raw.DisplayName();
            item.request.body.raw = json;
            item.request.body.options = new Options
            {
                raw = new Raw
                {
                    language = RawLanguage.Json.DisplayName()
                }
            };
            return builder;
        }

        protected Url GetUrl(string host, List<Query> queries, bool autoEscape)
        {
            if (queries != null)
                queries.ForEach(q =>
                {
                    if (q.value == null) q.value = "";
                    else if (autoEscape) q.value = Uri.EscapeDataString(q.value);
                });

            return new Url
            {
                host = new List<string>()
                {
                    host
                },
                query = queries,
            };
        }

        public RequestItemBuilder Url(string host, bool autoEscape = true)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            item.request.url = GetUrl(host, null, autoEscape);
            return builder;
        }

        public RequestItemBuilder Url(string host, string queryStr, bool autoEscape = true)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            var queries = queryStr?.Split('&').Select(q =>
            {
                var parts = q.Split('=');
                return new Query
                {
                    key = parts[0],
                    value = parts[1]
                };
            }).ToList();
            item.request.url = GetUrl(host, queries, autoEscape);
            return builder;
        }

        public RequestItemBuilder Url(string host, List<Query> queries, bool autoEscape = true)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            item.request.url = GetUrl(host, queries, autoEscape);
            return builder;
        }

        public RequestItemBuilder Name(string name)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            item.name = name;
            return builder;
        }

        public RequestItem Build()
        {
            return _item;
        }
    }
}
