using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Form;
using Logger;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.Text.RegularExpressions;
using WebTester;
using DataVerification;
using Execute;

namespace RegressionSystem
{
    [CodedUITest]
    public class CreateOutput
    {
        public CreateOutput()
        {
        }

        private const string batchPath = @"C:\users\deverett.APEX\repository\Regression03\Regression03\batches\";
        private const string runPlus = batchPath + "startClaimStakerPlus.bat";
        private const long defaultTestID = 55;
        private const string defaultClaimID = "2835042";
        private const string defaultClientID = "ZZZ";

        SenderAPI logger;
        //WebLayer web;
        //DataBase data;

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.xml", "|DataDirectory|\\TestData.xml", "clientIDs", DataAccessMethod.Sequential), DeploymentItem("TestData.xml"), TestMethod]
        [TestMethod]
        public void OutputMedicalClaim()
        {
            int errorCount = 0;
            logger = new SenderAPI();
            long testID = defaultTestID;
            //string claimID = defaultClaimID;
            //string clientID1 = "CUI";
            //string clientID2 = "CGF";
            //string clientID3 = "RIY";
            //long id;
            //string clientID = defaultClientID;

            //clientID = testContextInstance.DataRow["client"].ToString();

            //CASSegment segment = new CASSegment();
            
            //Batch.File(runPlus);
            //data = new DataBase();
            //web = new WebLayer();
            //testID = logger.RegisterTest();

            //segment.ParentTestID = testID;
            //segment.ClientID = clientID1;
            //web.Execute(segment);
            //id = data.ClaimMedicalBaseID(clientID1);
            //claimID = id.ToString();
            ////Playback.Wait(1000);
            //this.UIMap.CreateMedicalOutput(claimID);
            //this.UIMap.CloseCreateOutput();


            //web.CasSegment(clientID2, testID);
            //id = data.ClaimMedicalBaseID(clientID2);
            //claimID = id.ToString();
            ////Playback.Wait(1000);
            //this.UIMap.CreateMedicalOutput(claimID);
            //this.UIMap.CloseCreateOutput();

            //web.CasSegment(clientID2, testID);
            //id = data.ClaimMedicalBaseID(clientID2);
            //claimID = id.ToString();
            ////Playback.Wait(1000);
            //this.UIMap.CreateMedicalOutput(claimID);
            //this.UIMap.CloseCreateOutput();

            this.UIMap.CloseClaimStakerPlus();


            //    }
            //catch (Exception ex)
            //{
            //    logger.Error(ex.Message, testID);
            //    errorCount++;
            //}


            if (errorCount == 0)
                logger.PassFailTest(true, testID);
            else
                logger.PassFailTest(false, testID);
        }

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
        private long _claimID;

        public long ClaimID
        {
            get { return _claimID; }
            set { _claimID = value; }
        }

    }
}
