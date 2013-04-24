using System;

namespace Form
{
    public class Medical : Forms, IForm
    {

        public override string Name
        {
            get { return "Medical"; }
        }
        public override string DateTime1
        {
            get { return @"\s\*1[3-5][0-9]{4}\*[0-9]{4}"; }
        }
        public override string DateTime1Replace
        {
            get { return @"*130128*0234"; }
        }
        public override string Unique1
        {
            get { return @"\*0201\*[0-9]{6}"; }
        }
        public override string Unique1Replace
        {
            get { return @"*0201*544489"; }
        }
        public override string DateTime2
        {
            get { return @"\*0\*201[3-5][0-9]{4}\*[0-9]{6}"; }
        }
        public override string DateTime2Replace
        {
            get { return @"*0*20130128*023450"; }
        }
        public override string Unique2
        {
            get { return @"GE\*1\*[0-9]{6}"; }
        }
        public override string Unique2Replace
        {
            get { return @"GE*1*544489"; }
        }
        public override char Key
        {
            get { return 'm'; }
        }
        public override string File { get; set; }

        public override string ClaimID
        {
            get { throw new NotImplementedException(); }
        }

        public override string ClaimIDReplace
        {
            get { throw new NotImplementedException(); }
        }
    }
}
