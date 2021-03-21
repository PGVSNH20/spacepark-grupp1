using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceParkApi.Models
{
    public class Starship
    {
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("length")]
        public string Length { get; set; }
    }
}