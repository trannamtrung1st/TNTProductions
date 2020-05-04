using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNT.Core.WebApi.Postman
{
    [Serializable]
    public class FolderItemBuilder
    {
        protected FolderItem _item;
        public FolderItemBuilder()
        {
            _item = new FolderItem();
            _item.item = new List<Item>();
        }

        public FolderItemBuilder OAuth2(string accessToken, OAuth2AddTokenToEnum addTokenTo)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            item.auth = new Auth();
            item.auth.type = AuthType.OAuth2.DisplayName();
            //override
            item.auth.oauth2 = new List<OAuth2>();
            var listOAuth2 = new ListOAuth2Builder()
                .From(accessToken, addTokenTo)
                .Build();
            item.auth.oauth2.AddRange(listOAuth2);
            return builder;
        }

        public FolderItemBuilder Description(string desc)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            item.description = desc;
            return builder;
        }

        public FolderItemBuilder Name(string name)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            item.name = name;
            return builder;
        }

        public FolderItemBuilder AddItems(params Item[] items)
        {
            var builder = this.DeepClone();
            var item = builder._item;
            if (item.item == null)
                item.item = new List<Item>();
            item.item.AddRange(items);
            return builder;
        }

        public FolderItem Build()
        {
            return _item;
        }
    }
}
