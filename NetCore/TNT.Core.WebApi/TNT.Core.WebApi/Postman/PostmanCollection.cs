﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TNT.Core.WebApi.Postman
{
    [Serializable]
    public class PostmanCollection
    {
        public virtual Auth auth { get; set; }
        public virtual ProtocolProfileBehavior protocolProfileBehavior { get; set; }
        public virtual Info info { get; set; } = new Info();
        public virtual List<Item> item { get; set; }
        public virtual List<Variable> variable { get; set; }
    }

    [Serializable]
    public class Info
    {
        public virtual string _postman_id { get; set; } = Guid.NewGuid().ToString();
        public virtual string name { get; set; } = "Default";
        public virtual string description { get; set; } = "This collection is generated by TNT.Core.WebApi";
        public virtual string schema { get; set; } = "https://schema.getpostman.com/json/collection/v2.1.0/collection.json";
    }

    [Serializable]
    public class Auth
    {
        public virtual string type { get; set; }
        public virtual List<OAuth2> oauth2 { get; set; }
    }

    [Serializable]
    public class OAuth2
    {
        public virtual string key { get; set; }
        public virtual string value { get; set; }
        public virtual string type { get; set; }
    }

    [Serializable]
    public class ProtocolProfileBehavior
    {
    }

    [Serializable]
    public abstract class Item
    {
        public virtual string name { get; set; }
    }

    [Serializable]
    public class RequestItem : Item
    {
        public virtual Request request { get; set; }
        public virtual List<object> response { get; set; }
    }

    [Serializable]
    public class FolderItem : Item
    {
        public virtual Auth auth { get; set; }
        public virtual string description { get; set; }
        public virtual ProtocolProfileBehavior protocolProfileBehavior { get; set; }
        public virtual List<Item> item { get; set; }
    }

    [Serializable]
    public class Request
    {
        public virtual Auth auth { get; set; }
        public virtual string method { get; set; }
        public virtual List<Header> header { get; set; }
        public virtual Body body { get; set; }
        public virtual Url url { get; set; }
        public virtual string description { get; set; }
    }

    [Serializable]
    public class Body
    {
        public virtual string mode { get; set; }
        public virtual string raw { get; set; }
        public virtual Options options { get; set; }
    }

    [Serializable]
    public class Options
    {
        public virtual Raw raw { get; set; }
    }

    [Serializable]
    public class Raw
    {
        public virtual string language { get; set; }
    }

    [Serializable]
    public class Url
    {
        public virtual string raw { get; set; }
        public virtual List<string> host { get; set; }
        public virtual List<Query> query { get; set; }
    }

    [Serializable]
    public class Query
    {
        public virtual string key { get; set; }
        public virtual string value { get; set; }
    }

    [Serializable]
    public class Header
    {
        public virtual string key { get; set; }
        public virtual string value { get; set; }
        public virtual string type { get; set; }
    }

    [Serializable]
    public class Variable
    {
        public virtual string id { get; set; }
        public virtual string key { get; set; }
        public virtual string value { get; set; }
        public virtual string type { get; set; }
    }

    public enum AuthType
    {
        [Display(Name = "oauth2")]
        OAuth2 = 1,
    }

    public enum OAuth2AddTokenToEnum
    {
        [Display(Name = "header")]
        Header = 1,
    }

    public enum BodyMode
    {
        [Display(Name = "raw")]
        Raw = 1,
    }

    public enum RawLanguage
    {
        [Display(Name = "json")]
        Json = 1,
    }

}
