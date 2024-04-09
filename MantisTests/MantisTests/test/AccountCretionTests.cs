using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisTests
{

    [TestFixture]
    public class AccountCretionTests : TestBase
    {

        [SetUp]
        public void SetUpConfig()
        {
            app.Ftp.BackupFile("");
            app.Ftp.UploadFile("", null);

        }


        [Test]

        public void AccountCreation()
        {
            AccountData account = new AccountData()
            {
                Name = "SuperUser",
                Password = "qwe",
                Email = "superUser@mail.ru"
            };

            app.Registration.Register(account);
        }

        [TearDown]

        public void RestoreConfig()
        {
            app.Ftp.RestoreFile("");
        }
    }
}
