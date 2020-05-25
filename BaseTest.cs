using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Location for code that is shared between tests
    /// </summary>
    public class BaseTest
    {           
        //Model for Juice Shop app
        public JuiceShop JuiceShop { get; private set; }

        [SetUp]
        public void Setup()
        {
            //Instansiate a fresh model of the app
            JuiceShop = new JuiceShop();
        }

        [TearDown]
        public void TearDown()
        {
            //Clean up after ourselves
            JuiceShop.Dispose();
        }
    }
}
