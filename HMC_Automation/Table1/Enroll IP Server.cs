using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using AutoItX3Lib;


namespace HMC_Automation
{
    [TestFixture]
    public class Enroll_IP_Server : TestBase
    {

        //Validate IP Server page
        [Test]
        public void _0004_IPS_01_Validate_IP_Server_page()
        {
            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));
            IWebElement Dash = driver.FindElement(By.XPath(Constants.Dashboard));
            IWebElement IPserverMenu = driver.FindElement(By.XPath(Constants.IPserverMenu));
            IPserverMenu.Click();
            Thread.Sleep(3000);
            IWebElement License = driver.FindElement(By.XPath("//div[@id='divLicense']/div/div/div[2]/div[2]"));
            License.Click();
            Assert.IsTrue(License.Text.Contains("IP Server Licenses"));
            Thread.Sleep(3000);
            IWebElement Closebtn = driver.FindElement(By.XPath("//*[@id='btnClose']"));
            Closebtn.Click();
            if (License.Text.Contains("IP Server Licenses"))
            {
                Assert.Pass("Enroll IP server page navigated successfully");
            }
            else
            {
                Assert.Fail("Enroll IP server page not navigated");
            }


        }

        [Test]
        public void _0004_IPS_02_Validate_Enroll_IP_Server_page()
        {
            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));
            IWebElement Dash = driver.FindElement(By.XPath(Constants.Dashboard));
            IWebElement IPserverMenu = driver.FindElement(By.XPath(Constants.IPserverMenu));
            IPserverMenu.Click();
            Thread.Sleep(3000);
            IWebElement EnrollIPServerPage = driver.FindElement(By.XPath(Constants.EnrollIPServerPage));
            Thread.Sleep(3000);
            EnrollIPServerPage.Click();
            Thread.Sleep(3000);
            IWebElement AddNewGroup = driver.FindElement(By.XPath("//*[@id='btnAddNewGroup']"));
            if (AddNewGroup.Text.Contains("Add New Group"))
            {
                Assert.Pass("Enroll IP server page is navigated successfully");
            }
            else
            {
                Assert.Fail("Enroll IP server page is not navigated");
            }
        }

        [Test, Order(1)]
        public void _0004_IPS_03_Validate_Enroll_IP_Server()
        {
            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));
            IWebElement Dash = driver.FindElement(By.XPath(Constants.Dashboard));
            IWebElement IPserverMenu = driver.FindElement(By.XPath(Constants.IPserverMenu));
            IPserverMenu.Click();
            Thread.Sleep(3000);
            IWebElement EnrollIPServerPage = driver.FindElement(By.XPath(Constants.EnrollIPServerPage));
            Thread.Sleep(3000);
            EnrollIPServerPage.Click();
            Thread.Sleep(3000);
            IWebElement ServerName = driver.FindElement(By.XPath(Constants.ServerName));
            ServerName.SendKeys(ConfigProvider.GetConfigValue("ServerName"));
            IWebElement InternalIPAdress = driver.FindElement(By.XPath(Constants.InternalIPAdress));
            InternalIPAdress.SendKeys(ConfigProvider.GetConfigValue("InternalIPAddress"));
            IWebElement SerialNumber = driver.FindElement(By.XPath(Constants.SerialNumber));
            SerialNumber.SendKeys(ConfigProvider.GetConfigValue("SerialNumber"));
            IWebElement Userdropdown1 = driver.FindElement(By.XPath("//*[@id='dropdownlistContentddlCustomer']"));
            Userdropdown1.Click();
            IReadOnlyList<IWebElement> userlist = driver.FindElements(By.XPath("//*[@id='listBoxContentinnerListBoxddlCustomer']"));
            Thread.Sleep(2000);
            var userlst = userlist.SingleOrDefault().Text.Replace("\r\n", ",").Split(',');
            if (userlst.Count() >= 1)
            {
                for (int i = 0; i < userlst.Count(); i++)
                {
                    IWebElement checkbox = driver.FindElement(By.XPath("//*[@id='listitem" + i + "innerListBoxddlCustomer']"));
                    if (checkbox.Text.Contains(ConfigProvider.GetConfigValue("Selectuserlist")))
                    {
                        checkbox.Click();
                    }
                }
            }

            IWebElement CPUWarning = driver.FindElement(By.XPath("//*[@id='notifyTypCpu']"));
            CPUWarning.Click();
            IWebElement MemoryWarning = driver.FindElement(By.XPath("//input[@id='notifyTypMemory']"));
            MemoryWarning.Click();
            IWebElement FailtoWriteErrorWarning = driver.FindElement(By.XPath("//input[@id='notifyTypFailToWrite']"));
            FailtoWriteErrorWarning.Click();
            IWebElement ServerUp = driver.FindElement(By.XPath("//input[@id='notifyTypIpUp']"));
            ServerUp.Click();
            IWebElement ServerDownorWarning = driver.FindElement(By.XPath("//input[@id='notifyTypIpDown']"));
            ServerDownorWarning.Click();
            IWebElement CameraUp = driver.FindElement(By.XPath("//input[@id='notifyTypCameraUp']"));
            CameraUp.Click();
            IWebElement CameraDown = driver.FindElement(By.XPath("//input[@id='notifyTypCameraDown']"));
            CameraDown.Click();
            IWebElement MinutestoWarning = driver.FindElement(By.XPath("//input[@id='txtMinutestoWarning']"));
            int defaultvalue = 15;
            if (defaultvalue >= Convert.ToInt32(ConfigProvider.GetConfigValue("MinutestoWarning")))
            {
                for (int i = 0; i <= 30; i++)

                {

                    IWebElement downarrow = driver.FindElement(By.XPath("//*[@id='UserProfile']/div[1]/div/div[5]/div/div[1]/span/a[2]"));
                    downarrow.Click();
                    var MinutestoWarning1 = driver.FindElement(By.XPath(Constants.MinutesToWarning)).GetAttribute("aria-valuenow");
                    if (MinutestoWarning1.Equals(ConfigProvider.GetConfigValue("MinutestoWarning")))
                    {
                        break;
                    }

                }
            }

            else
            {
                for (int i = 0; i <= 30; i++)
                {
                    IWebElement Uparrow = driver.FindElement(By.XPath("//*[@id='UserProfile']/div[1]/div/div[5]/div/div[1]/span/a[1]"));
                    Uparrow.Click();
                    var MinutestoWarning1 = driver.FindElement(By.XPath(Constants.MinutesToWarning)).GetAttribute("aria-valuenow");
                    if (MinutestoWarning1.Equals(ConfigProvider.GetConfigValue("MinutestoWarning")))
                    {
                        break;
                    }
                }

            }

            int defaultvalue1 = 20;
            if (defaultvalue1 >= Convert.ToInt32(ConfigProvider.GetConfigValue("MinutesToError")))
            {
                for (int i = 0; i <= 30; i++)
                {

                    IWebElement downarrow = driver.FindElement(By.XPath("//*[@id='UserProfile']/div[1]/div/div[5]/div/div[2]/span/a[2]"));
                    downarrow.Click();
                    var MinutestoError2 = driver.FindElement(By.XPath(Constants.MinutesToError)).GetAttribute("aria-valuenow");
                    if (MinutestoError2.Equals(ConfigProvider.GetConfigValue("MinutesToError")))
                    {
                        break;
                    }

                }
            }

            else
            {
                for (int i = 0; i <= 30; i++)
                {
                    IWebElement Uparrow = driver.FindElement(By.XPath("//*[@id='UserProfile']/div[1]/div/div[5]/div/div[2]/span/a[1]"));
                    Uparrow.Click();
                    var MinutestoError1 = driver.FindElement(By.XPath(Constants.MinutesToError)).GetAttribute("aria-valuenow");
                    if (MinutestoError1.Equals(ConfigProvider.GetConfigValue("MinutesToError")))
                    {
                        break;
                    }

                }

            }
            IWebElement Newgroup = driver.FindElement(By.XPath(Constants.AddNewGroup));
            Newgroup.Click();
            Thread.Sleep(3000);
            IWebElement AddGroup = driver.FindElement(By.XPath("//*[@id='txtGroupName']"));
            AddGroup.SendKeys("Azure");
            IWebElement OK = driver.FindElement(By.XPath("//*[@id='btnSaveGroup']"));
            Thread.Sleep(2000);
            OK.Click();
            Thread.Sleep(3000);
            IWebElement Groupalreadyexist = driver.FindElement(By.XPath("//*[@id='windowDisplayMessage']"));
            if (Groupalreadyexist.Text.Contains("Error code - 51002 : Group already exists"))
            {
                IWebElement OKbtn = driver.FindElement(By.XPath("//*[@id='btnDisplayMessage']"));
                OKbtn.Click();
            }
            else
            {

                Thread.Sleep(3000);
                IWebElement GroupcreatedOKbtn = driver.FindElement(By.XPath("//input[@id='btnDisplayMessage']"));
                Thread.Sleep(3000);
                GroupcreatedOKbtn.Click();
                Thread.Sleep(3000);

            }
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            IWebElement savebutton = driver.FindElement(By.XPath("//button[@id='btnSave']"));
            Thread.Sleep(3000);
            savebutton.Click();
            Thread.Sleep(5000);
            IWebElement Successmessage = driver.FindElement(By.XPath("//*[@id='windowDisplayMessageContent']"));
            if (Successmessage.Text.Contains("Server details saved successfully"))
            {
                IWebElement OKBTN = driver.FindElement(By.XPath("//*[@id='btnDisplayMessage']"));
                OKBTN.Click();
            }

            else if (Successmessage.Text.Contains("Error code - 51001 : Server already exists"))
            {

                IWebElement OKBTN = driver.FindElement(By.XPath("//*[@id='btnDisplayMessage']"));
                OKBTN.Click();
                Assert.Fail("Server is already exists");

            }
            Thread.Sleep(5000);
            Successmessage.Click();
            Thread.Sleep(3000);
            IWebElement Homepage = driver.FindElement(By.XPath("//*[@id='homeclick']"));
            Homepage.Click();
            Thread.Sleep(2000);

        }
        [Test, Order(3)]
        public void _0004_IPS_04_Validate_Delete_IP_Serve()
        {
            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));
            IWebElement Dash = driver.FindElement(By.XPath(Constants.Dashboard));
            IWebElement IPserverMenu = driver.FindElement(By.XPath(Constants.IPserverMenu));
            IPserverMenu.Click();
            Thread.Sleep(3000);
            IReadOnlyList<IWebElement> DeleteIPServer = driver.FindElements(By.XPath("//*[@id='contenttablegrid']"));
            Thread.Sleep(2000);
            if (DeleteIPServer.Count > 0)
            {
                for (int i = 0; i <= DeleteIPServer.Count+1; i++)
                {
                    IWebElement row = driver.FindElement(By.XPath("//*[@id='row" + i + "grid']"));
                    if (row.Text.Contains(ConfigProvider.GetConfigValue("DeleteIPServer")))
                    {

                        IWebElement DeleteIPServer1 = driver.FindElement(By.XPath("//*[@id='row" + i + "grid']/div[6]"));
                        DeleteIPServer1.Click();
                        Thread.Sleep(2000);
                        IWebElement Yesbtn = driver.FindElement(By.XPath("//button[@id='btnConfirmationDialogYesForServerStatus']"));
                        Yesbtn.Click();
                        Thread.Sleep(3000);
                        IWebElement IPDelSuccessfully = driver.FindElement(By.XPath("//*[@id='windowDisplayMessage']"));
                        if (IPDelSuccessfully.Text.Contains("IP Server deleted successfully"))
                        {
                            IWebElement DelYes = driver.FindElement(By.XPath("//*[@id='windowDisplayMessageContent']/div[3]"));
                            DelYes.Click();

                        }

                    }

                }

            }
            IWebElement Homepage = driver.FindElement(By.XPath("//*[@id='homeclick']"));
            Homepage.Click();
            Thread.Sleep(2000);  

        }



        [Test, Order(2)]
        public void _0004_IPS_06_Validate_Edit_Ip_server()
        {
            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));
            IWebElement Dash = driver.FindElement(By.XPath(Constants.Dashboard));
            IWebElement IPserverMenu = driver.FindElement(By.XPath(Constants.IPserverMenu));
            IPserverMenu.Click();
            Thread.Sleep(3000);
            IReadOnlyList<IWebElement> EditIPServer = driver.FindElements(By.XPath("//*[@id='contenttablegrid']"));
            Thread.Sleep(3000);
            if (EditIPServer.Count > 0)
            {
                for (int i = 0; i <= EditIPServer.Count+1; i++)
                {
                    IWebElement row = driver.FindElement(By.XPath("//*[@id='row" + i + "grid']"));
                    if (row.Text.Contains(ConfigProvider.GetConfigValue("EditIPServer")))
                    {
                        IWebElement EditIPServer1 = driver.FindElement(By.XPath("//*[@id='row" + i + "grid']/div[7]"));
                        EditIPServer1.Click();
                        Thread.Sleep(2000);
                        IWebElement ServerNameedit = driver.FindElement(By.XPath("//*[@id='txtHostName']"));
                        ServerNameedit.Clear();
                        Thread.Sleep(2000);
                        ServerNameedit.SendKeys(ConfigProvider.GetConfigValue("EditSernameinIPserver"));
                        IWebElement SerialNumber = driver.FindElement(By.XPath("//*[@id='txtIpAddress']"));
                        SerialNumber.Clear();
                        Thread.Sleep(2000);
                        SerialNumber.SendKeys(ConfigProvider.GetConfigValue("EDitIPAddress"));
                        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                        IWebElement UpdateBtn = driver.FindElement(By.XPath(Constants.UpdateIPserver));
                        UpdateBtn.Click();
                        Thread.Sleep(3000);
                        IWebElement updatedsuccessfully = driver.FindElement(By.XPath("//*[@id='windowDisplayMessage']"));
                        if (updatedsuccessfully.Text.Contains("Server details updated"))
                        {
                            IWebElement OkBtn = driver.FindElement(By.XPath("//*[@id='windowDisplayMessageContent']/div[3]"));
                            Thread.Sleep(3000);
                            OkBtn.Click();
                            Thread.Sleep(3000);
                        }                   

                    }

                }
            }

        }
    }
    }
