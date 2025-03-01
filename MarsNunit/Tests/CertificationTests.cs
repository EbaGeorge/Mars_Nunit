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
        Login login;
        Certifications certification;
        public CertificationTests()
        {
            login=new Login();
            certification=new Certifications();
        }
        private readonly By certificationTabLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]");
        IWebElement certificationTab;

        [SetUp]
        public void Setup()
        {
           Initialise();
            var loginData = GetLoginData("D:\\Eba\\Industry Connect\\WorkSpace\\MarsQA\\MarsQA_MVP\\MarsQA_Nunit\\MarsQA_Nunit\\Data\\loginData.json");
            login.LoginActions(loginData);
            CertificationTab();
            DataCleanUp();

        }
        public void CertificationTab()
        {
            //Click on Certification Tab
            IWebElement certificationTab = driver.FindElement(certificationTabLocator);
            certificationTab.Click();
        }

        //Testcase for creating certification record
        [Test, Order(1)]
        public void CreateCertificationRecord()
        {
            //Start Test for ExtentReport
            CommonDriver.StartTest("CreateCertificationRecord");
            CommonDriver.LogTestInfo("CreateCertificationRecord started.");
            try
            {
                var testData = GetCreateCertificationData("D:\\Eba\\Industry Connect\\WorkSpace\\MarsQA\\MarsQA_MVP\\MarsQA_Nunit\\MarsQA_Nunit\\Data\\createCertificationData.json");
                certification.CreateNewCertifications(testData);
                IWebElement record = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));
                Assert.That(record.Text == testData.Certificate, "Certification is not added");
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
                var testData = GetUpdateCertificationData("D:\\Eba\\Industry Connect\\WorkSpace\\MarsQA\\MarsQA_MVP\\MarsQA_Nunit\\MarsQA_Nunit\\Data\\updateCertificationData.json");
                certification.UpdateCertifications(testData);
                IWebElement record = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));
                Assert.That(record.Text == testData.UpdatedCertificate);
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
                var testData = GetCreateCertificationData("D:\\Eba\\Industry Connect\\WorkSpace\\MarsQA\\MarsQA_MVP\\MarsQA_Nunit\\MarsQA_Nunit\\Data\\createCertificationData.json");
                certification.DeleteCertifications(testData);
                Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[1]/div", 20);
                IWebElement record = driver.FindElement(By.XPath("/html/body/div[1]/div"));
                Assert.That(record.Text, Is.EqualTo(testData.Certificate + testData.ExpectedMessage));
                CommonDriver.LogTestSuccess("DeleteCertificationRecord is passed");
            }
            catch (Exception ex)
            {
                CommonDriver.LogTestFailure("DeleteCertificationRecord is failed. " + ex.Message);
                throw;
            }
        }
        public CreateCertification GetCreateCertificationData(string filePath)
        {

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<CreateCertification>(json);
        }
        public UpdateCertification GetUpdateCertificationData(string filePath)
        {

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<UpdateCertification>(json);
        }

        public CreateCertificationWithoutAward GetCreateCertificationDataWithoutCertificate(string filePath)
        {

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<CreateCertificationWithoutAward>(json);
        }

        //Testcase to determine whether certification cannot be added without Certificate/Award
        [Test, Order(4)]
        public void CreateCertificationRecordWithoutCertificate()
        {
            //Start Test for ExtentReport
            CommonDriver.StartTest("CreateCertificationRecordWithoutCertificate");
            CommonDriver.LogTestInfo("CreateCertificationRecordWithoutCertificate started.");
            try
            {
                var testData = GetCreateCertificationDataWithoutCertificate("D:\\Eba\\Industry Connect\\WorkSpace\\MarsQA\\MarsQA_MVP\\MarsQA_Nunit\\MarsQA_Nunit\\Data\\createCertificationWithoutAward.json");
                certification.CreateNewCertificationsWithoutAward(testData);                      
                IWebElement record = driver.FindElement(By.XPath("/html/body/div[1]/div"));
                Assert.That(record.Text == testData.ExpectedMessage, "Certification is added without award");
                CommonDriver.LogTestSuccess("CreateCertificationRecordWithoutCertificate is passed");
            }
            catch (Exception ex)
            {
                CommonDriver.LogTestFailure("CreateCertificationRecordWithoutCertificate is failed. " + ex.Message);
                throw;
            }
        }

    }
}