using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace StatementsTesting
{
    public class StatementTest
    {
        StatementFiles file;
        DataRetrieval data;
        SenderAPI logger;
        private int _numOfTests;
        private const int DEFAULT_NUM_OF_TESTS = 5;

        public void Execute(string clientID, int numOfTests)
        {
            _numOfTests = numOfTests;
            Execute(clientID);
        }

        public void Execute(string clientID)
        {
            if (_numOfTests == 0 || _numOfTests == null)
            {
                _numOfTests = DEFAULT_NUM_OF_TESTS;
            }

            file = new StatementFiles();
            data = new DataRetrieval();
            logger = new SenderAPI();
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Claim_ID\tAccount Number\tLast Name\tFirst Name\tAddress\t\tCity\tState\tZip\n\n\n");

            string[] batches = file.copyStatements(clientID);

            foreach (string s in batches)
            {
                Statement_T[] batchArray = data.getBatch(s);
                foreach (var claim in batchArray)
                {
                    //TODO
                }
            }
        }
    }
}
