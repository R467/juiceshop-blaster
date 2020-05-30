using NUnit.Framework;

namespace Tests
{
    public class XSS : BaseTest
    {
        /// <summary>
        /// Perform a DOM XSS attack
        /// </summary>
        [Test]
        public void DomXss()
        {
            JuiceShop.GoTo("/");
            JuiceShop.Search("<iframe src='javascript: alert(`xss`)'>");

            Assert.IsTrue(JuiceShop.IsChallengeSolved(Challenge.LocalXssChallenge));
        }
    }
}
