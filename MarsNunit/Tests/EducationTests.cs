using AventStack.ExtentReports.Model;
using MarsQA_Nunit.Models;
using MarsQA_Nunit.Pages;
using MarsQA_Nunit.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using System.Runtime.InteropServices;

namespace MarsQA_Nunit.Tests
{
    [TestFixture]
    public class EducationTests : CommonDriver
    {
        Login login;
        Education education;
        public EducationTests()
        {
            login = new Login();
            education = new Education();
        }
        private readonly By educationTabLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]");
        IWebElement educationTab;

        //Declaring variable for setting where the screenshot has to be stored in file folder
        private string screenshotDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Screenshots");

        [SetUp]
        public void SetUp()
        {
            Initialise();
            var logindata = GetLoginData("D:\\Eba\\Industry Connect\\WorkSpace\\MarsQA\\MarsQA_MVP\\MarsQA_Nunit\\MarsQA_Nunit\\Data\\loginData.json");
            login.LoginActions(logindata);

            // Create screenshots directory if it does not exist
            if (!Directory.Exists(screenshotDirectory))
            {
                Directory.CreateDirectory(screenshotDirectory);
            }
            EducationTab();
            DataCleanUp();
        }


        public void EducationTab()
        {
            //Click on Certification Tab
            IWebElement educationTab = driver.FindElement(educationTabLocator);
            educationTab.Click();          
        }
        //Method to convert login json data to c# object
        public LoginData GetLoginData(string filePath)
        {
            string json = File.ReadAllText(filePath);
            LoginData data = JsonConvert.DeserializeObject<LoginData>(json);
            return data;
        }
        public CreateEducation GetCreateEducationData(string filePath)
        {

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<CreateEducation>(json);
        }
        public UpdateEducation GetUpdateEducationData(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<UpdateEducation>(json);
        }

        public CreateEducationRecordWithoutDegree GetCreateEducationDataWithoutDegree(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<CreateEducationRecordWithoutDegree>(json);
        }

        //Testcase to create an education record
        [Test, Order(1)]
        public void CreateEducationRecord()
        {
            try
            {
                CommonDriver.StartTest("CreateEducationRecord");
                CommonDriver.LogTestInfo("CreateEducationRecord started.");
                var educationData = GetCreateEducationData("D:\\Eba\\Industry Connect\\WorkSpace\\MarsQA\\MarsQA_MVP\\MarsQA_Nunit\\MarsQA_Nunit\\Data\\createEducationData.json");
                education.CreateEducation(educationData);
                IWebElement educationrecord = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
                Assert.That(educationrecord.Text == educationData.CountryCollege, "Education is not added");
                CommonDriver.LogTestSuccess("CreateEducationRecord passed.");
            }
            catch (Exception ex)
            {
                CommonDriver.LogTestFailure("CreateEducationRecord is failed. " + ex.Message);
            }
        }

        //Testcase for updating education record
        [Test, Order(2)]
        public void UpdateEducationRecord()
        {
            try
            {
                CommonDriver.StartTest("UpdateEducationRecord");
                CommonDriver.LogTestInfo("UpdateEducationRecord started.");
                var updateEducationData = GetUpdateEducationData("D:\\Eba\\Industry Connect\\WorkSpace\\MarsQA\\MarsQA_MVP\\MarsQA_Nunit\\MarsQA_Nunit\\Data\\updateEducation.json");
                education.UpdateEducationRecord(updateEducationData);
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 20);
                IWebElement educationrecord = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
                Assert.That(educationrecord.Text == updateEducationData.UpdatedCountryCollege, "Education Record is updated");
                CommonDriver.LogTestSuccess("UpdateEducationRecord passed.");
            }
            catch (Exception ex)
            {
                CommonDriver.LogTestFailure("UpdateEducationRecord is failed. " + ex.Message);
                CaptureScreenshot("UpdateEducationRecord");
            }
        }

        //Method to capture screenshot in case the test fails
        private void CaptureScreenshot(string testName)
        {
            if (driver is ITakesScreenshot screenshotDriver)
            {
                var screenshot = screenshotDriver.GetScreenshot();
                var screenshotFilePath = Path.Combine(screenshotDirectory, $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

                // Save screenshot by default as PNG
                screenshot.SaveAsFile(screenshotFilePath);

                //Attach the screenshot in the NUnit test report
                TestContext.AddTestAttachment(screenshotFilePath);
            }
        }

        //Testcase for deleting education record
        [Test, Order(3)]
        public void DeleteEducationRecord()
        {
            try
            {
                CommonDriver.StartTest("DeleteEducationRecord");
                CommonDriver.LogTestInfo("DeleteEducationRecord started.");
                var deleteEducationData = GetCreateEducationData("D:\\Eba\\Industry Connect\\WorkSpace\\MarsQA\\MarsQA_MVP\\MarsQA_Nunit\\MarsQA_Nunit\\Data\\createEducationData.json");
                education.DeleteEducationRecord(deleteEducationData);
                Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[1]/div", 30);
                Thread.Sleep(3000);
                IWebElement record = driver.FindElement(By.XPath("/html/body/div[1]/div"));
                Assert.That(record.Text == deleteEducationData.ExpectedMessage, "Education is not deleted");
                CommonDriver.LogTestSuccess("DeleteEducationRecord passed.");
            }
            catch (Exception ex)
            {
                CommonDriver.LogTestFailure("DeleteEducationRecord is failed. " + ex.Message);
            }
        }

        //Test to determine whether education record cannot be added without degree
        [Test, Order(4)]
        public void AddEducationRecordWithoutDegree()
        {
            try
            {
                CommonDriver.StartTest("AddEducationRecordWithoutDegree");
                CommonDriver.LogTestInfo("Add EducationRecord started.");
                var data = GetCreateEducationDataWithoutDegree("D:\\Eba\\Industry Connect\\WorkSpace\\MarsQA\\MarsQA_MVP\\MarsQA_Nunit\\MarsQA_Nunit\\Data\\educationRecordWithoutDegree.json");
                education.CreateEducationWithoutDegree(data);
                Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[1]/div", 30);
                IWebElement record = driver.FindElement(By.XPath("/html/body/div[1]/div"));
                Assert.That(record.Text == data.ExpectedMessage, "Education is not added without degree");
                CommonDriver.LogTestSuccess("AddEducationRecordWithoutDegree passed.");
            }
            catch (Exception ex)
            {
                CommonDriver.LogTestFailure("AddEducationRecordWithoutDegree is failed. " + ex.Message);
            }
        }
    }
}