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
        //Model for register page
        public RegisterPage RegisterPage { get; private set; }

        [SetUp]
        public void Setup()
        {
            //Instantiate a fresh model of the app
            JuiceShop = new JuiceShop();

            //Instantiate a fresh model of the register page
            RegisterPage = new RegisterPage();
        }

        [TearDown]
        public void TearDown()
        {
            //Clean up after ourselves
            JuiceShop.Dispose();
        }
    }
}
