using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Logger
{
    public class SenderAPI : ILogging, ISender
    {
        int caller { get; set; }

        public SenderAPI()
        {
            caller = 1;
        }

        public SenderAPI(int stkTrace)
        {
            caller = stkTrace;
        }

        RecieverAPI reciever = new RecieverAPI();

        public void EmbedError(object Message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void AddLog(string message, long TestID)
        {
            StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(caller);
            string callerName = frame.GetMethod().Name;

            TestErrorLog error = new TestErrorLog();
            error.Message_VC = message;
            error.DateCreated_DT = System.DateTime.Now;
            error.ExceptionThrower_VC = callerName;
            error.LogLevel_VC = "LEGACY";
            error.TestLog_ID = TestID;
        }



        public void Info(string message, long TestID)
        {
            StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(caller);
            string callerName = frame.GetMethod().Name;

            TestErrorLog info = new TestErrorLog();
            info.Message_VC = message;
            info.DateCreated_DT = System.DateTime.Now;
            info.ExceptionThrower_VC = callerName;
            info.LogLevel_VC = "INFO";
            info.TestLog_ID = TestID;

            reciever.Info(info);
        }

        public void Warn(string message, long TestID)
        {
            StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(caller);
            string callerName = frame.GetMethod().Name;

            TestErrorLog warn = new TestErrorLog();
            warn.Message_VC = message;
            warn.DateCreated_DT = System.DateTime.Now;
            warn.ExceptionThrower_VC = callerName;
            warn.LogLevel_VC = "ERROR";
            warn.TestLog_ID = TestID;

            reciever.Warn(warn);
        }

        public void Error(string message, long TestID)
        {
            StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(caller);
            string callerName = frame.GetMethod().Name;

            TestErrorLog error = new TestErrorLog();
            error.Message_VC = message;
            error.DateCreated_DT = System.DateTime.Now;
            error.ExceptionThrower_VC = callerName;
            error.LogLevel_VC = "ERROR";
            error.TestLog_ID = TestID;

            reciever.Error(error);
        }

        public void Fatal(string message, long TestID)
        {
            StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(caller);
            string callerName = frame.GetMethod().Name;

            TestErrorLog fatal = new TestErrorLog();
            fatal.Message_VC = message;
            fatal.DateCreated_DT = System.DateTime.Now;
            fatal.ExceptionThrower_VC = callerName;
            fatal.LogLevel_VC = "FATAL";
            fatal.TestLog_ID = TestID;

            reciever.Error(fatal);
        }

        public void Info(object error)
        {
            throw new NotImplementedException();
        }

        public void Warn(object error)
        {
            throw new NotImplementedException();
        }

        public void Error(object error)
        {
            throw new NotImplementedException();
        }

        public void Fatal(object error)
        {
            throw new NotImplementedException();
        }


    
        public void Info(string message, int level, long TestID)
        {
        	StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(level);
            string callerName = frame.GetMethod().Name;

            TestErrorLog info = new TestErrorLog();
            info.Message_VC = message;
            info.DateCreated_DT = System.DateTime.Now;
            info.ExceptionThrower_VC = callerName;
            info.LogLevel_VC = "INFO";
            info.TestLog_ID = TestID;

            reciever.Info(info);
        }

        public void Warn(string message, int level, long TestID)
        {
 	        StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(level);
            string callerName = frame.GetMethod().Name;

            TestErrorLog warn = new TestErrorLog();
            warn.Message_VC = message;
            warn.DateCreated_DT = System.DateTime.Now;
            warn.ExceptionThrower_VC = callerName;
            warn.LogLevel_VC = "INFO";
            warn.TestLog_ID = TestID;

            reciever.Info(warn);
        }

        public void Error(string message, int level, long TestID)
        {
            StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(level);
            string callerName = frame.GetMethod().Name;

            TestErrorLog error = new TestErrorLog();
            error.Message_VC = message;
            error.DateCreated_DT = System.DateTime.Now;
            error.ExceptionThrower_VC = callerName;
            error.LogLevel_VC = "INFO";
            error.TestLog_ID = TestID;

            reciever.Info(error);
        }

        public void Fatal(string message, int level, long TestID)
        {
            StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(level);
            string callerName = frame.GetMethod().Name;

            TestErrorLog fatal = new TestErrorLog();
            fatal.Message_VC = message;
            fatal.DateCreated_DT = System.DateTime.Now;
            fatal.ExceptionThrower_VC = callerName;
            fatal.LogLevel_VC = "INFO";
            fatal.TestLog_ID = TestID;

            reciever.Info(fatal);
        }

        public long RegisterTest()
        {
            StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(caller);
            string callerName = frame.GetMethod().Name;

            TestLogs_T log = new TestLogs_T();
            log.TestExecuted_VC = callerName;
            log.DateExecuted_DT = System.DateTime.Now;
            log.PassFail = false;

            long returnValue = reciever.RegisterTest(log);
            return returnValue;
        }

        public long RegisterTest(long parentTestID)
        {
            StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(caller);
            string callerName = frame.GetMethod().Name;

            TestLogs_T log = new TestLogs_T();
            log.TestExecuted_VC = callerName;
            log.DateExecuted_DT = System.DateTime.Now;
            log.ParentTest_ID = parentTestID;
            log.PassFail = false;

            long returnValue = reciever.RegisterTest(log);
            return returnValue;

        }

        public void PassFailTest(bool result, long testID)
        {
            reciever.PassFailTest(result, testID);
        }

        public void PassFailTest(bool result, long testID, string message)
        {
            reciever.PassFailTest(result, testID, message);
        }
    }
}
