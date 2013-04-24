using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTester;
namespace Controller
{
    class Control
    {
        static void Main(string[] args)
        {
            string userName = "demo1";
            string password = "medical1";
            Test.Initialize();
            Test.LogOnOneTouch(userName, password);
            Test.FormTest1();
        }
    }
}
