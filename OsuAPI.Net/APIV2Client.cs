using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OsuAPI.Net.Requests.V2;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OsuAPI.Net
{
    public class APIV2Client
    {
        private string _token;

        public APIV2Client(string access_token)
        {
            _token = access_token;
        }

        private static readonly string _httpListeningUrl = "http://localhost:9191/";

        public class AuthenticationStep
        {
            internal int client_id;
            internal int number;
            internal HttpListener listener;
            public string Link { get; internal set; }
        }

        public static AuthenticationStep StartAuthentication(int client_id)
        {
            var number = new Random().Next();

            var authLink = new UriBuilder(
                "https",
                "osu.ppy.sh",
                443,
                "oauth/authorize",
                $"?client_id={client_id}&redirect_uri={_httpListeningUrl}&response_type=code&scope=public&state={number}"
            ).Uri;

            var stepResult = new AuthenticationStep
            {
                client_id = client_id,
                number = number,
                listener = new HttpListener(),
                Link = authLink.ToString(),
            };
            stepResult.listener.Prefixes.Add(_httpListeningUrl);
            stepResult.listener.Start();

            return stepResult;
        }

        public static async Task<APIV2Token> FinalizeAuthenticationAsync(string client_secret, AuthenticationStep step)
        {
            var context = await step.listener.GetContextAsync();
            var request = context.Request;
            var response = context.Response;

            string responseString = "<html><body>You may now close this tab, go back to the application</body></html>";
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            var code = request.QueryString["code"];
            var state = request.QueryString["state"];

            if (state != step.number.ToString())
                throw new Exception("Got the wrong state from the authentication");

            using var http = new HttpClient
            {
                BaseAddress = new Uri("https://osu.ppy.sh")
            };

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "/oauth/token");

            var postParam = new Dictionary<string, string>()
                        {
                            { "client_id", "1950" },
                            { "client_secret", client_secret },
                            { "code", code },
                            { "grant_type", "authorization_code" },
                            { "redirect_uri", _httpListeningUrl }
                        };

            httpRequest.Content = new FormUrlEncodedContent(postParam);

            var httpResponse = await http.SendAsync(httpRequest);
            var stream = await httpResponse.Content.ReadAsStreamAsync();

            using StreamReader sr = new StreamReader(stream);
            using JsonReader reader = new JsonTextReader(sr);

            var obj = await JToken.ReadFromAsync(reader);

            if (obj["token_type"].Value<string>() != "Bearer")
                throw new Exception("Invalid token type");

            var token = new APIV2Token()
            {
                ExpiryDate = DateTime.Now.AddSeconds(obj["expires_in"].Value<int>()),
                AccessToken = obj["access_token"].Value<string>(),
                RefreshToken = obj["refresh_token"].Value<string>()
            };

            return token;
        }

        public async Task<T> QueryAsync<T>(IAPIV2Request<T> request) where T : class
        {
            if (_token == null)
                throw new Exception("Unauthorized client, please call PerformAuthenticationAsync or the constructor with a valid access key");

            var httpClient = new HttpClient
            {
                BaseAddress = new UriBuilder("https", "osu.ppy.sh", 443, "/api/v2/").Uri
            };
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");

            using var stream = await request.QueryAsync(httpClient);
            using StreamReader sr = new StreamReader(stream);

            // Temporary to view the api content
            string content = sr.ReadToEnd();
            using JsonReader reader = new JsonTextReader(new StringReader(content));

            //using JsonReader reader = new JsonTextReader(sr);

            JsonSerializer serializer = new JsonSerializer();

            return serializer.Deserialize<T>(reader);
        }
    }
}
