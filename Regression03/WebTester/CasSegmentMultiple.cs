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
    public class CASSegmentMultiple : WebForms
    {
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


        private void CASSegmentExecute()
        {
            long TestID = this.TestID;
            string clientID = this.client.ClientID;
            float total = 0.0f;

            float paidAmount = 50.04f;
            float adjustment0 = 779.20f;
            float adjustment1 = 75.76f;
            float adjustment2 = 100.00f;
            float adjustment3 = 44.96f;
            float adjustment4 = 19.00f;
            float adjustment5 = 87.55f;
            float adjustment6 = 13.50f;
            float adjustment7 = 111.00f;
            float adjustment8 = 39.00f;
            float adjustment9 = 66.66f;
            float adjustment10 = 213.00f;
            float adjustment11 = 69.69f;
            float adjustment12 = 4.00f;
            float adjustment13 = 9.95f;
            float adjustment14 = 71.00f;
            float adjustment15 = 21.00f;
            float adjustment16 = 0.95f;
            float adjustment17 = 44.55f;
            float adjustment18 = 66.02f;
            float adjustment19 = 147.89f;
            float adjustment20 = 12.12f;

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
                driver.FindElement(By.Id("MainContent_tbUsername")).SendKeys("admin" + clientID);
                driver.FindElement(By.Id("MainContent_tbPassword")).Clear();
                driver.FindElement(By.Id("MainContent_tbPassword")).SendKeys("hedge1!");
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
                driver.FindElement(By.Id("MainContent_ctl00_AddBatchButton"), 15).Click();
                driver.FindElement(By.Id("MainContent_ctl00_ClaimTypeBatchRadioButtonList_0"), 15).Click();
                driver.FindElement(By.Id("MainContent_ctl00_StatementCreateButton"), 15).Click();
            }
            catch (Exception ex)
            {
                logger.Fatal("Unable to create new batch: " + ex.Message, TestID);
                counter++;
            }
            try
            {

                new SelectElement(driver.FindElement(By.Id("electronicPayerCtrl_ddlOutputSubs"), 15)).SelectByText("BCBS NC (North Carolina)");
                driver.FindElement(By.Id("electronicPayerCtrl_rblChangeIsFor_0")).Click();
                driver.FindElement(By.Id("payerCtrl_tbID")).Clear();
                driver.FindElement(By.Id("payerCtrl_tbID")).SendKeys("68415");
                driver.FindElement(By.Id("payerCtrl_tbName")).Clear();
                driver.FindElement(By.Id("payerCtrl_tbName")).SendKeys("BCBS NC");
                driver.FindElement(By.Id("payerCtrl_tbAddress1")).Clear();
                driver.FindElement(By.Id("payerCtrl_tbAddress1")).SendKeys("P O BOX 1290");
                driver.FindElement(By.Id("payerCtrl_tbCity")).Clear();
                driver.FindElement(By.Id("payerCtrl_tbCity")).SendKeys("DURHAM");
                new SelectElement(driver.FindElement(By.Id("payerCtrl_ddlState"))).SelectByText("NC");
                driver.FindElement(By.Id("payerCtrl_tbZip")).Clear();
                driver.FindElement(By.Id("payerCtrl_tbZip")).SendKeys("27702");
                driver.FindElement(By.Id("box1Ctrl_cbOther")).Click();
                driver.FindElement(By.Id("subscriberCtrl_tbSubscriberID")).Clear();
                driver.FindElement(By.Id("subscriberCtrl_tbSubscriberID")).SendKeys("YPZW1314257507");
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

                driver.FindElement(By.Id("lineCtrl1_tbQuantity")).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbQuantity")).SendKeys("1");
                driver.FindElement(By.Id("lineCtrl1_tbNPI")).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbNPI")).SendKeys("1234567893");
                driver.FindElement(By.Id("lineCtrl1_tbNotes")).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbNotes")).SendKeys("TEST");
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_tbPrimaryPaidAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_tbPrimaryPaidAmount")).SendKeys(Convert.ToString(paidAmount));
                total += paidAmount;
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
            #region Adjustments
            try
            {
                new SelectElement(driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment0_ddlAdjustmentGroupCode"))).SelectByText("CO - Contractual Obligations");
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment0_tbAdjustmentReasonCode")).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment0_tbAdjustmentReasonCode")).SendKeys("45");
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment0_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment0_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment0));
                total += adjustment0;
                new SelectElement(driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment1_ddlAdjustmentGroupCode"))).SelectByText("PR - Patient Responsibility");
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment1_tbAdjustmentReasonCode")).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment1_tbAdjustmentReasonCode")).SendKeys("66");
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment1));
                total += adjustment1;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
                counter++;
            }
            
          
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();
                driver.Navigate().Refresh();

            
            
                
                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"))).SelectByText("PR - Patient Responsibility");
            
                

                
            
            try
            {
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("11");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment2));
                total += adjustment2;

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();
                driver.Navigate().Refresh();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("PR - Patient Responsibility");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("3");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment3));
                total += adjustment3;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();
                driver.Navigate().Refresh();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("OA - Other Adjustments");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("23");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment4));
                total += adjustment4;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("PR - Patient Responsibility");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("44");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment5));
                total += adjustment5;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("PR - Patient Responsibility");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("60");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment6));
                total += adjustment6;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("CO - Contractual Obligations");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("69");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment7));
                total += adjustment7;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("PR - Patient Responsibility");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("61");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment8));
                total += adjustment8;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("OA - Other Adjustments");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("70");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment9));
                total += adjustment9;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("PI - Payer Initiated Reductions");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("101");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment10));
                total += adjustment10;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("OA - Other Adjustments");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("103");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment11));
                total += adjustment11;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("CR - Correction and Reversals");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("112");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment12));
                total += adjustment12;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("PR - Patient Responibility");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("117");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment13));
                total += adjustment13;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("OA - Other Adjustments");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("133");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment14));
                total += adjustment14;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("OA - Other Adjustments");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("143");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment15));
                total += adjustment15;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("OA - Other Adjustments");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("155");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment16));
                total += adjustment16;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("PI - Payer Initiated Reductions");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("157");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment17));
                total += adjustment17;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("OA - Other Adjustments");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("159");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment18));
                total += adjustment18;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("OA - Other Adjustments");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("186");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment19));
                total += adjustment19;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("lineCtrl1_secondaryClaimCtrl_lbAddNewAdjustment"), 10).Click();

                new SelectElement(driver.FindElement(By.Id("lineCtrol1_secondaryClaimCtrl_adjustment2_ddlAdjustmentGroupCode"), 15)).SelectByText("OA - Other Adjustments");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment2_tbAdjustmentReasonCode"), 5).SendKeys("233");
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).Clear();
                driver.FindElement(By.Id("lineCtrl2_secondaryClaimCtrl_adjustment1_tbAdjustmentAmount")).SendKeys(Convert.ToString(adjustment20));
                total += adjustment20;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
#endregion
            try
            {
                driver.FindElement(By.Id("lineCtrl1_tbCharges"), 10).Clear();
                driver.FindElement(By.Id("lineCtrl1_tbCharges")).SendKeys(Convert.ToString(total));

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
