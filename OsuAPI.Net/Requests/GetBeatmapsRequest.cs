using OsuAPI.Net.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OsuAPI.Net.Requests
{
    public class GetBeatmapsRequest : IAPIRequest<List<Beatmap>>
    {
        public string EndPoint => "get_beatmaps";

        private readonly int? _beatmapSetId;
        private readonly int? _beatmapId;
        private readonly int _limit;
        private readonly Mods _mods;

        public GetBeatmapsRequest(int? beatmapId, int? beatmapSetId, Mods mods, int limit = 5)
        {
            _beatmapId = beatmapId;
            _beatmapSetId = beatmapSetId;
            _mods = mods;
            _limit = limit;
        }

        public Dictionary<string, string> CreateParameters() => new Dictionary<string, string>()
        {
            { "s", _beatmapSetId?.ToString() },
            { "b", _beatmapId?.ToString() },
            { "limit", _limit.ToString() },
            { "mods", ((int)_mods).ToString() }
        };
    }
}
