using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationExe
{
    interface IApplications
    {
        String path { get; }
        String exe { get; }
        String name { get; }
        bool status { get; set; }
        String loginName { get; set; }
        String loginPassword { get; set; }
        bool name_PasswordRequired { get; set; }
    }
}
