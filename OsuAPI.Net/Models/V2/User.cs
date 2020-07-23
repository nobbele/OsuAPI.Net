using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OsuAPI.Net.Models.V2
{
    public class User
    {
        [JsonProperty("username")] public string Username { get; set; }
    }
}
