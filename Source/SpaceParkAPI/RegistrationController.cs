using SpaceParkApi.DBContextModels;
using SpaceParkApi.Models;
using SpaceParkApi.SWApiStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkApi
{
    public class RegistrationController
    {
        public User User { get; set; }
        private SWApi swApi { get; set; }

        public RegistrationController()
        {
            swApi = new SWApi();
        }

        public async Task<bool> CheckUserIdentity(string userName)
        {
            User = await swApi.GetUserByName(userName);

            if (User == null) return false;

            return true;
        }

        public void AddParkingRegistration(string parkingTime, string spaceship)
        {
            ParkingRegistration parkingRegistration = new ParkingRegistration();
            parkingRegistration.ParkingStartTime = DateTime.Now;
            parkingRegistration.ParkingEndTime = DateTime.Now + TimeSpan.Parse(parkingTime);
            
            parkingRegistration.ParkingFee = Convert.ToDecimal(TimeSpan.Parse(parkingTime).TotalHours * 50);
            parkingRegistration.IsPaid = false;
            parkingRegistration.ParkingSpot = new ParkingSpot();
            parkingRegistration.SpaceShipName = spaceship;

            var db = new SpaceParkDbContext();

            try
            {

                var userEntity = db.Users.Where(u => u.name == User.name).Single();
                parkingRegistration.User = userEntity;
            }
            catch
            {
                parkingRegistration.User = User;
            }

            db.Add(parkingRegistration);
            db.SaveChanges();
        }

        public async Task<Spaceship> GetStarshiptById(int starshipId)
        {
            return await swApi.GetStarshiptById(starshipId);
        }

        public void UpdateParkingRegistration(string newTime)
        {
            var db = new SpaceParkDbContext();
            var userEntity = db.Users.Where(u => u.name == User.name).Single();
            var parkingRegistrationEntity = db.ParkingRegistrations.Where(p => p.User == userEntity).Single();
            var newEndTime = parkingRegistrationEntity.ParkingEndTime + TimeSpan.Parse(newTime);
            if (newEndTime < DateTime.Now)
                parkingRegistrationEntity.ParkingEndTime = DateTime.Now;
            else
                parkingRegistrationEntity.ParkingEndTime += TimeSpan.Parse(newTime);

            db.Update(parkingRegistrationEntity);
            db.SaveChanges();
        }
    }
}