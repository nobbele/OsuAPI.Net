using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OsuAPI.Net.Requests.V2
{
    public interface IAPIV2Request<T>
    {
        string CreateEndPoint();
        Dictionary<string, string> CreateParameters();

        Task<Stream> QueryAsync(HttpClient client);
    }
}
