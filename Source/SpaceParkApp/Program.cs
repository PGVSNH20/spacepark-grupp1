//using Newtonsoft.Json;
using System.Text.Json;
using RestSharp;
using SpaceParkApi.SWApiStore;
using System;
using Newtonsoft.Json;
using SpaceParkApi;

namespace SpaceParkApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var swApi = new SWApi();
            //swApi.GetAllPeople();
            //var people = swApi.PeopleList;
            //swApi.GetAllStarships();
            //var starships = swApi.StarshipsList;
            //swApi.GetAllPlanets();
            //var planets = swApi.PlanetsList;

            var registrator = new Registrator();
            //registrator.TruncateAll();
            var isAuthorised = registrator.UserChecker("Luke Skywalker");
            var acutallUser = registrator.User;
            var userStarships = registrator.GetUserStarships();
            registrator.SetCurrentStarship(12).AddNewRegistration("7:23");
            Console.WriteLine("nice");
        }
    }
}