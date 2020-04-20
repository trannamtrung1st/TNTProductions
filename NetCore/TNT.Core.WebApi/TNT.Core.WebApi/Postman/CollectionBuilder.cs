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

        public CollectionBuilder OAuth2(string accessToken, OAuth2AddTokenToEnum addTokenTo)
        {
            var builder = this.DeepClone();
            var col = builder._collection;
            col.Auth = new Auth();
            col.Auth.Type = AuthType.OAuth2.DisplayName();
            //override
            col.Auth.OAuth2 = new List<OAuth2>();
            var listOAuth2 = new ListOAuth2Builder()
                .From(accessToken, addTokenTo)
                .Build();
            col.Auth.OAuth2.AddRange(listOAuth2);
            return builder;
        }

        public CollectionBuilder AddStringVariables(params Variable[] vars)
        {
            var builder = this.DeepClone();
            var col = builder._collection;
            if (col.Variable == null)
                col.Variable = new List<Variable>();
            foreach (var v in vars)
            {
                if (v.Id == null) v.Id = Guid.NewGuid().ToString();
                v.Type = "string";
            }
            col.Variable.AddRange(vars);
            return builder;
        }

        public CollectionBuilder Info(string name, string description,
            string schema = "https://schema.getpostman.com/json/collection/v2.1.0/collection.json")
        {
            var builder = this.DeepClone();
            var col = builder._collection;
            col.Info = new Info()
            {
                Name = name,
                Schema = schema,
                Description = description,
                PostmanId = Guid.NewGuid().ToString()
            };
            return builder;

        }

        public CollectionBuilder AddItems(params Item[] items)
        {
            var builder = this.DeepClone();
            var col = builder._collection;
            if (col.Item == null)
                col.Item = new List<Item>();
            col.Item.AddRange(items);
            return builder;
        }

    }

}
