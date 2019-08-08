using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace AuroTest0
{
    class LoremLipsum
    {

        private readonly IWebDriver driver;
        public LoremLipsum(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//input[@id=\"bytes\"]")]
        IWebElement bytes;
        [FindsBy(How = How.XPath, Using = "//input[@id=\"paragraphs\"]")]
        IWebElement paragraphs;
        [FindsBy(How = How.XPath, Using = "//input[@id=\"words\"]")]
        IWebElement words;
        [FindsBy(How = How.XPath, Using = "//input[@id=\"lists\"]")]
        IWebElement lists;
        public void ChooseHowGenerate(string how)
        {
            switch (how)
            {
                case "ByBytes":
                    bytes.Click();
                    break;
                case "ByPargraphs":
                    paragraphs.Click();
                    break;
                case "ByWords":
                    words.Click();
                    break;
                case "ByLists":
                    lists.Click();
                    break;
                default:
                    throw new ArgumentException();
            }
        }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"amount\"]")]
        IWebElement Amount { get; set; }
        public void SetAmount(int amount)
        {
            Amount.Clear();
            string s_amount = Convert.ToString(amount);
            Amount.SendKeys(s_amount);
        }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"generate\"]")]
        public IWebElement Generate { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"lipsum\"]/p")]
        IWebElement LoremLipsumText { get; set; }
        string Generatedtext { get; set; }
        public void Remember()
        {
            Generatedtext = LoremLipsumText.Text;
        }
        public string Remind()
        {
            return Generatedtext;
        }
    }
}
