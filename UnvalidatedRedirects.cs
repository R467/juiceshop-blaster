using NUnit.Framework;

namespace Tests
{
    public class UnvalidatedRedirects : BaseTest
    {
        /// <summary>
        /// Let us redirect you to one of our crypto currency addresses
        /// </summary>
        [Test]
        public void OutdatedWhitelist()
        {
            JuiceShop.GoTo("/redirect?to=https://blockchain.info/address/1AbKfgvw9psQ41NbLi8kufDQTezwG8DRZm");

            Assert.IsTrue(IsChallengeSolved(Challenge.RedirectCryptoCurrencyChallenge));
        }
    }
}
