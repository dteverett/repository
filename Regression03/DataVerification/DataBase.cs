using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace DataVerification
{
    public class DataBase
    {
        
        public long ClaimMedicalBaseID(string clientID)
        {
            long claimID;
            using (Connection connection = new Connection())
            {
                ClaimMedicalBase_T claim = connection._repository.ClaimMedicalBase_Ts.Where(x => x.ClientID_VC == clientID && x.ReportDate_DT > System.DateTime.Now.AddMinutes(-5)).FirstOrDefault();
                //ClaimMedicalBase_T claim = aclaim[0];
                claimID = claim.ClaimMedicalBase_ID;
            }

            return claimID;
        }

        public long ClaimMedicalBaseID()
        {
            const string ClientID = "zzz";
            long ClaimID;
            using (Connection connection = new Connection())
            {
                ClaimMedicalBase_T claim = connection._repository.ClaimMedicalBase_Ts.OrderByDescending(x => x.ClientID_VC == ClientID && x.ReportDate_DT > System.DateTime.Now.AddMinutes(-5)).FirstOrDefault();
                ClaimID = claim.ClaimMedicalBase_ID;
            }

            return ClaimID;
        }
    }
}
