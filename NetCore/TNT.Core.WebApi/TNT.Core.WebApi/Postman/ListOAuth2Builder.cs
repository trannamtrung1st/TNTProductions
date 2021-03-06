﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TNT.Core.WebApi.Postman
{
    [Serializable]
    public class ListOAuth2Builder
    {
        protected List<OAuth2> _listOAuth2;
        public ListOAuth2Builder()
        {
            _listOAuth2 = new List<OAuth2>();
        }

        public ListOAuth2Builder From(string accessToken, OAuth2AddTokenToEnum addTokenTo)
        {
            var builder = this.DeepClone();
            var listOAuth2 = builder._listOAuth2;
            listOAuth2.Add(new OAuth2
            {
                key = "accessToken",
                type = "string",
                value = accessToken
            });
            listOAuth2.Add(new OAuth2
            {
                key = "addTokenTo",
                type = "string",
                value = addTokenTo.DisplayName()
            });
            return builder;
        }

        public List<OAuth2> Build()
        {
            return _listOAuth2;
        }

    }
}
