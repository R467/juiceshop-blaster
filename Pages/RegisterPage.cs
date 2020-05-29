using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Tests
{
    public class RegisterPage : JuiceShop
    {
        IWebElement Email;
        IWebElement Password;
        IWebElement RepeatPassword;
        IWebElement SecurityQuestion;
        IWebElement SecurityAnswer;
        IWebElement RegisterButton;
        IWebElement SecurityDropDownItem;

        public void Load()
        {
            GoTo("/#/register");

            ClearModals();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Email = Driver.FindElement(By.Id("emailControl"));
            Password = Driver.FindElement(By.Id("passwordControl"));
            RepeatPassword = Driver.FindElement(By.Id("repeatPasswordControl"));            
            SecurityAnswer = Driver.FindElement(By.Id("securityAnswerControl"));
            RegisterButton = Driver.FindElement(By.Id("registerButton"));
            SecurityQuestion = Driver.FindElement(By.ClassName("mat-select-arrow"));            
        }

        public void EnterUserName(string username)
        {
            Email.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            Password.SendKeys(password);
        }

        public void EnterRepeatPassword(string password)
        {
            RepeatPassword.SendKeys(password);
        }

        public void ClearPassword()
        {
            Password.Clear();
        }

        public void SelectASecurityQuestion(int index = 1)
        {
            SecurityQuestion.Click();

            //This can't be selected until after the security question dropdown is clicked
            SecurityDropDownItem = Driver.FindElement(By.Id("repeatPasswordControl"));

            SecurityDropDownItem.Click();
        }

        public void EnterSecurityQuestionAnswer(string answer)
        {
            SecurityAnswer.SendKeys(answer);
        }

        public void Register()
        {
            RegisterButton.Click();
        }
    }
}
