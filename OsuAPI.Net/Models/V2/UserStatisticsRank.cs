using Newtonsoft.Json;

namespace OsuAPI.Net.Models.V2
{
    public class UserStatisticsRank
    {
        [JsonProperty("global")] public int Global { get; set; }
        [JsonProperty("country")] public int Country { get; set; }
    }
}
