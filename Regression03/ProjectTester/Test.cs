using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Text.RegularExpressions;
namespace WebTester
{
    public class Test
    {
        static private StringBuilder verificationErrors;
        static private bool acceptNextAlert = true;

        static IWebDriver Driver = new FirefoxDriver();
        static string baseURL = "http://onetouch.apexedi.com/";

        public static void Initialize()
        {
            Initialize(baseURL);
        }

        public static void Initialize(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public static void LogOnOneTouch(string userName, string password)
        {
            Driver.Navigate().GoToUrl(baseURL + "/secure/Login.aspx?redit=%2fsecure%2fDefault.aspx");

            Driver.FindElement(By.Id("MainContent_tbUsername"), 10).Clear();
            Driver.FindElement(By.Id("MainContent_tbUsername")).SendKeys(userName);
            Driver.FindElement(By.Id("MainContent_tbPassword")).Clear();
            Driver.FindElement(By.Id("MainContent_tbPassword")).SendKeys(password);
            Driver.FindElement(By.Id("MainContent_btnSubmit")).Click();
        }

        public static void FormTest1()
        {
            Driver.FindElement(By.Id("MainContent_ctl00_AddBatchButton"), 10).Click();
            Driver.FindElement(By.Id("MainContent_ctl00_ClaimTypeBatchRadioButtonList_0"), 10).Click();
            Driver.FindElement(By.Id("MainContent_ctl00_StatementCreateButton")).Click();
            new SelectElement(Driver.FindElement(By.Id("electronicPayerCtrl_ddlOutputSubs"), 15)).SelectByText("United Healthcare");
            Driver.FindElement(By.Id("electronicPayerCtrl_rblChangeIsFor_1")).Click();
            Driver.FindElement(By.Id("electronicPayerCtrl_btnSaveChanges")).Click();
            //Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^This will update all claims within this batch that have the original payer destination information\\.(\n|\r\n)Do you want to continue[\\s\\S](\n|\r\n)(\n|\r\n)NOTE: If you wish to permanantly have these claims route to the selected payer, please contact your account manager\\.$"));
            Driver.FindElement(By.Id("MainContent_ctl00_TrackClaims_Payer_0"), 10).Click();
            //new SelectElement(Driver.FindElement(By.Id("adminCtrl_ddlOutputSubs"), 15)).SelectByText("United Healthcare[OS:1245]; Emdeon Medical[O:63]");
            //Driver.FindElement(By.Id("adminCtrl_btSavePayer")).Click();
            Driver.FindElement(By.Id("payerCtrl_tbName"), 10).Clear();
            Driver.FindElement(By.Id("payerCtrl_tbName")).SendKeys("UNITED HEALTHCARE");
            Driver.FindElement(By.Id("payerCtrl_tbAddress1")).Clear();
            Driver.FindElement(By.Id("payerCtrl_tbAddress1")).SendKeys("PO BOX 740809");
            Driver.FindElement(By.Id("payerCtrl_tbCity")).Clear();
            Driver.FindElement(By.Id("payerCtrl_tbCity")).SendKeys("Atlanta");
            new SelectElement(Driver.FindElement(By.Id("payerCtrl_ddlState"))).SelectByText("GA");
            Driver.FindElement(By.Id("payerCtrl_tbZip")).Clear();
            Driver.FindElement(By.Id("payerCtrl_tbZip")).SendKeys("30374-0809");
            Driver.FindElement(By.Id("subscriberCtrl_tbSubscriberID")).Clear();
            Driver.FindElement(By.Id("subscriberCtrl_tbSubscriberID")).SendKeys("842596535");
            Driver.FindElement(By.Id("patientCtrl_tbFirstName")).Clear();
            Driver.FindElement(By.Id("patientCtrl_tbFirstName")).SendKeys("Krystal");
            Driver.FindElement(By.Id("patientCtrl_tbLastName")).Clear();
            Driver.FindElement(By.Id("patientCtrl_tbLastName")).SendKeys("Amburgey");
            Driver.FindElement(By.Id("patientCtrl_tbDateOfBirth")).Clear();
            Driver.FindElement(By.Id("patientCtrl_tbDateOfBirth")).SendKeys("04031987");
            Driver.FindElement(By.Id("patientCtrl_rblSex_1")).Click();
            Driver.FindElement(By.Id("subscriberCtrl_tbFirstName")).Clear();
            Driver.FindElement(By.Id("subscriberCtrl_tbFirstName")).SendKeys("Krystal");
            Driver.FindElement(By.Id("subscriberCtrl_tbLastName")).Clear();
            Driver.FindElement(By.Id("subscriberCtrl_tbLastName")).SendKeys("Amburgey");
            Driver.FindElement(By.Id("patientCtrl_tbAddress1")).Clear();
            Driver.FindElement(By.Id("patientCtrl_tbAddress1")).SendKeys("9235 HUNTERS CREEK DRIVE");
            Driver.FindElement(By.Id("patientCtrl_rblPatientRelationshipToInsured_0")).Click();
            Driver.FindElement(By.Id("subscriberCtrl_tbAddress1")).Clear();
            Driver.FindElement(By.Id("subscriberCtrl_tbAddress1")).SendKeys("9235 HUNTERS CREEK DRIVE");
            Driver.FindElement(By.Id("patientCtrl_tbCity")).Clear();
            Driver.FindElement(By.Id("patientCtrl_tbCity")).SendKeys("CINCINNATI");
            new SelectElement(Driver.FindElement(By.Id("patientCtrl_ddlState"))).SelectByText("OH");
            Driver.FindElement(By.Id("patientCtrl_rblPatientMaritalStatus_2")).Click();
            Driver.FindElement(By.Id("subscriberCtrl_tbCity")).Clear();
            Driver.FindElement(By.Id("subscriberCtrl_tbCity")).SendKeys("cINCINNATI");
            new SelectElement(Driver.FindElement(By.Id("subscriberCtrl_ddlState"))).SelectByText("OH");
            Driver.FindElement(By.Id("subscriberCtrl_tbZip")).Clear();
            Driver.FindElement(By.Id("subscriberCtrl_tbZip")).SendKeys("45242-6621");
            Driver.FindElement(By.Id("patientCtrl_tbZip")).Clear();
            Driver.FindElement(By.Id("patientCtrl_tbZip")).SendKeys("45242-6621");
            Driver.FindElement(By.Id("subscriberCtrl_rblSex_1")).Click();
            Driver.FindElement(By.Id("subscriberCtrl_tbDateOfBirth")).Clear();
            Driver.FindElement(By.Id("subscriberCtrl_tbDateOfBirth")).SendKeys("04031987");
            Driver.FindElement(By.Id("subscriberCtrl_tbPlanName")).Clear();
            Driver.FindElement(By.Id("subscriberCtrl_tbPlanName")).SendKeys("UNITED HEALTHCARE");
            Driver.FindElement(By.Id("subscriberCtrl_rbListOtherCoverage_1")).Click();
            Driver.FindElement(By.Id("patientSignatureCtrl_cbSignatureOnFile")).Click();
            Driver.FindElement(By.Id("subscriberCtrl_cbSignatureOnFile")).Click();
            Driver.FindElement(By.Id("referringProviderCtrl_tbFirstName")).Clear();
            Driver.FindElement(By.Id("referringProviderCtrl_tbFirstName")).SendKeys("GREGORY");
            Driver.FindElement(By.Id("referringProviderCtrl_tbLastName")).Clear();
            Driver.FindElement(By.Id("referringProviderCtrl_tbLastName")).SendKeys("GAOTTSCHLICH");
            Driver.FindElement(By.Id("referringProviderCtrl_tbNPI")).Clear();
            Driver.FindElement(By.Id("referringProviderCtrl_tbNPI")).SendKeys("1234567893");
            Driver.FindElement(By.Id("diagnosisCodesCtrl_tbDiagnosisCode1")).Clear();
            Driver.FindElement(By.Id("diagnosisCodesCtrl_tbDiagnosisCode1")).SendKeys("477.8");
            Driver.FindElement(By.Id("diagnosisCodesCtrl_tbDiagnosisCode2")).Clear();
            Driver.FindElement(By.Id("diagnosisCodesCtrl_tbDiagnosisCode2")).SendKeys("477.0");
            Driver.FindElement(By.Id("lineCtrl1_tbDateFrom")).Clear();
            Driver.FindElement(By.Id("lineCtrl1_tbDateFrom")).SendKeys("03012013");
            Driver.FindElement(By.Id("lineCtrl1_tbPlaceOfServiceCode")).Clear();
            Driver.FindElement(By.Id("lineCtrl1_tbPlaceOfServiceCode")).SendKeys("11");
            Driver.FindElement(By.Id("lineCtrl1_tbProcedureCode")).Clear();
            Driver.FindElement(By.Id("lineCtrl1_tbProcedureCode")).SendKeys("95165");
            Driver.FindElement(By.Id("lineCtrl1_tbDiagnosisCodePointer1")).Clear();
            Driver.FindElement(By.Id("lineCtrl1_tbDiagnosisCodePointer1")).SendKeys("1");
            Driver.FindElement(By.Id("lineCtrl1_tbDiagnosisCodePointer2")).Clear();
            Driver.FindElement(By.Id("lineCtrl1_tbDiagnosisCodePointer2")).SendKeys("2");
            Driver.FindElement(By.Id("lineCtrl1_tbCharges")).Clear();
            Driver.FindElement(By.Id("lineCtrl1_tbCharges")).SendKeys("$204.00");
            Driver.FindElement(By.Id("lineCtrl1_tbQuantity")).Clear();
            Driver.FindElement(By.Id("lineCtrl1_tbQuantity")).SendKeys("12");
            Driver.FindElement(By.Id("lineCtrl1_tbNPI")).Clear();
            Driver.FindElement(By.Id("lineCtrl1_tbNPI")).SendKeys("1234567893");
            Driver.FindElement(By.Id("taxIDCtrl_tbPatientAccountNumber")).Clear();
            Driver.FindElement(By.Id("taxIDCtrl_tbPatientAccountNumber")).SendKeys("57814");
            Driver.FindElement(By.Id("taxIDCtrl_rblAcceptAssignment_0")).Click();
            Driver.FindElement(By.Id("facilityInfoCtrl_tbFacilityName")).Clear();
            Driver.FindElement(By.Id("facilityInfoCtrl_tbFacilityName")).SendKeys("aLLERGY AND ASTHMA AFFILI");
            Driver.FindElement(By.Id("facilityInfoCtrl_tbAddress1")).Clear();
            Driver.FindElement(By.Id("facilityInfoCtrl_tbAddress1")).SendKeys("4260 GLENDALE MILFORD RD");
            Driver.FindElement(By.Id("facilityInfoCtrl_tbCity")).Clear();
            Driver.FindElement(By.Id("facilityInfoCtrl_tbCity")).SendKeys("CINCINNATI");
            new SelectElement(Driver.FindElement(By.Id("facilityInfoCtrl_ddlState"))).SelectByText("OH");
            Driver.FindElement(By.Id("facilityInfoCtrl_tbZip")).Clear();
            Driver.FindElement(By.Id("facilityInfoCtrl_tbZip")).SendKeys("45242");
            Driver.FindElement(By.Id("facilityInfoCtrl_tbNPI")).Clear();
            Driver.FindElement(By.Id("facilityInfoCtrl_tbNPI")).SendKeys("1234567893");
            Driver.FindElement(By.Id("btnSubmit")).Click();
            try
            {
                Assert.AreEqual("$204.00", Driver.FindElement(By.Id("taxIDCtrl_tbBalanceDue"), 10).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Driver.FindElement(By.Id("main-logo")).Click();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private static string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
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
