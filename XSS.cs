using NUnit.Framework;

namespace Tests
{
    public class XSS : BaseTest
    {
        /// <summary>
        /// Perform a DOM XSS attack
        /// </summary>
        [Test]
        [Ignore("This will perform the XSS attack but the result won't be recorded")]
        public void DomXss()
        {
            JuiceShop.GoTo("/#/search");
            
            JuiceShop.Search("<iframe src=\"javascript: alert(`xss`)\">");

            Assert.IsTrue(IsChallengeSolved(Challenge.LocalXssChallenge));
        }
    }
}
