using RestSharp;
using SpaceParkApi.Models;
using SpaceParkApi.SWApiStore;
using SpaceParkAPI.DbContextModels;
using System;
using System.Collections.Generic;

namespace SpaceParkApi.SWApi
{
    public class SWApi
    {
        public List<User> PeopleList { get; set; }
        public List<Spaceship> StarshipsList { get; set; }
        public List<Planet> PlanetsList { get; set; }
        private RestClient _client { get; set; }

        public SWApi()
        {
            _client = new RestClient("https://swapi.dev/api/");
        }

        public void GetAllStarships(Type test)
        {
            var request = new RestRequest("starships/", DataFormat.Json);
            var response = _client.Get<ISWApiRespons<Spaceship>>(request);
            StarshipsList = response.Data.Results;
            if (response.Data.Next != null)
                StarshipsList.AddRange(GetNextJsonRespons<Spaceship>(response.Data.Next));
        }

        public void GetStarshipByName()
        {
        }

        private List<T> GetNextJsonRespons<T>(string url)
        {
            List<T> returnList = new List<T>();
            var requestString = url.Remove(0, _client.BaseUrl.ToString().Length);
            var request = new RestRequest(requestString, DataFormat.Json);
            var response = _client.Get<ISWApiRespons<T>>(request);
            returnList.AddRange(response.Data.Results);

            if (response.Data.Next != null)
                returnList.AddRange(GetNextJsonRespons<T>(response.Data.Next));

            return response.Data.Results;
        }
    }
}