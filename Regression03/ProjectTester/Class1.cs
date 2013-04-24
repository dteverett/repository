using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProjectTester
{
    class Class1
    {
        public void Written(string message)
        {
            //new StackFrame(1, true).GetMethod().Name
            
            StackTrace trace = new StackTrace();
            int caller = 1;
            StackFrame frame = trace.GetFrame(caller);
            string callerName = frame.GetMethod().Name;

            Console.WriteLine(callerName);
            Console.WriteLine();
            Console.WriteLine(message);
            Console.Read();

        }
    }
}
