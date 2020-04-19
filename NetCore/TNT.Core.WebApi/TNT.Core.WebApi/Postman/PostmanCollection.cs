using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TNT.Core.WebApi.Postman
{
    public class PostmanCollection
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("auth")]
        public Auth Auth { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("protocolProfileBehavior")]
        public ProtocolProfileBehavior ProtocolProfileBehavior { get; set; }
        [JsonProperty("info")]
        public Info Info { get; set; }
        [JsonProperty("item")]
        public List<Item> Item { get; set; }
        [JsonProperty("variable")]
        public List<Variable> Variable { get; set; }
    }

    public class Info
    {
        [JsonProperty("_postman_id")]
        public string PostmanId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("schema")]
        public string Schema { get; set; } = "https://schema.getpostman.com/json/collection/v2.1.0/collection.json";
    }

    public class Auth
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("oauth2")]
        public List<OAuth2> OAuth2 { get; set; }
    }

    public class OAuth2
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class ProtocolProfileBehavior
    {
    }

    public abstract class Item
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class RequestItem : Item
    {
        [JsonProperty("request")]
        public Request Request { get; set; }
        [JsonProperty("response")]
        public List<object> Response { get; set; }
    }

    public class FolderItem : Item
    {
        [JsonProperty("auth")]
        public Auth Auth { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("protocolProfileBehavior")]
        public ProtocolProfileBehavior ProtocolProfileBehavior { get; set; }
        [JsonProperty("item")]
        public List<Item> Item { get; set; }
    }

    public class Request
    {
        [JsonProperty("auth")]
        public Auth Auth { get; set; }
        [JsonProperty("method")]
        public string Method { get; set; }
        [JsonProperty("header")]
        public List<Header> Header { get; set; }
        [JsonProperty("body")]
        public Body Body { get; set; }
        [JsonProperty("url")]
        public Url Url { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Body
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }
        [JsonProperty("raw")]
        public string Raw { get; set; }
        [JsonProperty("options")]
        public Options Options { get; set; }
    }

    public class Options
    {
        [JsonProperty("raw")]
        public Raw Raw { get; set; }
    }

    public class Raw
    {
        [JsonProperty("language")]
        public string Language { get; set; }
    }

    public class Url
    {
        [JsonProperty("raw")]
        public string Raw { get; set; }
        [JsonProperty("host")]
        public List<string> Host { get; set; }
        [JsonProperty("query")]
        public List<Query> Query { get; set; }
    }

    public class Query
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Header
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Variable
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
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
