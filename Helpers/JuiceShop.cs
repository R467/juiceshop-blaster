﻿using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
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

            Driver = new ChromeDriver(Config["chromeDriverPath"], chromeOptions);
        }

        /// <summary>
        /// Checks to see if a challenge has been successfully complete
        /// </summary>
        /// <param name="challenge">The challenge to check</param>
        /// <returns>Whether the challenge has been successful</returns>
        public static bool IsChallengeSolved(Challenge challenge)
        {
            //Load config file
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

            //Get base url from config
            string juiceShopUrl = config["juiceShopUrl"];

            //Try up to 5 times to get the updated status of the challenge
            //If it hasn't returned by then assume it failed
            int attempts = 0;
            while (attempts < 5)
            {
                //Look up challenge by id
                var response = Client.GetStringAsync($"{juiceShopUrl}/api/Challenges/?id={(int)challenge}").Result;

                //Parse response from json to JsonChallengeResponse
                JsonChallengeResponse result = JsonSerializer.Deserialize<JsonChallengeResponse>(response);

                //Searching by id so assume the first result is the one we want
                if (result.Data.First().Solved == true) return true;

                Thread.Sleep(100);
            }

            return false;

        }

        public static void GoTo(string path)
        {
            //Prepend a slash if it's not already there
            if (path[0] != '/') path = '/' + path;

            Driver.Navigate().GoToUrl($"{JuiceShopUrl}{path}");
        }

        public void Dispose()
        {
            //Clean up after ourselves
            Driver.Dispose();
        }
    }
}
