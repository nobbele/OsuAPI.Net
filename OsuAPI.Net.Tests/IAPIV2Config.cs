using System;
using System.Collections.Generic;
using System.Text;

namespace OsuAPI.Net.Tests
{
    public interface IAPIV2Config
    {
        int? ClientId { get; }
        string ClientSecret { get; }

        APIV2Token Token { get; set; }
    }
}
