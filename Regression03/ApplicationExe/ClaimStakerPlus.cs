using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ApplicationExe
{
    public class ClaimStakerPlus : IApplications
    {
        private bool _Status;
        private string _LoginName;
        private string _LoginPassword;
        private bool _name_PasswordRequired = false;

        public string path
        {
            get { return @"C:\ClaimstakerPlus\"; }
        }

        public string exe
        {
            get { return @"RunClaimStakerUI.exe"; }
        }

        public string name
        {
            get { return "ClaimStaker"; }
        }

        public bool status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }
        public string loginName
        {
            get { return _LoginName; }
            set { _LoginName = value; }
        }
        public string loginPassword
        {
            get { return _LoginPassword; }
            set { _LoginPassword = value; }
        }
        public bool name_PasswordRequired
        {
            get { return _name_PasswordRequired; }
            set { _name_PasswordRequired = value; }
        }

        public void Execute()
        {
            ClaimStakerPlus instance = new ClaimStakerPlus();
            string ExeName = instance.path + instance.exe;

            ProcessStartInfo start = new ProcessStartInfo();
            start.Arguments = null;
            start.FileName = ExeName;

            using (Process proc = Process.Start(start))
            {

            }
        }
    }
}
