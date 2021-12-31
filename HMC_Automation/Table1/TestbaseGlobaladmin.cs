using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Threading;

namespace HMC_Automation
{

    class TestbaseGA
    {
        public static IWebDriver driver;
        public WebDriverWait wait;

        //Globaladmin
        [SetUp]
        public void initialize1()
        {
            driver = new ChromeDriver();
            string GlobaladminURL = ConfigurationManager.AppSettings["GlobaladminURL"].ToString();            
            driver.Navigate().GoToUrl(GlobaladminURL);
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            waitForElement("ID", "btnLogin", 20);
        }

        //Global_Admin login reusable code
        public void GALogin(string GAUser, string GApassword)
        {
            IWebElement username = driver.FindElement(By.XPath("//input[@id='txtLoginID']"));
            username.SendKeys(GAUser);
            IWebElement password = driver.FindElement(By.XPath("//input[@id='txtPassword']"));
            password.SendKeys(GApassword);
            IWebElement Login = driver.FindElement(By.XPath("//*[@id='btnLogin']"));
            Login.Click();
            waitForElement("XPATH", "//*[@id='dvglobaladmin']/a", 20);

        }
        public void Mousehover1(IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element);
            action.Build().Perform();

        }

        public void waitForElement(string type, string locator, int timeout)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            if (type == "ID")
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator)));
            }
            else if (type == "XPATH")
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            }
        }


        public void Mousehover(IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element);
            action.Build().Perform();        

        }

        //Close browser
        [TearDown]
        public void close()
        {
            driver.Close();
            driver.Quit();
        }

       
    }
}

