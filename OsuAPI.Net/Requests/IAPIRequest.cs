using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OsuAPI.Net.Requests
{
    public interface IAPIRequest<T> where T : class
    {
        string EndPoint { get; }
        // Do not access multiple times, cache if needed
        Dictionary<string, string> CreateParameters();

        async Task<T> QueryAsync(APIClient client, Dictionary<string, string> parameters)
        {
            using var http = new HttpClient();

            var requestParameters = CreateParameters();
            foreach (var pair in requestParameters)
            {
                if (pair.Value != null)
                    parameters.Add(pair.Key, pair.Value);
            }

            var builder = new UriBuilder
            {
                Scheme = "https",
                Host = client.BaseHost,
                Path = $"api/{EndPoint}",
                Query = string.Join("&", parameters.Select(pair => $"{pair.Key}={pair.Value}"))
            };

            using var stream = await http.GetStreamAsync(builder.Uri);
            using StreamReader sr = new StreamReader(stream);
            using JsonReader reader = new JsonTextReader(sr);

            JsonSerializer serializer = new JsonSerializer();

            return serializer.Deserialize<T>(reader);
        }
    }
}
