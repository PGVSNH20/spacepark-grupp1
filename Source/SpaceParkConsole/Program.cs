using SpaceParkApi;
using SpaceParkApi.Models;
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
                if (registrationController.UserHasActiveParking())
                {
                    Console.WriteLine($"You have an ongoing parking with end time {registrationController.ActiveParking.ParkingEndTime}.\n1: Change time\n2: End parking");
                    var choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        Console.WriteLine("Enter timespan to extend (hh:mm:ss) or shorten (-hh:mm:ss) parking");
                        registrationController.UpdateParkingRegistration(Console.ReadLine());
                    }
                    if (choice == 2)
                    {
                        registrationController.EndParkingRegistration();
                        Console.WriteLine($"Your parking is now ended. Parking fee is {registrationController.ActiveParking.ParkingFee} galactic credits");
                    }
                }
                else
                {
                    if(registrationController.FreeSpotsExists())
                    {

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
                        Console.WriteLine("Enter timespan (hh:mm:ss) to confirm parking length");

                        registrationController.AddParkingRegistration(Console.ReadLine(), spaceshipOpions[Convert.ToInt32(chosenSpaceship) - 1].name);
                    }
                    else
                    {
                        Console.WriteLine("No parking spots are available");
                    }

                }
            }
            else
            {
                Console.WriteLine("User not found! Try again!");
            }

            // KLAR: Ange om det finns en pågående parkering

            // KLAR: Ge val: starta ny/avsluta pågående/ändra pågående

            // Starta:
            // KLAR ange spaceship,
            // ATTGÖRA visa lediga platser,
            // KLAR ange sluttid

            //Meddela:
            // KLAR parkering startad,
            // ATTGÖRA position,
            // ATTGÖRA förväntad kostnad

            //Avsluta:
            // ATTGÖRA ange spaceship
            // Meddela:
            // KLAR slutpris,
            // ATTGÖRA fakturaadress,
            // ATTGÖRA betaldatum

            //Ändra:
            // ATTGÖRA ange spaceship,
            // KLAR ny sluttid

            //Meddela:
            // ATTGÖRA parkering startad,
            // ATTGÖRA position,
            // ATTGÖRA förväntad kostnad

            //var usersList = swapi.GetAllStarShips();
            //var user = await swapi.GetUserById(1);
            Console.WriteLine("slut");
        }
    }
}