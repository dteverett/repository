using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Data.Objects;
using System.Diagnostics;

using System.Data.Linq;

namespace Logger
{
    public class Log 
    {
        
        Connection connection = new Connection();
        private Level _logLevel;
        private string _thrower;
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public string Thrower
        {
            get { return _thrower; }
            set { _thrower = value; }
        }
        public Level LogLevel
        {  
            get { return _logLevel; }
            set { _logLevel = value; }
        }
        
        private void Write(TestErrorLog cast)
        {
            
            try
            {
                connection._repository.TestErrorLogs.InsertOnSubmit(cast);
                connection._repository.SubmitChanges();
                //connection._repository.TestErrorLogs.AddObject(cast);
                //connection._repository.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }

        }

        public void Call(object error)
        {
            var cast = error as TestErrorLog;
            Write(cast);
        }

        public long Register(TestLogs_T RLog)
        {
            try
            {
                
                connection._repository.TestLogs_Ts.InsertOnSubmit(RLog);
                connection._repository.SubmitChanges();
                //connection._repository.TestLogs_T.AddObject(RLog);
                //connection._repository.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }

            long returnValue = ReturnID();
            return returnValue;
        }

        private long ReturnID()
        {
            
            var RLog = connection._repository.TestLogs_Ts.OrderByDescending(x => x.DateExecuted_DT).FirstOrDefault();
            long returnValue = RLog.TestLog_ID;
            return returnValue;
        }

        internal void PassFailTest(bool result, long TestID)
        {
            using (Connection connect = new Connection())
            {
                TestLogs_T tLog = connect._repository.TestLogs_Ts.Where(x => x.TestLog_ID == TestID).FirstOrDefault();
                tLog.PassFail = result;
                connect._repository.SubmitChanges();
            }
        }

        internal void PassFailTest(bool result, long TestID, string message)
        {
            using (Connection connect = new Connection())
            {
                TestLogs_T tLog = connect._repository.TestLogs_Ts.Where(x => x.TestLog_ID == TestID).FirstOrDefault();
                tLog.PassFail = result;
                tLog.Notes_VC = message;
                connect._repository.SubmitChanges();
            }
        }
    }
}
