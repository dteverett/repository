using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatementsTesting
{
    public class Controller
    {
        private StatementTest statements;
        private StatementFiles files;


        public void Execute(string[] clientIDs)
        {
            statements = new StatementTest();
            files = new StatementFiles();
            string[][] groupBatches = new string[clientIDs.Length][];

            for (int i = 0; i < groupBatches.Length; i++)
            {
                groupBatches[i] = new string[StatementTest.DefaultNumOfTests];
            }
            for (int i = 0; i < clientIDs.Length; i++)
            {
                string clientID = clientIDs[i];
                groupBatches[i] = statements.Execute(clientID);
            }

            bool allClear = false;
            bool?[] clients = new bool?[groupBatches.Length];
            for (int i = 0; i < clients.Length; i++)
                clients[i] = false;

                while (!allClear)
                {
                    int counter = 0;
                    string firstDone = files.CheckFileEmpty(clientIDs);
                    for (int i = 0; i < clientIDs.Length; i++)
                    {
                        if (clients[i] == null)
                            counter++;
                        if (clientIDs[i] == firstDone)
                            clients[i] = null;
                    }
                    if (counter == 3)
                        allClear = true;


                }

        }

        public void Execute(string[] clientIDs, int numOfTests)
        {
            StatementTest.DefaultNumOfTests = numOfTests;
            Execute(clientIDs);
        }

        public void Execute(string clientID)
        {
            statements = new StatementTest();
            string[] batches = new string[10];
            batches = statements.Execute(clientID);
        }
    }
}
