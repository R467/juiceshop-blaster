using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;

namespace Tests
{
    public class JuiceShop : IDisposable
    {
        //Where Juice Shop is running
        public string JuiceShopUrl { get; private set; }
        //Chrome web driver
        public IWebDriver Driver { get; private set; }
        //appsettings.json
        public IConfiguration Config { get; private set; }

        public JuiceShop()
        {
            //Load config file
            Config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

            JuiceShopUrl = Config["juiceShopUrl"];

            //Run chrome in headless mode
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            chromeOptions.AddArguments("window-size=1920,1080");

            Driver = new ChromeDriver(Config["chromeDriverPath"], chromeOptions);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);            
        }

        public void Search(string query)
        {
            ClearModals();
            ClearOverlay();
            Driver.FindElement(By.ClassName("mat-search_icon-search")).Click();
            Driver.FindElement(By.Id("mat-input-0")).SendKeys(query);
            Driver.FindElement(By.Id("mat-input-0")).SendKeys(Keys.Enter);
        }

        /// <summary>
        /// Dimiss the two modals on the screen
        /// </summary>
        public void ClearModals()
        {
            Driver.FindElement(By.ClassName("cc-dismiss")).Click();
            Driver.FindElement(By.ClassName("close-dialog")).Click();
        }

        /// <summary>
        /// Remove the invisible overlay from the page
        /// </summary>
        public void ClearOverlay()
        {
            try
            {
                Driver.ExecuteJavaScript("return document.getElementsByClassName('cdk-overlay-backdrop')[0].remove();");
            }
            catch
            {
                //If we can't find the overlay then just move on
            }
        }

        /// <summary>
        /// Navigate to a page
        /// </summary>
        /// <param name="path">Relative path</param>
        public void GoTo(string path)
        {
            //Prepend a slash if it's not already there
            if (path[0] != '/') path = '/' + path;

            Driver.Navigate().GoToUrl($"{JuiceShopUrl}{path}");
        }

        /// <summary>
        /// Clean up after ourselves
        /// </summary>
        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}
