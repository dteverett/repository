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
            Console.WriteLine("Message: " + cast.Message_VC);
            Console.WriteLine("Thrown by: " + cast.ExceptionThrower_VC);
            Console.WriteLine("Test: " + cast.TestLog_ID);
            Console.WriteLine();
            
            try
            {
                using (Connection connection = new Connection())
                {
                    connection._repository.TestErrorLogs.InsertOnSubmit(cast);
                    connection._repository.SubmitChanges();
                    //connection._repository.TestErrorLogs.AddObject(cast);
                    //connection._repository.SaveChanges();
                }
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
            Console.WriteLine("Attempting to Register Test");
            try
            {
                using (Connection connection = new Connection())
                {
                    connection._repository.TestLogs_Ts.InsertOnSubmit(RLog);
                    connection._repository.SubmitChanges();
                    //connection._repository.TestLogs_T.AddObject(RLog);
                    //connection._repository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
            Console.WriteLine("Test Registered: " + RLog.TestLog_ID);
            Console.WriteLine();

            long returnValue = ReturnID();
            return returnValue;
        }

        private long ReturnID()
        {
            using (Connection connection = new Connection())
            {
                var RLog = connection._repository.TestLogs_Ts.OrderByDescending(x => x.DateExecuted_DT).FirstOrDefault();
                long returnValue = RLog.TestLog_ID;
                Console.WriteLine("ID returned: " + returnValue.ToString());
                Console.WriteLine();
                return returnValue;
            }

            
        }

        internal void PassFailTest(bool result, long TestID)
        {
            
            using (Connection connect = new Connection())
            {
                TestLogs_T tLog = connect._repository.TestLogs_Ts.Where(x => x.TestLog_ID == TestID).FirstOrDefault();
                tLog.PassFail = result;
                connect._repository.SubmitChanges();
            }
            Console.WriteLine("Test: " + TestID);
            Console.WriteLine("Passed: " + result);
            Console.WriteLine();
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
