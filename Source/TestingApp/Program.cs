using RestSharp;
using System;
using System.Collections.Generic;

namespace TestingApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/", DataFormat.Json);
            // NOTE: The Swreponse is a custom class which represents the data returned by the API, RestClient have buildin ORM which maps the data from the reponse into a given type of object
            var peopleResponse = client.Get<Users>(request);

            //foreach(var user in )
            //Console.WriteLine(peopleResponse.Data.name);
            Console.ReadLine();
        }
    }
}