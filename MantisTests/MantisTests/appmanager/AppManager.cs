using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace MantisTests
{
    public class AppManager 
    {
        protected IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        public string baseURL;

        public AppManager()
        {

            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = @"c:\program files (x86)\google\chrome\application\chrome.exe";
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            baseURL = "http://localhost:8080/mantisbt-1.3.20/login_page.php";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
        }
        public IWebDriver Driver
        {
            get { return driver; }
        }

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get;  set; }
    }

}
