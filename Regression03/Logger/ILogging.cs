using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace Logger
{
    interface ILogging
    {
        void EmbedError(object Message, Exception exception);

        void Info(object Message);
       // void Info(object Message, [CallerMemberName] string memberName = "");
        void Warn(object Message);
       // void Warn(object Message, [CallerMemberName] string memberName = "");
        void Error(object Message);
        //void Error(object Message, [CallerMemberName] string memberName = "");
        void Fatal(object Message);
        //void Fatal(object Message, [CallerMemberName] string memberName = "");
        

    }
}
