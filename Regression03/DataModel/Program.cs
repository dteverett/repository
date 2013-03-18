using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    class Program
    {
        static void Main(string[] args)
        {
            String result = "";
            Connection connect = new Connection();

            var Log = connect._repository.ApplicationLog_T.Where(x => x.Logger_VC == "INFO").ToArray();

            foreach (var log in Log)
            {
                result += log.Message_VC;
                result += "     \n";
            }
        }
    }
}
