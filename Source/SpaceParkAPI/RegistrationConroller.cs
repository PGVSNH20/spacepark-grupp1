using SpaceParkApi.DBContextModels;
using SpaceParkApi.SWApiStore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkApi
{
    public class RegistrationConroller
    {
        public async Task<User> CheckUserIdentity(string userName)
        {
            var swapi = new SWApi();
            var user = await swapi.GetUserByName(userName);
        }
    }
}