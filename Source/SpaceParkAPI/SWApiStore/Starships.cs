using Newtonsoft.Json;
using SpaceParkApi.Models;
using System.Collections.Generic;

namespace SpaceParkApi.SWApiStore
{
    public class Starships : ISWApiData<Spaceship>
    {
        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("results")]
        public List<Spaceship> Results { get; set; }
    }
}