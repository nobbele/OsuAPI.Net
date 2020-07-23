using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OsuAPI.Net.Requests.V2
{
    public abstract class IAPIV2GetRequest<T> : IAPIV2Request<T>
    {
        public abstract string CreateEndPoint();

        public abstract Dictionary<string, string> CreateParameters();

        public async Task<Stream> QueryAsync(HttpClient client)
        {
            var endpoint = CreateEndPoint();
            var parameters = CreateParameters();

            var url = $"{endpoint}?{string.Join("&", parameters.Select(pair => $"{pair.Key}={pair.Value}"))}";

            return await client.GetStreamAsync(url);
        }
    }
}
