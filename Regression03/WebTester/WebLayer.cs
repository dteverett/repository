using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logger;

namespace WebTester
{
    public class WebLayer
    {

        SenderAPI logger = new SenderAPI();

        public void Execute(WebForms[] forms)
        {
            long TestID = logger.RegisterTest();
            int resultsCounter = 0;

            foreach(WebForms form in forms)
            {
                TestResults results = form.Execute(form, TestID);
                if (results.Pass == true)
                    resultsCounter++;
            }
            if (resultsCounter == forms.Length - 1)
            {
                logger.PassFailTest(true, TestID);
            }
            else
                logger.PassFailTest(false, TestID, resultsCounter.ToString() + " subtests passed out of: " + forms.Length);
        }

        public void Execute(WebForms form)
        {
            TestResults results = form.Execute(form);
        }

        public void Execute(WebForms[] forms, long parentTestID)
        {
            foreach (WebForms form in forms)
            {
                TestResults results = form.Execute(form, parentTestID);
                
            }
        }

        public void Execute(WebForms form, long parentTestID)
        {
            TestResults results = form.Execute(form, parentTestID);
        }
    }
}
