﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestingApp
{
    internal class _User
    {
        public string name { get; set; }
    }

    internal class _Users
    {
        //[attribute mappning]
        public List<_User> users { get; set; }
    }
}