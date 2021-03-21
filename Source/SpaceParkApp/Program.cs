//using Newtonsoft.Json;
using System.Text.Json;
using RestSharp;
using SpaceParkApi.SWApi;
using SpaceParkApi.SWApiStore;
using System;
using Newtonsoft.Json;

namespace SpaceParkApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var swApi = new SWApi();
            swApi.GetAllPeople();
            var people = swApi.PeopleList;
            swApi.GetAllStarships();
            var starships = swApi.StarshipsList;
            swApi.GetAllPlanets();
            var planets = swApi.PlanetsList;
            Console.WriteLine("nice");
        }
    }
}