using OsuAPI.Net.Requests.V1;
using OsuAPI.Net.Models.V1;
using System;
using System.Threading.Tasks;
using Xunit;
using System.IO;

namespace OsuAPI.Net.Tests
{
    public class UnitTestV1
    {
        APIV1Client apiClient;

        public UnitTestV1()
        {
            if(!File.Exists("apiKey.txt"))
            {
                File.Create("apiKey.txt");
                throw new Exception("put your api v1 key into apiKey.txt");
            }
            apiClient = new APIV1Client(File.ReadAllText("apiKey.txt"));
        }

        [Fact]
        public async Task TestGetUser()
        {
            var response = await apiClient.QueryAsync(new GetUserRequest("nobbele", GameMode.Osu));

            if (response.Count < 1)
                throw new Exception("got 0 users");

            var user = response[0];

            Assert.Equal("nobbele", user.Username);
        }

        [Fact]
        public async Task TestGetBeatmapsWithSet()
        {
            var response = await apiClient.QueryAsync(new GetBeatmapsRequest(null, 39804, Mods.None, 2));

            if (response.Count < 1)
                throw new Exception("got 0 beatmaps");

            var beatmap = response[0];
            var beatmap2 = response[1];

            Assert.Equal(222.22, beatmap.Bpm);
            Assert.Equal("FOUR DIMENSIONS", beatmap2.Version);
        }

        [Fact]
        public async Task TestGetBeatmapsWithOldSet()
        {
            var response = await apiClient.QueryAsync(new GetBeatmapsRequest(null, 1, Mods.None, 1));

            if (response.Count < 1)
                throw new Exception("got 0 beatmaps");

            var beatmap = response[0];

            Assert.Equal(119.999, beatmap.Bpm);
            Assert.Equal("Normal", beatmap.Version);
        }

        [Fact]
        public async Task TestGetBeatmapsWithBeatmap()
        {
            var response = await apiClient.QueryAsync(new GetBeatmapsRequest(129891, null, Mods.None, 1));

            if (response.Count < 1)
                throw new Exception("got 0 beatmaps");

            var beatmap = response[0];

            Assert.Equal(222.22, beatmap.Bpm);
            Assert.Equal("FOUR DIMENSIONS", beatmap.Version);
        }

        [Fact]
        public async Task TestGetBeatmapsWithOldBeatmap()
        {
            var response = await apiClient.QueryAsync(new GetBeatmapsRequest(75, null, Mods.None, 1));

            if (response.Count < 1)
                throw new Exception("got 0 beatmaps");

            var beatmap = response[0];

            Assert.Equal(119.999, beatmap.Bpm);
            Assert.Equal("Normal", beatmap.Version);
        }

        [Fact]
        public async Task TestGetMatch()
        {
            var response = await apiClient.QueryAsync(new GetMatchRequest("64302801"));

            Assert.Equal("CC: (nobbele) vs (Garonen)", response.Metadata.Name);
            Assert.Equal(299882, response.Games[0].Scores[1].Score);
        }

        [Fact]
        public async Task TestGetBeatmapScore()
        {
            var response = await apiClient.QueryAsync(new GetBeatmapScoresRequest(129891, Mods.Hidden | Mods.HardRock, GameMode.Osu, 1));

            if (response.Count < 1)
                throw new Exception("got 0 scores");

            var score = response[0];

            Assert.Equal(124493, score.UserId);
        }

        [Fact]
        public async Task TestUserBest()
        {
            var response = await apiClient.QueryAsync(new GetUserBestScoresRequest(124493));

            if (response.Count < 1)
                throw new Exception("got 0 beatmaps");

            var beatmap = response[0];

            Assert.Equal(129891, beatmap.BeatmapId);
        }
    }
}
