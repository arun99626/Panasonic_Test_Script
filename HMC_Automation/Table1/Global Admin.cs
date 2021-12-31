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

namespace HMC_Automation
{
    [TestFixture]
    class Global_Admin: TestbaseGA
    {
        [Test]
        public void _0001_GA_01_Validate_Login()
        {
            GALogin(ConfigurationManager.AppSettings["GAUsername"].ToString(), ConfigurationManager.AppSettings["GApassword"].ToString());
            Thread.Sleep(3000);
            IWebElement Organization = driver.FindElement(By.XPath("//*[@id='txtOrgName']"));
            Organization.SendKeys("Test");
            IWebElement createtenantbtn = driver.FindElement(By.XPath("//*[@id='btnCreateNewOrg']"));
            Assert.IsTrue(createtenantbtn.Text.Contains(" New Organization"));
            if (createtenantbtn.Text.Contains(" New Organization"))
            {
                Assert.Pass("Globaladmin is logged in correctly ");
            }
            else
            {
                Assert.Fail("Globaladmin is failed to login");
            }

        }

        [Test]
        public void _0001_GA_02_Validate_TenantCreation()
        {
            GALogin(ConfigurationManager.AppSettings["GAUsername"].ToString(), ConfigurationManager.AppSettings["GApassword"].ToString());
            Thread.Sleep(3000);
            IWebElement Organization = driver.FindElement(By.XPath(Constants.OrganisationName));
            Organization.SendKeys(ConfigProvider.GetConfigValue("OrganisationName"));
            IWebElement DepartmentName = driver.FindElement(By.XPath(Constants.DepartmentName));
            DepartmentName.SendKeys(ConfigProvider.GetConfigValue("DepartmentName"));
            IWebElement TimeZone = driver.FindElement(By.XPath("//*[@id='s2id_ddlTimeZone']/a/span[2]/b"));
            //TimeZone.Click();
            //waitForElement("Xpath", "//*[@id='select2 - drop']", 3000);
            //IReadOnlyList<IWebElement> Timezone1 = driver.FindElements(By.XPath("//*[@id='select2 - drop']"));
            
            //if (Timezone1.Count > 0)
            //{
            //    for (int i = 0; i < Timezone1.Count; i++)
            //    {
            //        string text = Timezone1[i].Text;
            //        if (Timezone1[i].Text.Contains("(GMT +11:00) Magadan, Solomon Islands, New Caledonia"))
            //        {
            //            Actions action = new Actions(driver);
            //            action.MoveToElement(Timezone1[i]);
            //            action.Perform();
            //            Timezone1[i].Click();
            //            break;
            //        }
            //    }
            //}

            IWebElement Primaryadmintab = driver.FindElement(By.XPath("//div[@id='jqxTabs']/div[1]/ul/li[4]/div/div[1]"));
            Primaryadmintab.Click();
            IWebElement FirstName = driver.FindElement(By.XPath(Constants.GAFirstName));
            FirstName.SendKeys(ConfigProvider.GetConfigValue("GAFirstName"));
            IWebElement LastName = driver.FindElement(By.XPath(Constants.GALastName));
            LastName.SendKeys(ConfigProvider.GetConfigValue("GALastName"));
            IWebElement Username = driver.FindElement(By.XPath(Constants.GAUserName1));
            Username.SendKeys(ConfigProvider.GetConfigValue("GAUserName1"));
            IWebElement LoginID = driver.FindElement(By.XPath(Constants.GALoginID));
            LoginID.Click();
            IWebElement LicenseTab = driver.FindElement(By.XPath("//div[@id='jqxTabs']/div[1]/ul/li[5]/div/div[1]"));
            LicenseTab.Click();
            IWebElement StartDate = driver.FindElement(By.XPath("//input[@id='txtSelectedStartDate']"));
            StartDate.SendKeys(ConfigProvider.GetConfigValue("StartDate"));
            IWebElement EndDate = driver.FindElement(By.XPath("//input[@id='txtSelectedEndDate']"));
            EndDate.SendKeys(ConfigProvider.GetConfigValue("EndDate"));
            IWebElement NoofServers = driver.FindElement(By.XPath("//input[@id='txtNoOfServer']"));
            NoofServers.SendKeys(ConfigProvider.GetConfigValue("NoofServers"));
            IWebElement SMTPtab = driver.FindElement(By.XPath(Constants.SMTPtab));
            SMTPtab.Click();
            IWebElement checkSMTP = driver.FindElement(By.XPath("//*[@id='defaultSmtp']"));
            checkSMTP.Click();
            IWebElement Savebtn = driver.FindElement(By.XPath("//button[@id='btnSaveOrg']"));
            Savebtn.Click();
            Thread.Sleep(4000);
            IWebElement Savebtn1 = driver.FindElement(By.XPath("//*[@id='btnDisplayMessage']"));
            Thread.Sleep(2000);
            Savebtn1.Click();       

        }

        [Test,Order(4)]
        public void _0001_GA_10_Validate_TenantCreation_defaultSMTP()
        {
            GALogin(ConfigurationManager.AppSettings["GAUsername"].ToString(), ConfigurationManager.AppSettings["GApassword"].ToString());
            Thread.Sleep(3000);
            IWebElement Organization = driver.FindElement(By.XPath(Constants.OrganisationName));
            Organization.SendKeys(ConfigProvider.GetConfigValue("OrganisationName"));
            IWebElement DepartmentName = driver.FindElement(By.XPath(Constants.DepartmentName));
            DepartmentName.SendKeys(ConfigProvider.GetConfigValue("DepartmentName"));
            IWebElement TimeZone = driver.FindElement(By.XPath("//*[@id='s2id_ddlTimeZone']/a/span[2]/b"));
            //TimeZone.Click();
            //waitForElement("Xpath", "//*[@id='select2 - drop']", 3000);
            //IReadOnlyList<IWebElement> Timezone1 = driver.FindElements(By.XPath("//*[@id='select2 - drop']"));

            //if (Timezone1.Count > 0)
            //{
            //    for (int i = 0; i < Timezone1.Count; i++)
            //    {
            //        string text = Timezone1[i].Text;
            //        if (Timezone1[i].Text.Contains("(GMT +11:00) Magadan, Solomon Islands, New Caledonia"))
            //        {
            //            Actions action = new Actions(driver);
            //            action.MoveToElement(Timezone1[i]);
            //            action.Perform();
            //            Timezone1[i].Click();
            //            break;
            //        }
            //    }
            //}

            IWebElement Primaryadmintab = driver.FindElement(By.XPath("//div[@id='jqxTabs']/div[1]/ul/li[4]/div/div[1]"));
            Primaryadmintab.Click();
            IWebElement FirstName = driver.FindElement(By.XPath(Constants.GAFirstName));
            FirstName.SendKeys(ConfigProvider.GetConfigValue("GAFirstName"));
            IWebElement LastName = driver.FindElement(By.XPath(Constants.GALastName));
            LastName.SendKeys(ConfigProvider.GetConfigValue("GALastName"));
            IWebElement Username = driver.FindElement(By.XPath(Constants.GAUserName1));
            Username.SendKeys(ConfigProvider.GetConfigValue("GAUserName1"));
            IWebElement LoginID = driver.FindElement(By.XPath(Constants.GALoginID));
            LoginID.Click();
            IWebElement LicenseTab = driver.FindElement(By.XPath("//div[@id='jqxTabs']/div[1]/ul/li[5]/div/div[1]"));
            LicenseTab.Click();
            IWebElement StartDate = driver.FindElement(By.XPath("//input[@id='txtSelectedStartDate']"));
            StartDate.SendKeys(ConfigProvider.GetConfigValue("StartDate"));
            IWebElement EndDate = driver.FindElement(By.XPath("//input[@id='txtSelectedEndDate']"));
            EndDate.SendKeys(ConfigProvider.GetConfigValue("EndDate"));
            IWebElement NoofServers = driver.FindElement(By.XPath("//input[@id='txtNoOfServer']"));
            NoofServers.SendKeys(ConfigProvider.GetConfigValue("NoofServers"));
            IWebElement SMTPtab = driver.FindElement(By.XPath(Constants.SMTPtab));
            SMTPtab.Click();
            IWebElement checkSMTP = driver.FindElement(By.XPath("//*[@id='defaultSmtp']"));
            checkSMTP.Click();
            checkSMTP.Click();
            IWebElement Savebtn = driver.FindElement(By.XPath("//button[@id='btnSaveOrg']"));
            Savebtn.Click();
            Thread.Sleep(4000);
            IWebElement Savebtn1 = driver.FindElement(By.XPath("//*[@id='btnDisplayMessage']"));
            Thread.Sleep(7000);
            Savebtn1.Click();
            //Thread.Sleep(480000);

        }

        [Test,Order(3)]
        public void _0001_GA_03_Validate_Edit_tenant()
        {
            GALogin(ConfigurationManager.AppSettings["GAUsername"].ToString(), ConfigurationManager.AppSettings["GApassword"].ToString());
            Thread.Sleep(3000);
            IReadOnlyList<IWebElement> tenantlist = driver.FindElements(By.XPath("//*[@id='contentgrdOrganizationList']"));
            if (tenantlist.Count >0)
            {
                for (int i=0;i<=tenantlist.Count+1; i++)
                {
                    IWebElement row = driver.FindElement(By.XPath("//*[@id='row"+i+"grdOrganizationList']"));
                    if (row.Text.Contains(ConfigProvider.GetConfigValue("EditTenant")))
                    {
                        row.Click();
                        Thread.Sleep(2000);
                        IWebElement LicenseTab = driver.FindElement(By.XPath("//div[@id='jqxTabs']/div[1]/ul/li[5]/div/div[1]"));
                        LicenseTab.Click();
                        Thread.Sleep(2000);
                        IWebElement EndDate = driver.FindElement(By.XPath("//input[@id='txtSelectedEndDate']"));
                        EndDate.Clear();
                        Thread.Sleep(2000);
                        EndDate.SendKeys(ConfigProvider.GetConfigValue("EditLicenseEndDate"));
                        IWebElement NoofServers = driver.FindElement(By.XPath("//input[@id='txtNoOfServer']"));
                        NoofServers.Clear();
                        Thread.Sleep(2000);
                        NoofServers.SendKeys(ConfigProvider.GetConfigValue("EditNoofServers"));
                        Thread.Sleep(2000);
                        IWebElement Savebtn = driver.FindElement(By.XPath("//*[@id='btnSaveOrg']"));
                        Savebtn.Click();
                        Thread.Sleep(2000);
                        Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                        ss.SaveAsFile(@"C:\Users\sundar.a\OneDrive - HCL Technologies Ltd\Arun\arun\Arun\HMC_Automation\Screenshot\Test.png", ScreenshotImageFormat.Png);
                        IWebElement Updateorganisation = driver.FindElement(By.XPath("//*[@id='windowDisplayMessage']"));
                        if (Updateorganisation.Text.Contains("Organization Details is saved successfully"))
                        {
                            IWebElement OKbt = driver.FindElement(By.XPath("//*[@id='btnDisplayMessage']"));
                            OKbt.Click();
                            Thread.Sleep(3000);
                        }
                    }

                }
            }
            

        }

        [Test]
        public void _0001_GA_04_Validate_Delete_Tenant()

        {
            GALogin(ConfigurationManager.AppSettings["GAUsername"].ToString(), ConfigurationManager.AppSettings["GApassword"].ToString());
            Thread.Sleep(3000);
            IReadOnlyList<IWebElement> tenantlist = driver.FindElements(By.XPath("//*[@id='contentgrdOrganizationList']"));
            if (tenantlist.Count > 0)
            {
                for (int i = 0; i <= tenantlist.Count + 1; i++)
                {
                    IWebElement row = driver.FindElement(By.XPath("//*[@id='row" + i + "grdOrganizationList']"));
                    if (row.Text.Contains(ConfigProvider.GetConfigValue("DeleteTenant")))
                    {
                        row.Click();
                        Thread.Sleep(2000);
                        IWebElement Deleteorg = driver.FindElement(By.XPath("//*[@id='btndeleteOrgdetail']"));
                        Deleteorg.Click();
                        Thread.Sleep(3000);
                        IWebElement deleteyes = driver.FindElement(By.XPath("//*[@id='btnConfirmationDialogYes']"));
                        deleteyes.Click();
                        //string Messagetext= deleteyes.Text;
                        //string[] split=  Messagetext.Split('(');
                        IWebElement deletesucessfully = driver.FindElement(By.XPath("//*[@id='windowDisplayMessage']"));
                        if(deletesucessfully.Text.Contains("Organization Details deleted successfully"))
                        {
                            IWebElement OKBtn = driver.FindElement(By.XPath("//*[@id='btnDisplayMessage']"));
                            Thread.Sleep(3000);
                            OKBtn.Click();
                            Thread.Sleep(3000);
                        }
                    }
                }
            }
        }

        [Test]
        public void _0001_GA_GASMTP_01_Validate_Save_SMTP()
        {
            GALogin(ConfigurationManager.AppSettings["GAUsername"].ToString(), ConfigurationManager.AppSettings["GApassword"].ToString());
            Thread.Sleep(3000);
            IWebElement SMTP = driver.FindElement(By.XPath("//*[@id='smtpConfigTab']/div"));
            SMTP.Click();
            Thread.Sleep(3000);
            IWebElement SMTPServerName = driver.FindElement(By.XPath(Constants.SMTPServerName));
            SMTPServerName.Clear();
            SMTPServerName.SendKeys(ConfigProvider.GetConfigValue("SMTPServerName"));
            //IWebElement SMTPServerPortNumber = driver.FindElement(By.XPath(Constants.SMTPPortNumber));
            //SMTPServerPortNumber.SendKeys(ConfigProvider.GetConfigValue("SMTPServerPortNumber"));
            IWebElement SMTPServerUserName = driver.FindElement(By.XPath(Constants.SMTPServerUserName));
            SMTPServerUserName.Clear();
            SMTPServerUserName.SendKeys(ConfigProvider.GetConfigValue("SMTPServerUserName"));
            IWebElement SMTPServerPassword = driver.FindElement(By.XPath(Constants.SMTPServerPassword));
            SMTPServerPassword.Clear();
            SMTPServerPassword.SendKeys(ConfigProvider.GetConfigValue("SMTPServerPassword"));
            IWebElement SAvebtn = driver.FindElement(By.XPath(Constants.Savebtn));
            SAvebtn.Click();
            IWebElement Alertmessage = driver.FindElement(By.XPath("//*[@id='windowDisplayMessageContent']"));
            IWebElement OKbtn = driver.FindElement(By.XPath("//*[@id='btnDisplayMessage']"));
            Thread.Sleep(3000);
            OKbtn.Click();

        }

        [Test,Order(2)]
        public void _0001_GA_GASMTP_02_Validate_Test_SMTP()
        {
            GALogin(ConfigurationManager.AppSettings["GAUsername"].ToString(), ConfigurationManager.AppSettings["GApassword"].ToString());
            Thread.Sleep(3000);
            IWebElement SMTP = driver.FindElement(By.XPath("//*[@id='smtpConfigTab']/div"));
            SMTP.Click();
            Thread.Sleep(3000);
            IWebElement Sendgridoff = driver.FindElement(By.XPath("//*[@id='divContentId']/div/div[3]/div[1]/div[2]/div/div"));
            if (Sendgridoff.Text.Contains("Enabled"))
            {
                Sendgridoff.Click();
            }
            IWebElement SMTPServerName = driver.FindElement(By.XPath(Constants.SMTPServerName));
            SMTPServerName.Clear();
            SMTPServerName.SendKeys(ConfigProvider.GetConfigValue("SMTPServerName"));
            IWebElement SMTPServerUserName = driver.FindElement(By.XPath(Constants.SMTPServerUserName));
            SMTPServerUserName.Clear();
            SMTPServerUserName.SendKeys(ConfigProvider.GetConfigValue("SMTPServerUserName"));
            IWebElement SMTPServerPassword = driver.FindElement(By.XPath(Constants.SMTPServerPassword));
            SMTPServerPassword.Clear();
            SMTPServerPassword.SendKeys(ConfigProvider.GetConfigValue("SMTPServerPassword"));
            IWebElement SAvebtn = driver.FindElement(By.XPath(Constants.Savebtn));
            SAvebtn.Click();
            IWebElement Alertmessage = driver.FindElement(By.XPath("//*[@id='windowDisplayMessageContent']"));
            IWebElement OKbtn = driver.FindElement(By.XPath("//*[@id='btnDisplayMessage']"));
            Thread.Sleep(3000);
            OKbtn.Click();
            Thread.Sleep(3000);
            IWebElement TestSMTP = driver.FindElement(By.XPath(Constants.TestSMTPbtn));
            TestSMTP.Click();
            IWebElement Testemail = driver.FindElement(By.XPath(Constants.Testemail));
            Testemail.SendKeys(ConfigProvider.GetConfigValue("TestEMail"));
            waitForElement("Xpath", "//input[@id='txtemailtoaddress']",3000);
            IWebElement TestEmailOKButton = driver.FindElement(By.XPath("//button[@id='saveToAddress']"));
            TestEmailOKButton.Click();
            

        }

        [Test,Order(1)]
        public void _0001_GA_05_Validate_globaladmincreation()
        {

            GALogin(ConfigurationManager.AppSettings["GAUsername"].ToString(), ConfigurationManager.AppSettings["GApassword"].ToString());
            Thread.Sleep(3000);
            IWebElement Globaladmincreation = driver.FindElement(By.XPath(Constants.Globaladmincreation));
            Globaladmincreation.Click();
            Thread.Sleep(3000);
            IWebElement Username = driver.FindElement(By.XPath(Constants.ADUserName));
            Username.SendKeys(ConfigProvider.GetConfigValue("GACUserName"));            
            IWebElement password1 = driver.FindElement(By.XPath(Constants.ADPassword));
            password1.SendKeys(ConfigProvider.GetConfigValue("GACpassword"));
            IWebElement Confirmpassword = driver.FindElement(By.XPath(Constants.ADconfirmpassword));
            Confirmpassword.SendKeys(ConfigProvider.GetConfigValue("GACconfirmpassword"));
            IWebElement FirstName = driver.FindElement(By.XPath(Constants.ADFirstName));
            FirstName.SendKeys(ConfigProvider.GetConfigValue("GACFirstName"));
            IWebElement LastName = driver.FindElement(By.XPath(Constants.ADLastName));
            LastName.SendKeys(ConfigProvider.GetConfigValue("GACLastName"));
            IWebElement Savebttn = driver.FindElement(By.XPath(Constants.ADSavebutton));
            Savebttn.Click();
            Thread.Sleep(3000);
            IWebElement OKBTTN = driver.FindElement(By.XPath("//*[@id='btnDisplayMessage']"));
            Thread.Sleep(2000);
            OKBTTN.Click();
            Thread.Sleep(2000);

        }


        [Test]
        public void _0001_GA_DTSMTP_01_Validate_Save_SMTP()
        {

            GALogin(ConfigurationManager.AppSettings["GAUsername"].ToString(), ConfigurationManager.AppSettings["GApassword"].ToString());
            Thread.Sleep(3000);
            IWebElement SMTP = driver.FindElement(By.XPath("//*[@id='tenantSmtpTab']/div"));
            SMTP.Click();
            Thread.Sleep(2000);
            IWebElement SendGrid = driver.FindElement(By.XPath("//*[@id='divContentId']/div/div[3]/div[1]/div[2]/div/div/label[1]"));
            SendGrid.Click();
            IWebElement SMTPServerName = driver.FindElement(By.XPath(Constants.TenantSMTPServerName));
            SMTPServerName.Clear();
            SMTPServerName.SendKeys(ConfigProvider.GetConfigValue("TenantSMTPserverName"));
            IWebElement SMTPServerUserName = driver.FindElement(By.XPath(Constants.TenantSMTPServerUserName));
            SMTPServerUserName.Clear();
            SMTPServerUserName.SendKeys(ConfigProvider.GetConfigValue("TenantSMTPserverUserName"));
            IWebElement SMTPServerPassword = driver.FindElement(By.XPath(Constants.TenantSMTPServerPassword));
            SMTPServerPassword.Clear();
            SMTPServerPassword.SendKeys(ConfigProvider.GetConfigValue("TenantSMTPServerPassword"));
            IWebElement Savebtn = driver.FindElement(By.XPath(Constants.TenantSavebtn));
            Savebtn.Click();
            Thread.Sleep(2000);            
            IWebElement OKbt = driver.FindElement(By.XPath("//*[@id='btnDisplayMessage']"));
            OKbt.Click();

        }

        [Test,Order(3)]
        public void _0001_GA_DTSMTP_02_Validate_Test_SMTP()
        {
            GALogin(ConfigurationManager.AppSettings["GAUsername"].ToString(), ConfigurationManager.AppSettings["GApassword"].ToString());
            Thread.Sleep(3000);
            IWebElement SMTP = driver.FindElement(By.XPath("//*[@id='tenantSmtpTab']/div"));
            SMTP.Click();
            Thread.Sleep(3000);
            IWebElement SendGridoff = driver.FindElement(By.XPath("//*[@id='divContentId']/div/div[3]/div[1]/div[2]/div"));
            if (SendGridoff.Text.Contains("Enabled "))
            {
                SendGridoff.Click();
            }
            IWebElement SMTPServerName = driver.FindElement(By.XPath(Constants.TenantSMTPServerName));
            SMTPServerName.Clear();
            SMTPServerName.SendKeys(ConfigProvider.GetConfigValue("TenantSMTPserverName"));
            IWebElement SMTPServerUserName = driver.FindElement(By.XPath(Constants.TenantSMTPServerUserName));
            SMTPServerUserName.Clear();
            SMTPServerUserName.SendKeys(ConfigProvider.GetConfigValue("TenantSMTPserverUserName"));
            IWebElement SMTPServerPassword = driver.FindElement(By.XPath(Constants.TenantSMTPServerPassword));
            SMTPServerPassword.Clear();
            SMTPServerPassword.SendKeys(ConfigProvider.GetConfigValue("TenantSMTPServerPassword"));
            IWebElement Savebtn = driver.FindElement(By.XPath(Constants.TenantSavebtn));
            Savebtn.Click();
            Thread.Sleep(2000);
            IWebElement OKbt = driver.FindElement(By.XPath("//input[@id='btnDisplayMessage']"));            
            OKbt.Click();
            Thread.Sleep(2000);
            IWebElement Test1 = driver.FindElement(By.XPath(Constants.TenantTestemail));
            Test1.Click();
            Thread.Sleep(2000);
            IWebElement TestEmailtxt = driver.FindElement(By.XPath(Constants.TestEmailtxt));
            TestEmailtxt.SendKeys(ConfigProvider.GetConfigValue("TestEmailtxt"));
            IWebElement OKB = driver.FindElement(By.XPath("//button[@id='saveToAddress']"));            
            OKB.Click();
            Thread.Sleep(2000);
            IWebElement mailsent = driver.FindElement(By.XPath("//input[@id='btnDisplayMessage']"));
            mailsent.Click();

        }

    }
}
