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
        public async Task<bool> CheckUserIdentity(string userName)
        {
            var swapi = new SWApi();
            var user = await swapi.GetUserByName(userName);

            if (user == null) return false;

            return true;
        }
    }
}