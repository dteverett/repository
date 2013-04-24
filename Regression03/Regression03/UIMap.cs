using System.Globalization;

namespace Regression03
{
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Input;
    using System.CodeDom.Compiler;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;


    public partial class UIMap
    {


        /// <summary>
        /// StartAutoImport5010
        /// </summary>
        public void ModStartAutoImport5010()
        {
            #region Variable Declarations
            WinButton uIStartButton = this.UIAutoImport5010Window.UIStartWindow.UIStartButton;
            #endregion
            //5010 opens with start button disabled, wait before executing start
            uIStartButton.WaitForControlEnabled();

            // Click 'Start' button
            Mouse.Click(uIStartButton, new Point(37, 18));
        }

        /// <summary>
        /// StartApexWatcherValidators
        /// </summary>
        public void ModStartApexWatcherValidators()
        {
            #region Variable Declarations
            WinButton uIValidator = this.UIApexWatcherWindow.UIStoppedWindow1.UIValidator;
            WinButton uIImportMonitor = this.UIApexWatcherWindow.UIStoppedWindow.UIImportMonitor;
            WinButton uI5010Validator = this.UIApexWatcherWindow.UIStoppedWindow2.UI5010Validator;
            #endregion

            // Click 'Stopped' button
            Mouse.Click(uIValidator, new Point(32, 16));

            // Click 'Stopped' button
            Mouse.Click(uIImportMonitor, new Point(33, 29));

            // Click 'Stopped' button
            Mouse.Click(uI5010Validator, new Point(44, 20));
        }

        /// <summary>
        /// ClickClaimStakerPlus - Use 'ClickClaimStakerPlusParams' to pass parameters into this method.
        /// </summary>
        public void ClickClaimStakerPlus()
        {

            // Launch '\\apexdata\F_Drive_Test\ClaimStakerPlus\RunClaimStakerUI.exe'
            ApplicationUnderTest runClaimStakerUIApplication = ApplicationUnderTest.Launch(this.ClickClaimStakerPlusParams.ExePath, this.ClickClaimStakerPlusParams.AlternateExePath);
        }

        public virtual ClickClaimStakerPlusParams ClickClaimStakerPlusParams
        {
            get
            {
                if ((this.mClickClaimStakerPlusParams == null))
                {
                    this.mClickClaimStakerPlusParams = new ClickClaimStakerPlusParams();
                }
                return this.mClickClaimStakerPlusParams;
            }
        }

        private ClickClaimStakerPlusParams mClickClaimStakerPlusParams;

        /// <summary>
        /// ClickOKProblemConnectingButton
        /// </summary>
        public void ModClickOKProblemConnectingButton()
        {
            #region Variable Declarations
            WinButton uIOKProblemConnectingButton = this.UIOKWindow.UIOKProblemConnectingButton;
            #endregion


            // Click 'OK' button
            Mouse.Click(uIOKProblemConnectingButton, new Point(40, 8));
        }




        /// <summary>
        /// OutputDentalClaimNM187 - Use 'OutputDentalClaimNM187Params' to pass parameters into this method.
        /// </summary>
        public void OutputDentalClaimNM187(long input)
        {
            #region Variable Declarations
            WinMenuItem uICreateMenuItem = this.UIClaimStakerPlusWindow.UIClaimStakerMainMenuBar.UIOutputMenuItem.UICreateMenuItem;
            WinRadioButton uIDentalRadioButton = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UIDentalWindow.UIDentalRadioButton;
            WinRadioButton uIClaimIDRadioButton = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UIClaimIDWindow.UIClaimIDRadioButton;
            WinRadioButton uITestRadioButton = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UITestWindow.UITestRadioButton;
            WinEdit uITxtClaimIDEdit = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UITxtClaimIDWindow.UITxtClaimIDEdit;
            WinButton uICreateButton = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UICreateWindow.UICreateButton;
            WinButton uIOKProblemConnectingButton = this.UIOKWindow.UIOKProblemConnectingButton;
            #endregion

            // Click 'Output' -> 'Create' menu item
            Mouse.Click(uICreateMenuItem, new Point(40, 14));

            // Select 'Dental' radio button
            uIDentalRadioButton.Selected = this.OutputDentalClaimNM187Params.UIDentalRadioButtonSelected;

            // Select 'Claim ID:' radio button
            uIClaimIDRadioButton.Selected = this.OutputDentalClaimNM187Params.UIClaimIDRadioButtonSelected;

            // Select 'Test' radio button
            uITestRadioButton.Selected = this.OutputDentalClaimNM187Params.UITestRadioButtonSelected;

            // Type '4836547' in 'txtClaimID' text box
            uITxtClaimIDEdit.Text = input.ToString();

            // Click 'Create' button
            Mouse.Click(uICreateButton, new Point(30, 17));

            uIOKProblemConnectingButton.WaitForControlExist();

            // Click 'OK' button
            Mouse.Click(uIOKProblemConnectingButton, new Point(37, 5));

            uIOKProblemConnectingButton.WaitForControlNotExist();
        }

        public virtual OutputDentalClaimNM187Params OutputDentalClaimNM187Params
        {
            get
            {
                if ((this.mOutputDentalClaimNM187Params == null))
                {
                    this.mOutputDentalClaimNM187Params = new OutputDentalClaimNM187Params();
                }
                return this.mOutputDentalClaimNM187Params;
            }
        }

        private OutputDentalClaimNM187Params mOutputDentalClaimNM187Params;

        /// <summary>
        /// OutputClaimMedicalPartI - Use 'OutputClaimMedicalPartIParams' to pass parameters into this method.
        /// </summary>
        public void OutputClaimMedicalPartI(long input)
        {
            #region Variable Declarations
            WinMenuItem uICreateMenuItem = this.UIClaimStakerPlusWindow.UIClaimStakerMainMenuBar.UIOutputMenuItem.UICreateMenuItem;
            WinRadioButton uIClaimIDRadioButton = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UIClaimIDWindow.UIClaimIDRadioButton;
            WinRadioButton uITestRadioButton = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UITestWindow.UITestRadioButton;
            WinEdit uITxtClaimIDEdit = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UITxtClaimIDWindow.UITxtClaimIDEdit;
            WinButton uICreateButton = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UICreateWindow.UICreateButton;
            #endregion

            // Click 'Output' -> 'Create' menu item
            Mouse.Click(uICreateMenuItem, new Point(28, 11));

            // Select 'Claim ID:' radio button
            uIClaimIDRadioButton.Selected = this.OutputClaimMedicalPartIParams.UIClaimIDRadioButtonSelected;

            // Select 'Test' radio button
            uITestRadioButton.Selected = this.OutputClaimMedicalPartIParams.UITestRadioButtonSelected;

            // Type '6707895' in 'txtClaimID' text box
            uITxtClaimIDEdit.Text = input.ToString();

            // Click 'Create' button
            Mouse.Click(uICreateButton, new Point(49, 13));

        }

        public virtual OutputClaimMedicalPartIParams OutputClaimMedicalPartIParams
        {
            get
            {
                if ((this.mOutputClaimMedicalPartIParams == null))
                {
                    this.mOutputClaimMedicalPartIParams = new OutputClaimMedicalPartIParams();
                }
                return this.mOutputClaimMedicalPartIParams;
            }
        }

        private OutputClaimMedicalPartIParams mOutputClaimMedicalPartIParams;

        /// <summary>
        /// SelectOKOutputSuccess
        /// </summary>
        public void SelectOKOutputSuccess()
        {
            #region Variable Declarations
            WinButton uIOKProblemConnectingButton = this.UIOKWindow.UIOKProblemConnectingButton;
            #endregion

            uIOKProblemConnectingButton.WaitForControlExist(30000);
            // Click 'OK' button
            Mouse.Click(uIOKProblemConnectingButton, new Point(53, 15));
        }

        /// <summary>
        /// CloseApexWatcher
        /// </summary>
        public void CloseApexWatcher()
        {
            #region Variable Declarations
            WinButton apexWatcherCloseButton = this.UIApexWatcherWindow.UIApexWatcherTitleBar.ApexWatcherCloseButton;
            #endregion

            // The recording for the application under test '\\apexdata\F_Drive_Test\ApexWatcher\ApexWatcher.exe' may not be correct as it is located on a network share. Please install the application on a local path.

            // Click 'Close' button
            Mouse.Click(apexWatcherCloseButton, new Point(20, 8));

            apexWatcherCloseButton.WaitForControlNotExist();
        }

        /// <summary>
        /// ClickOK
        /// </summary>
        public void ClickOK()
        {
            #region Variable Declarations
            WinButton uIOKProblemConnectingButton = this.UIOKWindow.UIOKProblemConnectingButton;
            #endregion

            // Click 'OK' button
            Mouse.Click(uIOKProblemConnectingButton, new Point(41, 12));

            uIOKProblemConnectingButton.WaitForControlNotExist();
            UIClaimStakerAUTOIMPORWindow.UIClaimStakerAUTOIMPORTitleBar.WaitForControlNotExist(20000);
        }

        /// <summary>
        /// Close the instance of ClaimStakerPlus and it's window
        /// </summary>
        public void CloseClaimStakerPlus()
        {
            #region Variable Declarations
            WinButton claimStakerPlusCloseButton = this.UIClaimStakerPlusWindow.UIClaimStakerPlusTitleBar.ClaimStakerPlusCloseButton;
            #endregion

            // Click 'Close' button
            Mouse.Click(claimStakerPlusCloseButton, new Point(21, 10));
            claimStakerPlusCloseButton.WaitForControlNotExist(20000);
        }

        /// <summary>
        /// Close the pop-up window that appears when trying to close auto-import
        /// </summary>
        public void FinishCloseAutoImport()
        {
            #region Variable Declarations
            WinButton autoImportPopUpWindowYesButton = this.UIWarningWindow.UIYesWindow.AutoImportPopUpWindowYesButton;
            #endregion

            // Click '&Yes' button
            Mouse.Click(autoImportPopUpWindowYesButton, new Point(57, 15));
            autoImportPopUpWindowYesButton.WaitForControlNotExist(20000);

        }

        /// <summary>
        /// FinishCloseAutoImport5010
        /// </summary>
        public void FinishCloseAutoImport5010()
        {
            #region Variable Declarations
            WinButton confirmCloseAutoImportYesButton = this.UIConfirmCloseWindow.UIYesWindow.ConfirmCloseAutoImportYesButton;
            #endregion

            // Click '&Yes' button
            Mouse.Click(confirmCloseAutoImportYesButton, new Point(49, 14));
            confirmCloseAutoImportYesButton.WaitForControlNotExist();
        }

        /// <summary>
        /// SelectAutoImportClose
        /// </summary>
        public void SelectAutoImportClose()
        {
            #region Variable Declarations
            WinButton autoImportCloseButton = this.UIClaimStakerAUTOIMPORWindow.UIClaimStakerAUTOIMPORTitleBar.AutoImportCloseButton;
            #endregion

            // Click 'Close' button
            Mouse.Click(autoImportCloseButton, new Point(27, 8));
            //autoImportCloseButton.WaitForControlNotExist();
        }

        /// <summary>
        /// AssertAutoImportIsAutoImporting - Use 'AssertAutoImportIsAutoImportingExpectedValues' to pass parameters into this method.
        /// </summary>
        public void AssertAutoImportIsAutoImporting()
        {
            #region Variable Declarations
            WinClient uIClaimStakerAUTOIMPORClient = this.UIClaimStakerAUTOIMPORWindow.UIItemWindow1.UIClaimStakerAUTOIMPORClient;
            #endregion


            // Verify that the 'ControlType' property of 'ClaimStaker ==>> AUTO-IMPORT VERSION <<==' client equals 'Client'
            Assert.AreEqual(this.AssertAutoImportIsAutoImportingExpectedValues.UIClaimStakerAUTOIMPORClientControlType, uIClaimStakerAUTOIMPORClient.ControlType.ToString());
        }

        public virtual AssertAutoImportIsAutoImportingExpectedValues AssertAutoImportIsAutoImportingExpectedValues
        {
            get
            {
                if ((this.mAssertAutoImportIsAutoImportingExpectedValues == null))
                {
                    this.mAssertAutoImportIsAutoImportingExpectedValues = new AssertAutoImportIsAutoImportingExpectedValues();
                }
                return this.mAssertAutoImportIsAutoImportingExpectedValues;
            }
        }

        private AssertAutoImportIsAutoImportingExpectedValues mAssertAutoImportIsAutoImportingExpectedValues;

        /// <summary>
        /// PressedCancelButtonTestFindMe
        /// </summary>
        public void WaitAutoImportComplete()
        {
            #region Variable Declarations
            WinButton autoImportInActionCancelButton = this.UIClaimStakerAUTOIMPORWindow.UICancelWindow.AutoImportInActionCancelButton;
            #endregion

            autoImportInActionCancelButton.WaitForControlNotExist(100000);
        }

        /// <summary>
        /// CreteOutput - Use 'CreteOutputParams' to pass parameters into this method.
        /// </summary>
        public void CreateOutput(long ClaimID)
        {
            #region Variable Declarations
            WinMenuItem uICreateMenuItem = this.UIClaimStakerPlusWindow.UIClaimStakerMainMenuBar.UIOutputMenuItem.UICreateMenuItem;
            WinRadioButton uIClaimIDRadioButton = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UIClaimIDWindow.UIClaimIDRadioButton;
            WinRadioButton uITestRadioButton = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UITestWindow.UITestRadioButton;
            WinEdit uITxtClaimIDEdit = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UITxtClaimIDWindow.UITxtClaimIDEdit;
            WinButton uICreateButton = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UICreateWindow.UICreateButton;
            WinButton uIOKProblemConnectingButton = this.UIOKWindow.UIOKProblemConnectingButton;
            #endregion

            // Click 'Output' -> 'Create' menu item
            Mouse.Click(uICreateMenuItem, new Point(58, 9));

            // Select 'Claim ID:' radio button
            uIClaimIDRadioButton.Selected = this.CreteOutputParams.UIClaimIDRadioButtonSelected;

            // Select 'Test' radio button
            uITestRadioButton.Selected = this.CreteOutputParams.UITestRadioButtonSelected;

            // Type '6861271' in 'txtClaimID' text box
            uITxtClaimIDEdit.Text = this.CreteOutputParams.UITxtClaimIDEditText;

            // Click 'Create' button
            Mouse.Click(uICreateButton, new Point(49, 15));

            // Click 'OK' button
            Mouse.Click(uIOKProblemConnectingButton, new Point(58, 6));
        }

        public virtual CreteOutputParams CreteOutputParams
        {
            get
            {
                if ((this.mCreteOutputParams == null))
                {
                    this.mCreteOutputParams = new CreteOutputParams();
                }
                return this.mCreteOutputParams;
            }
        }

        private CreteOutputParams mCreteOutputParams;
    }
    /// <summary>
    /// Parameters to be passed into 'ClickClaimStakerPlus'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class ClickClaimStakerPlusParams
    {

        #region Fields
        /// <summary>
        /// Launch '\\apexdata\F_Drive_Test\ClaimStakerPlus\RunClaimStakerUI.exe'
        /// </summary>
        public string ExePath = "\\\\apexdata\\F_Drive_Test\\ClaimStakerPlus\\RunClaimStakerUI.exe";

        /// <summary>
        /// Launch '\\apexdata\F_Drive_Test\ClaimStakerPlus\RunClaimStakerUI.exe'
        /// </summary>
        public string AlternateExePath = "\\\\apexdata\\F_Drive_Test\\ClaimStakerPlus\\RunClaimStakerUI.exe";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'OutputDentalClaimNM187'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class OutputDentalClaimNM187Params
    {

        #region Fields
        /// <summary>
        /// Select 'Dental' radio button
        /// </summary>
        public bool UIDentalRadioButtonSelected = true;

        /// <summary>
        /// Select 'Claim ID:' radio button
        /// </summary>
        public bool UIClaimIDRadioButtonSelected = true;

        /// <summary>
        /// Select 'Test' radio button
        /// </summary>
        public bool UITestRadioButtonSelected = true;

        /// <summary>
        /// Type '4836547' in 'txtClaimID' text box
        /// </summary>
        public string UITxtClaimIDEditText = "00000";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'OutputClaimMedicalPartI'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class OutputClaimMedicalPartIParams
    {

        #region Fields
        /// <summary>
        /// Select 'Claim ID:' radio button
        /// </summary>
        public bool UIClaimIDRadioButtonSelected = true;

        /// <summary>
        /// Select 'Test' radio button
        /// </summary>
        public bool UITestRadioButtonSelected = true;

        /// <summary>
        /// Type '6707895' in 'txtClaimID' text box
        /// </summary>
        public string UITxtClaimIDEditText = "6707895";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'AssertAutoImportIsAutoImporting'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class AssertAutoImportIsAutoImportingExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that the 'ControlType' property of 'ClaimStaker ==>> AUTO-IMPORT VERSION <<==' client equals 'Client'
        /// </summary>
        public string UIClaimStakerAUTOIMPORClientControlType = "Client";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'CreteOutput'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class CreteOutputParams
    {

        #region Fields
        /// <summary>
        /// Select 'Claim ID:' radio button
        /// </summary>
        public bool UIClaimIDRadioButtonSelected = true;

        /// <summary>
        /// Select 'Test' radio button
        /// </summary>
        public bool UITestRadioButtonSelected = true;

        /// <summary>
        /// Type '6861271' in 'txtClaimID' text box
        /// </summary>
        private string uiText;
        public string UITxtClaimIDEditText
        {
            get { return uiText; }
            set { uiText = value; }
        }
        #endregion
}
}
