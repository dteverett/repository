using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using DataModel;

namespace Logger
{
    public class Log
    {
        private static String log = null;
        private static int counter = 1;
        private static Connection connection = new Connection();

        public static void AddLog(String message)
        {
            connection._connection.Tests.Where(x => x.DateCreated_DT != null).ToArray();
           
        }

        public static void DisplayLog()
        {
            Console.WriteLine(log);
            Console.Read();
            Console.WriteLine("Would you like to save this log file? Y/N");
            String reply = Console.ReadLine();
            if (reply.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                SaveLog();
            }
         
        }

        public static void SaveLog()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Specify destination filename";
            saveDialog.Filter = "Text Files| *.txt, *.docx";
            saveDialog.OverwritePrompt = true;
            saveDialog.InitialDirectory = @"\\apexdata\F_Drive_Test\QAFiles\Log\";
            saveDialog.ShowDialog();
            String destination = saveDialog.FileName;

            using (StreamWriter writer = new StreamWriter(destination))
            {
                writer.Write(log);
            }
        }
    }
}
