using Newtonsoft.Json;

namespace OsuAPI.Net.Models.V2
{
    public class UserStatisticsLevel
    {
        [JsonProperty("current")] public int Current { get; set; }
        [JsonProperty("progress")] public int Progress { get; set; }
    }
}
