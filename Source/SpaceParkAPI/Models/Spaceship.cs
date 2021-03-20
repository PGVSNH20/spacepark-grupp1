using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceParkApi.Models
{
    public class Spaceship
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }
    }
}