using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNT.Core.WebApi.Postman
{
    public class ItemBuilder
    {
        protected Item _item;
        public ItemBuilder()
        {
            _item = new Item();
            _item.Request = new Request();
            _item.Response = new List<object>();
        }

        public ItemBuilder OAuth2(string accessToken, OAuth2AddTokenToEnum addTokenTo)
        {
            if (_item.Request.Auth == null)
                _item.Request.Auth = new Auth();
            _item.Request.Auth.Type = AuthType.OAuth2.DisplayName();
            //override
            _item.Request.Auth.OAuth2 = new List<OAuth2>();
            var listOAuth2 = new ListOAuth2Builder()
                .From(accessToken, addTokenTo)
                .Build();
            _item.Request.Auth.OAuth2.AddRange(listOAuth2);
            return this;
        }

        public ItemBuilder Description(string desc)
        {
            _item.Request.Description = desc;
            return this;
        }

        public ItemBuilder Method(string method)
        {
            _item.Request.Method = method;
            return this;
        }

        public ItemBuilder AddHeaders(params Header[] headers)
        {
            if (_item.Request.Header == null)
                _item.Request.Header = new List<Header>();
            _item.Request.Header.AddRange(headers);
            return this;
        }

        public ItemBuilder JsonBody(string json)
        {
            _item.Request.Body = new Body();
            _item.Request.Body.Mode = BodyMode.Raw.DisplayName();
            _item.Request.Body.Raw = json;
            _item.Request.Body.Options = new Options
            {
                Raw = new Raw
                {
                    Language = RawLanguage.Json.DisplayName()
                }
            };
            return this;
        }

        public ItemBuilder Url(string raw, string host, string queryStr)
        {
            var queries = queryStr.Split('&').Select(q =>
            {
                var parts = q.Split('=');
                return new Query
                {
                    Key = parts[0],
                    Value = parts[1]
                };
            }).ToList();
            _item.Request.Url = new Url
            {
                Host = new List<string>()
                {
                    host
                },
                Query = queries,
                Raw = raw
            };
            return this;
        }
        public ItemBuilder Url(string raw, string host, List<Query> queries)
        {
            _item.Request.Url = new Url
            {
                Host = new List<string>()
                {
                    host
                },
                Query = queries,
                Raw = raw
            };
            return this;
        }

        public Item Build()
        {
            return _item;
        }
    }
}
