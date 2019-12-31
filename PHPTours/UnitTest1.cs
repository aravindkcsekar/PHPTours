using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PHPTours
{
    [TestClass]
    public class SignUpTests    {

        public IWebDriver InstBrowser()
        {
            IWebDriver driver = new ChromeDriver();

            //Navigate to PHP Tours Register page
            driver.Navigate().GoToUrl("https://www.phptravels.net/register");

            ////Maximize the window
            driver.Manage().Window.Maximize();
            return driver;

        }
        public void FillForm(IWebDriver driver)
        {
            
            IWebElement fName = driver.FindElement(By.Name("firstname"));
            fName.SendKeys("Aravind");

            IWebElement lName = driver.FindElement(By.Name("lastname"));
            lName.SendKeys("Chandrasekaran");

            IWebElement phone = driver.FindElement(By.Name("phone"));
            phone.SendKeys("6167347358");

            IWebElement eMail = driver.FindElement(By.Name("email"));
            eMail.SendKeys("ddmail@hmail.com");

            IWebElement pword = driver.FindElement(By.Name("password"));
            pword.SendKeys("123456");

            IWebElement cnfPword = driver.FindElement(By.Name("confirmpassword"));
            cnfPword.SendKeys("123456");

            IWebElement signUpBtn = driver.FindElement(By.CssSelector("#headersignupform > div:nth-child(9) > button"));
            signUpBtn.Click();
        }

        [TestMethod]
        public void NewUser()
        {
            IWebDriver driver = InstBrowser();
            FillForm(driver);


            //Find the Firstname text box using xpath
            

            string currentUrl = driver.Url;
            try
            {
                Assert.AreEqual("https://www.phptravels.net/account/", currentUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void ExistingUser()
        {
            IWebDriver driver = InstBrowser();
            FillForm(driver);

            string alertMsg = driver.FindElement(By.CssSelector("#headersignupform > div.resultsignup > div")).Text;
            try
            {
                Assert.AreEqual("Email Already Exists.", alertMsg, "doesnt match");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
    }
}
