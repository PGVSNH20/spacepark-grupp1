using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceParkApi.DBContextModels
{
    public class User
    {
        public int UserId { get; set; }
        public string name { get; set; }
        public string homeworld { get; set; }
        public List<string> starships { get; set; }
        public List<int> starshipsId { get; set; }
    }
}
