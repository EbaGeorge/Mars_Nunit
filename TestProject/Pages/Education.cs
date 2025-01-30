using MarsQA_Nunit.Models;
using MarsQA_Nunit.Utilities;
using OpenQA.Selenium;

namespace MarsQA_Nunit.Pages
{
    public class Education
    {
        private readonly By educationTabLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]");
        IWebElement educationTab;
        private readonly By addNewBtnLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div");
        IWebElement addNewBtn;
        private readonly By countryCollegeLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select");
        IWebElement countryCollege;
        private readonly By addBtnLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]");
        IWebElement addBtn;
        private readonly By editBtnLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[1]/i");
        IWebElement editBtn;
        private readonly By collegeNameLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[1]/div[1]/input");
        IWebElement college;
        private readonly By titleLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[1]/select");
        IWebElement titleToBeUpdated;
        private readonly By updateBtnLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]");
        IWebElement updateBtn;
        private readonly By deleteBtnLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i");
        IWebElement deleteBtn;
        private readonly By collegeNameAddLocator = By.Name("instituteName");
        IWebElement collegeNameAdd;
        

        //Method to create an education record
        public void CreateEducation(IWebDriver driver, CreateEducation record)
        {
            //Click on Education Tab
            educationTab = driver.FindElement(educationTabLocator);
            educationTab.Click();

            //Click on AddNew Button
            addNewBtn = driver.FindElement(addNewBtnLocator);
            addNewBtn.Click();

            //Enter College/University name
            collegeNameAdd = driver.FindElement(collegeNameAddLocator);
            collegeNameAdd.SendKeys(record.CollegeName);

            //Select Country of College
            IWebElement countryCollegeAdd = driver.FindElement(countryCollegeLocator);
            countryCollegeAdd.SendKeys(record.CountryCollege);

            //Select Title
            IWebElement titleAdd = driver.FindElement(By.Name("title"));
            titleAdd.SendKeys(record.Title);

            //Enter Degree
            IWebElement degreeAdd = driver.FindElement(By.Name("degree"));
            degreeAdd.SendKeys(record.Degree);

            //Select Year of Graduation
            IWebElement yearOfGraduationAdd = driver.FindElement(By.Name("yearOfGraduation"));
            yearOfGraduationAdd.SendKeys(record.YearOfGraduation);

            //Click on Add Button
            addBtn = driver.FindElement(addBtnLocator);
            addBtn.Click();
        }
        //Method to update an education record
        public void UpdateEducationRecord(IWebDriver driver, UpdateEducation record)
        {
            //Click on Education Tab
            educationTab = driver.FindElement(educationTabLocator);
            educationTab.Click();

            //Click on AddNew Button
            addNewBtn = driver.FindElement(addNewBtnLocator);
            addNewBtn.Click();

            //Enter College/University name
            IWebElement collegeName = driver.FindElement(By.Name("instituteName"));
            collegeName.SendKeys(record.CollegeName);

            //Select Country of College
            countryCollege = driver.FindElement(countryCollegeLocator);
            countryCollege.SendKeys(record.CountryCollege);

            //Select Title
            IWebElement title = driver.FindElement(By.Name("title"));
            title.SendKeys(record.Title);

            //Enter Degree
            IWebElement degree = driver.FindElement(By.Name("degree"));
            degree.SendKeys(record.Degree);

            //Select Year of Graduation
            IWebElement yearOfGraduation = driver.FindElement(By.Name("yearOfGraduation"));
            yearOfGraduation.SendKeys(record.YearOfGraduation);

            //Click on Add Button
            addBtn = driver.FindElement(addBtnLocator);
            addBtn.Click();

            //Click on Edit icon
            editBtn = driver.FindElement(editBtnLocator);
            editBtn.Click();

            //Enter College/University name
            college = driver.FindElement(collegeNameLocator);
            college.Clear();
            college.SendKeys(record.UpdatedCollegeName);

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[1]/div[2]/select", 16);
           
            //Select Country of College
            countryCollege = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[1]/div[2]/select"));
            countryCollege.Click();
            countryCollege.SendKeys(record.UpdatedCountryCollege);
            countryCollege.Click();

            //Select Title
            IWebElement titleToBeUpdated = driver.FindElement(titleLocator);
            titleToBeUpdated.Click();
            titleToBeUpdated.SendKeys(record.UpdatedTitle);
            titleToBeUpdated.Click();

            //Enter Degree
            IWebElement degreeToBeUpdated = driver.FindElement(By.Name("degree"));
            degreeToBeUpdated.Clear();
            degreeToBeUpdated.SendKeys(record.UpdatedDegree);

            //Select Year of Graduation
            IWebElement yearOfGraduationUpdated = driver.FindElement(By.Name("yearOfGraduation"));
            yearOfGraduationUpdated.Click();
            yearOfGraduationUpdated.SendKeys(record.UpdatedYear);
            yearOfGraduationUpdated.Click();

            //Click on Update Button
            updateBtn = driver.FindElement(updateBtnLocator);
            updateBtn.Click();
            Thread.Sleep(2000);
        }

        //Method to delete an education record
        public void DeleteEducationRecord(IWebDriver driver, CreateEducation record)
        {
            //Click on Education Tab
            educationTab = driver.FindElement(educationTabLocator);
            educationTab.Click();

            //Click on AddNew Button
            addNewBtn = driver.FindElement(addNewBtnLocator);
            addNewBtn.Click();

            //Enter College/University name
            IWebElement collegeName = driver.FindElement(By.Name("instituteName"));
            collegeName.SendKeys(record.CollegeName);

            //Select Country of College
            countryCollege = driver.FindElement(countryCollegeLocator);
            countryCollege.SendKeys(record.CountryCollege);

            //Select Title
            IWebElement title = driver.FindElement(By.Name("title"));
            title.SendKeys(record.Title);

            //Enter Degree
            IWebElement degree = driver.FindElement(By.Name("degree"));
            degree.SendKeys(record.Degree);

            //Select Year of Graduation
            IWebElement yearOfGraduation = driver.FindElement(By.Name("yearOfGraduation"));
            yearOfGraduation.SendKeys(record.YearOfGraduation);

            //Click on Add Button
            addBtn = driver.FindElement(addBtnLocator);
            addBtn.Click();
          
            //Click on Delete Icon
            deleteBtn = driver.FindElement(deleteBtnLocator);
            deleteBtn.Click();
        }
    }
}
