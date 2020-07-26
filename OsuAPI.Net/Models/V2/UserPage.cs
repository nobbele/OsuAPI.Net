using Newtonsoft.Json;

namespace OsuAPI.Net.Models.V2
{
    public class UserPage
    {
        [JsonProperty("html")] public string Html { get; set; }
        [JsonProperty("raw")] public string Raw { get; set; }
    }
}
