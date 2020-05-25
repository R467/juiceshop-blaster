using NUnit.Framework;

namespace Tests
{
    public class SensitiveDataExposure : BaseTest
    {
        [Test]
        public void ConfidentialDocument()
        {
            JuiceShop.GoTo("/ftp/acquisitions.md");
            
            Assert.IsTrue(JuiceShop.IsChallengeSolved(Challenge.directoryListingChallenge));
        }
    }
}