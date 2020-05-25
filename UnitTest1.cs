using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class Tests
    {
        private IWebDriver driver = new ChromeDriver("/usr/bin");

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {         Console.WriteLine("test")  ;
            //driver.Navigate().GoToUrl("http://localhost:3000/ftp/acquisitions.md");
            driver.Navigate().GoToUrl("http://localhost:3000/#/score-board");
            
            

            Assert.IsTrue(ScoreChecker.IsChallengeSolved(Challenge.directoryListingChallenge));
        }
    }
}