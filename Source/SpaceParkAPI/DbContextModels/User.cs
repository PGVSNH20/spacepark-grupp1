using Newtonsoft.Json;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;

namespace SpaceParkAPI.DbContextModels
{
    public class User
    {
        [JsonProperty("url")]
        public string SWPeopleUrl { get; set; }

        public int UserId { get; set; }

        public int SWPeopleId
        {
            set
            {
                SWPeopleUrl = $"https://swapi.dev/api/people/{value}/";
            }
            get
            {
                var url = SWPeopleUrl.Split('/', System.StringSplitOptions.RemoveEmptyEntries);
                return Convert.ToInt32(url[^1]);
            }
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("homeworld")]
        public string HomePlanetUrl { get; set; }

        public int HomePlanetId
        {
            set
            {
                HomePlanetUrl = $"https://swapi.dev/api/planets/{value}/";
            }
            get
            {
                var url = HomePlanetUrl.Split('/', System.StringSplitOptions.RemoveEmptyEntries);
                return Convert.ToInt32(url[^1]);
            }
        }

        [JsonProperty("starships")]
        public List<string> StarshispUrl { get; set; }

        public List<int> StarshipsId
        {
            set
            {
                foreach (var item in value)
                    StarshispUrl.Add($"https://swapi.dev/api/starships/{value}/");
            }
            get
            {
                var returnValue = new List<int>();
                foreach (var item in StarshispUrl)
                {
                    Console.WriteLine(item);
                    var urlArray = item.Split('/', System.StringSplitOptions.RemoveEmptyEntries);
                    returnValue.Add(Convert.ToInt32(urlArray[^1]));
                }
                return returnValue;
            }
        }
    }
}