using Newtonsoft.Json;
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

        public void GetAllStarships()
        {
            StarshipsList = new List<Spaceship>();
            var request = new RestRequest("starships/", DataFormat.Json);
            var respons = _client.Execute(request);
            var responsObj = JsonConvert.DeserializeObject<Starships>(respons.Content);
            StarshipsList.AddRange(responsObj.Results);
            while (responsObj.Next != null)
            {
                responsObj = GetNextJsonRespons<Starships>(responsObj.Next);
                StarshipsList.AddRange(responsObj.Results);
            }
        }

        public void GetAllPeople()
        {
            PeopleList = new List<User>();
            var request = new RestRequest("people/", DataFormat.Json);
            var respons = _client.Execute(request);
            var responsObj = JsonConvert.DeserializeObject<People>(respons.Content);
            PeopleList.AddRange(responsObj.Results);
            while (responsObj.Next != null)
            {
                responsObj = GetNextJsonRespons<People>(responsObj.Next);
                PeopleList.AddRange(responsObj.Results);
            }
        }

        public void GetAllPlanets()
        {
            PlanetsList = new List<Planet>();
            var request = new RestRequest("planets/", DataFormat.Json);
            var respons = _client.Execute(request);
            var responsObj = JsonConvert.DeserializeObject<Planets>(respons.Content);
            PlanetsList.AddRange(responsObj.Results);
            while (responsObj.Next != null)
            {
                responsObj = GetNextJsonRespons<Planets>(responsObj.Next);
                PlanetsList.AddRange(responsObj.Results);
            }
        }

        public void GetStarshipByName()
        {
        }

        private T GetNextJsonRespons<T>(string url)
        {
            var requestString = url.Remove(0, _client.BaseUrl.ToString().Length - 1);
            var request = new RestRequest(requestString, DataFormat.Json);
            var respons = _client.Execute(request);
            var responsObj = JsonConvert.DeserializeObject<T>(respons.Content);
            return responsObj;
        }
    }
}