using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OsuAPI.Net.Models
{
    public class BeatmapScore
    {
        [JsonProperty("score_id")]         public long ScoreId { get; set; }
        [JsonProperty("score")]            public int Score { get; set; }
        [JsonProperty("username")]         public string Username { get; set; }
        [JsonProperty("count300")]         public int Count300 { get; set; }
        [JsonProperty("count100")]         public int Count100 { get; set; }
        [JsonProperty("count50")]          public int Count50 { get; set; }
        [JsonProperty("countmiss")]        public int CountMiss { get; set; }
        [JsonProperty("maxcombo")]         public int MaxCombo { get; set; }
        [JsonProperty("countkatu")]        public int CountKatu { get; set; }
        [JsonProperty("countgeki")]        public int CountGeki { get; set; }
        [JsonConverter(typeof(BoolConverter))]
        [JsonProperty("perfect")]          public bool Perfect { get; set; }
        [JsonProperty("enabled_mods")]     public Mods Mods { get; set; }
        [JsonProperty("user_id")]          public long UserId { get; set; }
        [JsonProperty("rank")]             public string Rank { get; set; }
        [JsonProperty("pp")]               public float pp { get; set; }
        [JsonConverter(typeof(BoolConverter))]
        [JsonProperty("replay_available")] public bool ReplayAvailable { get; set; }
    }
}
