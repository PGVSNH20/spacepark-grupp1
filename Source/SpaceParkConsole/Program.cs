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
            Console.WriteLine("Welcome to SpacePark, please enter your name:");
            string name = Console.ReadLine();

            var swapi = new SWApi();
            var users = await swapi.GetAllUsers();

            foreach (var user in users)
            {
                if (name == user.name)
                {

                }
            }
            
            //Ange om det finns en pågående parkering

            //Ge val: starta ny/avsluta pågående/ändra pågående

            //Starta: ange spaceship, visa lediga platser, ange sluttid
            //Meddela: parkering startad, position, förväntad kostnad

            //Avsluta: ange spaceship
            //Meddela: slutpris, fakturaadress, betaldatum

            //Ändra: ange spaceship, ny sluttid
            //Meddela: parkering startad, position, förväntad kostnad

            
            //var usersList = swapi.GetAllStarShips();
            //var user = await swapi.GetUserById(1);
            Console.WriteLine("slut");
        }
    }
}