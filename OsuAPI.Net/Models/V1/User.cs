using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OsuAPI.Net.Models.V1
{
    public class User
    {
        [JsonIgnore]                      public string UserProfileImage => $"http://s.ppy.sh/a/{UserId}";

        [JsonProperty("user_id")]         public int UserId { get; set; }
        [JsonProperty("username")]        public string Username { get; set; }
        [JsonProperty("count300")]        public int Count300 { get; set; }
        [JsonProperty("count100")]        public int Count100 { get; set; }
        [JsonProperty("count50")]         public int Count50 { get; set; }
        [JsonProperty("playcount")]       public int PlayCount { get; set; }
        [JsonProperty("ranked_score")]    public long RankedScore { get; set; }
        [JsonProperty("total_score")]     public long TotalScore { get; set; }
        [JsonProperty("pp_rank")]         public int GlobalRank { get; set; }
        [JsonProperty("level")]           public double Level { get; set; }
        [JsonProperty("pp_raw")]          public double pp { get; set; }
        [JsonProperty("accuracy")]        public double Accuracy { get; set; }
        [JsonProperty("count_rank_ss")]   public int CountRankSS { get; set; }
        [JsonProperty("count_rank_s")]    public int CountRankS { get; set; }
        [JsonProperty("count_rank_a")]    public int CountRankA { get; set; }
        [JsonProperty("country")]         public string Country { get; set; }
        [JsonProperty("pp_country_rank")] public int CountryRank { get; set; }
        [JsonProperty("events")]          public List<Event> Events { get; set; }
    }
}
