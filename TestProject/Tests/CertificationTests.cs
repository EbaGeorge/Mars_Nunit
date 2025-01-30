using MarsQA_Nunit.Models;
using MarsQA_Nunit.Pages;
using MarsQA_Nunit.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace MarsQA_Nunit.Tests
{
    [TestFixture]
    public class CertificationTests : CommonDriver
    {
        Login login = new Login();
        Certifications certification = new Certifications();
        private readonly By certificationTabLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]");
        IWebElement certificationTab;
       
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            var testData = GetTestData();
            login.LoginActions(driver, testData.LoginData);
            CertificationTab();
            
        }
        public void CertificationTab()
        {
            //Click on Certification Tab
            IWebElement certificationTab = driver.FindElement(certificationTabLocator);
            certificationTab.Click();
            DataCleanUp();
        }
        

        //Method to convert data from json to c# object
        public TestData GetTestData()
        {
            var json = File.ReadAllText("D:\\Eba\\Industry Connect\\WorkSpace\\MarsQA\\MarsQA_MVP\\MarsQA_Nunit\\MarsQA_Nunit\\Data\\testData.json");
            return JsonConvert.DeserializeObject<TestData>(json);
        }

        //Testcase for creating certification record
        [Test,Order(1)]
        public void CreateCertificationRecord()
        {
            //Start Test for ExtentReport
            CommonDriver.StartTest("CreateCertificationRecord");
            CommonDriver.LogTestInfo("CreateCertificationRecord started.");
            try
            {
                var testData = GetTestData();
                certification.CreateNewCertifications(driver, testData.CreateCertification);
                IWebElement record = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));
                Assert.That(record.Text == testData.CreateCertification.Certificate, "Certification is not added");
                CommonDriver.LogTestSuccess("CreateCertificationRecord is passed");
            }
            catch (Exception ex)
            {
                CommonDriver.LogTestFailure("CreateCertificationRecord is failed. " + ex.Message);
                throw;
            }                  
        }

        //Testcase to update certification record
        [Test, Order(2)]
        public void UpdateCertificationRecord()
        {
            CommonDriver.StartTest("UpdateCertificationRecord");
            CommonDriver.LogTestInfo("UpdateCertificationRecord started.");
            try
            {
                var testData = GetTestData();
                certification.UpdateCertifications(driver, testData.UpdateCertification);
                IWebElement record = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));
                Assert.That(record.Text == testData.UpdateCertification.UpdatedCertificate);
                CommonDriver.LogTestSuccess("UpdateCertificationRecord is passed");
            }
            catch (Exception ex)
            {
                CommonDriver.LogTestFailure("UpdateCertificationRecord is  failed. " + ex.Message);
                throw;
            }
        }

        //Testcase to delete certification record
        [Test, Order(3)]
        public void DeleteCertificationRecord()
        {
            CommonDriver.StartTest("DeleteCertificationRecord");
            CommonDriver.LogTestInfo("DeleteCertificationRecord started.");
            try
            {
                var testData = GetTestData();
                certification.DeleteCertifications(driver, testData.CreateCertification);
                Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[1]/div", 20);
                IWebElement record = driver.FindElement(By.XPath("/html/body/div[1]/div"));          
                Assert.That(record.Text, Is.EqualTo(testData.CreateCertification.Certificate + testData.CreateCertification.ExpectedMessage));
                CommonDriver.LogTestSuccess("DeleteCertificationRecord is passed");
            }
            catch (Exception ex)
            {
                CommonDriver.LogTestFailure("DeleteCertificationRecord is failed. " + ex.Message);
                throw;
            }
        }
       
    }
}

