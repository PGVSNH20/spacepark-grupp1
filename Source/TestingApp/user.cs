using System;
using System.Collections.Generic;
using System.Text;

namespace TestingApp
{
    internal class User
    {
        public string name { get; set; }
    }

    internal class Users
    {
        //[attribute mappning]
        public List<User> users { get; set; }
    }
}