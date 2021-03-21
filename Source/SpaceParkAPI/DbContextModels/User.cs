using Newtonsoft.Json;
using RestSharp.Serializers;

namespace SpaceParkAPI.DbContextModels
{
    public class User
    {
        public int UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("homeworld")]
        public string HomePlanet { get; set; }
    }
}