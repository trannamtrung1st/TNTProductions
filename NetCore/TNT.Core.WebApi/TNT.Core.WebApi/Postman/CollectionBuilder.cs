using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TNT.Core.WebApi.Postman
{
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
            if (_collection.Auth == null)
                _collection.Auth = new Auth();
            _collection.Auth.Type = AuthType.OAuth2.DisplayName();
            //override
            _collection.Auth.OAuth2 = new List<OAuth2>();
            var listOAuth2 = new ListOAuth2Builder()
                .From(accessToken, addTokenTo)
                .Build();
            _collection.Auth.OAuth2.AddRange(listOAuth2);
            return this;
        }

        public CollectionBuilder AddStringVariables(params Variable[] vars)
        {
            if (_collection.Variable == null)
                _collection.Variable = new List<Variable>();
            foreach (var v in vars)
            {
                if (v.Id == null) v.Id = Guid.NewGuid().ToString();
                v.Type = "string";
            }
            _collection.Variable.AddRange(vars);
            return this;
        }

        public CollectionBuilder AddItems(params Item[] items)
        {
            if (_collection.Item == null)
                _collection.Item = new List<Item>();
            _collection.Item.AddRange(items);
            return this;
        }

    }

}
