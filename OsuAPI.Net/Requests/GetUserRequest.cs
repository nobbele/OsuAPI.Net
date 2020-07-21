using OsuAPI.Net.Models;
using System.Collections.Generic;

namespace OsuAPI.Net.Requests
{
    public class GetUserRequest : IAPIRequest<List<User>>
    {
        public string EndPoint => "get_user";

        private readonly string _username;
        private readonly int _userId;
        private readonly GameMode _mode;

        public GetUserRequest(string username, GameMode mode = GameMode.Osu)
        {
            _username = username;
            _mode = mode;
        }

        public GetUserRequest(int userId, GameMode mode = GameMode.Osu)
        {
            _userId = userId;
            _mode = mode;
        }

        public Dictionary<string, string> CreateParameters() => new Dictionary<string, string>()
        {
            { "u", _username != null ? _username : _userId.ToString() },
            { "type", _username != null ? "string" : "id" },
            { "m", ((int)_mode).ToString() },
        };
    }
}
