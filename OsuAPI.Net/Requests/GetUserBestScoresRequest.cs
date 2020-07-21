using OsuAPI.Net.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OsuAPI.Net.Requests
{
    public class GetUserBestScoresRequest : IAPIRequest<List<UserBestScore>>
    {
        public string EndPoint => "get_user_best";

        private readonly string _username;
        private readonly int _userId;
        private readonly GameMode _mode;
        private readonly int _limit;

        public GetUserBestScoresRequest(string username, GameMode mode = GameMode.Osu, int limit = 5)
        {
            _username = username;
            _mode = mode;
            _limit = limit;
        }

        public GetUserBestScoresRequest(int userId, GameMode mode = GameMode.Osu, int limit = 5)
        {
            _userId = userId;
            _mode = mode;
            _limit = limit;
        }

        public Dictionary<string, string> CreateParameters() => new Dictionary<string, string>()
        {
            { "u", _username != null ? _username : _userId.ToString() },
            { "type", _username != null ? "string" : "id" },
            { "m", ((int)_mode).ToString() },
            { "limit", _limit.ToString() }
        };
    }
}
