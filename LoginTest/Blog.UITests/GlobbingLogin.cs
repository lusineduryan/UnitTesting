using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Blog.UITests
{
    public class GlobbingLogin
    {
        [Fact]
        public void ValidLogin()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                const string homeUrl = "https://am.globbing.com/en/";
                driver.Navigate().GoToUrl(homeUrl);

                IWebElement login = driver.FindElement(By.Id("login-btn"));
                login.Click();

                IWebElement username = driver.FindElement(By.Name("email"));
                username.SendKeys("lusineduryan@mail.ru");

                IWebElement password = driver.FindElement(By.Name("password"));
                password.SendKeys("psw");

                IWebElement rememberMe = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div[1]/div/div[4]/form[1]/div[3]/label"));
                rememberMe.Click();

                driver.FindElement(By.Name("email")).Submit();

                Assert.StartsWith("Globbing", driver.Title);
            }
        }

        [Fact]
        public void InvalidLogin()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                const string homeUrl = "https://am.globbing.com/en";
                driver.Navigate().GoToUrl(homeUrl);

                IWebElement login = driver.FindElement(By.Id("login-btn"));
                login.Click();

                IWebElement username = driver.FindElement(By.Name("email"));
                username.SendKeys("lusineduryan@mail.ruu");

                IWebElement password = driver.FindElement(By.Name("password"));
                password.SendKeys("psw");

                IWebElement rememberMe = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div[1]/div/div[4]/form[1]/div[3]/label"));
                rememberMe.Click();

                driver.FindElement(By.Name("email")).Submit();

                var loginError = driver.FindElement(By.CssSelector("#user-login-form > div:nth-child(2) > p"));
                Assert.Equal("Your username or password is incorrect", loginError.Text);

                username.Clear();
                username.SendKeys("lusineduryan@mail.ru");
                driver.FindElement(By.Name("email")).Submit();

                Assert.StartsWith("Globbing", driver.Title);
            }
        }

        [Fact]
        public void EmptyLogin()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                const string homeUrl = "https://am.globbing.com/en";
                
                driver.Navigate().GoToUrl(homeUrl);

                IWebElement login = driver.FindElement(By.Id("login-btn"));
                login.Click();

                IWebElement username = driver.FindElement(By.Name("email"));
                username.SendKeys("lusineduryan@mail.ruu");

                IWebElement password = driver.FindElement(By.Name("password"));
                password.SendKeys("");

                IWebElement rememberMe = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div[1]/div/div[4]/form[1]/div[3]/label"));
                rememberMe.Click();

                driver.FindElement(By.Name("email")).Submit();

                var loginError = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div[1]/div/div[4]/form[1]/div[2]/p"));
                Assert.Equal("Enter password", loginError.Text);

                password.SendKeys("psw");
                driver.FindElement(By.Name("email")).Submit();

                
                Assert.StartsWith("Globbing", driver.Title);
            }
        }
    }
}
