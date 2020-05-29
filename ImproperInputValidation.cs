using NUnit.Framework;

namespace Tests
{
    public class ImproperInputValidation : BaseTest
    {
        /// <summary>
        /// Retrieve the photo of Bjoern's cat in "melee combat-mode"
        /// </summary>
        [Test]
        public void MissingEncoding()
        {
            JuiceShop.GoTo("/assets/public/images/uploads/😼-%23zatschi-%23whoneedsfourlegs-1572600969477.jpg");

            Assert.IsTrue(JuiceShop.IsChallengeSolved(Challenge.MissingEncodingChallenge));
        }

        /// <summary>
        /// Follow the DRY principle while registering a user
        /// </summary>
        [Test]
        public void RepetitiveRegistration()
        {
            RegisterPage.Load();
            RegisterPage.EnterUserName("test@test.com");
            RegisterPage.EnterPassword("12345");
            RegisterPage.EnterRepeatPassword("12345");
            RegisterPage.SelectASecurityQuestion();
            RegisterPage.EnterSecurityQuestionAnswer("answer");

            RegisterPage.ClearPassword();
            RegisterPage.EnterPassword("switcheroo");

            RegisterPage.Register();

            Assert.IsTrue(JuiceShop.IsChallengeSolved(Challenge.PasswordRepeatChallenge));
        }
    }
}
