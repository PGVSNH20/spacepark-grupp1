using Newtonsoft.Json;
using SpaceParkApi.DBContextModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceParkApi.Models
{
    public class Users
    {
        [JsonProperty("results")]
        public List<User> results { get; set; }
    }
}
