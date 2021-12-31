using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMC_Automation
{
    [TestFixture]
    public class LoginPage:TestBase
    {
        //Validate Login page
        [Test]
        public void _0002_UL_01_Validate_Login_Page()
        {
            IWebElement loginbtn = driver.FindElement(By.Id("btnLogin"));
            Assert.IsTrue(driver.Title.Contains(ConfigProvider.GetConfigValue(Constants.Title)));
            Assert.IsTrue(loginbtn.Displayed);
        }

        //validate correct credentials
        [Test]
        public void _0002_UL_02_Validate_login_Successfully()
        {

            login(ConfigurationManager.AppSettings["USERNAME"].ToString(), ConfigurationManager.AppSettings["PASSWORD"].ToString());
            //Thread.Sleep(3000);
            IWebElement dropdown= driver.FindElement(By.XPath("//li[@id='dvPassword']/a"));
            Assert.IsTrue(dropdown.Text.Contains("Sundar Arun"));
            if (dropdown.Text.Contains("Sundar Arun"))
            {
                Assert.Pass("Given loginID is logged in correctly ");
            }
            else
            {
                Assert.Fail("Login ID is going in different account");
            }
            
        }

        //validate incorrect password
        [Test]
        public void _0002_UL_03_Validate_invalid_Password()

        {

            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));
            //Thread.Sleep(1000);
            IWebElement Alert = driver.FindElement(By.XPath("//*[@id='windowDisplayMessage']"));
            if (Alert.Text.Contains("Error code - 10003 : Login failed. Please enter valid credentials."))
            {
                IWebElement OKbutton = driver.FindElement(By.XPath("//*[@id='windowDisplayMessageContent']/div[3]"));
                OKbutton.Click();
                Assert.Pass("Invalid Password Testcase Pass");

            }
            else if(Alert.Text.Contains("User has reached maximum retry count, Please reset your password"))
            {
                Assert.Pass("User has reached maximum retry count, Please reset your password - Testcase Pass");
            }
            
            else
            {
                Assert.Fail("Invalid login testcase fail");
            }
        }

        //validate incorrect Username
        [Test]
        public void _0002_UL_04_Validate_invalid_Username()
        {
            login("arun99626@gmail.com", "123456");
            //Thread.Sleep(2000);
            IWebElement Alert = driver.FindElement(By.Id("displayMessageText"));
            if (Alert.Text.Contains("Error code - 10003 : Login failed. Please enter valid credentials."))
            {
                Assert.Pass("Invalid Username TC is Pass");
            }
            else if(Alert.Text.Contains("User has reached maximum retry count, Please reset your password"))
            {
                Assert.Pass("User has reached maximum retry count, Please reset your password - Testcase Pass");
            }
            else
            {
                Assert.Fail("Invalid Username TC is Fail");
            }
             
        }

        //Signout
        [Test]
        public void _0002_UL_05_Validate_logout()
        {
            login("arun99626@gmail.com", "123456");
            //Thread.Sleep(3000);
            IWebElement displayname = driver.FindElement(By.XPath("//li[@id='dvPassword']/a"));
            //Assert.IsTrue(displayname.Text.Contains("Tester Automation"));
            displayname.Click();
            Thread.Sleep(1000);
            IWebElement logout = driver.FindElement(By.XPath("//li[@id='dvLogout']/a"));
            logout.Click();
            waitForElement("ID", "btnLogin", 20);
            if (driver.FindElement(By.Id("btnLogin")).Displayed)
            {
                Assert.Pass("Logout successfully");
            }
            else
            {
                Assert.Fail("Logout failed, Please verify manually");
            }
            Thread.Sleep(5000);        



        }

       

       
    }
}
