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

        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            var request = new RestRequest("people/", DataFormat.Json);

            var peopleResponse = Client.Get<People>(request);

            users.AddRange(peopleResponse.Data.results);

            while (peopleResponse.Data.next != null)
            {
                var requestString = peopleResponse.Data.next.Replace("https://swapi.dev/api/", "");
                request = new RestRequest(requestString, DataFormat.Json);

                peopleResponse = Client.Get<People>(request);
                users.AddRange(peopleResponse.Data.results);
            }

            return users;
        }

        public List<Spaceship> GetAllStarShips()
        {
            var starships = new List<Spaceship>();

            var request = new RestRequest("starships/", DataFormat.Json);

            var starshipsResponse = Client.Get<StarShips>(request);

            starships.AddRange(starshipsResponse.Data.results);

            while (starshipsResponse.Data.next != null)
            {
                var requestString = starshipsResponse.Data.next.Replace("https://swapi.dev/api/", "");
                request = new RestRequest(requestString, DataFormat.Json);

                starshipsResponse = Client.Get<StarShips>(request);
                starships.AddRange(starshipsResponse.Data.results);
            }

            return starships;
        }

        public async Task<User> GetUserById(int user)
        {
            var request = new RestRequest($"people/{user}/", DataFormat.Json);

            var resUser = await Client.GetAsync<User>(request);
            return resUser;
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