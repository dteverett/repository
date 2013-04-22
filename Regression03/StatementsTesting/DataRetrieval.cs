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
                using(Connection connection = new Connection())
                {   
                    Statement_T[] claimArray = connection._repository.Statement_Ts.Where(x => x.BatchNum_VC == batch).ToArray();

                    return claimArray;
                }
            }
        
    }
}
