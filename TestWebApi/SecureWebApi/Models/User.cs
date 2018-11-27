using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace SecureWebApi.Models
{
    public class User
    {
        //test
        public static IDictionary<string, User> Mappings { get; set; }
        static User()
        {
            Mappings = new Dictionary<string, User>();
            Mappings.Add("TNT", new User()
            {
                Username = "TNT",
                Password = "123",
                UserId = "1",
                Roles = new List<string>() { "Administrator" }
            });

            Mappings.Add("TrungTranGG", new User()
            {
                Username = "TrungTranGG",
                Password = null,
                UserId = "107863564601151415208",
                Roles = new List<string>() { "Guest" }
            });

            Mappings.Add("TranTrungFB", new User()
            {
                Username = "TranTrungFB",
                Password = null,
                UserId = "1085396321635305",
                Roles = new List<string>() { "Guest" }
            });

            Mappings.Add("ABC", new User()
            {
                Username = "ABC",
                Password = "123",
                UserId = "2",
                Roles = new List<string>() { "Manager" }
            });

            Mappings.Add("DEF", new User()
            {
                Username = "DEF",
                Password = "123",
                UserId = "3",
                Roles = new List<string>() { "Guest" }
            });
        }
        //-------------------

        public IEnumerable<string> Roles { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? TokenGenTime { get; set; }
        public DateTime? TokenExpiryTime { get; set; }

        public UserViewModel ToViewModel()
        {
            return new UserViewModel(this);
        }

    }

    public class UserViewModel : GenericIdentity
    {
        public string Username { get; set; }
        public string UserId { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public string Token { get; set; }
        public DateTime? TokenGenTime { get; set; }
        public DateTime? TokenExpiryTime { get; set; }


        protected User entity;
        public UserViewModel(User user) : base(user.Username, ClaimTypes.Name)
        {
            this.entity = user;
            this.Username = user.Username;
            this.UserId = user.UserId;
            this.Roles = user.Roles;
            this.Token = user.Token;
            this.TokenGenTime = user.TokenGenTime;
            this.TokenExpiryTime = user.TokenExpiryTime;
        }

        public User ToEntity()
        {
            return entity;
        }
    }
}