using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using OpaqueMail.Net;

namespace MantisTests
{
    public class RegistrationHelper : HelperBase
    {

        public RegistrationHelper(AppManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenLoginPage();
            OpenRegisterPage();
            FillRegisterForm(account);
            SubmitResgistration();
            string url = GetConfirmationUrl(account);
            FillPasswordForm(url,account);
            SubmitPasswordForm();
        }

        public void SubmitPasswordForm()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        public void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);
        }

        public string GetConfirmationUrl(AccountData account)
        {
            string message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        public void OpenRegisterPage()
        {
            driver.FindElements(By.CssSelector("li"))[0].Click();
        }

        public void SubmitResgistration()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        public void FillRegisterForm(AccountData account)
        {
            driver.FindElement(By.Id("username")).SendKeys(account.Name);
            driver.FindElement(By.Id("email-field")).SendKeys(account.Email);
        }

        public void OpenLoginPage()
        {
            if (driver.Url != manager.baseURL + "/login_page.php")
            {
                manager.Driver.Url = manager.baseURL + "/login_page.php";
            }
        }
    }
}
