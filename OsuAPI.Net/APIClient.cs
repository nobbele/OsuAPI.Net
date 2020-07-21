using OsuAPI.Net.Requests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OsuAPI.Net
{
    public class APIClient
    {
        public string BaseHost => "osu.ppy.sh";

        private readonly string _token;

        public APIClient(string token)
        {
            _token = token;
        }

        public async Task<T> QueryAsync<T>(IAPIRequest<T> request) where T : class
        {
            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("k", _token) });
            return await request.QueryAsync(this, new Dictionary<string, string> { { "k", _token } });
        }
    }
}
