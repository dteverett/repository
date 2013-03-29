using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;
namespace WebTester
{
    public class DataVerification
    {
        SenderAPI logger = new SenderAPI();
       
        public object column;
        Connection connection = new Connection();
        DateTime today = DateTime.Today;


        public object retrieveDoctor(string userName, long TestID)
        {
            try
            {
                column = connection._repository.Doctors.FirstOrDefault(x => x.username == userName && x.created > today.AddDays(-1));
            }
            catch (Exception ex)
            {
                logger.Fatal(ex.Message, TestID);
            }

            return column as Doctor;

        }

        public object retrieveDoctor(string userName, string[] verifications, long TestID)
        {
           try
            {
                column = connection._repository.Doctors.FirstOrDefault(x => x.username == userName && x.created > today.AddDays(-1));
            }
            catch (Exception ex)
            {
                logger.Fatal(ex.Message, TestID);
            }

           return column;

        }

    }
}
