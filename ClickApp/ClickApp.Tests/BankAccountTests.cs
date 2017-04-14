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
        public void CreateBankAccountFirstScenario()
        {
            string initialBalance = "2000";
            string interest = "4.5";
            string deposit = "500";
            string withdraw = "398.50";
            string totalBalance = "2214";


            Assert.AreEqual(totalBalance, CreateBankAccountOne(initialBalance, interest, deposit, withdraw));
        }

        [Test]
        public void CreateBankAccountSecondScenario()
        {
            string initialBalance = "2850.60";
            string interest = "4";
            string deposit = "500.75";
            string withdraw = "398";
            string totalBalance = "3087.404";


            Assert.AreEqual(totalBalance, CreateBankAccountOne(initialBalance, interest, deposit, withdraw));
        }

        public string CreateBankAccountOne(string initialBalance, string interest, string deposit, string withdraw)
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://localhost:62256/");

                IWebElement _initialInput = driver.FindElement(By.Id("Initial"));
                _initialInput.Clear();
                _initialInput.SendKeys(initialBalance);

                IWebElement _interestInput = driver.FindElement(By.Id("Interest"));
                _interestInput.Clear();
                _interestInput.SendKeys(interest);

                IWebElement _createButton = driver.FindElement(By.Id("create"));
                _createButton.Click();
                WaitForJSToLoad(driver);

                IWebElement _depositInput = driver.FindElement(By.Id("Deposit"));
                _depositInput.Clear();
                _depositInput.SendKeys(deposit);

                IWebElement _depositButton = driver.FindElement(By.XPath("/html/body/form/div/div[5]/div/input"));
                _depositButton.Click();
                WaitForJSToLoad(driver);

                IWebElement _interestButton = driver.FindElement(By.XPath("/html/body/form/div/div[3]/div/input[2]"));
                _interestButton.Click();
                WaitForJSToLoad(driver);

                IWebElement _withdrawInput = driver.FindElement(By.Id("Withdraw"));
                _withdrawInput.Clear();
                _withdrawInput.SendKeys(withdraw);

                IWebElement _withdrawButton = driver.FindElement(By.XPath("/html/body/form/div/div[7]/div/input"));
                _withdrawButton.Click();
                WaitForJSToLoad(driver);

                IWebElement _getBalanceButton = driver.FindElement(By.Id("getbalance"));
                _getBalanceButton.Click();
                WaitForJSToLoad(driver);

                IWebElement _balanceLabel = driver.FindElement(By.XPath("/html/body/form/div/div[8]/div"));

                return _balanceLabel.Text;
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
