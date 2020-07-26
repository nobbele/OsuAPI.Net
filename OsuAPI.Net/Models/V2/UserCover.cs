using Newtonsoft.Json;

namespace OsuAPI.Net.Models.V2
{
    public class UserCover
    {
        [JsonProperty("custom_url")] public string CustomUrl { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
        [JsonProperty("id")] public int? Id { get; set; }
    }
}
