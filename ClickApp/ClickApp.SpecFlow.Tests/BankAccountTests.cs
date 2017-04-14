using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System;

namespace ClickApp.Tests
{
    public class BankAccountTests
    {

        [Test]
        public void StartApplication()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://localhost:62256/");

                IWebElement _initialInput = driver.FindElement(By.Id("Initial"));
                _initialInput.Clear();
                _initialInput.SendKeys("2000");

                IWebElement _interestInput = driver.FindElement(By.Id("Interest"));
                _interestInput.Clear();
                _interestInput.SendKeys("4.5");

                IWebElement _createButton = driver.FindElement(By.Id("create"));
                _createButton.Click();
                WaitForJSToLoad(driver);

                IWebElement _depositInput = driver.FindElement(By.Id("Deposit"));
                _depositInput.Clear();
                _depositInput.SendKeys("500");

                IWebElement _depositButton = driver.FindElement(By.XPath("/html/body/form/div/div[5]/div/input"));
                _depositButton.Click();
                WaitForJSToLoad(driver);

                IWebElement _interestButton = driver.FindElement(By.XPath("/html/body/form/div/div[3]/div/input[2]"));
                _interestButton.Click();
                WaitForJSToLoad(driver);

                IWebElement _withdrawInput = driver.FindElement(By.Id("Withdraw"));
                _withdrawInput.Clear();
                _withdrawInput.SendKeys("398.50");

                IWebElement _withdrawButton = driver.FindElement(By.XPath("/html/body/form/div/div[7]/div/input"));
                _withdrawButton.Click();
                WaitForJSToLoad(driver);

                IWebElement _getBalanceButton = driver.FindElement(By.Id("getbalance"));
                _getBalanceButton.Click();
                WaitForJSToLoad(driver);

                IWebElement _balanceLabel = driver.FindElement(By.XPath("/html/body/form/div/div[8]/div"));
                Assert.AreEqual("2214", _balanceLabel.Text);
            }
        }


        public void Sleep(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        public Boolean WaitForJSToLoad(IWebDriver driver, int timeout = 30)
        {
            Sleep(2000);

            //Additional code for handling webdriver and js

            return true;
        }


    }
}
