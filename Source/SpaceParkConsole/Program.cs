using RestSharp;
using SpaceParkApi.SWApiStore;
using System;
using System.Threading.Tasks;

namespace SpaceParkConsole
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var swapi = new SWApi();
            //var usersList = swapi.GetAllStarShips();
            var user = await swapi.GetUserById(1);
            Console.WriteLine("slut");
        }
    }
}