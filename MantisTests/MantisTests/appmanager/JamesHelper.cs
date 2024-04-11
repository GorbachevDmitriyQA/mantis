using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;

namespace MantisTests
{ 
    public class JamesHelper : HelperBase
    {
        public JamesHelper (AppManager manager) : base (manager) { }

        public void AddAccount(AccountData account)
        {
            if (VerifyAccount(account))
            {
                return;
            }
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("adduser " + account.Name + " " + account.Password);
            System.Console.Out.WriteLine(telnet.Read());
        }

        public void DeleteAccount(AccountData account)
        {
            if (!VerifyAccount(account))
            {
                return;
            }
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("deluser " + account.Name);
            System.Console.Out.WriteLine(telnet.Read());
        }
        public bool VerifyAccount(AccountData account)
        {
            TelnetConnection telnet = LoginToJames();
            System.Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("verify " + account.Name);
            string existAccount = telnet.Read();
            if (existAccount.Contains("does not exist"))
            {
                return false;
            };
            return true;
        }

        private TelnetConnection LoginToJames()
        {
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
            System.Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            System.Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            System.Console.Out.WriteLine(telnet.Read());
            return telnet;
        }

    }
}
