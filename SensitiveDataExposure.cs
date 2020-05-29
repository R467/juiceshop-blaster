using NUnit.Framework;

namespace Tests
{
    public class SensitiveDataExposure : BaseTest
    {
        /// <summary>
        /// Acces a confidential document
        /// </summary>
        [Test]
        public void ConfidentialDocument()
        {
            JuiceShop.GoTo("/ftp/acquisitions.md");
            
            Assert.IsTrue(JuiceShop.IsChallengeSolved(Challenge.DirectoryListingChallenge));
        }

        /// <summary>
        /// Find the endpoint that serves usage data to be scraped by a popular monitoring system
        /// /metrics is monitored by Prometheus
        /// </summary>
        public void ExposedMetrics()
        {
            JuiceShop.GoTo("/metrics");

            Assert.IsTrue(JuiceShop.IsChallengeSolved(Challenge.ExposedMetricsChallenge));
        }
    }
}