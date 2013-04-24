using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebTester
{
    interface IWebForms
    {
        TestResults Execute(WebForms form);
        TestResults Execute(WebForms form, long parentTestID);
    }
}
