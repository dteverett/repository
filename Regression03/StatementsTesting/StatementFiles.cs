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
        private const string ExportPath = @"\\apexdata\data\ClaimStaker\Claims\BACKUP\";
        private const string targetPath = @"\\apexfiler\apexdata\StatementTesting\Source\";
        private const string referencePath = @"\\apexdata\F_Drive_Test\QA\Statements\";
        private int _numOfTests;

        public string[] copyStatements(string clientID, int numOfTests)
        {
            _numOfTests = StatementTest.DefaultNumOfTests;
            string[] returnValues = copyStatements(clientID);
            return returnValues;
        }

        public string[] copyStatements(string clientID)
        {
            _numOfTests = StatementTest.DefaultNumOfTests;
            DataRetrieval data = new DataRetrieval();
            int counter = 0;
            string fileName = "";
            string destFileName = "";
            string refFileName = "";
            string[] returnValues = new string[_numOfTests];

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            string exportPathComplete = Path.Combine(ExportPath, clientID);
            if (Directory.Exists(exportPathComplete))
            {
                string[] files = Directory.GetFiles(exportPathComplete);

                for(int i = 0; counter < _numOfTests && i < files.Length;i++)
                {
                    string s = files[i];
                        fileName = Path.GetFileName(s);
                    if (fileName.StartsWith("S"))
                    {
                        string reversedFileName = Reverse(fileName);

                        if (reversedFileName.StartsWith("f"))
                        {
                            char c = reversedFileName[2];
                            if (c.CompareTo('p') == 0)
                            {
                                try
                                {
                                    refFileName = Path.Combine(referencePath, fileName);
                                    File.Copy(s, refFileName, true);
                                    string modifiedReversed = reversedFileName.Substring(4);
                                    string finalFileName = Reverse(modifiedReversed);
                                    destFileName = Path.Combine(targetPath, finalFileName);
                                    string fileNameStripped = stripBatchName(finalFileName);

                                    data.DeleteStatements(fileNameStripped);
                                    File.Copy(s, destFileName, true);
                                    returnValues[counter++] = fileNameStripped;
                                }
                                catch (IOException ex)
                                {
                                    Console.WriteLine("EXCEPTION: {0}", ex.Message);
                                }
                            }
                        }
                    }
                }
            }
            return returnValues;
        }

        private string stripBatchName(string finalFileName)
        {
            char[] newFileName = new char[finalFileName.Length - 1];
            int count = 0;
            foreach (char s in finalFileName)
            {
                if(!s.Equals('.'))
                {
                    newFileName[count++] = s;
                }
            }
            string returnName = new String(newFileName);

            return returnName;

        }

        public string Reverse(string text)
        {
            if (text == null) return null;

            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        /// <summary>
        /// Returns true while the file exists
        ///
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public string CheckFileEmpty(string[] clientIDs)
        {
            bool anyDone = false;
            while (!anyDone)
            {
                string[] files = Directory.GetFiles(targetPath);
                string[] fileNames = new string[files.Length];
                for (int i = 0; i < files.Length; i++)
                {
                    fileNames[i] = Path.GetFileName(files[i]);
                }
                string clientID = clientIDs[0];
                //for (int i = 0; i < clientIDs.Length; i++)
                //{
                    
                //}


                    foreach (string file in fileNames)
                    {
                        string fname = file.Substring(12);
                        if (fname.ToLower().Equals(clientID))
                            return clientID;
                    }
            }
            return "none"; //fix this of course
        }
    }
}
