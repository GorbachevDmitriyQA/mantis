using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace MantisTests
{
    public class AdminHelper : HelperBase
    {
        public AdminHelper(AppManager manager) : base(manager) { }

        public List<AccountData> GetAllAccounts()
        {
            manager.Auth.AdminLogin();
            List<AccountData> accounts = new List<AccountData>();
            driver.Url = manager.baseURL + "/manage_user_page.php";
            IList <IWebElement> rows = driver.FindElements(By.CssSelector("table tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.CssSelector("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;

                accounts.Add(new AccountData()
                {
                    Name = name,
                    Id = id
                });
            }
            manager.Auth.Logout(); 
            return accounts;
        }

        public void DeleteAccount(AccountData account)
        {
            manager.Auth.AdminLogin();
            driver.Url = manager.baseURL + "/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.CssSelector("#manage-user-delete-form input.button")).Click();
            driver.FindElement(By.CssSelector("input.button[value='Удалить учетную запись']")).Click();
            Thread.Sleep(1200);
            manager.Auth.Logout();
        }
    }
}
