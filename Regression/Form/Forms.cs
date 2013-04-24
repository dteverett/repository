﻿namespace Form
{
    /// <summary>
    /// Base class, uses IForm Interface.  Base class to be passed as an argument
    /// to other methods so that multiple/overloaded methods aren't required to take 
    /// seperate medical/dental forms
    /// </summary>
    public abstract class Forms : IForm
    {
        public abstract string Name { get; }
        public abstract string DateTime1 { get;}
        public abstract string DateTime1Replace { get;  }
        public abstract string Unique1 { get;  }
        public abstract string Unique1Replace { get; }
        public abstract string DateTime2 { get;  }
        public abstract string DateTime2Replace { get; }
        public abstract string Unique2 { get; }
        public abstract string Unique2Replace { get;  }
        public abstract char Key { get; }
        public abstract string File { get; set; }
        public abstract string ClaimID { get;}
        public abstract string ClaimIDReplace { get; }
        
    }

 
}
