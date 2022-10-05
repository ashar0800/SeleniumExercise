using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;
using log4net;

namespace SeleniumQuizAshar
{

    public class BaseClass
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static IWebDriver driver;


        public BaseClass() { } //Constructor
        public BaseClass(string browserName)
        {
            
            if (browserName == "Chrome")
                driver = new ChromeDriver();
            else if (browserName == "Firefox")
                driver = new FirefoxDriver();
            else if (browserName == "Edge")
                driver = new EdgeDriver();
            else
                driver = null;

            log.Info("Browser Set: "+ browserName);
        }
        public void setURL(string url)
        {
            log.Info("URL set");
            driver.Url = url;
        }

        public void implicitWait(int i)
        {
            log.Info("Implicit Wait Called");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(i);
        }

        public IWebElement findElement(By path)

        {
            log.Info("Find Element Called");
            return driver.FindElement(path);
        }

        public void myClick(By path)
        {
            log.Info("Element Clicked");
            findElement(path).Click();
        }
       

        public void myText(By path, string i)
        {
            log.Info("Text Entered");
            findElement(path).SendKeys(i);
        }

        public void maximizeWindow()
        {
            log.Info("Window Maximized");
            driver.Manage().Window.Maximize();

        }
        public void validateHomePage()
        {
            log.Info("HomePage Validated via Title");
            //Whether HomePage is loaded on screen: Verification via Title
            new WebDriverWait(BaseClass.driver, TimeSpan.FromSeconds(5)).Until(driver => driver.Title.Equals(TestMainClass.homepageTitle));

        }

        public void getScreenshot(string img)
        {
            log.Info("Screenshot Taken");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@img, ScreenshotImageFormat.Png);
        }
    }
}
