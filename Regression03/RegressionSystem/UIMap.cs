namespace RegressionSystem
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


    public partial class UIMap
    {

        /// <summary>
        /// CreateMedicalOutput - Use 'CreateMedicalOutputParams' to pass parameters into this method.
        /// </summary>
        public void CreateMedicalOutput(string testData)
        {
            #region Variable Declarations
            WinMenuItem uICreateMenuItem = this.UIClaimStakerPlusWindow.UIClaimStakerMainMenuBar.UIOutputMenuItem.UICreateMenuItem;
            WinRadioButton uIClaimIDRadioButton = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UIClaimIDWindow.UIClaimIDRadioButton;
            WinRadioButton uITestRadioButton = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UITestWindow.UITestRadioButton;
            WinEdit uITxtClaimIDEdit = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UITxtClaimIDWindow.UITxtClaimIDEdit;
            WinButton uICreateButton = this.UIClaimStakerPlusWindow.UICreateOutputWindow.UICreateWindow.UICreateButton;
            WinButton uIOKButton = this.UIOKWindow.UIOKButton;
            #endregion

            // Click 'Output' -> 'Create' menu item
            Mouse.Click(uICreateMenuItem, new Point(42, 14));

            // Select 'Claim ID:' radio button
            uIClaimIDRadioButton.Selected = this.CreateMedicalOutputParams.UIClaimIDRadioButtonSelected;

            // Select 'Test' radio button
            uITestRadioButton.Selected = this.CreateMedicalOutputParams.UITestRadioButtonSelected;

            // Type '6860984' in 'txtClaimID' text box
            uITxtClaimIDEdit.Text = testData;

            // Click 'Create' button
            Mouse.Click(uICreateButton, new Point(23, 2));

            // Click 'OK' button
            Mouse.Click(uIOKButton, new Point(48, 14));
        }

        public virtual CreateMedicalOutputParams CreateMedicalOutputParams
        {
            get
            {
                if ((this.mCreateMedicalOutputParams == null))
                {
                    this.mCreateMedicalOutputParams = new CreateMedicalOutputParams();
                }
                return this.mCreateMedicalOutputParams;
            }
        }

        private CreateMedicalOutputParams mCreateMedicalOutputParams;
    }
    /// <summary>
    /// Parameters to be passed into 'CreateMedicalOutput'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class CreateMedicalOutputParams
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
        /// Type '6860984' in 'txtClaimID' text box
        /// </summary>
        public string UITxtClaimIDEditText = "6860984";
        #endregion
}
}
