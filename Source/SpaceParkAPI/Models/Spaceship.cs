using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceParkApi.Models
{
    public class Spaceship
    {
        [JsonProperty("name")]
        public string ShipName { get; set; }

        [JsonProperty("lenght")]
        public string Lenght { get; set; }
    }
}