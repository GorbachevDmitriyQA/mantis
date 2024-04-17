using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Reflection;
using System.Globalization;
using NUnit.Framework;

namespace MantisTests
{
    public class ManagmentMenuHelper : HelperBase
    {
        public ManagmentMenuHelper(AppManager manager):base(manager) { }

        public void OpenControlPage()
        {
            driver.FindElement(By.CssSelector(".manage-menu-link")).Click();
        }

        public void ProjectMenu()
        {
            OpenControlPage();
            driver.FindElement(By.CssSelector("div#manage-menu li:nth-child(2)")).Click();
        }

    }
}
