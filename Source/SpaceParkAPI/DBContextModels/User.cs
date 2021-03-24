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
        public List<int> starshipsId {
            get {
                    return AddStarshipIds();
                }
            set { } 
        }

        public List<int> AddStarshipIds()
        {
            List<int> ids = new List<int>();
            foreach (var starship in starships)
            {
                string[] values = starship.Split('/');
                int.TryParse(values[5], out int result);
                ids.Add(result);
            }
            return ids;

        }
    }
}
