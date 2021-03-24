using RestSharp;
using SpaceParkApi;
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
            string userName = Console.ReadLine();
            var registrationController = new RegistrationController();
            var userExists = await registrationController.CheckUserIdentity(userName);

            if (userExists)
            {
                var user = registrationController.User;
                foreach(var id in user.starshipsId)
                {
                    Console.WriteLine(id);
                }
                Console.WriteLine($"Welcome {user.name}!");
            }
            else
            {
                Console.WriteLine("User not found! Try again!");
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