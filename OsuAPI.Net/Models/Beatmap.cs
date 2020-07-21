using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OsuAPI.Net.Models
{
    public class Beatmap
    {
        public string CoverImage => $"https://assets.ppy.sh/beatmaps/{BeatmapSetId}/covers/cover.jpg";
        public string CoverThumbnail => $"https://b.ppy.sh/thumb/{BeatmapSetId}l.jpg";

        [JsonProperty("approved")]         public Status Status { get; set; }
        [JsonProperty("approved_date")]    public DateTime? ApprovedDate { get; set; }
        [JsonProperty("last_update")]      public DateTime LastUpdate { get; set; }
        [JsonProperty("artist")]           public string Artist { get; set; }
        [JsonProperty("beatmap_id")]       public int BeatmapId { get; set; }
        [JsonProperty("beatmapset_id")]    public int BeatmapSetId { get; set; }
        [JsonProperty("bpm")]              public double Bpm { get; set; }
        [JsonProperty("creator")]          public string Creator { get; set; }
        [JsonProperty("difficultyrating")] public double DifficultyRating { get; set; }
        [JsonProperty("diff_size")]        public double CS { get; set; }
        [JsonProperty("diff_overall")]     public double OD { get; set; }
        [JsonProperty("diff_approach")]    public double AR { get; set; }
        [JsonProperty("diff_drain")]       public double HP { get; set; }
        [JsonProperty("hit_length")]       public int DrainLength { get; set; }
        [JsonProperty("source")]           public string Source { get; set; }
        [JsonProperty("genre_id")]         public Genre Genre { get; set; }
        [JsonProperty("language_id")]      public Language Language { get; set; }
        [JsonProperty("title")]            public string Title { get; set; }
        [JsonProperty("total_length")]     public int TotalLength { get; set; }
        [JsonProperty("version")]          public string Version { get; set; }
        [JsonProperty("file_md5")]         public string MD5 { get; set; }
        [JsonProperty("mode")]             public GameMode Mode { get; set; }
        [JsonProperty("tags")]             public string Tags { get; set; }
        [JsonProperty("favourite_count")]  public int FavoriteCount { get; set; }
        [JsonProperty("playcount")]        public int PlayCount { get; set; }
        [JsonProperty("passcount")]        public int PassCount { get; set; }
        [JsonProperty("max_combo")]        public int? MaxCombo { get; set; }
    }
}
