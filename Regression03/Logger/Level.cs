using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    public class Level
    {
        private Levels _status;
        public Levels status
        {
            get { return _status; }
            set { _status = value; }
        }
        public enum Levels { Info, Warn, Error, Fatal };

        //public override string ToString()
        //{
        //    if (status == 0)
        //    {
        //        return "Info";
        //    }
        //    if (status == 1)
        //    {
        //        return "Warn";
        //    }
        //}
    }
}
