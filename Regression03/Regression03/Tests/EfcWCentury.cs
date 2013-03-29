using System;
using System.Collections.Generic;
using System.IO;
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
using System.Linq;


namespace Regression03
{
    /// <summary>
    /// Summary description for CodedUITest2
    /// </summary>
    [CodedUITest]
    public class EfcWCentury
    {
        public EfcWCentury()
        {
        }
        SenderAPI log = new SenderAPI();

        private const string batchPaths = @"\\apexdata\user\deverett\Documents\Visual Studio 2012\Projects\Regression03\Regression03\batches\";

         private const string hardCopies =
            @"\\apexdata\user\deverett\Documents\Visual Studio 2012\Projects\Regression03\Regression03\hardCopies\";

        private const string import4010 = batchPaths + "Import4010DentalMZA.bat";

        private const string outputFileLocation = @"\\apexdata\F_Drive_Test\Claimstaker\Output\output.txt";

        private const string autoDeleteFile = batchPaths + "deleteClaimAuto.bat";

        private const string HardCopy = hardCopies + "MZAClaimHardCopy.txt";

        private const string startAutoWatcher = batchPaths + "StartAutoImportApexWatcher.bat";

        private const string changeFileName = batchPaths + "changeFileNameOnOutput.bat";

        private const string clientBatch = "0000000000MZA";


        Connection connection = new Connection();
        /// <summary>
        /// Test an EC&F with Century input dental batch
        /// </summary>
        [TestMethod]
        public void CodedUITestMethod()
        {
            long TestID = log.RegisterTest();
            //Delete claims w/ same batch number to allow for auto-import
            var deleteBatch = connection._repository.ClaimDentalBase_T.Where(x => x.BatchNumber_VC == clientBatch);
            foreach (var claim in deleteBatch)
            {
                connection._repository.ClaimDentalBase_T.DeleteObject(claim);
            }
            connection._repository.SaveChanges();
            Batch.File(autoDeleteFile);

            //start apexWatcher and AutoImport batch file
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
                    log.AddLog("Claim " + claim.ClaimDentalBase_ID + " has an Output Exception", TestID);
                if (claim.ClaimStatusType_ID == 3)
                {
                    log.Error("Claim " + claim.ClaimDentalBase_ID + " failed on import", TestID);
                }
            }
            connection._repository.SaveChanges();
            var MZAClaim =
                connection._repository.ClaimDentalBase_T.FirstOrDefault(
                    x => x.BatchNumber_VC == clientBatch && x.Payer_ID == 67946);

            if (MZAClaim.OutputSub_ID != 3728)
                log.Error("Claim " + MZAClaim.ClaimDentalBase_ID + " has an incorrect OutputSub_ID value", TestID);


            long claimID = MZAClaim.ClaimDentalBase_ID;
            this.UIMap.OutputDentalClaimNM187(claimID);

            
            //change file name in claimstaker\output\ to static value
            Batch.File(changeFileName);
            string claimContents;
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
                log.Fatal(ex.Message, TestID);
            }
            string hardCopy;
            using (TextReader reader = new StreamReader(HardCopy))
            {
                hardCopy = reader.ReadToEnd();
            }
            if (!hardCopy.Equals(dental01.File))
            {
                log.Error("Output Files in ECF_w_Century are not matching up", TestID);
            }
            foreach (var claim in dentalBatch)
            {
                if (claim.Provider_ID != 11748 && claim.Provider_ID != 14571 && claim.Provider_ID != 11724)
                {
                    log.Error("Claim " + claim.ClaimDentalBase_ID + " from client MZA using EF&C with Century software is not assigned to a valid provider", TestID);
                }
            }

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
