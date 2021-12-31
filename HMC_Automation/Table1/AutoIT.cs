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
    class AutoIT
    {
        AutoItX3 auto = new AutoItX3();
        [Test,Order(1)]
        public void Camera_Up()
        {
            auto.Run(@"C:\arun\Arun\VI Camera Simulator1.1\VI Camera Simulator1.1\VI Camera Simulator.exe", @"C:\arun\Arun\VI Camera Simulator1.1\VI Camera Simulator1.1",auto.SW_SHOWNORMAL);
            auto.Sleep(2000);
            auto.ControlFocus("VI Camera Simulator", "", "WindowsForms10.BUTTON.app.0.141b42a_r30_ad11");
            auto.Sleep(3000);
            auto.ControlClick("VI Camera Simulator", "", "WindowsForms10.BUTTON.app.0.141b42a_r30_ad11");

        }

        [Test,Order(3)]
        public void Camera_Down()
        {

            auto.ControlFocus("VI Camera Simulator", "", "WindowsForms10.BUTTON.app.0.141b42a_r30_ad11");
            auto.Sleep(3000);
            auto.ControlClick("VI Camera Simulator", "", "WindowsForms10.BUTTON.app.0.141b42a_r30_ad11");

        }

        [Test]
        public void Camera_Delete()
        {

            auto.ControlFocus("VI Camera Simulator", "", "WindowsForms10.BUTTON.app.0.141b42a_r30_ad13");
            auto.Sleep(3000);
            auto.ControlClick("VI Camera Simulator", "", "WindowsForms10.BUTTON.app.0.141b42a_r30_ad13");
            auto.Sleep(3000);
            auto.ControlClick("Delete All", "", "Button1");

        }

        [Test,Order(2)]
        public void Camera_Add()
        {

            //auto.ControlFocus("VI Camera Simulator", "", "WindowsForms10.Window.8.app.0.141b42a_r6_ad12");
            //auto.Sleep(2000);
            auto.ControlClick("VI Camera Simulator", "", "WindowsForms10.BUTTON.app.0.141b42a_r6_ad12");
            auto.Sleep(2000);
            auto.ControlSetText("Add Cameras", "", "WindowsForms10.EDIT.app.0.141b42a_r6_ad11", "20");
            auto.Sleep(2000);
            auto.ControlClick("Add Cameras", "", "WindowsForms10.BUTTON.app.0.141b42a_r6_ad11");

        }

        [Test]
        public void Server_Down()
        {

            //auto.Run(@"C:\Program Files\VI Enterprise\Service Manager\IPServerManager.exe", @"C:\Program Files\VI Enterprise\Service Manager");
            //auto.Sleep(4000);
            auto.ControlFocus("IP Server Manager", "", "WindowsForms10.Window.8.app.0.141b42a_r6_ad128");
            auto.Sleep(3000);
            auto.ControlClick("IP Server Manager", "", "WindowsForms10.Window.8.app.0.141b42a_r6_ad128");
            auto.Sleep(3000);
            auto.ControlClick("IP Server Manager","", "WindowsForms10.Window.8.app.0.141b42a_r6_ad122");

        }

        [Test]
        public void Server_Up()
        {

            auto.ControlFocus("IP Server Manager","", "WindowsForms10.Window.8.app.0.141b42a_r6_ad127");
            auto.Sleep(3000);
            auto.ControlClick("IP Server Manager", "", "WindowsForms10.Window.8.app.0.141b42a_r6_ad127");
            auto.Sleep(3000);
            auto.ControlClick("IP Server Manager", "", "WindowsForms10.Window.8.app.0.141b42a_r6_ad122");

        }

        [Test]
        public void Server_Restart()
        {

            auto.ControlFocus("IP Server Manager", "", "WindowsForms10.Window.8.app.0.141b42a_r6_ad126");
            auto.Sleep(3000);
            auto.ControlClick("IP Server Manager", "", "WindowsForms10.Window.8.app.0.141b42a_r6_ad126");
            auto.Sleep(5000);
            auto.ControlClick("IP Server Manager", "", "WindowsForms10.Window.8.app.0.141b42a_r6_ad122");

        }

    }
}
