using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumQuizAshar
{
    public class Login : BaseClass
    {
        #region
        By login_Signup_Button = By.XPath("//*[@id='header']/div/div/div/div[2]/div/ul/li[4]/a");
        By loginIsVisible = By.XPath("//*[@id='form']/div/div/div[1]/div/h2");
        By Email = By.Name("email");
        By Password = By.Name("password");
        By submitLogin = By.XPath("//*[@id='form']/div/div/div[1]/div/form/button");

        By usernameValidator = By.XPath("//*[@id='header']/div/div/div/div[2]/div/ul/li[10]/a/b");
        By logoutButton = By.XPath("//*[@id='header']/div/div/div/div[2]/div/ul/li[4]/a");
        By deleteAccountButton = By.XPath("//*[@id='header']/div/div/div/div[2]/div/ul/li[5]/a");
        By confirmDelete = By.XPath("//*[@id='deleteModal']/div/div/div[2]/form/button");
        #endregion

        public void click_login_signup()
        {
            myClick(login_Signup_Button);
        }
        
        public void validate_login_screen()
        {
            var i = findElement(loginIsVisible).Text;
            Assert.AreEqual(i, "Login to your account");
        }

        public void loginTest(string userEmail, string userPassword)
        {
            maximizeWindow();
            
            click_login_signup();
            log.Info("------------- Clicked on Login Button-------------");
            getScreenshot(".\\TestStep 1.04.png");
            getScreenshot(".\\TestStep 4.04.png");
            validate_login_screen();
            log.Info("-------------Verification: 'Login to your account' is visible-------------");
            getScreenshot(".\\TestStep 1.05.png");
            getScreenshot(".\\TestStep 4.05.png");
            myText(Email, userEmail);
            myText(Password, userPassword);
            log.Info("-------------Email and password Entered-------------");
            getScreenshot(".\\TestStep 1.06.png");
            getScreenshot(".\\TestStep 4.06.png");
            Thread.Sleep(1000);
            

            myClick(submitLogin);
            log.Info("-------------Login Credentials Submitted-------------");
            getScreenshot(".\\TestStep 1.07.png");
            getScreenshot(".\\TestStep 4.07.png");
            implicitWait(10);
            
        }

        //After the Account is Logged in
        public void validateLogin_Signup()
        {
            var i = findElement(usernameValidator).GetAttribute("innerHTML");
            Assert.AreEqual(TestMainClass.fullname, i);
            Thread.Sleep(1000);

        }

        public void logout()
        {
            implicitWait(5);
            myClick(logoutButton);
            Thread.Sleep(1000);
        }
        public void validateLogout()
        {
            Assert.AreEqual(findElement(submitLogin).Text, "Login");
            Thread.Sleep(1000);
        }

        public void deleteAccount()
        {
            Thread.Sleep(500);
            myClick(deleteAccountButton);
            implicitWait(10);
            myClick(confirmDelete);
            
        }
        public void validateDeletion()
        {
            By textView=By.XPath("//*[text()='Account Deleted']");
            //new WebDriverWait(BaseClass.driver, TimeSpan.FromSeconds(5)).Until(ElementNotVisible);        
        }
        


    }
}
