using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Logger;

namespace StatementsTesting
{
    public class StatementFiles
    {
        private const string exportPath = @"\\apexdata\F_Drive_Test\ClaimStaker\Claims\BACKUP\";
        private const string targetPath = @"\\apexfiler\apexdata\StatementTesting\Source\";
        private const string referencePath = @"\\apexdata\F_Drive_Test\QA\Statements\";
        private int _numOfTests = 10;
        public int NumOfTests
        {
            get { return _numOfTests; }
            set { _numOfTests = value; }
        }


        public string[] copyStatements(string clientID, int numOfTests)
        {
            NumOfTests = numOfTests;
            string[] returnValues = copyStatements(clientID);
            return returnValues;
        }

        public string[] copyStatements(string clientID)
        {
            int counter = NumOfTests;
            string fileName = "";
            string destFileName = "";
            string refFileName = "";
            string[] returnValues = new string[NumOfTests];

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
                if (Directory.Exists(exportPath))
                {
                    string[] files = Directory.GetFiles(exportPath);

                    foreach (string s in files)
                    {
                        fileName = Path.GetFileName(s);
                        string reversedFileName = (string)fileName.Reverse();

                        if (reversedFileName.StartsWith("f") && counter < NumOfTests)
                        {
                            if(reversedFileName[2].Equals("p"))
                            {
                                refFileName = Path.Combine(referencePath, fileName);
                                File.Copy(s, refFileName, true);
                                string modifiedReversed = reversedFileName.Substring(4);
                                string finalFileName = (string)modifiedReversed.Reverse();
                                destFileName = Path.Combine(targetPath, finalFileName);
                                File.Copy(s, destFileName, true);
                                

                                string fileNameStripped = stripBatchName(finalFileName);
                                returnValues[counter++] = fileNameStripped; 
                            }
                        }

                    }
                }
                return returnValues;
        }

        private string stripBatchName(string finalFileName)
        {
            char[] newFileName = new char[finalFileName.Length];
            int count = 0;
            foreach (char s in finalFileName)
            {
                if(!s.Equals("."))
                {
                    newFileName[count++] = s;
                }
            }
            string returnName = new String(newFileName);

            return returnName;

        }
    }
}
