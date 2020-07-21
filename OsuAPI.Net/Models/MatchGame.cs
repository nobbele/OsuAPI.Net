using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OsuAPI.Net.Models
{
    public class MatchGame
    {
        [JsonProperty("game_id")]      public long GameId { get; set; }
        [JsonProperty("start_time")]   public DateTime StartTime { get; set; }
        [JsonProperty("end_time")]     public DateTime? EndTime { get; set; }
        [JsonProperty("beatmap_id")]   public int BeatmapId { get; set; }
        [JsonProperty("play_mode")]    public GameMode Mode { get; set; }
        [JsonProperty("match_type")]   public int MatchType { get; set; }
        [JsonProperty("scoring_type")] public ScoringType ScoringType { get; set; }
        [JsonProperty("team_type")]    public TeamType TeamType { get; set; }
        [JsonProperty("mods")]         public Mods Mods { get; set; }
        [JsonProperty("scores")]       public List<MatchScore> Scores { get; set; }
    }
}
