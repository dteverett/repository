using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Logger;


namespace WebTester
{
    public class CASSegment : WebForms
    {
        public CASSegment()
        {
        }

        public CASSegment(Client client)
        {
            this.client = client;
            this.testResults = new TestResults();
        }

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        RandomStringGenerator randomString;


        static SenderAPI logger = new SenderAPI();



        public override TestResults Execute(WebForms form)
        {
            this.TestID = logger.RegisterTest();
            CASSegmentExecute();
            return this.testResults;
        }

        public override TestResults Execute(WebForms form, long parentTestID)
        {
            this.TestID = logger.RegisterTest(parentTestID);
            CASSegmentExecute();
            return this.testResults;
        }



        /// <summary>
        /// /////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="TestID"></param>
        /// <param name="groupCode"></param>


        

        private void CASSegmentExecute()
        {
            long TestID = this.TestID;
            string clientID = this.client.ClientID;

            randomString = new RandomStringGenerator();
            string fName = randomString.GetLongRandom();
            string lName = randomString.GetLongRandom().Substring(2);
            string mName = fName.Substring(4, 1);
            string address = randomString.GetRandom();
            int counter = 0;

            driver = new FirefoxDriver();
            baseURL = "https://onetouch.apexedi.com/";
            verificationErrors = new StringBuilder();

            try
            {
                driver.Navigate().GoToUrl(baseURL + "/secure/Login.aspx?redir=%2fsecure%2fDefault.aspx");
                driver.FindElement(By.Id("MainContent_tbUsername")).Clear();
                driver.FindElement(By.Id("MainContent_tbUsername")).SendKeys(client.ClientLogin);
                driver.FindElement(By.Id("MainContent_tbPassword")).Clear();
                driver.FindElement(By.Id("MainContent_tbPassword")).SendKeys(client.ClientPassword);
                driver.FindElement(By.Id("MainContent_btnSubmit")).Click();
            }
            catch (Exception ex)
            {
                logger.Fatal("Failure to Log on to OneTouch: " + ex.Message, TestID);
                counter++;
            }
            try
            {
                driver.FindElement(By.Id("track_link"), 15).Click();
                driver.FindElement(By.Id("ctl00_MainContent_ctl00_AddBatchButton")).Click();
                driver.FindElement(By.Id("ctl00_MainContent_ctl00_ClaimTypeBatchRadioButtonList_0")).Click();
                driver.FindElement(By.Id("ctl00_MainContent_ctl00_StatementCreateButton")).Click();
            }
            catch (Exception ex)
            {
                logger.Fatal("Unable to create new batch: " + ex.Message, TestID);
                counter++;
                return;
            }
            try
            {

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
                driver.FindElement(By.Id("patientCtrl_tbFirstName")).Clear();
                driver.FindElement(By.Id("patientCtrl_tbFirstName")).SendKeys(fName);
                driver.FindElement(By.Id("patientCtrl_tbMiddleName")).Clear();
                driver.FindElement(By.Id("patientCtrl_tbMiddleName")).SendKeys(mName);
                driver.FindElement(By.Id("patientCtrl_tbLastName")).Clear();
                driver.FindElement(By.Id("patientCtrl_tbLastName")).SendKeys(lName);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
                counter++;
            }
            try
            {
                
                driver.FindElement(By.Id("patientCtrl_tbDateOfBirth"), 5).Clear();
                driver.FindElement(By.Id("patientCtrl_tbDateOfBirth"), 5).SendKeys("01111969");
            }
            catch (Exception ex)
            {
                logger.Error("Unable to locate DateBox: " + ex.Message, TestID);
                counter++;
            }
            try
            {
                
                driver.FindElement(By.Id("patientCtrl_rblSex_0")).Click();
                driver.FindElement(By.Id("subscriberCtrl_tbFirstName")).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbFirstName")).SendKeys(fName);
                driver.FindElement(By.Id("subscriberCtrl_tbMiddleName")).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbMiddleName")).SendKeys(mName);
                driver.FindElement(By.Id("subscriberCtrl_tbLastName")).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbLastName")).SendKeys(lName);
                driver.FindElement(By.Id("patientCtrl_tbAddress1")).Clear();
                driver.FindElement(By.Id("patientCtrl_tbAddress1")).SendKeys(address);
                driver.FindElement(By.Id("patientCtrl_rblPatientRelationshipToInsured_0")).Click();
                driver.FindElement(By.Id("subscriberCtrl_tbAddress1")).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbAddress1")).SendKeys(address);
                driver.FindElement(By.Id("patientCtrl_tbCity")).Clear();
                driver.FindElement(By.Id("patientCtrl_tbCity")).SendKeys("SALEMBURG");
                new SelectElement(driver.FindElement(By.Id("patientCtrl_ddlState"))).SelectByText("NC");
                driver.FindElement(By.Id("patientCtrl_tbZip")).Clear();
                driver.FindElement(By.Id("patientCtrl_tbZip")).SendKeys("28385");
                driver.FindElement(By.Id("patientCtrl_rblPatientMaritalStatus_1")).Click();
                driver.FindElement(By.Id("subscriberCtrl_tbCity")).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbCity")).SendKeys("SALEMBURG");
                new SelectElement(driver.FindElement(By.Id("subscriberCtrl_ddlState"))).SelectByText("NC");
                driver.FindElement(By.Id("subscriberCtrl_tbZip")).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbZip")).SendKeys("28385");
                driver.FindElement(By.Id("subscriberCtrl_tbGroupNumber")).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbGroupNumber")).SendKeys("NONE");
                driver.FindElement(By.Id("otherSubscriberCtrl_tbFirstName")).Clear();
                driver.FindElement(By.Id("otherSubscriberCtrl_tbFirstName")).SendKeys(fName);
                driver.FindElement(By.Id("otherSubscriberCtrl_tbMiddleName")).Clear();
                driver.FindElement(By.Id("otherSubscriberCtrl_tbMiddleName")).SendKeys(mName);
                driver.FindElement(By.Id("otherSubscriberCtrl_tbLastName")).Clear();
                driver.FindElement(By.Id("otherSubscriberCtrl_tbLastName")).SendKeys(lName);
                driver.FindElement(By.Id("otherSubscriberCtrl_tbGroupNumber")).Clear();
                driver.FindElement(By.Id("otherSubscriberCtrl_tbGroupNumber")).SendKeys("242622952Z");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
                counter++;
            }
            try
            {
                driver.FindElement(By.Id("otherSubscriberCtrl_tbDateOfBirth"), 5).Clear();
                driver.FindElement(By.Id("otherSubscriberCtrl_tbDateOfBirth"), 5).SendKeys("01111969");
            }
            catch (Exception ex)
            {
                logger.Error("Unable to locate DateBox: " + ex.Message, TestID);
                counter++;
            }
            try
            {
                driver.FindElement(By.Id("otherSubscriberCtrl_rblSex_0")).Click();
                driver.FindElement(By.Id("otherPayerCtrl_tbName")).Clear();
                driver.FindElement(By.Id("otherPayerCtrl_tbName")).SendKeys("MEDICARE NC");
                driver.FindElement(By.Id("patientSignatureCtrl_cbSignatureOnFile")).Click();
                driver.FindElement(By.Id("subscriberCtrl_cbSignatureOnFile")).Click();
                driver.FindElement(By.Id("referringProviderCtrl_tbFirstName")).Clear();
                driver.FindElement(By.Id("referringProviderCtrl_tbFirstName")).SendKeys("THE");
                driver.FindElement(By.Id("referringProviderCtrl_tbMiddleName")).Clear();
                driver.FindElement(By.Id("referringProviderCtrl_tbMiddleName")).SendKeys("DARK");
                driver.FindElement(By.Id("referringProviderCtrl_tbLastName")).Clear();
                driver.FindElement(By.Id("referringProviderCtrl_tbLastName")).SendKeys("LORD");
                driver.FindElement(By.Id("referringProviderCtrl_tbNPI")).Clear();
                driver.FindElement(By.Id("referringProviderCtrl_tbNPI")).SendKeys("1942263470");
                driver.FindElement(By.Id("diagnosisCodesCtrl_tbReservedForLocalUse")).Clear();
                driver.FindElement(By.Id("diagnosisCodesCtrl_tbReservedForLocalUse")).SendKeys("SECONDARYCLAIM");
                driver.FindElement(By.Id("diagnosisCodesCtrl_tbDiagnosisCode1")).Clear();
                driver.FindElement(By.Id("diagnosisCodesCtrl_tbDiagnosisCode1")).SendKeys("611.1");
                driver.FindElement(By.Id("divLinkLeft1")).Click();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
                counter++;
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_tbDateFrom"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbDateFrom"), 5).SendKeys("03102013");
                driver.FindElement(By.Id("lineCtrl1_tbDateTo"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbDateTo"), 5).SendKeys("03102013");
                
            }
            catch (Exception ex)
            {
                logger.Error("Unable to locate DateBox in Line Items Medical Form: " + ex.Message, TestID); 
                counter++;
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_tbPlaceOfServiceCode"), 10).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbPlaceOfServiceCode")).SendKeys("22");
                driver.FindElement(By.Id("lineCtrl1_tbProcedureCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbProcedureCode"), 5).SendKeys("19300");
                driver.FindElement(By.Id("lineCtrl1_tbDiagnosisCodePointer1")).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbDiagnosisCodePointer1")).SendKeys("1");
                driver.FindElement(By.Id("lineCtrl1_tbCharges")).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbCharges")).SendKeys("1158");
                driver.FindElement(By.Id("lineCtrl1_tbQuantity")).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbQuantity")).SendKeys("1");
                driver.FindElement(By.Id("lineCtrl1_tbNPI")).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbNPI")).SendKeys("1234567893");
                driver.FindElement(By.Id("lineCtrl1_tbNotes")).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbNotes")).SendKeys("TEST");
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_tbPrimaryPaidAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_tbPrimaryPaidAmount")).SendKeys("303.04");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
                counter++;
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_tbAdjudicationDate"), 10).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_tbAdjudicationDate"), 5).SendKeys("03272013");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
                counter++;
            }
            try
            {
                new SelectElement(driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment0_ddlAdjustmentGroupCode"))).SelectByText("CO - Contractual Obligations");
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment0_tbAdjustmentReasonCode")).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment0_tbAdjustmentReasonCode")).SendKeys("45");
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment0_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment0_tbAdjustmentAmount")).SendKeys("779.20");
                new SelectElement(driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment1_ddlAdjustmentGroupCode"))).SelectByText("PR - Patient Responsibility");
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment1_tbAdjustmentReasonCode")).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment1_tbAdjustmentReasonCode")).SendKeys("66");
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys("75.76");
                driver.FindElement(By.Id("taxIDCtrl_tbPatientAccountNumber")).Clear();
                driver.FindElement(By.Id("taxIDCtrl_tbPatientAccountNumber")).SendKeys("011941" + lName);
                driver.FindElement(By.Id("taxIDCtrl_rblAcceptAssignment_0")).Click();
                driver.FindElement(By.Id("tbSignatureOfPhysician")).Clear();
                driver.FindElement(By.Id("tbSignatureOfPhysician")).SendKeys("DR FRODO BAGGINS");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
                counter++;
            }
            try
            {
                driver.FindElement(By.Id("tbSignatureOfPhysicianDate"), 5).Clear();
                driver.FindElement(By.Id("tbSignatureOfPhysicianDate"), 5).SendKeys("04012013");
            }
            catch (Exception ex)
            {
                logger.Error("Unable to locate DateBox for physician Signature: " + ex.Message, TestID);
                counter++;
            }
            try
            {
                driver.FindElement(By.Id("facilityInfoCtrl_tbFacilityName")).Clear();
                driver.FindElement(By.Id("facilityInfoCtrl_tbFacilityName")).SendKeys("SAMPSON REG MED");
                driver.FindElement(By.Id("facilityInfoCtrl_tbAddress1")).Clear();
                driver.FindElement(By.Id("facilityInfoCtrl_tbAddress1")).SendKeys("607 BEAMAN STREET");
                driver.FindElement(By.Id("facilityInfoCtrl_tbCity")).Clear();
                driver.FindElement(By.Id("facilityInfoCtrl_tbCity")).SendKeys("CLINTON");
                new SelectElement(driver.FindElement(By.Id("facilityInfoCtrl_ddlState"))).SelectByText("NC");
                driver.FindElement(By.Id("facilityInfoCtrl_tbZip")).Clear();
                driver.FindElement(By.Id("facilityInfoCtrl_tbZip")).SendKeys("28328-2647");
                driver.FindElement(By.Id("facilityInfoCtrl_tbNPI")).Clear();
                driver.FindElement(By.Id("facilityInfoCtrl_tbNPI")).SendKeys("1609857432");
                driver.FindElement(By.Id("btnSubmit"), 5).Click();
                driver.FindElement(By.Id("btnSubmit"), 20).Click();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
                counter++;
            }
            try
            {
                Assert.AreEqual("$1158.00", driver.FindElement(By.Id("taxIDCtrl_tbTotalCharge"), 15).GetAttribute("value"));
            }
            catch (Exception e)
            {
                logger.Error(e.Message, TestID);
                counter++;
            }
            try
            {
                driver.FindElement(By.Id("track_link"), 5).Click();
                //driver.FindElement(By.Id("MainContent_ct100_TrackBatch_btn
                driver.FindElement(By.Id("MainContent_ctl00_TrackBatch_btnReleaseBatch_0"), 10).Click();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
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
                logger.PassFailTest(true, TestID);
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
