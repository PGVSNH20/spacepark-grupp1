using Newtonsoft.Json;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceParkApp
{
    internal class _User
    {
        public string name { get; set; }
    }

    internal class _Users
    {
        //[SerializeAs(Name = "results")]
        [JsonProperty("results")]
        public List<_User> users { get; set; }
    }
}