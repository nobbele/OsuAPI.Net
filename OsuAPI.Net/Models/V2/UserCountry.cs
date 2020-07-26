using Newtonsoft.Json;

namespace OsuAPI.Net.Models.V2
{
    public class UserCountry
    {
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
    }
}
