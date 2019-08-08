using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace AuroTest0
{
    class BBC
    {
        private readonly IWebDriver driver;
        public BBC(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//a[@href = '/news']")]
        public IWebElement News { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@class = 'gel-long-primer gs-u-ph']")]
        public IWebElement More { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@href='/news/have_your_say']")]
        public IWebElement HaveYouSay { get; set; }
        [FindsBy(How = How.XPath, Using = "(//h2[@id=\"featured-contents\"]/following-sibling::div//a[@href='/news/uk-47933096'])[1]")]
        public IWebElement DoYouHaveAStory { get; set; }
        [FindsBy(How = How.XPath, Using = "//textarea[@placeholder='What questions would you like us to investigate?']")]
        public IWebElement BBCTextField { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Name']")]
        public IWebElement BBCName { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Email address']")]
        public IWebElement BBCEmail { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Age']")]
        public IWebElement BBCAge { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Postcode']")]
        public IWebElement BBCPostcode { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[@type='checkbox'])[1]")]
        public IWebElement SignMeUpForBbcNewsDaily_button { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[@type='checkbox'])[2]")]
        public IWebElement PleaseDontPublishMyName_button { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@class = 'button']")]
        public IWebElement Submit_button { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@href=\"Homepage\"")]
        public IWebElement Home { get; set; }
        public void GoToDoYouHaveAStory_page()
        {
            News.Click();
            More.Click();
            HaveYouSay.Click();
            DoYouHaveAStory.Click();
        }
        public void PrtScrn()
        {
            List<string> Filenames = new List<string>();
            DirectoryInfo directory = new DirectoryInfo(@"C:\\Users\\admin\\Pictures\\\\BBCTests");//Assuming Test is your Folder
            FileInfo[] Files = directory.GetFiles("*.png"); //Getting Text files
            foreach (FileInfo file in Files)
            {
                Filenames.Add(file.Name);
            }
            for (int i = 1; true; i++)
            {
                if (!Filenames.Contains(("BBCScreen" + i.ToString() + ".png")))
                {
                    Screenshot screen = ((ITakesScreenshot)driver).GetScreenshot();
                    screen.SaveAsFile("C:\\Users\\admin\\Pictures\\BBCTests\\BBCScreen" + i.ToString() + ".png", OpenQA.Selenium.ScreenshotImageFormat.Png);
                    break;
                }

            }
        }
    }
}
