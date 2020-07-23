using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OsuAPI.Net.Models.V1
{
    public class Match
    {
        [JsonProperty("match")] public MatchMetadata Metadata { get; set; }
        [JsonProperty("games")] public List<MatchGame> Games { get; set; }
    }
}
