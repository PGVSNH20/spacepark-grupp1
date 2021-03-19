using Newtonsoft.Json;
using SpaceParkApi.DBContextModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceParkApi.Models
{
    class Users
    {
        [JsonProperty("results")]
        public List<User> UserList { get; set; }
    }
}
