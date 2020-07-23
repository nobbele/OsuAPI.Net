using Newtonsoft.Json;
using OsuAPI.Net.Requests.V1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OsuAPI.Net
{
    public class APIV1Client
    {
        public string BaseHost => "osu.ppy.sh";

        private readonly string _token;

        public APIV1Client(string token)
        {
            _token = token;
        }

        public async Task<T> QueryAsync<T>(IAPIV1Request<T> request) where T : class
        {
            var parameters = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("k", _token) };

            var requestParameters = request.CreateParameters();
            parameters.AddRange(requestParameters.Where(p => p.Value != null));

            var builder = new UriBuilder
            {
                Scheme = "https",
                Host = BaseHost,
                Path = $"api/{request.EndPoint}",
                Query = string.Join("&", parameters.Select(pair => $"{pair.Key}={pair.Value}"))
            };

            using var http = new HttpClient();
            using var stream = await http.GetStreamAsync(builder.Uri);
            using StreamReader sr = new StreamReader(stream);
            using JsonReader reader = new JsonTextReader(sr);

            JsonSerializer serializer = new JsonSerializer();

            return serializer.Deserialize<T>(reader);
        }
    }
}
