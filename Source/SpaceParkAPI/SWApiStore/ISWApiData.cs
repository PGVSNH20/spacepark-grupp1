using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceParkApi.SWApiStore
{
    public interface ISWApiData<T>
    {
        [JsonProperty("results")]
        public List<T> Results { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}