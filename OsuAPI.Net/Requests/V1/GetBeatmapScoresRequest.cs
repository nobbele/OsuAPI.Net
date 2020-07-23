using OsuAPI.Net.Models.V1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OsuAPI.Net.Requests.V1
{
    public class GetBeatmapScoresRequest : IAPIV1Request<List<BeatmapScore>>
    {
        public string EndPoint => "get_scores";

        private readonly int _beatmapId;
        private readonly Mods _mods;
        private readonly GameMode _mode;
        private readonly int _limit;

        public GetBeatmapScoresRequest(int beatmapId, Mods mods, GameMode mode = GameMode.Osu, int limit = 50)
        {
            _beatmapId = beatmapId;
            _mods = mods;
            _mode = mode;
            _limit = limit;
        }

        public Dictionary<string, string> CreateParameters() => new Dictionary<string, string>
        {
            { "b", _beatmapId.ToString() },
            { "m", ((int)_mode).ToString() },
            { "mods", ((int)_mods).ToString() },
            { "limit", _limit.ToString() },
        };
    }
}
