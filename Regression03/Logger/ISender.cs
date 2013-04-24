using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    interface ISender : ILogging
    {
        void Info(string message, int level, long TestID);
        void Warn(string message, int level, long TestID);
        void Error(string message, int level, long TestID);
        void Fatal(string message, int level, long TestID);
    }
}
