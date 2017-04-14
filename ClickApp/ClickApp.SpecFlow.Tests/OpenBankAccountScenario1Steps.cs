using System;
using System.Threading;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace ClickApp.SpecFlow.Tests
{
    [Binding]
    public class OpenBankAccountScenario1Steps
    {
        private IWebDriver _driver;
       

        [Given(@"I am on the bank account creation screen")]
        public void GivenIAmOnTheBankAccountCreationScreen()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl("http://localhost:62256/");
        }
        
        [Given(@"I enter initial balance of (.*)")]
        public void GivenIEnterInitialBalanceOf(String p0)
        {
            IWebElement _initialInput = _driver.FindElement(By.Id("Initial"));
            _initialInput.Clear();
            _initialInput.SendKeys(p0);

        }
        
        [Given(@"I enter interest rate of (.*)")]
        public void GivenIEnterInterestRateOf(String p0)
        {

            IWebElement _interestInput = _driver.FindElement(By.Id("Interest"));
            _interestInput.Clear();
            _interestInput.SendKeys(p0);

        }
        
        [Given(@"I click create account")]
        public void GivenIClickCreateAccount()
        {
            IWebElement _createButton = _driver.FindElement(By.Id("create"));
            _createButton.Click();
            WaitForJSToLoad(_driver);
        }
        
        [Given(@"I deposit (.*)")]
        public void GivenIDeposit(String p0)
        {
            IWebElement _depositInput = _driver.FindElement(By.Id("Deposit"));
            _depositInput.Clear();
            _depositInput.SendKeys(p0);
            IWebElement _depositButton = _driver.FindElement(By.XPath("/html/body/form/div/div[5]/div/input"));
            _depositButton.Click();
            WaitForJSToLoad(_driver);
        }
        
        [Given(@"I add interest")]
        public void GivenIAddInterest()
        {
            IWebElement _interestButton = _driver.FindElement(By.XPath("/html/body/form/div/div[3]/div/input[2]"));
            _interestButton.Click();
            WaitForJSToLoad(_driver);
        }
        
        [Given(@"I withdraw (.*)")]
        public void GivenIWithdraw(String p0)
        {
            IWebElement _withdrawInput = _driver.FindElement(By.Id("Withdraw"));
            _withdrawInput.Clear();
            _withdrawInput.SendKeys(p0);

            IWebElement _withdrawButton = _driver.FindElement(By.XPath("/html/body/form/div/div[7]/div/input"));
            _withdrawButton.Click();
            WaitForJSToLoad(_driver);
        }
        
        [When(@"I get balance")]
        public void WhenIGetBalance()
        {
            IWebElement _getBalanceButton = _driver.FindElement(By.Id("getbalance"));
            _getBalanceButton.Click();
            WaitForJSToLoad(_driver);
        }
        
        [Then(@"I check the balance with (.*)")]
        public void ThenICheckTheBalanceWith(String p0)
        {
            IWebElement _balanceLabel = _driver.FindElement(By.XPath("/html/body/form/div/div[8]/div"));
            Assert.AreEqual(p0, _balanceLabel.Text);
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
