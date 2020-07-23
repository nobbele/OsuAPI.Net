using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OsuAPI.Net.Requests.V2
{
    public abstract class IAPIV2PostRequest<T> : IAPIV2Request<T>
    {
        public abstract string CreateEndPoint();

        public abstract Dictionary<string, string> CreateParameters();

        public async Task<Stream> QueryAsync(HttpClient client)
        {
            return null;
        }
    }
}
