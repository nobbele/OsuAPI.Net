using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OsuAPI.Net.Models.V1
{
    public class MatchMetadata
    {
        [JsonProperty("match_id")]   public long MatchId { get; set; }
        [JsonProperty("name")]       public string Name { get; set; }
        [JsonProperty("start_time")] public DateTime StartTime { get; set; }
        [JsonProperty("end_time")]   public DateTime? EndTime { get; set; }
    }
}
