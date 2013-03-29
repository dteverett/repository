using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Logger
{
    public class RecieverAPI : ILogging
    {
        int caller = 1;

        public RecieverAPI()
        {
        }

        Log log = new Log();



        public void AddLog(string message)
        {
            StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(caller);
            string callerName = frame.GetMethod().Name;

            TestErrorLog error = new TestErrorLog();
            error.Message_VC = message;
            error.DateCreated_DT = System.DateTime.Now;
            error.ExceptionThrower_VC = callerName;
            error.LogLevel_VC = "LEGACY";
        }
        
        public void Info(object error)
        {
            log.Call(error);
        }

        public void Warn(object error)
        {
            log.Call(error);
        }

        public void Error(object error)
        {
            log.Call(error);
        }

        public void Fatal(object error)
        {
            log.Call(error);
        }

        public long RegisterTest(TestLogs_T Rlog)
        {
            long returnValue = log.Register(Rlog);
            return returnValue;
        }
    }
}
