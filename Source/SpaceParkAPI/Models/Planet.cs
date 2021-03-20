using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceParkApi.Models
{
    public class Planet
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}