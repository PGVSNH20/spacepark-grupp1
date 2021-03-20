using Newtonsoft.Json;
using SpaceParkAPI.DbContextModels;
using System.Collections.Generic;

namespace SpaceParkApi.SWApiStore
{
    public class People : ISWApiRespons<User>
    {
        [JsonProperty("results")]
        public List<User> Results { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}