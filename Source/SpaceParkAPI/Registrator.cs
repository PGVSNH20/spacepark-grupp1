using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SpaceParkApi.Models;
using SpaceParkApi.SWApiStore;
using SpaceParkAPI.DbContextModels;

namespace SpaceParkApi
{
    public class Registrator
    {
        public User User { get; set; }
        public Starship Starship { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public bool UserChecker(string userName)
        {
            var swApi = new SWApi();
            swApi.GetAllPeople();
            var people = swApi.PeopleList;
            //var dpUserReg = new List<User>();
            //using (var db = new SpaceParkDbContext())
            //{
            //    dpUserReg = db.Users.Where(u => u.Name == userName).ToList();
            //}
            //if (dpUserReg.Count > 0)
            //    User = dpUserReg[0];
            //else
            //    User = people.Find(u => u.Name == userName);
            User = people.Find(u => u.Name == userName);
            if (User == null)
                return false;
            return true;
        }

        public List<Starship> GetUserStarships()
        {
            var userShips = new List<Starship>();
            var swApi = new SWApi();
            foreach (var starshipId in User.StarshipsId)
            {
                var starship = swApi.GetStarshipById(starshipId);
                userShips.Add(starship);
            }
            return userShips;
        }

        public Registrator SetCurrentStarship(int starshipId)
        {
            var swApi = new SWApi();
            Starship = swApi.GetStarshipById(starshipId);
            return this;
        }

        public void AddNewRegistration(string parkingTime)
        {
            var newRegistration = new ParkingRegistration();
            newRegistration.ParkingRegistrationId = new Guid();
            newRegistration.User = User;
            newRegistration.ParkingSpot = new ParkingSpot();
            newRegistration.StarshipId = Starship.Id;
            StartTime = DateTime.Now;
            newRegistration.StartTime = StartTime;
            EndTime = StartTime + TimeSpan.Parse(parkingTime);
            newRegistration.EndTime = EndTime;
            newRegistration.ParkingFee = Convert.ToDecimal((EndTime - StartTime).TotalHours) * 45;

            using (var db = new SpaceParkDbContext())
            {
                db.Add(newRegistration);
                db.SaveChanges();
            }
        }

        public void TruncateAll()
        {
            using (var db = new SpaceParkDbContext())
            {
                db.Database.ExecuteSqlRaw("DELETE FROM ParkingRegistrations");

                db.SaveChanges();
            }
            using (var db = new SpaceParkDbContext())
            {
                db.Database.ExecuteSqlRaw("DELETE FROM Users");
                db.Database.ExecuteSqlRaw("DELETE FROM ParkingSpots");

                db.SaveChanges();
            }
        }
    }
}