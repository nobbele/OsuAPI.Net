using Newtonsoft.Json;

namespace OsuAPI.Net.Models.V2
{
    public class UserRankHistory
    {
        [JsonProperty("mode")] public string Mode { get; set; }
        [JsonProperty("data")] public int[] Data { get; set; }
    }
}
