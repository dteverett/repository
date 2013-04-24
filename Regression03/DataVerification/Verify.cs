using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logger;

namespace DataVerification
{
    public class Verify
    {
        SenderAPI logger = new SenderAPI();
        int tryCount = 0;
        int maxTry = 3;
        string sCode;
        string uName;
        long TestID;
        bool? results;

        public bool RegiVerifications(string salesCode, string userName, long testID)
        {
            sCode = salesCode;
            uName = userName;
            TestID = testID;
          
                Retrieve retrieve = new Retrieve();
                Doctor dr = retrieve.ReturnDoctor(userName);
                SalesCode_T code = retrieve.GetSalesCode(salesCode);
                SalesCodeType_T type = retrieve.GetSalesCodeType(code.SalesCodeType_ID);

            results = false;

            while (tryCount < maxTry && results == false)
            {
                results = verifyValues(dr, code, type);
                
            }
            if (results == null)
            {
                results = false;
            }
            return (bool)results;
            
        }

        private bool? verifyValues(Doctor dr, SalesCode_T code, SalesCodeType_T type)
        {
            tryCount++;
            try
            {
                if (dr.PerClaimRateOverBlockThreshold_SM != type.PerClaimRateOverBlockThreshold_SM)
                {
                    return false;
                }
                if (!dr.EligibilityBaseAmountMed_VC.Equals(type.EligibilityBaseAmount_VC))
                {
                    return false;
                }
            }
            catch (NullReferenceException ex)
            {
                if (tryCount >= maxTry)
                {
                    logger.Fatal(ex.Message, TestID);
                    results = null;
                    return results;
                }
                
                logger.Warn("Unable to retrieve values from database", TestID);
            }
                 
            return true;
        }
    }
}
