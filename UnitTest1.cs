using System;
using System.Drawing.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AuroTest0
{
    [TestClass]
    public class UnitTest1

    {
        public static string ans;
        public static string ans2;

        [TestMethod]
        public void TestBegun()
        {
            IWebDriver driver = new ChromeDriver();
            LoremLipsum one = new LoremLipsum(driver);
            driver.Navigate().GoToUrl("https://www.lipsum.com/");
            one.ChooseHowGenerate("ByBytes");
            one.SetAmount(141);
            one.Generate.Click();
            one.Remember();
            BBC two = new BBC(driver);
            driver.Navigate().GoToUrl("https://www.bbc.com");
            two.GoToDoYouHaveAStory_page();
            two.BBCTextField.SendKeys(one.Remind());
            two.BBCName.SendKeys("Yaroslav Krasnoshchokov");
            two.BBCAge.SendKeys("20");
            two.BBCEmail.SendKeys("kilaronikus@gmail.com");
            two.BBCPostcode.SendKeys("03110");
            two.SignMeUpForBbcNewsDaily_button.Click();
            two.PrtScrn();
            driver.Close();
        }
        [TestMethod]
        public void NameBlankError()
        {
            IWebDriver driver = new ChromeDriver();
            LoremLipsum one = new LoremLipsum(driver);
            driver.Navigate().GoToUrl("https://www.lipsum.com/");
            one.ChooseHowGenerate("ByBytes");
            one.SetAmount(141);
            one.Generate.Click();
            one.Remember();
            BBC two = new BBC(driver);
            driver.Navigate().GoToUrl("https://www.bbc.com");
            two.GoToDoYouHaveAStory_page();
            two.BBCTextField.SendKeys(one.Remind());
            two.BBCAge.SendKeys("20");
            two.BBCEmail.SendKeys("kilaronikus@gmail.com");
            two.BBCPostcode.SendKeys("03110");
            two.SignMeUpForBbcNewsDaily_button.Click();
            two.Submit_button.Click();
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual(two.InputError.Text, "Name can\'t be blank");
            driver.Close();
        }
        [TestMethod]
        public void EmailBlankError()
        {
            IWebDriver driver = new ChromeDriver();
            LoremLipsum one = new LoremLipsum(driver);
            driver.Navigate().GoToUrl("https://www.lipsum.com/");
            one.ChooseHowGenerate("ByBytes");
            one.SetAmount(141);
            one.Generate.Click();
            one.Remember();
            BBC two = new BBC(driver);
            driver.Navigate().GoToUrl("https://www.bbc.com");
            two.GoToDoYouHaveAStory_page();
            two.BBCTextField.SendKeys(one.Remind());
            two.BBCName.SendKeys("Yaroslav Krasnoshchokov");
            two.BBCAge.SendKeys("20");
            two.BBCPostcode.SendKeys("03110");
            two.SignMeUpForBbcNewsDaily_button.Click();
            two.Submit_button.Click();
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual(two.InputError.Text, "Email address can't be blank");
            driver.Close();
        }
    }
}
