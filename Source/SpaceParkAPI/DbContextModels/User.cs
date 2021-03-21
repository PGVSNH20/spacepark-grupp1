using Newtonsoft.Json;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;

namespace SpaceParkAPI.DbContextModels
{
    public class User
    {
        public int UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("homeworld")]
        public string HomePlanetUrl { get; set; }

        public int HomePlanetId
        {
            get
            {
                var url = HomePlanetUrl.Split('/', System.StringSplitOptions.RemoveEmptyEntries);
                return Convert.ToInt32(url[url.Length - 1]);
            }
        }

        [JsonProperty("starships")]
        public List<string> StarshispUrl { get; set; }

        public List<int> StarshipsId
        {
            get
            {
                var returnValue = new List<int>();
                foreach (var item in StarshispUrl)
                {
                    Console.WriteLine(item);
                    var urlArray = item.Split('/', System.StringSplitOptions.RemoveEmptyEntries);
                    returnValue.Add(Convert.ToInt32(urlArray[urlArray.Length - 1]));
                }
                return returnValue;
            }
        }
    }
}