using Newtonsoft.Json;

namespace OsuAPI.Net.Models.V2
{
    public class UserKudosu
    {
        [JsonProperty("total")] public int Total { get; set; }
        [JsonProperty("available")] public int Available { get; set; }
    }
}
