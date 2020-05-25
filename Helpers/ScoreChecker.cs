using System.Net.Http;
using System.Text.Json;
using System.Linq;

namespace Tests
{
    public static class ScoreChecker
    {
        private static readonly HttpClient Client = new HttpClient();

        public static bool IsChallengeSolved(Challenge challenge)
        {
            var response = Client.GetStringAsync($"http://localhost:3000/api/Challenges/?id={(int)challenge}").Result;


            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true
            };

            JsonChallenge result = JsonSerializer.Deserialize<JsonChallenge>(response, options);

            return result.solved;
        }
    }
}