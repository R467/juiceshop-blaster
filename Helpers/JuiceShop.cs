using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace Tests
{
    public class JuiceShop : IDisposable
    {
        //Where Juice Shop is running
        public static string JuiceShopUrl { get; private set; }
        //Chrome web driver
        public static IWebDriver Driver { get; private set; }
        //appsettings.json
        public IConfiguration Config { get; private set; }
        //Http client used to check score
        private static readonly HttpClient Client = new HttpClient();

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

        /// <summary>
        /// Checks to see if a challenge has been successfully complete
        /// </summary>
        /// <param name="challenge">The challenge to check</param>
        /// <returns>Whether the challenge has been successful</returns>
        public static bool IsChallengeSolved(Challenge challenge)
        {
            //Try up to 10 times to get the updated status of the challenge
            //If it hasn't returned by then assume it failed
            int attempts = 0;
            while (attempts < 10)
            {
                //Look up challenge by id
                var response = Client.GetStringAsync($"{JuiceShopUrl}/api/Challenges/?id={(int)challenge}").Result;

                //Parse response from json to JsonChallengeResponse
                JsonChallengeResponse result = JsonSerializer.Deserialize<JsonChallengeResponse>(response);

                //Searching by id so assume the first result is the one we want
                if (result.Data.First().Solved == true) return true;

                Thread.Sleep(500);
                attempts++;                
            }

            return false;
        }

        public void Search(string query)
        {
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
        public static void GoTo(string path)
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
