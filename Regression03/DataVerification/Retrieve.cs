using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVerification
{
    public class Retrieve
    {
        

        public void Test()
        {
            using (Connection connection = new Connection())
            {
                var doctor = connection._repository.Doctors.OrderByDescending(x => x.created).FirstOrDefault();
                Console.WriteLine(doctor.created);
                Console.WriteLine(doctor.name);
                Console.WriteLine(doctor.providers);
                Console.Read();
            }
        }

        public Doctor ReturnDoctor()
        {
            using (Connection connection = new Connection())
            {
                var doc = connection._repository.Doctors.OrderByDescending(x => x.created).FirstOrDefault();
                return doc as Doctor;
            }
        }

        public Doctor ReturnDoctor(string name)
        {
            using (Connection connection = new Connection())
            {
                var doc = connection._repository.Doctors.FirstOrDefault(x => x.username == name);
                return doc as Doctor;
            }
        }

        public SalesCode_T GetSalesCode()
        {
            using (Connection connection = new Connection())
            {
                var code = connection._repository.SalesCode_Ts.OrderByDescending(x => x.LastUpdate_DT).FirstOrDefault();
                return code as SalesCode_T;
            }
        }

        public SalesCode_T GetSalesCode(string code_VC)
        {
            using (Connection connection = new Connection())
            {
                var code = connection._repository.SalesCode_Ts.Where(x => x.Code_VC == code_VC).FirstOrDefault();
                return code as SalesCode_T;
            }
        }

        public SalesCodeType_T GetSalesCodeType()
        {
            using (Connection connection = new Connection())
            {
                var code = connection._repository.SalesCodeType_Ts.OrderByDescending(x => x.LastUpdate_DT).FirstOrDefault();
                return code as SalesCodeType_T;
            }
        }

        public SalesCodeType_T GetSalesCodeType(int type_ID)
        {
            using (Connection connection = new Connection())
            {
                var code = connection._repository.SalesCodeType_Ts.Where(x => x.SalesCodeType_ID == type_ID).FirstOrDefault();
                return code as SalesCodeType_T;
            }
        }

    }
}
