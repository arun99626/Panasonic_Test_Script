using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMC_Automation
{
    public static class Constants

    {
        //Dashboard and Menu
        public const string Title = "TITLE";
        public const string UserName = "USERNAME";
        public const string Dashboard = "//div[@id='divHomePageContents']/div[1]/div[1]/div[1]/div/p[1]";
        public const string Settings= "//li[@id='dvSettings']/a";
        public const string Userdropdown = "//li[@id='dvUserSettings']/a";
        public const string password = "PASSWORD";

        //Globaladmin login page
        public const string GAUsername = "//*[@id='txtLoginID']";
        public const string GAPassword = "//*[@id='txtPassword']";
        public const string OrganisationName = "//input[@id='txtOrgName']";
        public const string DepartmentName= "//input[@id='txtTechnologyName']";
        public const string GAFirstName = "//*[@id='txtFirstName']";
        public const string GALastName = "//*[@id='txtLastName']";
        public const string GAUserName1 = "//*[@id='txtEmailId']";
        public const string GALoginID = "//*[@id='txtLoginId']";
        public const string SMTPtab = "//*[@id='jqxTabs']/div[1]/ul/li[6]/div";


        //Global Admin SMTP
        public const string SMTPServerName = "//input[@id='txtAppSettingServerName']";
        public const string SMTPPortNumber = "//input[@id='txtAppSettingServerPortNumber']";
        public const string SMTPServerUserName = "//input[@id='txtAppSettingServerUserName']";
        public const string SMTPServerPassword = "//input[@id='txtAppSettingServerPassword']";
        public const string Savebtn = "//button[@id='btnSaveOrgSetting']";
        public const string TestSMTPbtn = "//button[@id='btnSMTPTest']";
        public const string Discardchangesbtn = "//button[@id='btnDiscardChanges']";
        public const string Testemail =  "//input[@id='txtemailtoaddress']";

        //Default SMTP configuration
        public const string TenantSMTPServerName = "//*[@id='tenantAppSettingServerName']";
        public const string TenantSMTPServerUserName = "//*[@id='tenantAppSettingServerUname']";
        public const string TenantSMTPServerPassword = "//input[@id='tenantAppSettingServerPwd']";
        public const string TenantSavebtn = "//button[@id='btntenantSave']";
        public const string TenantTestemail = "//*[@id='btntenantSMTPTest']";
        public const string TenantReset = "//*[@id='btntenantClearChanges']";
        public const string TenantSendgrid = "//*[@id='divContentId']/div/div[3]/div[1]/div[2]/div/div/label[2]";
        public const string SSLEncription =  "//*[@id='divContentId']/div/div[3]/div[2]/div[2]/div/div/label[2]";
        public const string Discardchanges = "//button[@id='btntenantDiscardChanges']";
        public const string OKBTN = "//input[@id='btnDisplayMessage']";
        public const string TestEmailtxt = "//input[@id='txtemailtoaddress']";


        //Global admins creation
        public const string Globaladmincreation = "//li[@id='GlobalAdminConfigTab']";
        public const string ADUserName = "//input[@id='txtEmailId']";
        public const string ADPassword = "//*[@id='txtPassword']";
        public const string ADconfirmpassword = "//input[@id='txtConfirmPassword']";
        public const string ADuserID = "//input[@id='txtLoginId']";
        public const string ADFirstName = "//input[@id='txtFirstName']";
        public const string ADLastName = "//input[@id='txtFamilyName']";
        public const string ADSavebutton = "//button[@id='btnSaveGlobalAdminUser']";
        public const string ADNewUser = "//button[@id='btnCreateNewGlobalAdminUser']";


        // User Creation Page
        public const string CreateButton= "//button[@id='btnCreateNewUser']";
        public const string FirstName = "//input[@id='txtFirstName']";
        public const string LastName = "//input[@id='txtLastName']";
        public const string EmailID = "//input[@id='txtEmailId']";
        public const string PhoneNo = "//input[@id='txtPhoneNumber']";
        public const string Extension ="//input[@id='txtExtnPhoneNumber']";
        public const string Password1= "//input[@id='txtPassword']";
        public const string ConfirmPassword = "//input[@id='txtConfirmPassword']";
        public const string Description= "//*[@id='txtDescription']";
        public const string ResetpasswordfornextLogin = "//label[@id='divAdminConfig']/div/div[1]/div/div/label[2]";
        public const string IsActive= "//label[@id='IsActivediv']/div/div/label[1]";
        public const string UserGroup= "//*[@id='dropdownlistContentddlUserGroups']/span";

        //Change Password
        public const string Oldpassword = "//*[@id='txtOldPassword']";
        public const string NewPassword = "//*[@id='txtNewPassword']";
        public const string ConfirmNewPassword = "//*[@id='txtchangeConfirmPassword']";

        //ddlUserGroups
        public const string UserGroup1 = "//*[@id='listitem0innerListBoxddlUserGroups']/span";
        public const string AssignGroupBtn = "//button[@id='btnAddUserGroup']";
        public const string UserGroupDisplay = "//*[@id='row0grdAssignUserGroupList']/div[1]";
        public const string Address = "//input[@id='txtAddress']";
        public const string City = "//input[@id='txtCity']";
        public const string State = "//input[@id='txtState']";
        public const string Zip = "//input[@id='txtZip']";
        public const string Country = "//div[@id='dropdownlistContentddlCountry']";
        public const string Fax = "//input[@id='txtFax']";
        public const string SupportEmailID = "//input[@id='txtSupportContactEmail']";
        public const string UserTimeZone = "//*[@id='dropdownlistArrowddlusertimezone']/div";
        public const string RestBtn = "//input[@id='lnkUserReset']";
        public const string SaveBtn = "//input[@id='btnSave']";
        public const string SupportContactEmail = "//input[@id='txtSupportContactEmail']";

        //Enroll IP Server
        public const string IPserverMenu = "//*[@id='dvEquipmentAsset']/a";
        public const string EnrollIPServerPage = "//*[@id='equipmentGroupTab']/div";
        public const string ServerName= "//input[@id='txtHostName']";
        public const string InternalIPAdress = "//*[@id='txtIpAddress']";
        public const string SerialNumber = "//input[@id='txtSerialNumber']";
        public const string AddNewGroup = "//*[@id='btnAddNewGroup']";
        public const string Savebutton = "//button[@id='btnSave']";
        public const string Location1 = "//input[@id='txtLocation']";
        public const string City1 = "//*[@id='txtCity']";
        public const string State1 = "//input[@id='txtState']";
        public const string Building = "//input[@id='txtBuilding']";
        public const string Floor = "//input[@id='txtFloor']";
        public const string Room = "//input[@id='txtRoom']";
        public const string RoomTelephone = "//input[@id='txtRoomTelePhone']";
        public const string EditIPserver = "//*[@id='row0grid']/div[7]";
        public const string UpdateIPserver = "//button[@id='btnSave']";
        public const string MinutesToWarning = "//input[@id='txtMinutestoWarning']";
        public const string MinutesToError = "//*[@id='txtMinutestoError']";
        
    }
}
