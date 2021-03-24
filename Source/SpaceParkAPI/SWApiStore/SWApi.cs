using RestSharp;
using SpaceParkApi.DBContextModels;
using SpaceParkApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkApi.SWApiStore
{
    public class SWApi
    {
        public RestClient Client { get; set; } = new RestClient("https://swapi.dev/api/");

        public async Task<List<User>> GetAllUsers()
        {
            var users = new List<User>();

            var request = new RestRequest("people/", DataFormat.Json);

            var peopleResponse = await Client.GetAsync<People>(request);

            users.AddRange(peopleResponse.results);

            while (peopleResponse.next != null)
            {
                var requestString = peopleResponse.next.Replace("https://swapi.dev/api/", "");
                request = new RestRequest(requestString, DataFormat.Json);

                peopleResponse = await Client.GetAsync<People>(request);
                users.AddRange(peopleResponse.results);
            }

            return users;
        }

        public async Task<List<Spaceship>> GetAllStarShips()
        {
            var starships = new List<Spaceship>();

            var request = new RestRequest("starships/", DataFormat.Json);

            var starshipsResponse = await Client.GetAsync<StarShips>(request);

            starships.AddRange(starshipsResponse.results);

            while (starshipsResponse.next != null)
            {
                var requestString = starshipsResponse.next.Replace("https://swapi.dev/api/", "");
                request = new RestRequest(requestString, DataFormat.Json);

                starshipsResponse = await Client.GetAsync<StarShips>(request);
                starships.AddRange(starshipsResponse.results);
            }

            return starships;
        }

        public async Task<Planet> GetPlanetById(int planet)
        {
            var request = new RestRequest($"planets/{planet}/", DataFormat.Json);

            var resPlanet = await Client.GetAsync<Planet>(request);
            return resPlanet;
        }

        public async Task<User> GetUserById(int user)
        {
            var request = new RestRequest($"people/{user}/", DataFormat.Json);

            var resUser = await Client.GetAsync<User>(request);
            return resUser;
        }

        public async Task<User> GetUserByName(string userName)
        {
            var users = await GetAllUsers();

            return users.Find(u => u.name.ToLower() == userName.ToLower());
        }

        public void GetTest()
        {
            var request = new RestRequest("people/", DataFormat.Json);

            // NOTE: The Swreponse is a custom class which represents the data returned by the API, RestClient have buildin ORM which maps the data from the reponse into a given type of object
            var peopleResponse = Client.Get<People>(request);

            //Console.WriteLine(peopleResponse.Data.Count);
            //foreach (var p in peopleResponse.Data.Results)
            //{
            //    Console.WriteLine(p.Name);
            //}
        }
    }
}