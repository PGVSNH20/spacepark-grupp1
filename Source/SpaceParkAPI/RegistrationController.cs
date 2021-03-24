using SpaceParkApi.DBContextModels;
using SpaceParkApi.Models;
using SpaceParkApi.SWApiStore;
using System;
using System.Collections.Generic;
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

        public void AddParkingRegistration(string parkingTime)
        {
            ParkingRegistration parkingRegistration = new ParkingRegistration();
            parkingRegistration.ParkingStartTime = DateTime.Now;
            DateTime endTime = DateTime.Now + TimeSpan.Parse(parkingTime);
        }

        public async Task<Spaceship> GetStarshiptById(int starshipId)
        {
            return await swApi.GetStarshiptById(starshipId);
        }
    }
}