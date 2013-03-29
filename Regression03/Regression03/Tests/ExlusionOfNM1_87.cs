using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Execute;
using System.Linq;
using Logger;
using System.IO;
using Form;


namespace Regression03
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class ExlusionOfNM1_87
    {
        public ExlusionOfNM1_87()
        {
        }
        Connection connection = new Connection();
        SenderAPI log = new SenderAPI();

        private const string batchPaths = @"\\apexdata\user\deverett\Documents\Visual Studio 2012\Projects\Regression03\Regression03\batches\";

        private const string hardCopies =
           @"\\apexdata\user\deverett\Documents\Visual Studio 2012\Projects\Regression03\Regression03\hardCopies\";

        private const string import4010 = batchPaths + "Import4010DentalMZH.bat";

        private const string outputFileLocation = @"\\apexdata\F_Drive_Test\Claimstaker\Output\output.txt";

        private const string autoDeleteFile = batchPaths + "deleteClaimAuto.bat";

        private const string NM1_87 = @"NM1\*87\*";

        private const string HardCopy = hardCopies + "MZHHardCopy.txt";

        private const string startAutoWatcher = batchPaths + "StartAutoImportApexWatcher.bat";

        private const string changeFileName = batchPaths + "changeFileNameOnOutput.bat";

        private const string clientBatch = "0000000000MZH";  //Client ID goes HERE
        /// <summary>
        /// Tests dental claim from client MZH to ensure that NM1*87 segment is not included
        /// </summary>
        [TestMethod]
        public void ExlusionofNM1_87()
        {
            long TestID = log.RegisterTest();
            Batch.File(autoDeleteFile);
            
            var deleteBatch = connection._repository.ClaimDentalBase_T.Where(x => x.BatchNumber_VC == clientBatch);
            foreach (var claim in deleteBatch)
            {
                connection._repository.ClaimDentalBase_T.DeleteObject(claim);
            }
            connection._repository.SaveChanges();
            //start apexWatcher and AutoImport batch file
            Batch.File(startAutoWatcher);
            this.UIMap.ActivateValidatorsApexWatcher();
            Batch.File(import4010);

            this.UIMap.LogInClaimStakerPlus();

            Playback.Wait(15000);
            this.UIMap.WaitAutoImportComplete();
            var resultMzh =
                connection._repository.ClaimDentalBase_T.Where(
                    x => x.BatchNumber_VC == clientBatch && x.OutputSub_ID == 366).ToArray();
            foreach (var claim in resultMzh)
            {
                if (claim.ClaimStatusType_ID == 6 || claim.ClaimStatusType_ID == 2 || claim.ClaimStatusType_ID == 9)
                  claim.ClaimStatusType_ID = 1;
                if (claim.ClaimStatusType_ID == 10)
                    log.Error("Claim " + claim.ClaimDentalBase_ID + " has an Output Exception", TestID);
                if (claim.ClaimStatusType_ID == 3)
                {
                    log.Error("Claim " + claim.ClaimDentalBase_ID + " failed on import", TestID);
                }
            }
            connection._repository.SaveChanges();
            /////
            var ClaimMzh =
                connection._repository.ClaimDentalBase_T.FirstOrDefault(
                    x => x.BatchNumber_VC == clientBatch && x.OutputSub_ID == 366 && x.Provider_ID == 13377);

            long claimID = ClaimMzh.ClaimDentalBase_ID;
            this.UIMap.OutputDentalClaimNM187(claimID);

            Batch.File(changeFileName);
            string claimContents;
            Playback.Wait(15000);
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
                log.Error(ex.Message, TestID);
            }
            if (Regex.IsMatch(dental01.File, NM1_87))
            {
                log.Error("ERROR: File associated with dental claim " + claimID + " appears to contain a NM1*87 segment", TestID);
            }
            foreach (var claim in resultMzh)
            {
                if(claim.Provider_ID != 13369 && claim.Provider_ID != 13376 && claim.Provider_ID != 13377)
                    log.Error("ERROR: Dental claim associated with Claim ID " + claim.ClaimDentalBase_ID + " is not assigned a correct providers ID", TestID);
            }
            string hardCopy;
            using (TextReader reader = new StreamReader(HardCopy))
            {
                hardCopy = reader.ReadToEnd();
            }
            if (!hardCopy.Equals(dental01.File))
            {
                log.Error("Output Files in " + clientBatch + " are not matching up", TestID);
            }
            this.UIMap.CloseClaimStakerPlus();
            this.UIMap.SelectAutoImportClose();
            this.UIMap.FinishCloseAutoImport();
            this.UIMap.CloseApexWatcher();

            Batch.File(autoDeleteFile);
            Playback.Wait(1000);
        }

        /// <summary>
        /// Test an EC&F with Century input dental batch
        /// </summary>
       

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
