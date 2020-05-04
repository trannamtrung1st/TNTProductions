using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TNT.Core.WebApi.Postman
{
    [Serializable]
    public class CollectionBuilder
    {
        protected PostmanCollection _collection;

        public CollectionBuilder()
        {
            _collection = new PostmanCollection();
        }

        public PostmanCollection Build()
        {
            return _collection;
        }

        public CollectionBuilder oauth2(string accessToken, OAuth2AddTokenToEnum addTokenTo)
        {
            var builder = this.DeepClone();
            var col = builder._collection;
            col.auth = new Auth();
            col.auth.type = AuthType.OAuth2.DisplayName();
            //override
            col.auth.oauth2 = new List<OAuth2>();
            var listoauth2 = new ListOAuth2Builder()
                .From(accessToken, addTokenTo)
                .Build();
            col.auth.oauth2.AddRange(listoauth2);
            return builder;
        }

        public CollectionBuilder AddStringVariables(params Variable[] vars)
        {
            var builder = this.DeepClone();
            var col = builder._collection;
            if (col.variable == null)
                col.variable = new List<Variable>();
            foreach (var v in vars)
            {
                if (v.id == null) v.id = Guid.NewGuid().ToString();
                v.type = "string";
            }
            col.variable.AddRange(vars);
            return builder;
        }

        public CollectionBuilder Info(string name, string description,
            string schema = "https://schema.getpostman.com/json/collection/v2.1.0/collection.json")
        {
            var builder = this.DeepClone();
            var col = builder._collection;
            col.info = new Info()
            {
                name = name,
                schema = schema,
                description = description,
                _postman_id = Guid.NewGuid().ToString()
            };
            return builder;

        }

        public CollectionBuilder AddItems(params Item[] items)
        {
            var builder = this.DeepClone();
            var col = builder._collection;
            if (col.item == null)
                col.item = new List<Item>();
            col.item.AddRange(items);
            return builder;
        }

    }

}
