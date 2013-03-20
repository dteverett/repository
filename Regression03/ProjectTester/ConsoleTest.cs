using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logger;
using Regression03;
using Form;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using DataModel;
using System.Data.SqlClient;
using System.Data.Sql;


namespace ProjectTester
{
    class ConsoleTest
    {
        //[STAThread]
        static void Main(string[] args)
        {
            DataModel.Connection connection = new DataModel.Connection();
            //var medical = new Medical();
            //var dental = new Dental();
            ////dental.File =
            ////    "ISA*00*          *00*          *ZZ*870578776      *ZZ*133052274      *130214*1205*^*00501*999999999*1*T*:~GS*HC*870578776*133052274*20130214*1202*568995*X*005010X224A2~ST*837*0001*005010X224A2~BHT*0019*00*0*20130214*120528*CH~NM1*41*2*APEX EDI INC*****46*870578776~PER*IC*ROGER ADAMS*TE*8016420300~NM1*40*2*WEBMD*****46*133052274~HL*1**20*1~NM1*85*2*DENTISTRY FOR CHILDREN ATLANTA*****XX*1144509852~N3*4536 CHAMBLEE DUNWOODY RD STE 211~N4*ATLANTA*GA*303386201~REF*EI*452475387~REF*G5*9~REF*0B*DN014083~PER*IC*STEFANIE YI*TE*7704551238~HL*2*1*22*0~SBR*P*18*******MC~NM1*IL*1*ISINUGBEN*ANDY****MI*111895645819~N3*290 WINDING RIVER D~N4*ATLANTA*GA*30350~DMG*D8*19940515*M~NM1*PR*2*ACS/GHP/ GEORGIA MEDICAID*****PI*CKGA1~N3*P.O. BOX 105205~N4*TUCKER*GA*300855205~CLM*10644901-123*512***11:B:1*Y*A*Y*Y~DTP*472*D8*20130107~REF*D9*D4903359~NM1*82*1*CARA*YASHEENA****XX*1720393291~PRV*PE*PXC*1223P0221X~LX*1~SV3*AD:D2392*230****1~TOO*JP*31*O:B~REF*6R*1~LX*2~SV3*AD:D2393*282****1~TOO*JP*29*M:O:D~REF*6R*2~SE*36*0001~GE*1*568995~IEA*1*999999999~";

            

            //OpenFileDialog openDialog = new OpenFileDialog();
            //openDialog.InitialDirectory = @"\\apexdata\F_Drive_Test\claimstaker\output\";
            //openDialog.ShowDialog();
            //string file;// = openDialog.FileName();
            //using (StreamReader reader = new StreamReader(openDialog.FileName))
            //{
            //    file = reader.ReadToEnd();
            //}
            //dental.File = file;
            //var returned = Form.Convert.convertToText(dental);
            //using (StreamWriter writer = new StreamWriter(@"C:\users\deverett.APEX\desktop\testFile.txt"))
            //{
            //    writer.Write(returned.File);
            //}

            var results = connection._connection.ClaimMedicalBase_T.FirstOrDefault(x => x.BatchNumber_VC == "0607111524ALR");

            Console.WriteLine(results.ClaimMedicalBase_ID.ToString());

            Console.Read();
        }
    }
}
