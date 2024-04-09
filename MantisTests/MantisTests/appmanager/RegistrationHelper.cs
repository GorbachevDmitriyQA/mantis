using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

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
        }

        private void OpenRegisterPage()
        {
            driver.FindElements(By.CssSelector("li"))[0].Click();
        }

        private void SubmitResgistration()
        {
            throw new NotImplementedException();
        }

        private void FillRegisterForm(AccountData account)
        {
            driver.FindElement(By.Id("username")).SendKeys(account.Name);
            driver.FindElement(By.Id("email-field")).SendKeys(account.Email);
        }

        public void OpenLoginPage()
        {

            manager.Driver.Url = "http://localhost:8080/mantisbt-1.3.20/login_page.php";
        }
    }
}
