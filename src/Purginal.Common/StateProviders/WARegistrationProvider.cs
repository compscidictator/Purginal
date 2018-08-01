using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Purginal.Common.StateProviders
{

    public class WARegistrationProvider : IStateProvider
    {
        private const string LoginUrl = "https://weiapplets.sos.wa.gov/myvote/#/login";
        private const string LoginPage = "Login.ashx";
        private const string VoterPage = "Voter.ashx";

        private const string StatusCss = "[ng-bind-html=\"labels['shared-registration-Status'] | sanitize\"";

        public async Task<Registration> CheckRegistration(RegistrationInfo regInfo)
        {
            using(var driver = WebDriverFactory.CreateWebDriver())
            {
                driver.Navigate().GoToUrl(LoginUrl);
                var firstName = driver.FindElement(By.Id("FirstName"));
                var lastName = driver.FindElement(By.Id("LastName"));
                var month = driver.FindElement(By.Id("Month"));
                var day = driver.FindElement(By.Id("Day"));
                var year = driver.FindElement(By.Id("Year"));
                
                firstName.SendKeys(regInfo.FirstName);
                lastName.SendKeys(regInfo.LastName);
                month.SendKeys(regInfo.DateOfBirth.Month.ToString());
                day.SendKeys(regInfo.DateOfBirth.Day.ToString());
                year.SendKeys(regInfo.DateOfBirth.Year.ToString());

                driver.FindElement(By.Id("btn-login")).Click();
                
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0,0,5));
                wait.Until(drv => drv.FindElement(By.CssSelector(StatusCss)));

                var statusLabel = driver.FindElement(By.CssSelector(StatusCss));
                var status = statusLabel.FindElement(By.XPath("following-sibling::div"));

                return new Registration{
                    Active = status.Text.Equals("Active")
                };
            }
        }

        public State State => State.WA;
    }
}
