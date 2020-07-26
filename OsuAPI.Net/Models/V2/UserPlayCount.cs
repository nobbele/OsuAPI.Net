using Newtonsoft.Json;
using System;

namespace OsuAPI.Net.Models.V2
{
    public class UserPlayCount
    {
        [JsonProperty("start_date")] public DateTime StartDate { get; set; }
        [JsonProperty("count")] public int Count { get; set; }
    }
}
