using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace calculatorTest
{
    // [OneTimeSetUp]
    public class FunctionalTests
    {
        private IWebDriver Driver;

        [SetUp]
        public void OpenBrowser()
        {
            this.Driver = new ChromeDriver();
        }

        [Test]
        public void CalculateNormalValues()
        {
            this.Driver.Navigate().GoToUrl("https://aqueous-depths-68559.herokuapp.com");
            Thread.Sleep(1000); // изчакване 
            var quantity = Driver.FindElement(By.Id("quantity"));
            quantity.SendKeys("100");
            var width = Driver.FindElement(By.Id("leftOperand"));
            width.SendKeys("90");
            var height = Driver.FindElement(By.Id("rightOperand"));
            height.SendKeys("50");
            var bleed = Driver.FindElement(By.Id("bleed"));
            bleed.SendKeys("1.5");
            Driver.FindElement(By.XPath("/html/body/div/div/form/fieldset/div[6]/div/button")).Click(); // click Calculate

            Thread.Sleep(500); // waiting 

            int expectedResult = 4;
            int pageResult =int.Parse(Driver.FindElement(By.Id("result")).GetAttribute("value"));
            Assert.IsTrue(pageResult == expectedResult);

            Thread.Sleep(500); // waiting
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            this.Driver.Quit();
        }

    }
}