using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OsuAPI.Net.Models
{
    public class MatchScore
    {
        [JsonProperty("slot")]      public int Slot { get; set; }
        [JsonProperty("team")]      public Team Team { get; set; }
        [JsonProperty("score")]     public int Score { get; set; }
        [JsonProperty("maxcombo")]  public int MaxCombo { get; set; }
        [JsonProperty("count50")]   public int Count50 { get; set; }
        [JsonProperty("count100")]  public int Count100 { get; set; }
        [JsonProperty("count300")]  public int Count300 { get; set; }
        [JsonProperty("countmiss")] public int CountMiss { get; set; }
        [JsonProperty("countgeki")] public int CountGeki { get; set; }
        [JsonProperty("countkatu")] public int CountKatu { get; set; }
        [JsonConverter(typeof(BoolConverter))]
        [JsonProperty("perfect")]   public bool Perfect { get; set; }
        [JsonConverter(typeof(BoolConverter))]
        [JsonProperty("pass")]      public bool Pass { get; set; }
    }
}
