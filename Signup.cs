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
    public class Signup : BaseClass
    {
        #region
        By SignupButton = By.XPath("//*[@id='header']/div/div/div/div[2]/div/ul/li[4]/a");
        By Name = By.Name("name");
        By Email = By.XPath("//*[@id='form']/div/div/div[3]/div/form/input[3]");
        By submitButton = By.XPath("//*[@id='form']/div/div/div[3]/div/form/button");


        
        By genderRadioButton = By.Id("id_gender1");
        By Password = By.Id("password");
        By Day = By.Id("days");
        By Month = By.Id("months");
        By Year = By.Id("years");

        By Newsletter = By.Id("newsletter");
        By Optin = By.Id("optin");

        By Firstname = By.Id("first_name");
        By Lastname = By.Id("last_name");
        By Company = By.Id("company");
        By Address1= By.Id("address1");
        By Address2 = By.Id("address2");

        By Country = By.Id("country");
        By State=By.Id("state");
        By City = By.Id("city");
        By Zipcode = By.Id("zipcode");
        By Mobile = By.Id("mobile_number");
        By createAccountButton = By.XPath("//*[@id='form']/div/div/div/div[1]/form/button");
        By accountValidation = By.XPath("//*[@id='form']/div/div/div/h2/b");
        By continueButton = By.XPath("//*[@id='form']/div/div/div/div/a");
        By usernameValidator = By.XPath("//*[@id='header']/div/div/div/div[2]/div/ul/li[10]/a/b");
        By deleteAccountButton = By.XPath("//*[@id='header']/div/div/div/div[2]/div/ul/li[5]/a");
        By confirmDelete = By.XPath("//*[@id='deleteModal']/div/div/div[2]/form/button");
        #endregion

        public void SignupTest( string name, string email, string password, string fname,
                                string lname,string company,string address1,string address2,
                                string state,string city,string zipcode,string mobile)
        {
            maximizeWindow();
            implicitWait(5);
            Thread.Sleep(1000);

            myClick(SignupButton);
            log.Info("-------------TestStep 1.04: Signup Button Clicked-------------");
            myText(Name, name);
            myText(Email, email);
            log.Info("-------------TestStep 1.06: Name and Email Address Entered-------------");

            Thread.Sleep(1000);
            myClick(submitButton);
            log.Info("-------------TestStep 1.07: Sign Up Button Clicked-------------");
            // this is now a new page
            implicitWait(20);
            Thread.Sleep(5000);


            myClick(genderRadioButton);
            myText(Password,password);

            Thread.Sleep(500);


            new SelectElement(findElement(Day)).SelectByText("18");
            new SelectElement(findElement(Month)).SelectByText("April");
            new SelectElement(findElement(Year)).SelectByText("1999");
            log.Info("-------------TestStep 1.08: Filled Data Successfully------------- ");
            myClick(Newsletter);
            log.Info("-------------TestStep 1.10: Selected checkbox 'Sign up for our newsletter!'-------------");
            myClick(Optin);
            log.Info("-------------TestStep 1.11: Selected checkbox 'Receive special offers from our partners!'-------------");
            myText(Firstname, fname);
            myText(Lastname, lname);
            myText(Company, company);
            myText(Address1, address1);
            myText(Address2, address2);
            new SelectElement(findElement(Country)).SelectByText("Canada");
            myText(State, state);
            myText(City, city);
            myText(Zipcode, zipcode);
            myText(Mobile, mobile);
            log.Info("-------------TestStep 1.12: Filled Details Successfully: First name, Last name, Company, Address, Address2, Country, State, City, Zipcode, Mobile Number");
            myClick(createAccountButton);
            log.Info("-------------TestStep 1.13: Create Account Button Clicked-------------");
            validateSuccessMessage();
            log.Info("-------------TestStep 1.14; Verify that 'Account Created' is visible-------------");
            myClick(continueButton);
            log.Info("-------------TestStep 1.15: Click on Continue button-------------");
            
        }

        public void validateSuccessMessage()
        {
            Assert.AreEqual(findElement(accountValidation).Text, "ACCOUNT CREATED!");
        }
        public void validateLogin_Signup()
        {
            var i = findElement(usernameValidator).GetAttribute("innerHTML");
            Assert.AreEqual(TestMainClass.fullname, i);
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
            By textView = By.XPath("//*[text()='Account Deleted']");
            //new WebDriverWait(BaseClass.driver, TimeSpan.FromSeconds(5)).Until(ElementNotVisibleException);        
        }

    }
}
