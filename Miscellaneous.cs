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

            Assert.IsTrue(IsChallengeSolved(Challenge.PrivacyPolicyChallenge));
        }

        /// <summary>
        /// Find the carefully hidden 'Score Board' page
        /// </summary>
        [Test]
        public void ScoreBoard()
        {
            JuiceShop.GoTo("#/score-board");

            Assert.IsTrue(IsChallengeSolved(Challenge.ScoreBoardChallenge));
        }
    }
}
