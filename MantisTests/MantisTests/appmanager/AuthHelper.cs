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
using NUnit.Framework;

namespace MantisTests
{
    public class AuthHelper : HelperBase
    {
        public AuthHelper(AppManager manager): base(manager) { }

        public void AccountLogin(AccountData account)
        {
            if (driver.Url != manager.baseURL)
            {
                driver.Url = manager.baseURL;
            }
            FillLoginForm(account);
            SubmitLogin();
        }
        public void FillLoginForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
        }

        public void FillLoginForm()
        {
            driver.FindElement(By.Name("username")).SendKeys("administrator");
            driver.FindElement(By.Name("password")).SendKeys("qwe");
        }
        public void SubmitLogin()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        public void AdminLogin()
        {
            if (driver.Url != manager.baseURL + "/login_page.php")
            {
                manager.Registration.OpenLoginPage();
            }
            FillLoginForm();
            SubmitLogin();
        }

        public void Logout()
        {
            driver.FindElement(By.CssSelector("#logout-link")).Click();
        }
    }
}
