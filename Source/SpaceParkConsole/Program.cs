using RestSharp;
using SpaceParkApi;
using SpaceParkApi.Models;
using SpaceParkApi.SWApiStore;
using System;
using System.Collections.Generic;
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
                Console.WriteLine($"Welcome {user.name}!");
                //if (UserHasActiveParking(user))
                //{
                //    ...
                //}

                Console.WriteLine("Chose spaceship to park:");

                var spaceshipOpions = new List<Spaceship>();
                foreach (var id in user.starshipsId)
                {
                    var spaceship = await registrationController.GetStarshiptById(id);
                    spaceshipOpions.Add(spaceship);
                    Console.WriteLine($"{spaceshipOpions.Count}: {spaceship.name}");
                }
                string chosenSpaceship = Console.ReadLine();
                Console.WriteLine($"You chose {spaceshipOpions[Convert.ToInt32(chosenSpaceship) - 1].name}");

                registrationController.AddParkingRegistration("10:00:00", spaceshipOpions[Convert.ToInt32(chosenSpaceship) - 1].name);






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