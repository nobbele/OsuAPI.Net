using Newtonsoft.Json;
using System;

namespace OsuAPI.Net.Models.V2
{
    public class UserAchievement
    {
        [JsonProperty("achieved_at")] public DateTime AchievedAt { get; set; }
        [JsonProperty("achievement_id")] public int AchievementId { get; set; }
    }
}
