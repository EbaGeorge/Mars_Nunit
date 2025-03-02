using MarsQA_Nunit.Models;
using MarsQA_Nunit.Utilities;
using OpenQA.Selenium;

namespace MarsQA_Nunit.Pages
{
    public class Certifications:CommonDriver
    {
        private readonly By certificationTabLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]");
        IWebElement certificationTab;
        private readonly By addNewBtnLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div");
        IWebElement addNewBtn;
        private readonly By yearLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select");
        IWebElement year;
        private readonly By addBtnLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]");
        IWebElement addBtn;
        private readonly By editIconLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i");
        IWebElement editIcon;
        private readonly By updateBtnLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]");
        IWebElement update;
        private readonly By certificateFromLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/div/div[2]/input");
        IWebElement certificateFromToBeUpdated;
        private readonly By certificateLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/div/div[1]/input");
        IWebElement certificate;
        private readonly By yearToBeLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/div/div[3]/select");
        IWebElement yearToBeUpdated;
        private readonly By deleteIconLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]/i");
        IWebElement deleteIcon;

        //Method to create new certification record
        public void CreateNewCertifications(CreateCertification record)
        {

            //Click on Certification Tab
            certificationTab = driver.FindElement(certificationTabLocator);
            certificationTab.Click();

            //Click on Add New Button
            addNewBtn = driver.FindElement(addNewBtnLocator);
            addNewBtn.Click();

            //Enter Certificate/Award
            IWebElement certificate = driver.FindElement(By.Name("certificationName"));
            certificate.SendKeys(record.Certificate);

            //Enter Certified From
            IWebElement certificateFrom = driver.FindElement(By.Name("certificationFrom"));
            certificateFrom.SendKeys(record.CertificateFrom);

            //Select Year
            year = driver.FindElement(yearLocator);
            year.SendKeys(record.Year);

            //Click on Add Button
            IWebElement addBtn = driver.FindElement(addBtnLocator);
            addBtn.Click();
        }

        //Method to update certification record
        public void UpdateCertifications(UpdateCertification record)
        {

            //Click on Certification Tab
            certificationTab = driver.FindElement(certificationTabLocator);
            certificationTab.Click();

            //Click on Add New Button
            addNewBtn = driver.FindElement(addNewBtnLocator);
            addNewBtn.Click();

            //Enter Certificate/Award
            IWebElement certificate = driver.FindElement(By.Name("certificationName"));
            certificate.SendKeys(record.Certificate);

            //Enter Certified From
            IWebElement certificateFrom = driver.FindElement(By.Name("certificationFrom"));
            certificateFrom.SendKeys(record.CertificateFrom);

            //Select Year
            year = driver.FindElement(yearLocator);
            year.SendKeys(record.Year);

            //Click on Add Button
            addBtn = driver.FindElement(addBtnLocator);
            addBtn.Click();

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i", 20);

            //Click on Update Icon
            editIcon = driver.FindElement(editIconLocator);
            editIcon.Click();

            //Update Certificate/Award
            certificate = driver.FindElement(certificateLocator);
            certificate.Clear();
            certificate.SendKeys(record.UpdatedCertificate);

            //Update Certified From
            certificateFromToBeUpdated = driver.FindElement(certificateFromLocator);
            certificateFromToBeUpdated.Clear();
            certificateFromToBeUpdated.SendKeys(record.UpdatedCertificateFrom);

            //Update Year
            yearToBeUpdated = driver.FindElement(yearToBeLocator);
            yearToBeUpdated.Click();
            yearToBeUpdated.SendKeys(record.UpdatedYear);
            yearToBeUpdated.Click();

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]", 20);

            //Click on Update Button
            update = driver.FindElement(updateBtnLocator);
            update.Click();
            Thread.Sleep(2000);
        }

        //Method to delete certification record
        public void DeleteCertifications(CreateCertification record)
        {

            //Click on Certification Tab
            certificationTab = driver.FindElement(certificationTabLocator);
            certificationTab.Click();

            //Click on Add New Button
            addNewBtn = driver.FindElement(addNewBtnLocator);
            addNewBtn.Click();

            //Enter Certificate/Award
            IWebElement certificate = driver.FindElement(By.Name("certificationName"));
            certificate.SendKeys(record.Certificate);

            //Enter Certified From
            IWebElement certificateFrom = driver.FindElement(By.Name("certificationFrom"));
            certificateFrom.SendKeys(record.CertificateFrom);

            //Select Year
            year = driver.FindElement(yearLocator);
            year.SendKeys(record.Year);

            //Click on Add Button
            addBtn = driver.FindElement(addBtnLocator);
            addBtn.Click();

            //Click on Delete icon
            IWebElement deleteIcon = driver.FindElement(deleteIconLocator);
            deleteIcon.Click();
            Thread.Sleep(3000);
        }
        //Method to create certification record without award
        public void CreateNewCertificationsWithoutAward(CreateCertificationWithoutAward record)
        {

            //Click on Certification Tab
            certificationTab = driver.FindElement(certificationTabLocator);
            certificationTab.Click();

            //Click on Add New Button
            addNewBtn = driver.FindElement(addNewBtnLocator);
            addNewBtn.Click();

            //Enter Certified From
            IWebElement certificateFrom = driver.FindElement(By.Name("certificationFrom"));
            certificateFrom.SendKeys(record.CertificateFrom);

            //Select Year
            year = driver.FindElement(yearLocator);
            year.SendKeys(record.Year);

            //Click on Add Button
            IWebElement addBtn = driver.FindElement(addBtnLocator);
            addBtn.Click();
        }
    }
}