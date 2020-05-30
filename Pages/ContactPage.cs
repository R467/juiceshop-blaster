using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Data;

namespace Tests
{
    public class ContactPage : JuiceShop
    {
        IWebElement Comment;
        IWebElement Captcha;
        IWebElement CaptchaInput;
        IWebElement SubmitButton;

        public void Load()
        {
            GoTo("/#/contact");

            ClearModals();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Comment = Driver.FindElement(By.Id("comment"));
            Captcha = Driver.FindElement(By.Id("captcha"));
            CaptchaInput = Driver.FindElement(By.Id("captchaControl"));
            SubmitButton = Driver.FindElement(By.Id("submitButton"));
        }

        public void EnterComment(string comment)
        {
            Comment.SendKeys(comment);
        }

        public void SolveCaptcha()
        {
            var question = Captcha.Text;

            var result = new DataTable().Compute(question, null);

            CaptchaInput.SendKeys(result.ToString());
        }

        public void Submit()
        {
            Driver.ExecuteJavaScript("document.getElementById('submitButton').disabled = false;");
            SubmitButton.Click();
        }
    }
}
