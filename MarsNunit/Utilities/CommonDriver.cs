using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using MarsQA_Nunit.Models;
using MarsQA_Nunit.Pages;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace MarsQA_Nunit.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentTest test;
        
        //File path where report is generated
        private static string reportPath = "extentReports.html";

        public void Initialise()
        {
            // create driver
            driver = new ChromeDriver();

        }
        // Set up ExtentReports once for the entire suite
        [OneTimeSetUp]
        public static void SetupExtentReport()
        {
            // Initialize the ExtentReports only once(if we want to get testcase report for both education and certification.)
            if (extent == null)
            {
                var htmlReporter = new ExtentSparkReporter(reportPath);
                extent = new ExtentReports();
                // Attach reporter to extent
                extent.AttachReporter(htmlReporter);
            }
        }

        // Finalize the report after all tests
        [OneTimeTearDown]
        public static void TearDownExtentReport()
        {
            extent.Flush();
        }

        // Start a test and log details
        public static void StartTest(string testName)
        {
            test = extent.CreateTest(testName);
        }

        // Log test success
        public static void LogTestSuccess(string message)
        {
            if (test != null) test.Pass(message);
        }

        // Log test failure
        public static void LogTestFailure(string message)
        {
            if (test != null) test.Fail(message);
        }

        // Log information during the test execution
        public static void LogTestInfo(string message)
        {
            if (test != null) test.Info(message);
        }

        //Executed after every testcase
        [TearDown]
        public void Close()
        {
            DataCleanUp();
            driver.Quit();

        }

        //Method to perform DataCleanUp
        public void DataCleanUp()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

                while (true)
                {
                    IWebElement deleteButton;
                    try
                    {

                        Wait.WaitToBeVisible(driver, "XPath", "(//td[@class='right aligned']//i[@class='remove icon'])[1]", 38);
                        deleteButton = driver.FindElement(By.XPath("(//td[@class='right aligned']//i[@class='remove icon'])[1]"));
                        deleteButton.Click();
                        Console.WriteLine("Record deleted.");
                        break;
                        
                    }
                    catch (StaleElementReferenceException)
                    {
                        Console.WriteLine("The element is stale. Re-locating...");
                        continue;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error during deletion: {e.Message}");
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Safe Click failed: " + e.Message);
            }
        }

        //Method to convert login json data to c# object
        public LoginData GetLoginData(string filePath)
        {
            string json = File.ReadAllText(filePath);
            LoginData data = JsonConvert.DeserializeObject<LoginData>(json);
            return data;
        }
       
    }
}