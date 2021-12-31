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
using AutoIt;

namespace HMC_Automation
{
    
    class Auto_Installer
    {
        AutoItX3 autoinstaller = new AutoItX3();
        [Test]
        public void VIHM_Installer()
        {
            autoinstaller.Run(@"C:\Installer\VI Health MonitorPlus v1.4.0.17-November 20th.exe");
            autoinstaller.Sleep(30000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17", "", "Button1");
            autoinstaller.Sleep(4000);
            autoinstaller.ControlClick("VI Health MonitorPlus v1.4.0.17", "", "Button1");
            autoinstaller.Sleep(5000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17", "", "Button3");
            autoinstaller.Sleep(5000);
            autoinstaller.ControlClick("VI Health MonitorPlus v1.4.0.17", "", "Button3");
            autoinstaller.Sleep(5000);
            autoinstaller.ControlClick("VI Health MonitorPlus v1.4.0.17","", "Button1");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlClick("VI Health MonitorPlus v1.4.0.17","", "Button5");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlClick("VI Health MonitorPlus v1.4.0.17","", "Button1");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17","", "Button2");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlClick("VI Health MonitorPlus v1.4.0.17", "", "Button2");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17","", "Edit1");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlSetText("VI Health MonitorPlus v1.4.0.17", "", "Edit1", "VA20576@america.gds.panasonic.com");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17", "", "Edit2");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlSetText("VI Health MonitorPlus v1.4.0.17", "", "Edit2", "HealthMon12");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17", "", "Edit3");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlSetText("VI Health MonitorPlus v1.4.0.17", "", "Edit3", "HCLTestEnv");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlClick("VI Health MonitorPlus v1.4.0.17","", "Button2");
            autoinstaller.Sleep(30000);
            autoinstaller.ControlFocus("VI Health MonitorPlus - InstallShield Wizard", "", "Static2");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlFocus("VI Health MonitorPlus - InstallShield Wizard", "", "Button1");
            autoinstaller.Sleep(3000);
            autoinstaller.ControlClick("VI Health MonitorPlus - InstallShield Wizard","", "Button1");
            autoinstaller.Sleep(3000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17","", "Button4");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlClick("VI Health MonitorPlus v1.4.0.17", "", "Button4");
            autoinstaller.Sleep(30000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17","", "Edit1");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlSetText("VI Health MonitorPlus v1.4.0.17","", "Edit1", "vihmplustest.database.windows.net");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17", "", "Edit2");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlSetText("VI Health MonitorPlus v1.4.0.17", "", "Edit2", "VIHMaAdministrator");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17", "", "Edit3");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlSetText("VI Health MonitorPlus v1.4.0.17", "", "Edit3", "HclInstall12#");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17", "", "Edit4");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlSetText("VI Health MonitorPlus v1.4.0.17", "", "Edit4", "VIHM_GlobalDB_Automation");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17", "", "Button5");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlClick("VI Health MonitorPlus v1.4.0.17", "", "Button5");
            autoinstaller.Sleep(15000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17", "", "Static1");
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17", "", "Button1");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlClick("VI Health MonitorPlus v1.4.0.17", "", "Button1");
            autoinstaller.Sleep(3000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17","", "Button2");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlClick("VI Health MonitorPlus v1.4.0.17", "", "Button2");
            autoinstaller.Sleep(8000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17","", "ComboBox1");
            autoinstaller.Sleep(8000);                        
            autoinstaller.ControlCommand("VI Health MonitorPlus v1.4.0.17", "", "ComboBox1", "SelectString", "(GMT-08:00) Pacific Time (US & Canada)");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17","", "Edit2");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlSend("VI Health MonitorPlus v1.4.0.17", "", "Edit2","123456");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17","", "Edit3");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlSetText("VI Health MonitorPlus v1.4.0.17", "", "Edit3", "123456");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17","", "Button1");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlClick("VI Health MonitorPlus v1.4.0.17", "", "Button1");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17","", "Button1");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlClick("VI Health MonitorPlus v1.4.0.17", "", "Button1");
            autoinstaller.WinWaitActive("VI Health MonitorPlus v1.4.0.17", "Finish");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlFocus("VI Health MonitorPlus v1.4.0.17", "Finish", "Button4");
            autoinstaller.Sleep(2000);
            autoinstaller.ControlClick("VI Health MonitorPlus v1.4.0.17", "Finish", "Button4");

        }
    }
}
