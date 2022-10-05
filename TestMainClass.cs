using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumQuizAshar
{


    [TestClass]
    public class TestMainClass
    {

        //Hardcoding vals
        public static string url ="https://www.automationexercise.com/";
        public static string useremail = "123@dha1234.com";
        public static string userpassword = "random123";
        public static string firstname= "random123";
        public static string lastname = "random123";
        public static string fullname = firstname + " " + lastname;
        public static string state = "Ontario";
        public static string city = "Mississauga";
        public static string zipcode = "1234567";
        public static string mobile = "1234567890";
        public static string address1 = "random";
        public static string address2 = "random";
        public static string company = "random";
        public static string homepageTitle = "Automation Exercise";



        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }
        
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "data.xml", "Login", DataAccessMethod.Sequential)]
        public void getData() { } //XML source


        BaseClass object1 = new BaseClass("Chrome");

       
        [TestMethod]
        public void TestCase01()
        {
            BaseClass.log.Info("----------------------------------------------WELCOME TO TESTCASE 01--------------------------------------------------");
            Signup signup= new Signup();
            BaseClass.log.Info("-----------TestStep 1.01: Browser launched-------------");
            signup.getScreenshot(".\\TestStep1.01.png");
            signup.setURL(url);
            BaseClass.log.Info("-------------TestStep 1.02: navigation to the URL-------------");
            signup.getScreenshot(".\\TestStep1.02.png");
            signup.validateHomePage();
            
            BaseClass.log.Info("-------------TestStep 1.03: HomePage validation");
            signup.getScreenshot(".\\TestStep1.03.png");
            signup.SignupTest(fullname,useremail, userpassword, firstname, lastname, company, address1, address2, state, city, zipcode, mobile);
            signup.validateLogin_Signup();
            BaseClass.log.Info("-------------TestStep 1.16: Logged in as username Visible-------------");
            signup.getScreenshot(".\\TestStep1.16.png");
            
            signup.deleteAccount();
            BaseClass.log.Info("-------------TestStep 1.17: Delete Account Clicked-------------");
            signup.getScreenshot(".\\TestStep1.17.png");
            
            signup.validateDeletion();
            BaseClass.log.Info("-------------TestStep 1.18: Deletion Validation Function Entered-------------");
            signup.getScreenshot(".\\TestStep1.18.png");
        }
        [TestMethod]
        public void TestCase02()
        {
            BaseClass.log.Info("----------------------------------------WELCOME TO TEST CASE 02---------------------------------------------------");
            Login login = new Login();
            BaseClass.log.Info("-------------TestStep 1: URL set-------------");
            login.getScreenshot(".\\TestStep2.01.png");
            login.setURL(url);
            BaseClass.log.Info("-------------TestStep 2: URL loaded successfully-------------");
            login.getScreenshot(".\\TestStep2.02.png"); 
            login.validateHomePage();
            BaseClass.log.Info("-------------TestStep 3: Verify that home page is visible successfully-------------");
            login.getScreenshot(".\\TestStep2.03.png");
            login.loginTest(useremail,userpassword);
            login.validateLogin_Signup();
            BaseClass.log.Info("-------------TestStep 8: Verify that 'Logged in as username' is visible-------------");
            login.getScreenshot(".\\TestStep2.08.png");
            login.deleteAccount();
            BaseClass.log.Info("-------------Test Step 9. Click 'Delete Account' button-------------");
            login.getScreenshot(".\\TestStep2.09.png");
            login.validateDeletion();
            BaseClass.log.Info("-------------Test Step 10. Deletion Validation Action Tried-------------");
            login.getScreenshot(".\\TestStep2.10.png");
        }

        [TestMethod]
        public void TestCase04()
        {
            BaseClass.log.Info("--------------------------------------------------Welcome to TESTCASE 04----------------------------------------------");
            Login login1 = new Login();
            login1.setURL(url);
            login1.getScreenshot(".\\TestStep4.02.png");
            BaseClass.log.Info("Test Step 2. URL set");
            login1.validateHomePage();
            login1.getScreenshot(".\\TestStep4.03.png");
            BaseClass.log.Info("Test Step 3. Verify homepage visibility");
            login1.loginTest(useremail, userpassword);
            
            login1.validateLogin_Signup();
            BaseClass.log.Info("Test Step 8. Verify that 'Logged in as username' is visible");
            login1.getScreenshot(".\\TestStep4.08.png");
            login1.logout();
            BaseClass.log.Info("Test Step 9. Logout Action Attempted");
            login1.getScreenshot(".\\TestStep4.09.png");
            login1.validateLogout();
            BaseClass.log.Info("Test Step 10. Verify that user is navigated to login page");
            login1.getScreenshot(".\\TestStep4.10.png");
        }





    }
}

