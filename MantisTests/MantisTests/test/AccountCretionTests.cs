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

        //[SetUp]
        //public void SetUpConfig()
        //{
        //    app.Ftp.BackupFile("/config_inc.php");
        //    using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
        //    {
        //        app.Ftp.UploadFile("/config_inc.php", localFile);
        //    }
        //}


        [Test]

        public void AccountCreation()
        {
            AccountData account = new AccountData()
            {
                Name = "qwe",
                Password = "dsf",
                Email = "wqe@mail.ru"
            };

            app.Registration.Register(account);
        }

        [TearDown]

        public void RestoreConfig()
        {
            app.Ftp.RestoreFile("/config_inc.php");
        }
    }
}
