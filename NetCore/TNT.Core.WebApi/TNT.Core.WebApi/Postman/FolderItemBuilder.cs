using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNT.Core.WebApi.Postman
{
    public class FolderItemBuilder
    {
        protected FolderItem _item;
        public FolderItemBuilder()
        {
            _item = new FolderItem();
            _item.Item = new List<Item>();
        }

        public FolderItemBuilder OAuth2(string accessToken, OAuth2AddTokenToEnum addTokenTo)
        {
            _item.Auth = new Auth();
            _item.Auth.Type = AuthType.OAuth2.DisplayName();
            //override
            _item.Auth.OAuth2 = new List<OAuth2>();
            var listOAuth2 = new ListOAuth2Builder()
                .From(accessToken, addTokenTo)
                .Build();
            _item.Auth.OAuth2.AddRange(listOAuth2);
            return this;
        }

        public FolderItemBuilder Description(string desc)
        {
            _item.Description = desc;
            return this;
        }

        public FolderItemBuilder Name(string name)
        {
            _item.Name = name;
            return this;
        }

        public FolderItemBuilder AddItems(params Item[] items)
        {
            if (_item.Item == null)
                _item.Item = new List<Item>();
            _item.Item.AddRange(items);
            return this;
        }

        public FolderItem Build()
        {
            return _item;
        }
    }
}
