using MarsQA_Nunit.Models;
using MarsQA_Nunit.Utilities;
using OpenQA.Selenium;

namespace MarsQA_Nunit.Pages
{
    public class Login : CommonDriver
    {
        //Method to perform login 
        public void LoginActions(IWebDriver driver,LoginData login)
        {
            driver.Navigate().GoToUrl(login.LoginUrl);
            //Maximize chrome window
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //Click on SignIn button
            IWebElement signInButton = driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a"));
            signInButton.Click();
            //Enter Email Address
            IWebElement emailAddress = driver.FindElement(By.Name("email"));
            emailAddress.SendKeys(login.Email);
            //Enter Password
            IWebElement passwordLogin = driver.FindElement(By.Name("password"));
            passwordLogin.SendKeys(login.Password);
            //Click on Login Button
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();
        }
    }
}
