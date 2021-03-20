using Newtonsoft.Json;
using SpaceParkApi.Models;
using System.Collections.Generic;

namespace SpaceParkApi.SWApiStore
{
    public class Planets : ISWApiRespons<Planet>
    {
        [JsonProperty("results")]
        public List<Planet> Results { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}