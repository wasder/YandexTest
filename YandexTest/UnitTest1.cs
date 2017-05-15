using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace YandexTest
{
    [TestClass]
    public class UnitTest1
    {
       
        [TestMethod]
        public void MoreThan1k()
        {
            IWebDriver driver = new ChromeDriver(@"E:\Dropbox\Projects\YandexTest\chromedriver");
            driver.Navigate().GoToUrl("https://www.yandex.ru/");
            IWebElement query = driver.FindElement(By.Name("text"));

            query.SendKeys("Открытие");
            query.Submit();
            IWebElement result;
            
            try
            {
                result = driver.FindElement(By.ClassName("serp-adv__found")); // Нашёлся 131 млн результатов
            }
            catch (NoSuchElementException e)
            {
                driver.Quit();
                Assert.Fail("Нет результатов");
                return;
            }

            string resultText = result.Text;
            
            if (!resultText.Contains("млн") && !resultText.Contains("тыс")) 
            {
                driver.Quit();
                Assert.Fail("Меньше тысячи результатов");
            }
            
            driver.Quit();
        }
    }
}
