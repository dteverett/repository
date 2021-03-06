﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Execute;
using Form;
using Logger;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace Regression03
{
    /// <summary>
    /// Testing AAL batch, client that uses regular 4010 specs to send claims
    /// </summary>
    [CodedUITest]
    public class GenericDental
    {
        public GenericDental()
        {
        }

        private const string batchPaths = @"\\apexdata\user\deverett\Documents\Visual Studio 2012\Projects\Regression03\Regression03\batches\";

        private const string hardCopies =
            @"\\apexdata\user\deverett\Documents\Visual Studio 2012\Projects\Regression03\Regression03\hardCopies\";

        private const string import4010 = batchPaths + "Import4010DentalAAL.bat";  //Batch File name here

        private const string outputFileLocation = @"\\apexdata\F_Drive_Test\Claimstaker\Output\output.txt";

        private const string autoDeleteFile = batchPaths + "deleteClaimAuto.bat";

        private const string HardCopy = hardCopies + "hardCopyAAL.txt";  //Specific import batch file name goes here

        private const string startAutoWatcher = batchPaths + "StartAutoImportApexWatcher.bat";

        private const string changeFileName = (batchPaths + "changeFileNameOnOutput.bat");

        private const string clientBatch = "0000000000AAL";  //Client ID goes HERE

        Connection connection = new Connection();

        [TestMethod]
        public void CodedUITestMethod1()
        {
            string hardCopy;
            string claimContents;

            var deleteBatch = connection._repository.ClaimDentalBase_T.Where(x => x.BatchNumber_VC == clientBatch);
            foreach (var claim in deleteBatch)
            {
                connection._repository.ClaimDentalBase_T.DeleteObject(claim);
            }
            connection._repository.SaveChanges();

            Batch.File(autoDeleteFile);
            Batch.File(startAutoWatcher);
            this.UIMap.ActivateValidatorsApexWatcher();
            Batch.File(import4010);
            
            this.UIMap.LogInClaimStakerPlus();

            //Allow autoImport time to import entire batch
            Playback.Wait(15000);
            this.UIMap.WaitAutoImportComplete();

            var dentalBatch = connection._repository.ClaimDentalBase_T.Where(x => x.BatchNumber_VC == clientBatch).ToArray();
            foreach (var claim in dentalBatch)
            {
                if (claim.ClaimStatusType_ID == 6 || claim.ClaimStatusType_ID == 2 || claim.ClaimStatusType_ID == 9)
                    claim.ClaimStatusType_ID = 1;
                if (claim.ClaimStatusType_ID == 10)
                    Log.AddLog("Claim " + claim.ClaimDentalBase_ID + " has an Output Exception");
                if (claim.ClaimStatusType_ID == 3)
                {
                    Log.AddLog("Claim " + claim.ClaimDentalBase_ID + " failed on import");
                }
            }
            connection._repository.SaveChanges();

            //Find specific claim here   //Find specific claim here         //Find specific claim    

            var dentalClaim =
                connection._repository.ClaimDentalBase_T.FirstOrDefault(   ////Single out specific Claim
                    x => x.BatchNumber_VC == clientBatch && x.OutputSub_ID == 41);  //here

            long claimID = dentalClaim.ClaimDentalBase_ID;

            this.UIMap.OutputDentalClaimNM187(claimID);
            //playback wait warning area
            Batch.File(changeFileName);
            
            //playback wait warning area        ////////
            Playback.Wait(5000);
            using (TextReader reader = new StreamReader(outputFileLocation))//read static value file
            {
                claimContents = reader.ReadToEnd();

            }
            var dental01 = new Dental();
            dental01.File = claimContents;
            try
            {
                var form = Form.Convert.convertToText(dental01);
                if (form is Dental)
                {
                    dental01 = form as Dental;
                }
            }
            catch (Exception ex)
            {
                Log.AddLog(ex.Message);
            }
            
            using (TextReader reader = new StreamReader(HardCopy))
            {
                hardCopy = reader.ReadToEnd();
            }
            if (!hardCopy.Equals(dental01.File))
            {
                Log.AddLog("Output Files in " + clientBatch + " are not matching up");
            }

            //Add special case logic here  //Add special case logic here //Add special case logic here //add special case logic here

            this.UIMap.CloseClaimStakerPlus();
            this.UIMap.SelectAutoImportClose();
            this.UIMap.FinishCloseAutoImport();
            this.UIMap.CloseApexWatcher();
            Batch.File(autoDeleteFile);
            Playback.Wait(1000);
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

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
    }
}
