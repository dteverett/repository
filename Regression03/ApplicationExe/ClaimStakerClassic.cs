using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ApplicationExe
{
    public class ClaimStakerClassic : IApplications
    {
        bool _Status;
        string _LoginName;
        string _LoginPassword;
        bool _Name_PasswordRequired = false;

        public string path
        {
            get { return @"C:\ClaimStaker\"; }
        }

        public string exe
        {
            get { return @"RunClaimStaker.exe"; }
        }

        public string name
        {
            get { return "ClaimStaker Classic"; }
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
            get
            {
                return _LoginName;
            }
            set
            {
                _LoginName = value;
            }
        }

        public string loginPassword
        {
            get
            {
                return _LoginPassword;
            }
            set
            {
                _LoginPassword = value;
            }
        }

        public bool name_PasswordRequired
        {
            get
            {
                return _Name_PasswordRequired;
            }
            set
            {
                _Name_PasswordRequired = value;
            }
        }

        public void Execute()
        {
            ClaimStakerClassic instance = new ClaimStakerClassic();
            string ExeName = instance.path + instance.exe;

            ProcessStartInfo start = new ProcessStartInfo();
            start.Arguments = @"C:\ClaimStaker 0";
            start.FileName = ExeName;

            using (Process proc = Process.Start(start))
            {

            }
        }
    }
}
