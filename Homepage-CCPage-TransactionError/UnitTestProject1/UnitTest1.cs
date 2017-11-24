using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.justanswer.com/");
            driver.FindElement(By.Id("question-input")).SendKeys("Hello, my dog ate some chocolate");
            driver.FindElement(By.ClassName("button-orange")).Click();
            Thread.Sleep(8500);
            driver.FindElement(By.ClassName("logo-mastercard")).Click();
            driver.FindElement(By.ClassName("input-card-number")).SendKeys("5304529389838426");
            driver.FindElement(By.ClassName("input-exp-month")).FindElement(By.XPath("//option[@value='10']")).Click(); //for some reason exit message appears after entering month
            Thread.Sleep(3500);
            driver.FindElement(By.ClassName("li-cc-exit-modal")).FindElement(By.XPath("//div[@class='continue']")).Click(); //closing exit message
            driver.FindElement(By.ClassName("input-exp-year")).FindElement(By.XPath("//option[@value='2021']")).Click();
            driver.FindElement(By.ClassName("input-card-code")).SendKeys("111");
            driver.FindElement(By.ClassName("input-postal-code")).SendKeys("11111");
            driver.FindElement(By.ClassName("button-submit")).Click();
            Thread.Sleep(10000);
            Assert.IsTrue(driver.FindElement(By.ClassName("transaction-error")).Displayed, "No transaction error");
        }
    }
}
