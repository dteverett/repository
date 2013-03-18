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

namespace Regression03
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class ProviderAssignment
    {
        private const string import5010 =
            @"\\apexdata\user\deverett\Documents\Visual Studio 2012\Projects\Regression03\Regression03\Import5010RIY.bat";

        private const string batchPaths = @"\\apexdata\user\deverett\Documents\Visual Studio 2012\Projects\Regression03\Regression03\batches\";

        private const string hardCopies =
            @"\\apexdata\user\deverett\Documents\Visual Studio 2012\Projects\Regression03\Regression03\hardCopies\";

        private const string outputFileLocation = @"\\apexdata\F_Drive_Test\Claimstaker\Output\output.txt";

        private const string autoDeleteFile = batchPaths + "deleteClaimAuto.bat";

        private const string HardCopy = hardCopies + "hardCopyRIY.txt";  //Specific import batch file name goes here

        private const string startAutoWatcher = batchPaths + "StartAutoImportApexWatcher.bat";

        private const string changeFileName = (batchPaths + "changeFileNameOnOutput.bat");

        private const string clientBatch = "0000000000RIY";  //Client ID goes HERE

        Connection connection = new Connection();
        public ProviderAssignment()
        {
        }

        /// <summary>
        /// Test imported batch RIY
        /// Ensure that all claims are assigned the provider RIY as per Test Case 
        /// 5010, Medical?
        /// </summary>
        [TestMethod]
        public void CodedUITestMethod1()
        {
            Batch.File(autoDeleteFile);

            var deleteBatch = connection._repository.ClaimMedicalBase_T.Where(x => x.BatchNumber_VC == clientBatch);
            foreach (var claim in deleteBatch)
            {
                connection._repository.ClaimMedicalBase_T.DeleteObject(claim);
            }
            connection._repository.SaveChanges();

            Batch.File(import5010);
            this.UIMap.AssertAutoImportOpened();
            this.UIMap.ModStartAutoImport5010();

            Playback.Wait(20000);
            var resultRIY = connection._repository.ClaimMedicalBase_T.Where(x => x.BatchNumber_VC == clientBatch).ToArray();
            connection._repository.SaveChanges();

            foreach (var i in resultRIY)
            {
                Assert.AreEqual(i.Provider_ID, 15533);
                Assert.AreEqual(i.ClientID_VC, "RIY");
            }

            if (resultRIY.Count() != 11)
            {
                Log.AddLog("Error: Count of .RIY did not return as 11.");
            }
            this.UIMap.LogInClaimStakerPlus();

            var medicalClaim =
                connection._repository.ClaimMedicalBase_T.FirstOrDefault(
                    x => x.BatchNumber_VC == clientBatch && x.OutputSub_ID == 1509);

            long claimID = medicalClaim.ClaimMedicalBase_ID;
            this.UIMap.OutputClaimMedicalPartI(claimID);
            this.UIMap.SelectOKOutputSuccess();
            
            
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
