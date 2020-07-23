using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OsuAPI.Net.Models.V1
{
    public class UserBestScore
    {
        [JsonProperty("beatmap_id")]       public int BeatmapId { get; set; }
        [JsonProperty("score")]            public long TotalScore { get; set; }
        [JsonProperty("username")]         public string Username { get; set; }
        [JsonProperty("maxcombo")]         public int MaxCombo { get; set; }
        [JsonProperty("count300")]         public int Count300 { get; set; }
        [JsonProperty("count100")]         public int Count100 { get; set; }
        [JsonProperty("count50")]          public int Count50 { get; set; }
        [JsonProperty("countmiss")]        public int CountMiss { get; set; }
        [JsonProperty("countkatu")]        public int CountKatu { get; set; }
        [JsonProperty("countgeki")]        public int CountGeki { get; set; }
        [JsonConverter(typeof(BoolConverter))]
        [JsonProperty("perfect")]          public bool Perfect { get; set; }
        [JsonProperty("enabled_mods")]     public Mods EnabledMods { get; set; }
        [JsonProperty("user_id")]          public int UserId { get; set; }
        [JsonProperty("date")]             public DateTime Date { get; set; }
        [JsonProperty("rank")]             public string Rank { get; set; }
        [JsonProperty("pp")]               public double pp { get; set; }
        [JsonConverter(typeof(BoolConverter))]
        [JsonProperty("replay_available")] public bool ReplayAvailable { get; set; }
    }
}
