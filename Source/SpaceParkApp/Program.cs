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
            var foo = new SWApi();
            foo.GetAllPeople();
            var people = foo.PeopleList;
            foo.GetAllStarships();
            var starships = foo.StarshipsList;
            Console.WriteLine("nice");
            Console.WriteLine("nice");
        }
    }
}