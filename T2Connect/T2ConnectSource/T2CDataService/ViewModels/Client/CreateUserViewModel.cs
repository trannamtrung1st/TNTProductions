using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2CDataService.Global;
using T2CDataService.Models;
using T2CDataService.ViewModels;

namespace T2CDataService.ViewModels.Client
{
    public class CreateUserViewModel : BaseViewModel<User>
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("firstname")]
        public string Firstname { get; set; }
        [JsonProperty("lastname")]
        public string Lastname { get; set; }
        [JsonProperty("dob")]
        public Nullable<DateTime> Dob { get; set; }
        [JsonProperty("joinedDate")]
        public Nullable<DateTime> JoinedDate { get; set; }
        [JsonIgnore]
        public bool Deactive { get; set; }

        public CreateUserViewModel(User entity) : this()
        {
            FromEntity(entity);
        }

        public CreateUserViewModel()
        {
        }

    }
}
