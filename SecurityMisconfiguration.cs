using NUnit.Framework;

namespace Tests
{
    class SecurityMisconfiguration : BaseTest
    {
        /// <summary>
        /// Provoke an error that is neither very gracefully nor consistently handled
        /// </summary>
        [Test]
        public void ErrorHandling()
        {
            JuiceShop.GoTo("/rest/qwertz");

            Assert.IsTrue(JuiceShop.IsChallengeSolved(Challenge.ErrorHandlingChallenge));
        }
    }
}
