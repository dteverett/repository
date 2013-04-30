using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;
using System.Reflection;

namespace StatementsTesting
{
    class StatementTest
    {
        StatementFiles file;
        DataRetrieval data;
        SenderAPI logger;
        private const int DEFAULT_NUM_OF_TESTS = 5;

        public string[] Execute(string clientID)
        {
            if (DefaultNumOfTests == 0)
            {
                DefaultNumOfTests = DEFAULT_NUM_OF_TESTS;
            }

            file = new StatementFiles();
            data = new DataRetrieval();
            logger = new SenderAPI();
            //StringBuilder sb = new StringBuilder();

            //sb.AppendFormat("Claim_ID\tAccount Number\tLast Name\tFirst Name\tAddress\t\tCity\tState\tZip\n\n\n");



            string[] batches = file.copyStatements(clientID);
            return batches;
        }

        public void Display(string[] batches)
        {
            StringBuilder sb = new StringBuilder();
            BindingFlags b = BindingFlags.Instance | BindingFlags.Public;
            var columns = typeof(StatementLineItem_T).GetProperties(b);
            var statement = typeof (Statement_T).GetProperties(b);

            foreach (string s in batches)
            {
                Statement_T[] batchArray = data.getBatch(s);
                foreach (var claim in batchArray)
                {
                    sb.Append("\n********************** CLAIM " + claim.Claim_ID + " **************************\n");
                    Console.WriteLine();
                    Console.WriteLine("********************* CLAIM {0} **************************", claim.Claim_ID);
                    Console.WriteLine();

                    for (int i = 0; i < 98; i++ )
                    {
                       var p = statement[i];
                        if (p == null)
                            break;
                        object x = p.GetGetMethod().Invoke(claim, null);
                        if (x != null)
                        {
                            if (x is String)
                            {
                                if (String.IsNullOrEmpty((string)x))
                                    break;
                                Console.WriteLine(p.Name + " = " + x);
                                sb.Append(p.Name + " = " + x + "\n");
                            }
                            else if (x is int || x is long || x is float || x is double || x is Int16 || x is Int32 ||
                                x is Int64 || x is uint || x is short || x is ulong)
                            {
                                if ((double) x == 0)
                                    break;
                                Console.WriteLine(p.Name + " = " + x.ToString());
                                sb.Append(p.Name + " = " + x.ToString() + "\n");
                            }
                            else
                            {
                                Console.WriteLine(p.Name + " = " + x.ToString());
                                sb.Append(p.Name + " = " + x.ToString() + "\n");
                            }
                            
                        }
                    }

                    StatementLineItem_T[] lineArray = data.getLineItems(claim.Claim_ID);

                    foreach (StatementLineItem_T line in lineArray)
                    {
                        for (int i = 0; i < 25; i++) //using reflection namespace and bindingFlags
                        {
                            var p = columns[i];
                            if (p == null)
                                break;
                            object x = p.GetGetMethod().Invoke(line, null);
                            if (x != null)
                            {
                                if (x is string)
                                {
                                    if (String.IsNullOrEmpty((String)x))
                                        break;
                                    Console.WriteLine(p.Name + " = " + x);
                                    sb.Append(p.Name + " = " + x + "\n");
                                }
                                else if (x is int || x is long || x is float || x is double || x is Int16 || x is Int32 ||
                                    x is Int64 || x is uint || x is short || x is ulong)
                                {
                                    if ((double) x == 0)
                                        break;
                                    Console.Write(p.Name + " = " + x.ToString() + "\n");
                                    sb.Append(p.Name + " = " + x.ToString() + "\n");
                                }
                                else
                                {
                                    Console.WriteLine(p.Name + " = " + x.ToString());
                                    sb.Append(p.Name + " = " + x.ToString() + "\n");
                                }
                                
                            }
                        }
                        Console.WriteLine();
                        sb.Append("\n");
                    }
                }
            }
        }

        private async void WriteToFile(StringBuilder sb, string clientID, long statementID)
        {
            string docPath = @"\\ApexData\F_Drive_Test\QA\";
            string fileName = clientID + statementID.ToString();

            using (StreamWriter outfile = new StreamWriter(docPath + fileName, true))
            {
                await outfile.WriteAsync(sb.ToString());
            }
        }

        public static int DefaultNumOfTests { get; set; }
    }
}
