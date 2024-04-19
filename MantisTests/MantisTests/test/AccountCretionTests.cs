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
                Name = "Dimchansky",
                Password = "Dimchansky",
                Email = "Dimchansky@localhost.localdomain"
            };
            List<AccountData> accounts = app.Admin.GetAllAccounts();
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);
            if (existingAccount != null)
            {
                app.Admin.DeleteAccount(existingAccount);
            }
            List<AccountData> oldList = app.Admin.GetAllAccounts();
            app.James.DeleteAccount(account);
            app.James.AddAccount(account);
            app.Registration.Register(account);
            List<AccountData> newList = app.Admin.GetAllAccounts();
            Assert.AreEqual(oldList.Count + 1, newList.Count);

        }


        //[TearDown]

        //public void RestoreConfig()
        //{
        //    app.Ftp.RestoreFile("/config_inc.php");
        //}
    }
}
