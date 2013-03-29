using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Data.Objects;
using System.Diagnostics;

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
                connection._repository.TestErrorLogs.AddObject(cast);
                connection._repository.SaveChanges();
            }
            catch (Exception ex)
            {

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
                connection._repository.TestLogs_T.AddObject(RLog);
                connection._repository.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            long returnValue = ReturnID();
            return returnValue;
        }

        private long ReturnID()
        {
            var RLog = connection._repository.TestLogs_T.OrderByDescending(x => x.DateExecuted_DT).FirstOrDefault();
            long returnValue = RLog.TestLog_ID;
            return returnValue;
        }
    }
}
