using OsuAPI.Net.Models.V2;
using System;
using System.Collections.Generic;
using System.Text;

namespace OsuAPI.Net.Requests.V2
{
    public class GetUserRequest : IAPIV2GetRequest<User>
    {
        private int _userId;

        public GetUserRequest(int userId)
        {
            _userId = userId;
        }

        public override string CreateEndPoint() => $"users/{_userId}";

        public override Dictionary<string, string> CreateParameters() => new Dictionary<string, string>()
        {

        };
    }
}
