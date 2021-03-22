using RestSharp;
using SpaceParkApi.SWApiStore;
using System;

namespace SpaceParkConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var swapi = new SWApi();
            var usersList = swapi.GetAllStarShips();
            Console.WriteLine("slut");
        }
    }
}