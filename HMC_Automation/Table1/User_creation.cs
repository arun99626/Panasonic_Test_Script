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
    public class User_creation : TestBase
    {
        private string configurationmanager;
        private int i;

        //Verify to display User creation page
        [Test]
        public void _0003_UC_01_Validate_Usercreation_page()
        {
            //login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigurationManager.AppSettings["PASSWORD"].ToString());
            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));
            IWebElement Dash = driver.FindElement(By.XPath(Constants.Dashboard));
            IWebElement settings = driver.FindElement(By.XPath("//li[@id='dvSettings']/a"));
            settings.Click();
            waitForElement("XPATH", Constants.Userdropdown, 5);
            IWebElement Usertab = driver.FindElement(By.XPath(Constants.Userdropdown));
            if (Usertab.Text.Contains("Users"))
            {
                Assert.Pass("User creation page is displayed");
            }
            else
            {
                Assert.Fail("User creation page is not displayed");
            }
        }
        // Verify to display all fields in User creation page
        [Test]
        public void _0003_UC_02_Validate_Create_User_Button()
        {
            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));
            IWebElement Dash = driver.FindElement(By.XPath(Constants.Dashboard));
            IWebElement settings = driver.FindElement(By.XPath(Constants.Settings));
            settings.Click();
            waitForElement("xpath", Constants.Userdropdown, 20);
            IWebElement Usertab = driver.FindElement(By.XPath(Constants.Userdropdown));
            Usertab.Click();
            Thread.Sleep(2000);
            waitForElement("xpath", Constants.CreateButton, 20);
            string result = string.Empty;
            if (driver.FindElement(By.XPath(Constants.CreateButton)).Displayed)
            {
                result = "Create button is available in user creation page /n";
            }
            else
            {
                result = " Failed - Create button is not available in user creation page /n";
            }
            if (driver.FindElement(By.XPath(Constants.EmailID)).Displayed)
            {
                result = result + "Email id field is available in user creation page /n";
            }
            else
            {
                result = result + "  Failed - Email id field is not available in user creation page /n";
            }

            if (driver.FindElement(By.XPath(Constants.SaveBtn)).Displayed)
            {
                result = result + "SaveBtn field is available in user creation page /n";
            }
            else
            {
                result = result + " Failed - SaveBtn field is not available in user creation page /n";
            }

            if (result.Contains("Failed"))
            {
                Assert.Fail(result);
            }
            else
            {
                Assert.Pass(result);
            }
        }
        [Test,Order(1)]
        public void _0003_UC_03_Validate_Create_New_Admin()
        {
            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));                                           
            IWebElement Dash = driver.FindElement(By.XPath(Constants.Dashboard));
            UesrcreationEntries("Admin");
        }

        [Test]
        public void _0003_UC_04_Validate_Create_New_User()
        {
            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));
            IWebElement Dash = driver.FindElement(By.XPath(Constants.Dashboard));
            UesrcreationEntries("User");

        }

        [Test,Order(2)]
        public void _0003_UC_05_Validate_Edit_Users()
        {
            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));
            IWebElement Dash = driver.FindElement(By.XPath(Constants.Dashboard));
            Thread.Sleep(3000);
            IWebElement settings = driver.FindElement(By.XPath(Constants.Settings));
            settings.Click();
            waitForElement("xpath", Constants.Userdropdown, 20);
            IWebElement Usertab = driver.FindElement(By.XPath(Constants.Userdropdown));
            Usertab.Click();
            Thread.Sleep(3000);
            IWebElement openlist = driver.FindElement(By.XPath("//*[@id='dvUserGrid']/span"));
            openlist.Click();
            Thread.Sleep(3000);
            IReadOnlyList<IWebElement> Userlistdelete = driver.FindElements(By.XPath("//*[@id='contentgrdUserList']"));
            var Deleteuser = Userlistdelete.SingleOrDefault().Text.Replace("\r\n", ",").Split(',');
            if (Deleteuser.Count() > 0)
            {
                for (int i=0; i<= Deleteuser.Count();i++)
                {
                    IWebElement SelectUser = driver.FindElement(By.XPath("//*[@id='row"+ i +"grdUserList']"));
                    if (SelectUser.Text.Contains(ConfigProvider.GetConfigValue("EditUserfromlist")))
                    {
                        SelectUser.Click();
                        
                    }

                }

            }
            IWebElement FirstName = driver.FindElement(By.XPath("//*[@id='txtFirstName']"));
            Thread.Sleep(3000);
            FirstName.Clear();
            FirstName.SendKeys(ConfigProvider.GetConfigValue("EditFirstName"));
            IWebElement LastName = driver.FindElement(By.XPath("//*[@id='txtLastName']"));
            Thread.Sleep(3000);
            LastName.Clear();
            LastName.SendKeys(ConfigProvider.GetConfigValue("EditLastName"));            
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            IWebElement SaveBtn = driver.FindElement(By.XPath("//*[@id='btnSave']"));
            SaveBtn.Click();
            IWebElement editsuccessfully = driver.FindElement(By.XPath("//*[@id='windowDisplayMessage']"));
            if (editsuccessfully.Text.Contains("User Details saved successfully."))
            {
                IWebElement Okbutton = driver.FindElement(By.XPath("//*[@id='windowDisplayMessageContent']/div[3]"));
                Okbutton.Click();
                Thread.Sleep(3000);
            }

        }
        [Test,Order(3)]
        public void _0003_UC_06_Validate_Delete_Users()
        {
            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));
            IWebElement Dash = driver.FindElement(By.XPath(Constants.Dashboard));
            Thread.Sleep(3000);
            IWebElement settings = driver.FindElement(By.XPath(Constants.Settings));
            settings.Click();
            waitForElement("xpath", Constants.Userdropdown, 20);
            IWebElement Usertab = driver.FindElement(By.XPath(Constants.Userdropdown));
            Usertab.Click();
            Thread.Sleep(2000);
            IWebElement openlist = driver.FindElement(By.XPath("//*[@id='dvUserGrid']/span"));
            Thread.Sleep(2000);
            openlist.Click();
            IReadOnlyList<IWebElement> Userlistdelete = driver.FindElements(By.XPath("//*[@id='contentgrdUserList']"));
            var Deleteuser = Userlistdelete.SingleOrDefault().Text.Replace("\r\n", ",").Split(',');
            if (Deleteuser.Count() > 0)
            {
                for (int i = 0; i <= Deleteuser.Count(); i++)
                {
                    IWebElement SelectUser = driver.FindElement(By.XPath("//*[@id='row" + i + "grdUserList']"));
                    if (SelectUser.Text.Contains(ConfigProvider.GetConfigValue("Deleteusers")))
                    {
                        SelectUser.Click();

                    }

                }

            }
            IWebElement FirstName = driver.FindElement(By.XPath("//*[@id='txtFirstName']"));
            FirstName.Click();
            IWebElement LastName = driver.FindElement(By.XPath("//*[@id='txtFirstName']"));
            LastName.Click();
            IWebElement FirsPhonenumber = driver.FindElement(By.XPath("//*[@id='txtPhoneNumber']"));
            Thread.Sleep(2000);
            FirsPhonenumber.SendKeys("123456789");
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            IWebElement Deleteusers = driver.FindElement(By.XPath("//*[@id='lnkDelete']"));
            Deleteusers.Click();
            IWebElement deleteyes = driver.FindElement(By.XPath("//*[@id='window']"));
            if (deleteyes.Text.Contains("Do you really want to delete User: (Sumitha A) ?"))
            {
                IWebElement Deleteconfirm = driver.FindElement(By.XPath("//*[@id='btnConfirmationDialogYes']"));
                Deleteconfirm.Click();
            }
            Thread.Sleep(2000);
            IWebElement deletecon = driver.FindElement(By.XPath("//*[@id='windowDisplayMessage']"));
            if (deletecon!=null)
            {
                IWebElement delOK = driver.FindElement(By.XPath("//*[@id='btnConfirmationDialogYes']"));
                delOK.Click();
                Thread.Sleep(3000);
                IWebElement deletedsuccessfully = driver.FindElement(By.XPath("//*[@id='windowDisplayMessage']"));
                if (deletedsuccessfully != null)
                {
                    IWebElement deleteOK = driver.FindElement(By.XPath("//*[@id='windowDisplayMessageContent']/div[3]"));
                    deleteOK.Click();
                }
            }
            Thread.Sleep(3000);
        }


        public void UesrcreationEntries(string type)
        {
            Thread.Sleep(3000);
            IWebElement Termsandcondition = driver.FindElement(By.XPath("//*[@id='firstLoginTermsConditionModal']/div/div/div[1]"));
            if (Termsandcondition.Text.Contains("Software License Agreement"))
            {
                IWebElement Savebtn = driver.FindElement(By.XPath("//*[@id='saveTermsandcondn']"));
                Savebtn.Click();                
            }
            Thread.Sleep(3000);
            IWebElement PasswordChange = driver.FindElement(By.XPath("//*[@id='pwdChangePopup']/div/div/div[1]"));
            if (PasswordChange.Text.Contains("Change Your Password"))
            {
                IWebElement Oldpassword = driver.FindElement(By.XPath(Constants.Oldpassword));
                Oldpassword.SendKeys(ConfigProvider.GetConfigValue("OldPassword"));
                IWebElement Newpassword = driver.FindElement(By.XPath(Constants.NewPassword));
                Newpassword.SendKeys(ConfigProvider.GetConfigValue("NewPassword"));
                IWebElement ConfirmNewpassword = driver.FindElement(By.XPath(Constants.ConfirmNewPassword));
                ConfirmNewpassword.SendKeys(ConfigProvider.GetConfigValue("ConfirmNewpassword"));
                IWebElement Savebutton = driver.FindElement(By.XPath("//*[@id='btnchangepwdSave']"));
                Savebutton.Click();
                Thread.Sleep(4000);
                IWebElement CPOK = driver.FindElement(By.XPath("//*[@id='windowDisplayMessageContent']/div[3]"));
                CPOK.Click();
                Thread.Sleep(3000);
                IWebElement Username1 = driver.FindElement(By.XPath("//*[@id='txtLoginID']"));
                Username1.SendKeys(ConfigProvider.GetConfigValue("USERNAME"));
                IWebElement password1 = driver.FindElement(By.XPath("//*[@id='txtPassword']"));
                password1.SendKeys(ConfigProvider.GetConfigValue("ConfirmNewpassword"));
                IWebElement Loginbtn = driver.FindElement(By.XPath("//*[@id='btnLogin']"));
                Loginbtn.Click();
            }
            Thread.Sleep(3000);
            IWebElement settings = driver.FindElement(By.XPath(Constants.Settings));
            settings.Click();
            Thread.Sleep(3000);
            //waitForElement("xpath", Constants.Userdropdown, 20);
            IWebElement Usertab = driver.FindElement(By.XPath(Constants.Userdropdown));
            Usertab.Click();
            Thread.Sleep(2000);
            //waitForElement("xpath", Constants.CreateButton, 20);
            IWebElement FirstName = driver.FindElement(By.XPath(Constants.FirstName));
            FirstName.SendKeys(ConfigProvider.GetConfigValue("First_Name"));
            IWebElement LastName = driver.FindElement(By.XPath(Constants.LastName));
            LastName.SendKeys(ConfigProvider.GetConfigValue("Last_Name"));
            IWebElement EmailID = driver.FindElement(By.XPath(Constants.EmailID));
            EmailID.SendKeys(ConfigProvider.GetConfigValue("EmailID"));
            IWebElement Password1 = driver.FindElement(By.XPath(Constants.Password1));
            Password1.SendKeys(ConfigProvider.GetConfigValue("Password1"));
            IWebElement ConfirmPassword = driver.FindElement(By.XPath(Constants.ConfirmPassword));
            ConfirmPassword.SendKeys(ConfigProvider.GetConfigValue("Confirm_Password"));
            IWebElement Description = driver.FindElement(By.XPath(Constants.Description));
            Description.SendKeys(ConfigProvider.GetConfigValue("Description"));
            IWebElement UserGroup = driver.FindElement(By.XPath(Constants.UserGroup));
            UserGroup.Click();
            Thread.Sleep(2000);
            IReadOnlyList<IWebElement> Usergroups = driver.FindElements(By.XPath("//div[@id='listBoxContentinnerListBoxddlUserGroups']/div/div"));
            for (int i = 0; i <= Usergroups.Count; i++)
            {
                if (Usergroups[i].Text.Contains(type))
                {
                    Usergroups[i].Click();
                    break;
                }
            }
            IWebElement AssignGroupBtn = driver.FindElement(By.Id("btnAddUserGroup"));
            AssignGroupBtn.Click();
            IWebElement SupportContactEmail = driver.FindElement(By.XPath(Constants.SupportContactEmail));
            SupportContactEmail.SendKeys(ConfigProvider.GetConfigValue("SupportContactEmail1"));
            //driver.FindElement(By.Id("txtSupportContactEmail")).SendKeys(ConfigProvider.GetConfigValue("EmailID"));
            driver.FindElement(By.XPath("//div[@id='ddlusertimezone']/div/div/div")).Click();
            waitForElement("XPATH", "//div[@id='listBoxContentinnerListBoxddlusertimezone']/div", 50);            
            IReadOnlyList<IWebElement> timezones = driver.FindElements(By.XPath("//div[@id='listBoxContentinnerListBoxddlusertimezone']/div/div"));
            if (timezones.Count > 0)
            {
                for (int i = 0; i < timezones.Count; i++)
                {

                    string text = timezones[i].Text;

                    if (timezones[i].Text.Contains("(GMT-08:00) Pacific Time (US & Canada)"))
                    {
                        Actions action = new Actions(driver);
                        action.MoveToElement(timezones[i]);
                        action.Perform();
                        timezones[i].Click();
                        break;
                    }
                }

            }       
            IWebElement SaveButton = driver.FindElement(By.XPath(Constants.SaveBtn));
            SaveButton.Click();
            Thread.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.Id("displayMessageText")).Text.Contains("User Details saved successfully."));
            Thread.Sleep(3000);
            IWebElement OkButton = driver.FindElement(By.Id("btnDisplayMessage"));
            Thread.Sleep(5000);
            OkButton.Click();
            Thread.Sleep(3000);
        }

        [Test]
        public void _0003_UC_05_Validate_FirstName()

        {
            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));
            IWebElement Dash = driver.FindElement(By.XPath(Constants.Dashboard));
            IWebElement settings = driver.FindElement(By.XPath(Constants.Settings));
            settings.Click();
            waitForElement("xpath", Constants.Userdropdown, 20);
            IWebElement Usertab = driver.FindElement(By.XPath(Constants.Userdropdown));
            Usertab.Click();
            Thread.Sleep(2000);
            waitForElement("xpath", Constants.CreateButton, 20);
            IWebElement FirstName = driver.FindElement(By.XPath(Constants.FirstName));
            FirstName.SendKeys(ConfigProvider.GetConfigValue("First_Name"));
            IWebElement LastName = driver.FindElement(By.XPath(Constants.LastName));
            LastName.SendKeys(ConfigProvider.GetConfigValue("Last_Name"));
            IWebElement EmailID = driver.FindElement(By.XPath(Constants.EmailID));
            EmailID.SendKeys(ConfigProvider.GetConfigValue("EmailID"));
            IWebElement Password1 = driver.FindElement(By.XPath(Constants.Password1));
            Password1.SendKeys(ConfigProvider.GetConfigValue("Password1"));
            IWebElement ConfirmPassword = driver.FindElement(By.XPath(Constants.ConfirmPassword));
            ConfirmPassword.SendKeys(ConfigProvider.GetConfigValue("Confirm_Password"));
            IWebElement Description = driver.FindElement(By.XPath(Constants.Description));
            Description.SendKeys(ConfigProvider.GetConfigValue("Description"));
            IWebElement UserGroup = driver.FindElement(By.XPath(Constants.UserGroup));
            UserGroup.Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='listitem1innerListBoxddlUserGroups']/span")).Click();
            IWebElement AssignGroupBtn = driver.FindElement(By.XPath(Constants.AssignGroupBtn));
            AssignGroupBtn.Click();
            IWebElement SupportContactEmail = driver.FindElement(By.XPath(Constants.SupportContactEmail));
            SupportContactEmail.SendKeys(ConfigProvider.GetConfigValue("SupportContactEmail1"));

            driver.FindElement(By.XPath("//div[@id='ddlusertimezone']/div/div/div")).Click();
            waitForElement("XPATH", "//div[@id='listBoxContentinnerListBoxddlusertimezone']/div", 5000);
            IReadOnlyList<IWebElement> timezones= driver.FindElements(By.XPath("//div[@id='listBoxContentinnerListBoxddlusertimezone']/div/div"));
            if (timezones.Count > 0)
            {
                for (i= 0; i < timezones.Count; i ++)
                {
                    string text = timezones[i].Text;
                    if (timezones[i].Text.Contains("(GMT-08:00) Pacific Time (US & Canada)"))
                    {
                        Actions action = new Actions(driver);
                        action.MoveToElement(timezones[i]);
                        action.Perform();
                        timezones[i].Click();                                                
                    }
                }
            }

            IWebElement SaveButton = driver.FindElement(By.XPath(Constants.SaveBtn));
            SaveButton.Click();
            waitForElement("ID", "displayMessageText",5000);
            Assert.IsTrue(driver.FindElement(By.Id("displayMessageText")).Text.Contains("User created successfully"));
            IWebElement OkButton = driver.FindElement(By.Id("btnDisplayMessage"));
            OkButton.Click();
            if (FirstName.Text.Contains("Some of the mandatory fields are missing. Please provide input and try again."))
            {
                Assert.Pass("First Name field mandatory validation is Pass");
            }
            else
            {
                //Assert.Fail("First Name field mandatory validation is Fail");
            }
            driver.FindElement(By.XPath("//input[@id='btnDisplayMessage']")).Click();

        }

        [Test]
        public void _0003_UC_06_Validate_LastName()

        {
            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));
            IWebElement Dash = driver.FindElement(By.XPath(Constants.Dashboard));
            IWebElement settings = driver.FindElement(By.XPath(Constants.Settings));
            settings.Click();
            waitForElement("xpath", Constants.Userdropdown, 20);
            IWebElement Usertab = driver.FindElement(By.XPath(Constants.Userdropdown));
            Usertab.Click();
            Thread.Sleep(2000);
            waitForElement("xpath", Constants.CreateButton, 20);
            IWebElement FirstName = driver.FindElement(By.XPath(Constants.FirstName));
            FirstName.SendKeys(ConfigProvider.GetConfigValue("First_Name"));
            IWebElement LastName = driver.FindElement(By.XPath(Constants.LastName));
            LastName.SendKeys(ConfigProvider.GetConfigValue("Last_Name"));
            IWebElement EmailID = driver.FindElement(By.XPath(Constants.EmailID));
            EmailID.SendKeys(ConfigProvider.GetConfigValue("EmailID"));
            IWebElement Password1 = driver.FindElement(By.XPath(Constants.Password1));
            Password1.SendKeys(ConfigProvider.GetConfigValue("Password1"));
            IWebElement ConfirmPassword = driver.FindElement(By.XPath(Constants.ConfirmPassword));
            ConfirmPassword.SendKeys(ConfigProvider.GetConfigValue("Confirm_Password"));
            IWebElement Description = driver.FindElement(By.XPath(Constants.Description));
            Description.SendKeys(ConfigProvider.GetConfigValue("Description"));
            IWebElement UserGroup = driver.FindElement(By.XPath(Constants.UserGroup));
            UserGroup.Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='listitem1innerListBoxddlUserGroups']/span")).Click();
            IWebElement AssignGroupBtn = driver.FindElement(By.XPath(Constants.AssignGroupBtn));
            AssignGroupBtn.Click();
            IWebElement SupportContactEmail = driver.FindElement(By.XPath(Constants.SupportContactEmail));
            SupportContactEmail.SendKeys(ConfigProvider.GetConfigValue("SupportContactEmail1"));

            driver.FindElement(By.XPath("//div[@id='ddlusertimezone']/div/div/div")).Click();
            waitForElement("XPATH", "//div[@id='listBoxContentinnerListBoxddlusertimezone']/div", 5000);
            IReadOnlyList<IWebElement> timezones = driver.FindElements(By.XPath("//div[@id='listBoxContentinnerListBoxddlusertimezone']/div/div"));
            if (timezones.Count > 0)
            {
                for (i = 0; i < timezones.Count; i++)
                {
                    string text = timezones[i].Text;
                    if (timezones[i].Text.Contains("(GMT-08:00) Pacific Time (US & Canada)"))
                    {
                        Actions action = new Actions(driver);
                        action.MoveToElement(timezones[i]);
                        action.Perform();
                        timezones[i].Click();

                    }
                }
            }
            IWebElement SaveButton = driver.FindElement(By.XPath(Constants.SaveBtn));
            SaveButton.Click();

            if (FirstName.Text.Contains("Some of the mandatory fields are missing. Please provide input and try again."))
            {
                Assert.Pass("Last Name field mandatory validation is Pass");
            }
            else
            {
                
            }
            driver.FindElement(By.XPath("//input[@id='btnDisplayMessage']")).Click();

        }

        [Test]
        public void _0003_UC_07_Validate_Password()

        {
            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));
            IWebElement Dash = driver.FindElement(By.XPath(Constants.Dashboard));
            IWebElement settings = driver.FindElement(By.XPath(Constants.Settings));
            settings.Click();
            waitForElement("xpath", Constants.Userdropdown, 20);
            IWebElement Usertab = driver.FindElement(By.XPath(Constants.Userdropdown));
            Usertab.Click();
            Thread.Sleep(2000);
            waitForElement("xpath", Constants.CreateButton, 20);
            IWebElement FirstName = driver.FindElement(By.XPath(Constants.FirstName));
            FirstName.SendKeys(ConfigProvider.GetConfigValue("First_Name"));
            IWebElement LastName = driver.FindElement(By.XPath(Constants.LastName));
            LastName.SendKeys(ConfigProvider.GetConfigValue("Last_Name"));
            IWebElement EmailID = driver.FindElement(By.XPath(Constants.EmailID));
            EmailID.SendKeys(ConfigProvider.GetConfigValue("EmailID"));
            IWebElement Password1 = driver.FindElement(By.XPath(Constants.Password1));
            Password1.SendKeys(ConfigProvider.GetConfigValue("Password1"));
            IWebElement ConfirmPassword = driver.FindElement(By.XPath(Constants.ConfirmPassword));
            ConfirmPassword.SendKeys(ConfigProvider.GetConfigValue("Confirm_Password"));
            IWebElement Description = driver.FindElement(By.XPath(Constants.Description));
            Description.SendKeys(ConfigProvider.GetConfigValue("Description"));
            IWebElement UserGroup = driver.FindElement(By.XPath(Constants.UserGroup));
            UserGroup.Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='listitem1innerListBoxddlUserGroups']/span")).Click();
            IWebElement AssignGroupBtn = driver.FindElement(By.XPath(Constants.AssignGroupBtn));
            AssignGroupBtn.Click();
            IWebElement SupportContactEmail = driver.FindElement(By.XPath(Constants.SupportContactEmail));
            SupportContactEmail.SendKeys(ConfigProvider.GetConfigValue("SupportContactEmail1"));

            driver.FindElement(By.XPath("//div[@id='ddlusertimezone']/div/div/div")).Click();
            waitForElement("XPATH", "//div[@id='listBoxContentinnerListBoxddlusertimezone']/div", 5000);
            IReadOnlyList<IWebElement> timezones = driver.FindElements(By.XPath("//div[@id='listBoxContentinnerListBoxddlusertimezone']/div/div"));
            if (timezones.Count > 0)
            {
                for (i = 0; i < timezones.Count; i++)
                {
                    string text = timezones[i].Text;
                    if (timezones[i].Text.Contains("(GMT-08:00) Pacific Time (US & Canada)"))
                    {
                        Actions action = new Actions(driver);
                        action.MoveToElement(timezones[i]);
                        action.Perform();
                        timezones[i].Click();

                    }
                }
            }
            IWebElement SaveButton = driver.FindElement(By.XPath(Constants.SaveBtn));
            SaveButton.Click();

            if (FirstName.Text.Contains("Some of the mandatory fields are missing. Please provide input and try again."))
            {
                Assert.Pass("Password field mandatory validation is Pass");
            }
            else
            {

            }
            driver.FindElement(By.XPath("//input[@id='btnDisplayMessage']")).Click();

        }

        [Test]
        public void _0003_UC_08_Validate_ConfirmPassword()

        {
            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));
            IWebElement Dash = driver.FindElement(By.XPath(Constants.Dashboard));
            IWebElement settings = driver.FindElement(By.XPath(Constants.Settings));
            settings.Click();
            waitForElement("xpath", Constants.Userdropdown, 20);
            IWebElement Usertab = driver.FindElement(By.XPath(Constants.Userdropdown));
            Usertab.Click();
            Thread.Sleep(2000);
            waitForElement("xpath", Constants.CreateButton, 20);
            IWebElement FirstName = driver.FindElement(By.XPath(Constants.FirstName));
            FirstName.SendKeys(ConfigProvider.GetConfigValue("First_Name"));
            IWebElement LastName = driver.FindElement(By.XPath(Constants.LastName));
            LastName.SendKeys(ConfigProvider.GetConfigValue("Last_Name"));
            IWebElement EmailID = driver.FindElement(By.XPath(Constants.EmailID));
            EmailID.SendKeys(ConfigProvider.GetConfigValue("EmailID"));
            IWebElement Password1 = driver.FindElement(By.XPath(Constants.Password1));
            Password1.SendKeys(ConfigProvider.GetConfigValue("Password1"));
            IWebElement ConfirmPassword = driver.FindElement(By.XPath(Constants.ConfirmPassword));
            ConfirmPassword.SendKeys(ConfigProvider.GetConfigValue("Confirm_Password"));
            IWebElement Description = driver.FindElement(By.XPath(Constants.Description));
            Description.SendKeys(ConfigProvider.GetConfigValue("Description"));
            IWebElement UserGroup = driver.FindElement(By.XPath(Constants.UserGroup));
            UserGroup.Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='listitem1innerListBoxddlUserGroups']/span")).Click();
            IWebElement AssignGroupBtn = driver.FindElement(By.XPath(Constants.AssignGroupBtn));
            AssignGroupBtn.Click();
            IWebElement SupportContactEmail = driver.FindElement(By.XPath(Constants.SupportContactEmail));
            SupportContactEmail.SendKeys(ConfigProvider.GetConfigValue("SupportContactEmail1"));

            driver.FindElement(By.XPath("//div[@id='ddlusertimezone']/div/div/div")).Click();
            waitForElement("XPATH", "//div[@id='listBoxContentinnerListBoxddlusertimezone']/div", 5000);
            IReadOnlyList<IWebElement> timezones = driver.FindElements(By.XPath("//div[@id='listBoxContentinnerListBoxddlusertimezone']/div/div"));
            if (timezones.Count > 0)
            {
                for (i = 0; i < timezones.Count; i++)
                {
                    string text = timezones[i].Text;
                    if (timezones[i].Text.Contains("(GMT-08:00) Pacific Time (US & Canada)"))
                    {
                        Mousehover(timezones[i]);                                        
                        timezones[i].Click();

                    }
                }
            }
            IWebElement SaveButton = driver.FindElement(By.XPath(Constants.SaveBtn));
            Mousehover(SaveButton);                      
            SaveButton.Click();

            if (FirstName.Text.Contains("Some of the mandatory fields are missing. Please provide input and try again."))
            {
                Assert.Pass("Confirm Password field mandatory validation is Pass");
            }
            else
            {

            }
            driver.FindElement(By.XPath("//input[@id='btnDisplayMessage']")).Click();

            }

        [Test]
        public void _0003_UC_09_Validate_UserGroup()
        {
            login(ConfigProvider.GetConfigValue(Constants.UserName), ConfigProvider.GetConfigValue(Constants.password));
            IWebElement Dash = driver.FindElement(By.XPath(Constants.Dashboard));
            IWebElement settings = driver.FindElement(By.XPath(Constants.Settings));
            settings.Click();
            waitForElement("xpath", Constants.Userdropdown, 20);
            IWebElement Usertab = driver.FindElement(By.XPath(Constants.Userdropdown));
            Usertab.Click();
            Thread.Sleep(2000);
            waitForElement("xpath", Constants.CreateButton, 20);
            IWebElement FirstName = driver.FindElement(By.XPath(Constants.FirstName));
            FirstName.SendKeys(ConfigProvider.GetConfigValue("First_Name"));
            IWebElement LastName = driver.FindElement(By.XPath(Constants.LastName));
            LastName.SendKeys(ConfigProvider.GetConfigValue("Last_Name"));
            IWebElement EmailID = driver.FindElement(By.XPath(Constants.EmailID));
            EmailID.SendKeys(ConfigProvider.GetConfigValue("EmailID"));
            IWebElement Password1 = driver.FindElement(By.XPath(Constants.Password1));
            Password1.SendKeys(ConfigProvider.GetConfigValue("Password1"));
            IWebElement ConfirmPassword = driver.FindElement(By.XPath(Constants.ConfirmPassword));
            ConfirmPassword.SendKeys(ConfigProvider.GetConfigValue("Confirm_Password"));
            IWebElement Description = driver.FindElement(By.XPath(Constants.Description));
            Description.SendKeys(ConfigProvider.GetConfigValue("Description"));
            IWebElement UserGroup = driver.FindElement(By.XPath(Constants.UserGroup));
            UserGroup.Click();
            Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//*[@id='listitem1innerListBoxddlUserGroups']/span")).Click();
            IWebElement AssignGroupBtn = driver.FindElement(By.XPath(Constants.AssignGroupBtn));
            AssignGroupBtn.Click();
            IWebElement UserGroupokbtn = driver.FindElement(By.XPath("//div[@id='windowDisplayMessage']/div[2]/div[3]/input"));
            waitForElement("xpath", "//div[@id='windowDisplayMessage']/div[2]/div[3]/input",5000);
            UserGroupokbtn.Click();
            IWebElement SupportContactEmail = driver.FindElement(By.XPath(Constants.SupportContactEmail));
            SupportContactEmail.SendKeys(ConfigProvider.GetConfigValue("SupportContactEmail1"));
            driver.FindElement(By.XPath("//div[@id='dropdownlistWrapperddlusertimezone']/div[2]/div")).Click();
            //waitForElement("XPATH", "//div[@id='listBoxContentinnerListBoxddlusertimezone']/div", 5000);
            waitForElement("XPATH", "//div[@id='listBoxddlusertimezone']/div/div/div/div[@id='listBoxContentinnerListBoxddlusertimezone']/div/div", 5000);
            IReadOnlyList<IWebElement> timezones = driver.FindElements(By.XPath("//div[@id='listBoxddlusertimezone']/div/div/div/div[@id='listBoxContentinnerListBoxddlusertimezone']/div/div"));
            if (timezones.Count > 0)
            {
                for (i = 0; i < timezones.Count; i++)
                {
                    string text = timezones[i].Text;
                    if (timezones[i].Text.Contains("(GMT-08:00) Pacific Time (US & Canada)"))
                    {
                        Mousehover(timezones[i]);
                        timezones[i].Click();
                    }
                }
            }
            IWebElement SaveButton = driver.FindElement(By.XPath(Constants.SaveBtn));
            Mousehover(SaveButton);
            SaveButton.Click();

            if (FirstName.Text.Contains("Some of the mandatory fields are missing. Please provide input and try again."))
            {
                Assert.Pass("Confirm Password field mandatory validation is Pass");
            }
            else
            {

            }
            driver.FindElement(By.XPath("//input[@id='btnDisplayMessage']")).Click();

        }
    
        
        
        private void waitForElement()
        {
            throw new NotImplementedException();
        }

        private void login(object appsettings)
        {
            throw new NotImplementedException();
        }

    }
        
    }

