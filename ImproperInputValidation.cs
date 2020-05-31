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

            Assert.IsTrue(IsChallengeSolved(Challenge.MissingEncodingChallenge));
        }

        /// <summary>
        /// Follow the DRY principle while registering a user
        /// </summary>
        [Test]
        public void RepetitiveRegistration()
        {
            //Fill out the form
            RegisterPage.Load();
            RegisterPage.EnterUserName("test@test.com");
            RegisterPage.EnterPassword("12345");
            RegisterPage.EnterRepeatPassword("12345");
            RegisterPage.SelectASecurityQuestion();
            RegisterPage.EnterSecurityQuestionAnswer("answer");

            //Clear the password field and change the value
            RegisterPage.ClearPassword();
            RegisterPage.EnterPassword("switcheroo");

            RegisterPage.Register();

            Assert.IsTrue(IsChallengeSolved(Challenge.PasswordRepeatChallenge));
        }

        /// <summary>
        /// Give a devastating zero-star feedback to the store
        /// </summary>
        [Test]
        public void ZeroStars()
        {
            ContactPage.Load();
            ContactPage.EnterComment("comment");
            ContactPage.SolveCaptcha();
            ContactPage.Submit();

            Assert.IsTrue(IsChallengeSolved(Challenge.ZeroStarsChallenge));
        }
    }
}
