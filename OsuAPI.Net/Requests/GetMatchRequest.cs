using OsuAPI.Net.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OsuAPI.Net.Requests
{
    public class GetMatchRequest : IAPIRequest<Match>
    {
        public string EndPoint => "get_match";

        private readonly string _matchId;

        public GetMatchRequest(string matchId)
        {
            _matchId = matchId;
        }

        public Dictionary<string, string> CreateParameters() => new Dictionary<string, string>()
        {
            { "mp", _matchId.ToString() }
        };
    }
}
