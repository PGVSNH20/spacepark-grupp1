using RestSharp;
using SpaceParkAPI.DbContextModels;
using System;

namespace SpaceParkApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/", DataFormat.Json);
            // NOTE: The Swreponse is a custom class which represents the data returned by the API, RestClient have buildin ORM which maps the data from the reponse into a given type of object
            var peopleResponse = client.Get<_Users>(request);

            //foreach(var user in )
            //Console.WriteLine(peopleResponse.Data.name);

            var newUser = new User();
            newUser.Name = "edgar";
            using (var db = new SpaceParkDbContext())
            {
                db.Add(newUser);
                db.SaveChanges();
            }

            Console.ReadLine();
        }
    }
}