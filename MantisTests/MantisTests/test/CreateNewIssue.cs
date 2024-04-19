using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace MantisTests
{
    [TestFixture]
    public class CreateNewIssue : TestBase
    {

        [Test]
        
        public void CreateIssue()
        {
            ProjectData project = new ProjectData()
            {
                Id = "1"
            };
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "qwe"
            };
            IssueData issue = new IssueData()
            {
                Summary = "This functional bug",
                Decsription = "bug is detected and subscribe in this bug-report",
                Category = "General"
            };

            app.API.CreateNewIssue(account, issue, project);
        }

    }
}
