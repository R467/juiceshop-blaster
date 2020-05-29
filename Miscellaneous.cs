using NUnit.Framework;

namespace Tests
{
    public class Miscellaneous : BaseTest
    {
        /// <summary>
        /// Read our privacy policy
        /// </summary>
        [Test]
        public void PrivacyPolicy()
        {
            JuiceShop.GoTo("#/privacy-security/privacy-policy");

            Assert.IsTrue(JuiceShop.IsChallengeSolved(Challenge.PrivacyPolicyChallenge));
        }
    }
}
