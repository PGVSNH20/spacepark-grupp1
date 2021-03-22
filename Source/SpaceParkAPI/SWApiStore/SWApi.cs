using RestSharp;
using SpaceParkApi.DBContextModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceParkApi.SWApiStore
{
    internal class SWApi
    {
        public void GetTest()
        {
            var client = new RestClient("https://swapi.dev/api/");

            var request = new RestRequest("people/", DataFormat.Json);

            // NOTE: The Swreponse is a custom class which represents the data returned by the API, RestClient have buildin ORM which maps the data from the reponse into a given type of object
            var peopleResponse = client.Get<User>(request);

            Console.WriteLine(peopleResponse.Data.Count);
            foreach (var p in peopleResponse.Data.Results)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}