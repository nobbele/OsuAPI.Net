using System;
using System.Collections.Generic;
using System.Text;

namespace OsuAPI.Net
{
    public class APIV2Token
    {
        public DateTime ExpiryDate { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
