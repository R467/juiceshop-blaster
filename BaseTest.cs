using NUnit.Framework;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;

namespace Tests
{
    /// <summary>
    /// Location for code that is shared between tests
    /// </summary>
    public class BaseTest
    {           
        //Model for Juice Shop app
        public JuiceShop JuiceShop { get; private set; }
        //Model for register page
        public RegisterPage RegisterPage { get; private set; }
        //Model for feedback page
        public ContactPage ContactPage { get; private set; }
        //Http Client used to check score
        private HttpClient Client = new HttpClient();

        [SetUp]
        public void Setup()
        {
            //Instantiate a fresh model of the app
            JuiceShop = new JuiceShop();

            //Instantiate a fresh model of the register page
            RegisterPage = new RegisterPage();

            //Instantiate a fresh model of the feedback page
            ContactPage = new ContactPage();
        }

        [TearDown]
        public void TearDown()
        {
            //Clean up after ourselves
            JuiceShop.Dispose();
        }

        /// <summary>
        /// Checks to see if a challenge has been successfully complete
        /// </summary>
        /// <param name="challenge">The challenge to check</param>
        /// <returns>Whether the challenge has been successful</returns>
        public bool IsChallengeSolved(Challenge challenge)
        {
            //Try up to 10 times to get the updated status of the challenge
            //If it hasn't returned by then assume it failed
            int attempts = 0;
            while (attempts < 10)
            {
                //Look up challenge by id
                var response = Client.GetStringAsync($"{JuiceShop.JuiceShopUrl}/api/Challenges/?id={(int)challenge}").Result;

                //Parse response from json to JsonChallengeResponse
                JsonChallengeResponse result = JsonSerializer.Deserialize<JsonChallengeResponse>(response);

                //Searching by id so assume the first result is the one we want
                if (result.Data.First().Solved == true) return true;

                Thread.Sleep(500);
                attempts++;
            }

            return false;
        }
    }
}
