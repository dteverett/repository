using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Data.Objects;
using System.Diagnostics;

namespace Logger
{
    public class Logging : ILogging
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
        
        public void Write()
        {
            string written = this._logLevel.ToString();
            Test test = new Test();
            test.Message_VC = this._message;
            test.DateCreated_DT = System.DateTime.Now;
            test.ExceptionThrower_VC = this._thrower;
            test.LogLevel_VC = this._logLevel.ToString();

            connection._repository.Tests.AddObject(test);
            connection._repository.SaveChanges();
        }

        public void Error(object message)
        {
            StackTrace trace = new StackTrace();
            int caller = 1;
            StackFrame frame = trace.GetFrame(caller);
            string callerName = frame.GetMethod().Name;

            Test error = new Test();
            error.Message_VC = (string)message;
            error.DateCreated_DT = System.DateTime.Now;
            error.ExceptionThrower_VC = callerName;
            error.LogLevel_VC = "ERROR";
            connection._repository.Tests.AddObject(error);
            connection._repository.SaveChanges();
        }
        public void Info(object message)
        {
            StackTrace trace = new StackTrace();
            int caller = 1;
            StackFrame frame = trace.GetFrame(caller);
            string callerName = frame.GetMethod().Name;

            Test info = new Test();
            info.Message_VC = (string)message;
            info.DateCreated_DT = System.DateTime.Now;
            info.ExceptionThrower_VC = callerName;
            info.LogLevel_VC = "INFO";
            connection._repository.Tests.AddObject(info);
            connection._repository.SaveChanges();
        }
        public void Warn(object message)
        {
            StackTrace trace = new StackTrace();
            int caller = 1;
            StackFrame frame = trace.GetFrame(caller);
            string callerName = frame.GetMethod().Name;

            Test warn = new Test();
            warn.Message_VC = (string)message;
            warn.DateCreated_DT = System.DateTime.Now;
            warn.ExceptionThrower_VC = callerName;
            warn.LogLevel_VC = "WARN";
            connection._repository.Tests.AddObject(warn);
            connection._repository.SaveChanges();
        }
        public void Fatal(object message)
        {
            StackTrace trace = new StackTrace();
            int caller = 1;
            StackFrame frame = trace.GetFrame(caller);
            string callerName = frame.GetMethod().Name;

            Test fatal = new Test();
            fatal.Message_VC = (string)message;
            fatal.DateCreated_DT = System.DateTime.Now;
            fatal.ExceptionThrower_VC = callerName;
            fatal.LogLevel_VC = "FATAL";
            connection._repository.Tests.AddObject(fatal);
            connection._repository.SaveChanges();
        }

        public void EmbedError(object message, Exception exception)
        {
            //TODO
            throw new NotImplementedException();
        }

    }
}
