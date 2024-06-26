﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpaqueMail;
using OpaqueMail.Net;

namespace MantisTests
{
    public class MailHelper : HelperBase
    {
        public MailHelper(AppManager manager) : base(manager) { }

        public string GetLastMail(AccountData account)
        {
            for (int i = 0; i < 30; i ++)
            {
                Pop3Client pop3 = new Pop3Client("localhost", 110, account.Name, account.Password, false);
                pop3.Connect();
                pop3.Authenticate();
                if (pop3.GetMessageCount() > 0)
                {
                    ReadOnlyMailMessage message =  pop3.GetMessage(1);
                    string body = message.Body;
                    pop3.DeleteMessage(1);
                    pop3.LogOut();
                    return body;
                }
                else
                {
                    Thread.Sleep(2000);
                }
            }
            return null;
        }
    }
}
