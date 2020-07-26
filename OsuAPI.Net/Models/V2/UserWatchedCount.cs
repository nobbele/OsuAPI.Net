using Newtonsoft.Json;
using System;

namespace OsuAPI.Net.Models.V2
{
    public class UserWatchedCount
    {
        [JsonProperty("start_date")] public DateTime StartDate { get; set; }
        [JsonProperty("count")] public int Count { get; set; }
    }
}
