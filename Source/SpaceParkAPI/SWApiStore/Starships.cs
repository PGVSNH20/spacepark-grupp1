using Newtonsoft.Json;
using SpaceParkApi.Models;
using System.Collections.Generic;

namespace SpaceParkApi.SWApiStore
{
    public class Starships : ISWApiData<Starship>
    {
        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("results")]
        public List<Starship> Results { get; set; }
    }
}