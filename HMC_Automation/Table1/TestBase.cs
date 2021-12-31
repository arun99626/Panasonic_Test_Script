using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace HMC_Automation
{
    public class TestBase
    {
        //Variable declaration
        public static IWebDriver driver;        
        public WebDriverWait wait;

        //Tenant login
         [SetUp]
        public void initialize()
        {
            driver = new ChromeDriver();
            string baseurl = ConfigurationManager.AppSettings["BASEURL"].ToString();
            driver.Navigate().GoToUrl(baseurl);
            driver.Manage().Window.Maximize();
            waitForElement("ID", "btnLogin", 20);
            //IWebElement username = driver.FindElement(By.XPath("//input[@id='txtLoginID']"));
            //username.SendKeys(ConfigProvider.GetConfigValue("USERNAME"));
            //IWebElement Password = driver.FindElement(By.XPath("//input[@id='txtPassword']"));
            //Password.SendKeys(ConfigProvider.GetConfigValue("PASSWORD"));
            //IWebElement submit = driver.FindElement(By.XPath("//button[@id='btnLogin']"));
            //submit.Click();
            //waitForElement("XPATH", "//div[@id='divHomePageContents']/div[1]/div[1]/div[1]/div/p[1]", 20);

        }    


        //login reusable code
        public void login(string usern, string pwd)
        {
            IWebElement username = driver.FindElement(By.XPath("//input[@id='txtLoginID']"));
            username.SendKeys(usern);
            IWebElement Password = driver.FindElement(By.XPath("//input[@id='txtPassword']"));
            Password.SendKeys(pwd);
            IWebElement submit = driver.FindElement(By.XPath("//button[@id='btnLogin']"));
            submit.Click();
            waitForElement("XPATH", "//div[@id='divHomePageContents']/div[1]/div[1]/div[1]/div/p[1]", 20);
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

