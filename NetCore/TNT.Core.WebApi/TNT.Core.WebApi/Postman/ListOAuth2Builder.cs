using System;
using System.Collections.Generic;
using System.Text;

namespace TNT.Core.WebApi.Postman
{
    public class ListOAuth2Builder
    {
        protected List<OAuth2> _listOAuth2;
        public ListOAuth2Builder()
        {
            _listOAuth2 = new List<OAuth2>();
        }

        public ListOAuth2Builder From(string accessToken, OAuth2AddTokenToEnum addTokenTo)
        {
            _listOAuth2.Add(new OAuth2
            {
                Key = "accessToken",
                Type = "string",
                Value = accessToken
            });
            _listOAuth2.Add(new OAuth2
            {
                Key = "addTokenTo",
                Type = "string",
                Value = addTokenTo.DisplayName()
            });
            return this;
        }

        public List<OAuth2> Build()
        {
            return _listOAuth2;
        }

    }
}
