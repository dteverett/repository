using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Form
{
    public class Dental : Forms, IForm
    {
        public override string Name
        {
            get { return "Dental"; }
        }
        public override string DateTime1
        {
            get { return @"\s\*[1,3]{2}[0-9]{4}\*[0-9]*"; }
        }
        public override string DateTime1Replace
        {
            get { return @"*130128*0234"; }
        }
        public override string Unique1
        {
            get { return @"\*[2][0][1][0-9]{5}\*[0-9]{6}\*"; }
        }
        public override string Unique1Replace
        {
            get { return @"*20130212*103606*"; }
        }
        public override string DateTime2
        {
            get { return @"\*[2][0][1][0-9]{5}\*[0-9]{4}\*[0-9]{6}\*"; }
        }
        public override string DateTime2Replace
        {
            get { return @"*20130212*1002*565056*"; }
        }
        public override string Unique2
        {
            get { return @"\*[0-9]{6}\~"; }
        }
        public override string Unique2Replace
        {
            get { return @"*565056~"; }
        }
        public override char Key
        {
            get { return 'd'; }
        }
        public override string File { get; set; }

        public override string ClaimID
        {
            get { return @"D9\*D[0-9]{7}\~"; }
        }
        public override string ClaimIDReplace
        {
            get { return @"D9*D4903359~"; }
        }
    }
}
