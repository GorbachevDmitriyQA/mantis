using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisTests
{
    public class TestJames : TestBase
    {
        [Test]
        public void TestingJames()
        {
            AccountData account = new AccountData()
            { 
                Name = "super",
                Password = "super" 
            };
            Assert.IsFalse(app.James.VerifyAccount(account));
            app.James.AddAccount(account);
            Assert.IsTrue(app.James.VerifyAccount(account));
            app.James.DeleteAccount(account);
            Assert.IsFalse(app.James.VerifyAccount(account));
        }
    }
}
