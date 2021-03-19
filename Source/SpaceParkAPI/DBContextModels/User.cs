using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceParkApi.DBContextModels
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string HomeWorld { get; set; }
    }
}
