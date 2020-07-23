using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OsuAPI.Net.Requests.V1
{
    public interface IAPIV1Request<T>
    {
        string EndPoint { get; }
        Dictionary<string, string> CreateParameters();
    }
}
