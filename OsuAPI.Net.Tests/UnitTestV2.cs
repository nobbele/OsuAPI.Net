using ConfigNet;
using ConfigNet.Stores;
using OsuAPI.Net.Requests.V2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OsuAPI.Net.Tests
{
    public class UnitTestV2
    {
        APIV2Client apiClient;

        public UnitTestV2()
        {
            var config = new ConfigurationBuilder<IAPIV2Config>()
                .AddStore(new JsonStore("apiV2config.json"))
                .Build();

            if (config.Token == null || config.Token.AccessToken == null)
            {
                if (config.ClientId == null || config.ClientSecret == null)
                    throw new Exception("Put your client id and secret in the apiV2config.json file");
                var step = APIV2Client.StartAuthentication(config.ClientId.Value);
                Console.WriteLine($"Open {step.Link} in your browser");

                Process myProcess = new Process();
                try
                {
                    myProcess.StartInfo.UseShellExecute = true;
                    myProcess.StartInfo.FileName = step.Link;
                    myProcess.Start();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                var midStep = APIV2Client.RegisterAuthenticationAsync(step).Result;
                config.Token = APIV2Client.FinalizeAuthenticationAsync(config.ClientSecret, step, midStep).Result;
            }

            apiClient = new APIV2Client(config.Token.AccessToken);
        }

        [Fact]
        public async Task TestGetUser()
        {
            var user = await apiClient.QueryAsync(new GetUserRequest(10006423));


            Assert.Equal("nobbele", user.Username);
        }
    }
}
