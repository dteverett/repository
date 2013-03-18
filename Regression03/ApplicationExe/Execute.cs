using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ApplicationExe
{
    public class Execute
    {
        public Execute()
        {

        }

        private void ExecuteClaimStakerPlus()
        {
            int exitCode;
            ClaimStakerPlus instance = new ClaimStakerPlus();
            string ExeName = instance.path + @"\" + instance.exe;
            

            ProcessStartInfo start = new ProcessStartInfo();
            start.Arguments = null;
            start.FileName = ExeName;

            using (Process proc = Process.Start(start))
            {
                proc.WaitForExit();

                exitCode = proc.ExitCode;
            }

           
        }
        private void ExecuteClaimStakerClassic()
        {

        }



        public void ExecuteAll()
        {
            ExecuteClaimStakerPlus();

        }

    }
}
