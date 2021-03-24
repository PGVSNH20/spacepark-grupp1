using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceParkApi.DBContextModels
{
    public class User
    {
        public int Id
        { get
            {
                return int.Parse(url.Split('/')[5]);
            }
          set { } 
        }

        public string url { get; set; }
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
