using SpaceParkApi;
using SpaceParkApi.DBContextModels;
using System;
using Xunit;

namespace SpaceParkTests
{
    public class UnitTests
    {
        [Fact]
        public async void WhenEnteringNonStarWarsUser_ExpectUserIdentityFalse()
        {
            var registrationController = new RegistrationController();
            var userExists = await registrationController.CheckUserIdentity("TestUserName");

            Assert.False(userExists);
        }

        [Fact]
        public async void WhenEnteringStarWarsUser_ExpectUserIdentityTrue()
        {
            var registrationController = new RegistrationController();
            var userExists = await registrationController.CheckUserIdentity("han solo");

            Assert.True(userExists);
        }

        [Fact]
        public async void WhenEnteringStarWarsUser_ExcpectUserBeAssignedObject()
        {
            var registrationController = new RegistrationController();
            var userExists = await registrationController.CheckUserIdentity("r2-d2");

            var user = registrationController.User;

            Assert.IsType<User>(user);

        }
    }
}
