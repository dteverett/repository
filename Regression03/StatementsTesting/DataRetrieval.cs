using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatementsTesting
{
    class DataRetrieval
    {
        

            public Statement_T[] getBatch(string batch)
            {
                Statement_T[] claimArray;
                using(Connection connection = new Connection())
                {   
                    claimArray = connection._repository.Statement_Ts.Where(x => x.BatchNum_VC == batch).ToArray();
                }
                return claimArray;
            }

        public StatementLineItem_T[] getLineItems(long claimID)
        {
            StatementLineItem_T[] lineArray;
            using (Connection connection = new Connection())
            {
                 lineArray = connection._repository.StatementLineItem_Ts.Where(x => x.Claim_ID == claimID).ToArray();
            }
            return lineArray;
        }
        
        public void DeleteStatements(string batchID)
        {
            using (Connection connection = new Connection())
            {
                Statement_T[] deleteBatch = connection._repository.Statement_Ts.Where(x => x.BatchNum_VC == batchID).ToArray();

                foreach (Statement_T statementT in deleteBatch)
                {
                    connection._repository.Statement_Ts.DeleteOnSubmit(statementT);
                }
                connection._repository.SubmitChanges();
            }
        }
    }
}
