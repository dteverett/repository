using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Logger;

namespace WebTester
{
    public class Medical5010 : WebForms, IWebForms
    {
        public Medical5010()
        {
        }


        public Medical5010(Client client)
        {
            this.client = client;
            this.testResults = new TestResults();
        }
                
        public override TestResults Execute(WebForms form)
        {

            executeMedical5010Test(this.TestID);
            return this.testResults;
        }

        public override TestResults Execute(WebForms form, long parentTestID)
        {

            executeMedical5010Test(this.TestID);
            return this.testResults;
        }

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private SenderAPI logger = new SenderAPI();

        private void executeMedical5010Test(long parentTestID)
        {
            this.TestID = logger.RegisterTest(parentTestID);
            this.testResults.TestID = this.TestID;
            executeMedical5010Test();
        }

        private void executeMedical5010Test()
        {
            if (this.TestID == null || this.TestID == 0)
            {
                this.TestID = logger.RegisterTest();
                this.testResults.TestID = this.TestID;
            }

            driver = new FirefoxDriver();
            baseURL = "https://onetouch.apexedi.com/";
            verificationErrors = new StringBuilder();

            RandomStringGenerator randomString = new RandomStringGenerator();
            string fName = randomString.GetLongRandom();
            string lName = randomString.GetLongRandom().Substring(2);
            string mName = fName.Substring(4, 1);
            string address = randomString.GetRandom();
            int counter = 0;

            driver.Navigate().GoToUrl(baseURL + "/secure/Login.aspx?redir=%2fsecure%2fDefault.aspx");
            driver.FindElement(By.Id("MainContent_tbUsername")).Clear();
            driver.FindElement(By.Id("MainContent_tbUsername")).SendKeys(this.client.ClientLogin);
            driver.FindElement(By.Id("MainContent_tbPassword")).Clear();
            driver.FindElement(By.Id("MainContent_tbPassword")).SendKeys(this.client.ClientPassword == null ? defaultPassword : this.client.ClientPassword);
            driver.FindElement(By.Id("MainContent_btnSubmit")).Click();
            try
            {
                driver.FindElement(By.Id("track_link"), 15).Click();
            }
            catch (NoSuchElementException ex)
            {
                counter++;
                logger.Warn(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("MainContent_ctl00_AddBatchButton"), 15).Click();
                driver.FindElement(By.Id("MainContent_ctl00_ClaimTypeBatchRadioButtonList_0"), 15).Click();
                driver.FindElement(By.Id("MainContent_ctl00_StatementCreateButton"), 5).Click();
                new SelectElement(driver.FindElement(By.Id("electronicPayerCtrl_ddlOutputSubs"), 15)).SelectByText("United Healthcare");
                driver.FindElement(By.Id("electronicPayerCtrl_rblChangeIsFor_0")).Click();
                driver.FindElement(By.Id("electronicPayerCtrl_btnSaveChanges")).Click();
                driver.FindElement(By.Id("payerCtrl_tbID"), 15).Clear();
                driver.FindElement(By.Id("payerCtrl_tbID")).SendKeys("11889");
                driver.FindElement(By.Id("payerCtrl_tbName")).Clear();
                driver.FindElement(By.Id("payerCtrl_tbName")).SendKeys("UNITED HEALTHCARE");
                driver.FindElement(By.Id("payerCtrl_tbAddress1")).Clear();
                driver.FindElement(By.Id("payerCtrl_tbAddress1")).SendKeys("PO BOX 30555");
                driver.FindElement(By.Id("payerCtrl_tbCity")).Clear();
                driver.FindElement(By.Id("payerCtrl_tbCity")).SendKeys("SALT LAKE CITY");
                new SelectElement(driver.FindElement(By.Id("payerCtrl_ddlState"))).SelectByText("UT");
                driver.FindElement(By.Id("payerCtrl_tbZip")).Clear();
                driver.FindElement(By.Id("payerCtrl_tbZip")).SendKeys("80310");
                driver.FindElement(By.Id("subscriberCtrl_tbSubscriberID")).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbSubscriberID")).SendKeys("WXYZ0969666");
                driver.FindElement(By.Id("subscriberCtrl_tbFirstName")).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbFirstName")).SendKeys(fName);
                driver.FindElement(By.Id("subscriberCtrl_tbMiddleName")).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbMiddleName")).SendKeys(mName);
                driver.FindElement(By.Id("subscriberCtrl_tbLastName")).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbLastName")).SendKeys(lName);
                driver.FindElement(By.Id("patientCtrl_tbDateOfBirth"), 5).Clear();
                driver.FindElement(By.Id("patientCtrl_tbDateOfBirth"), 5).SendKeys("06091969");
                driver.FindElement(By.Id("patientCtrl_tbFirstName")).Clear();
                driver.FindElement(By.Id("patientCtrl_tbFirstName")).SendKeys(fName);
                driver.FindElement(By.Id("patientCtrl_tbMiddleName")).Clear();
                driver.FindElement(By.Id("patientCtrl_tbMiddleName")).SendKeys(mName);
                driver.FindElement(By.Id("patientCtrl_tbLastName")).Clear();
                driver.FindElement(By.Id("patientCtrl_tbLastName")).SendKeys(lName);
                driver.FindElement(By.Id("patientCtrl_rblSex_0")).Click();
                driver.FindElement(By.Id("patientCtrl_tbAddress1")).Clear();
                driver.FindElement(By.Id("patientCtrl_tbAddress1")).SendKeys("933 EAST WING CIRCLE");
                driver.FindElement(By.Id("patientCtrl_rblPatientRelationshipToInsured_0")).Click();
                driver.FindElement(By.Id("patientCtrl_tbCity")).Clear();
                driver.FindElement(By.Id("patientCtrl_tbCity")).SendKeys("PLEASANT GROVE");
                new SelectElement(driver.FindElement(By.Id("patientCtrl_ddlState"))).SelectByText("UT");
                driver.FindElement(By.Id("patientCtrl_tbZip")).Clear();
                driver.FindElement(By.Id("patientCtrl_tbZip")).SendKeys("84062");
                driver.FindElement(By.Id("subscriberCtrl_tbAddress1")).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbAddress1")).SendKeys("933 EAST WING CIRCLE");
                driver.FindElement(By.Id("subscriberCtrl_tbCity")).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbCity")).SendKeys("PLEASANT GROVE");
                new SelectElement(driver.FindElement(By.Id("subscriberCtrl_ddlState"))).SelectByText("UT");
                driver.FindElement(By.Id("subscriberCtrl_tbZip")).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbZip")).SendKeys("84062");
                driver.FindElement(By.Id("patientCtrl_rblPatientMaritalStatus_2")).Click();
                driver.FindElement(By.Id("otherSubscriberCtrl_tbFirstName")).Clear();
                driver.FindElement(By.Id("otherSubscriberCtrl_tbFirstName")).SendKeys(fName);
                driver.FindElement(By.Id("otherSubscriberCtrl_tbMiddleName")).Clear();
                driver.FindElement(By.Id("otherSubscriberCtrl_tbMiddleName")).SendKeys(mName);
                driver.FindElement(By.Id("otherSubscriberCtrl_tbLastName")).Clear();
                driver.FindElement(By.Id("otherSubscriberCtrl_tbLastName")).SendKeys(lName);
                driver.FindElement(By.Id("otherSubscriberCtrl_tbGroupNumber")).Clear();
                driver.FindElement(By.Id("otherSubscriberCtrl_tbGroupNumber")).SendKeys("BCCA569121002");
                driver.FindElement(By.Id("subscriberCtrl_tbGroupNumber")).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbGroupNumber")).SendKeys("NONE");
                driver.FindElement(By.Id("otherSubscriberCtrl_tbDateOfBirth"), 5).Clear();
                driver.FindElement(By.Id("otherSubscriberCtrl_tbDateOfBirth"), 5).SendKeys("06091969");
                driver.FindElement(By.Id("subscriberCtrl_rblSex_0")).Click();
                driver.FindElement(By.Id("subscriberCtrl_tbDateOfBirth"), 5).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbDateOfBirth"), 5).SendKeys("06091969");
                driver.FindElement(By.Id("otherSubscriberCtrl_rblSex_0")).Click();
                driver.FindElement(By.Id("otherPayerCtrl_tbName")).Clear();
                driver.FindElement(By.Id("otherPayerCtrl_tbName")).SendKeys("MEDICARE UT");
                driver.FindElement(By.Id("patientSignatureCtrl_cbSignatureOnFile")).Click();
                driver.FindElement(By.Id("subscriberCtrl_cbSignatureOnFile")).Click();
                driver.FindElement(By.Id("referringProviderCtrl_tbFirstName")).Clear();
                driver.FindElement(By.Id("referringProviderCtrl_tbFirstName")).SendKeys("SAURON");
                driver.FindElement(By.Id("referringProviderCtrl_tbMiddleName")).Clear();
                driver.FindElement(By.Id("referringProviderCtrl_tbMiddleName")).SendKeys("OF");
                driver.FindElement(By.Id("referringProviderCtrl_tbLastName")).Clear();
                driver.FindElement(By.Id("referringProviderCtrl_tbLastName")).SendKeys("MORDOR");
                driver.FindElement(By.Id("referringProviderCtrl_tbNPI")).Clear();
                driver.FindElement(By.Id("referringProviderCtrl_tbNPI")).SendKeys("1234567893");
                driver.FindElement(By.Id("diagnosisCodesCtrl_tbReservedForLocalUse")).Clear();
                driver.FindElement(By.Id("diagnosisCodesCtrl_tbReservedForLocalUse")).SendKeys("SECONDARYCLAIM");
                driver.FindElement(By.Id("diagnosisCodesCtrl_tbDiagnosisCode1")).Clear();
                driver.FindElement(By.Id("diagnosisCodesCtrl_tbDiagnosisCode1")).SendKeys("611.1");
                driver.FindElement(By.Id("diagnosisCodesCtrl_tbDiagnosisCode2")).Clear();
                driver.FindElement(By.Id("diagnosisCodesCtrl_tbDiagnosisCode2")).SendKeys("251.2");
                driver.FindElement(By.Id("divLinkLeft1"), 5).Click();
                driver.FindElement(By.Id("lineCtrl1_tbDateFrom"), 10).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbDateFrom"), 10).SendKeys("03022013");
                driver.FindElement(By.Id("lineCtrl1_tbDateTo"), 10).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbDateTo"), 10).SendKeys("03022013");
                driver.FindElement(By.Id("lineCtrl1_tbPlaceOfServiceCode")).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbPlaceOfServiceCode")).SendKeys("22");
                driver.FindElement(By.Id("lineCtrl1_tbProcedureCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbProcedureCode"), 5).SendKeys("95165");
                driver.FindElement(By.Id("lineCtrl1_tbDiagnosisCodePointer1")).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbDiagnosisCodePointer1")).SendKeys("1");
                driver.FindElement(By.Id("lineCtrl1_tbCharges")).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbCharges")).SendKeys("500");
                driver.FindElement(By.Id("lineCtrl1_tbQuantity")).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbQuantity")).SendKeys("1");
                driver.FindElement(By.Id("lineCtrl1_tbNPI")).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbNPI")).SendKeys("1234567893");
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_tbAdjudicationDate"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_tbAdjudicationDate"), 5).SendKeys("03072013");
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_tbPrimaryPaidAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_tbPrimaryPaidAmount")).SendKeys("300");
                new SelectElement(driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment0_ddlAdjustmentGroupCode"))).SelectByText("PR - Patient Responsibility");
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment0_tbAdjustmentReasonCode")).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment0_tbAdjustmentReasonCode")).SendKeys("66");
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment0_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment0_tbAdjustmentAmount")).SendKeys("100");
                new SelectElement(driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment1_ddlAdjustmentGroupCode"))).SelectByText("CO - Contractual Obligations");
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment1_tbAdjustmentReasonCode")).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment1_tbAdjustmentReasonCode")).SendKeys("45");
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys("100");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, this.TestID);
                counter++;
            }
            try
            {

                //driver.FindElement(By.Id("lbAddNewLine")).Click();
                //driver.FindElement(By.Id("lineCtrl2_tbPlaceOfServiceCode")).Clear();
                //driver.FindElement(By.Id("lineCtrl2_tbPlaceOfServiceCode")).SendKeys("22");
                //driver.FindElement(By.Id("lineCtrl2_tbDiagnosisCodePointer1")).Clear();
                //driver.FindElement(By.Id("lineCtrl2_tbDiagnosisCodePointer1")).SendKeys("2");
                //driver.FindElement(By.Id("lineCtrl2_tbCharges")).Clear();
                //driver.FindElement(By.Id("lineCtrl2_tbCharges")).SendKeys("500");
                //driver.FindElement(By.Id("lineCtrl2_tbQuantity")).Clear();
                //driver.FindElement(By.Id("lineCtrl2_tbQuantity")).SendKeys("1");
                //driver.FindElement(By.Id("lineCtrl2_tbNPI")).Clear();
                //driver.FindElement(By.Id("lineCtrl2_tbNPI")).SendKeys("1234567893");
                //driver.FindElement(By.Id("divLinkLeft2")).Click();
                //driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_tbPrimaryPaidAmount")).Clear();
                //driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_tbPrimaryPaidAmount")).SendKeys("300");
                //new SelectElement(driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment0_ddlAdjustmentGroupCode"))).SelectByText("OA - Other Adjustments");
                //driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment0_tbAdjustmentReasonCode")).Clear();
                //driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment0_tbAdjustmentReasonCode")).SendKeys("102");
                //driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment0_tbAdjustmentAmount")).Clear();
                //driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment0_tbAdjustmentAmount")).SendKeys("100");
                //new SelectElement(driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_ddlAdjustmentGroupCode"))).SelectByText("OA - Other Adjustments");
                //driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentReasonCode")).Clear();
                //driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentReasonCode")).SendKeys("11");
                //driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                //driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys("100");


                driver.FindElement(By.Id("taxIDCtrl_tbPatientAccountNumber")).Clear();
                driver.FindElement(By.Id("taxIDCtrl_tbPatientAccountNumber")).SendKeys("DABRAH20132");
                driver.FindElement(By.Id("taxIDCtrl_rblAcceptAssignment_0")).Click();
                driver.FindElement(By.Id("tbSignatureOfPhysician")).Clear();
                driver.FindElement(By.Id("tbSignatureOfPhysician")).SendKeys("DR SAURON OF MORDOR");
                driver.FindElement(By.Id("tbSignatureOfPhysicianDate"), 5).Clear();
                driver.FindElement(By.Id("tbSignatureOfPhysicianDate"), 5).SendKeys("04012013");
                driver.FindElement(By.Id("facilityInfoCtrl_tbFacilityName")).Clear();
                driver.FindElement(By.Id("facilityInfoCtrl_tbFacilityName")).SendKeys("MORDOR");
                driver.FindElement(By.Id("facilityInfoCtrl_tbAddress1")).Clear();
                driver.FindElement(By.Id("facilityInfoCtrl_tbAddress1")).SendKeys("911 S 1450 E");
                driver.FindElement(By.Id("facilityInfoCtrl_tbCity")).Clear();
                driver.FindElement(By.Id("facilityInfoCtrl_tbCity")).SendKeys("OREM");
                new SelectElement(driver.FindElement(By.Id("facilityInfoCtrl_ddlState"))).SelectByText("UT");
                driver.FindElement(By.Id("facilityInfoCtrl_tbZip")).Clear();
                driver.FindElement(By.Id("facilityInfoCtrl_tbZip")).SendKeys("84057");
                driver.FindElement(By.Id("facilityInfoCtrl_tbContactName")).Clear();
                driver.FindElement(By.Id("facilityInfoCtrl_tbContactName")).SendKeys("SAURON");
                driver.FindElement(By.Id("facilityInfoCtrl_tbNPI")).Clear();
                driver.FindElement(By.Id("facilityInfoCtrl_tbNPI")).SendKeys("1234567893");
                driver.FindElement(By.Id("btnSubmit")).Click();

                driver.FindElement(By.Id("track_link"), 15).Click();
                driver.FindElement(By.Id("MainContent_ct100_TrackBatch_btnReleaseBatch_0"), 20).Click();


            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, this.TestID);
                counter++;
            }
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());

            if (counter == 0)
            {
                logger.PassFailTest(true, this.TestID);
                this.testResults.Pass = true;
            }

        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alert.Text;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    
    }
}
