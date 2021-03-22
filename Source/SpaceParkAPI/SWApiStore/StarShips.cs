using SpaceParkApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceParkApi.SWApiStore
{
    class StarShips
    {
        public List<Spaceship> results { get; set; }
        public string next { get; set; }
    }
}
