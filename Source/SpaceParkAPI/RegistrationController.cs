using SpaceParkApi.DBContextModels;
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
        public async Task<bool> CheckUserIdentity(string userName)
        {
            var swapi = new SWApi();
            User = await swapi.GetUserByName(userName);

            if (User == null) return false;

            return true;
        }
    }
}