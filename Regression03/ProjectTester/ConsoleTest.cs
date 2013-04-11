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
using System.Data.SqlClient;
using System.Data.Sql;
using WebTester;
using System.Data.Linq;
using DataVerification;
using System.Reflection;
using System.Globalization;
using Microsoft.Win32;


namespace ProjectTester
{
    class ConsoleTest
    {
        //[STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
 

            //CASSegment cas = new CASSegment();
            ////CreateOutput output = new CreateOutput();
            //DataBase data = new DataBase();


            ////long testID = cas.TheCasSegmentTest();
            ////long ClaimID = data.ClaimMedicalBaseID("zzz");

            ////long ClaimID = 6861277;

            //CASSegment segment = new CASSegment();

            ////segment.TheCasSegmentTest();

            //long claimID = data.ClaimMedicalBaseID("cui");
            //Console.WriteLine(claimID.ToString());
            //Console.Read();

            //CASSegmentMultiple multiple = new CASSegmentMultiple();
            //multiple.TheCasSegmentMultiple("cui");

            //string[] salesCode = new string[] { "APDM7521", "APDX1273", "APDM9612", "APDX4240" };
            //RegiSalesMultiple regi = new RegiSalesMultiple();
            //regi.MultipleProvidersTest(salesCode, false);

            var array = buildMedicalForms();
            WebLayer web = new WebLayer();
            web.Execute(array);

            
        }

        private static WebForms[] buildMedicalForms()
        {
            Client cui = new Client("cui", "clintonsa", "claims123");
            Client cgf = new Client("cgf", "Leary15660", "claims123");
            Client zzz = new Client("zzz", "demo1", "medical1");
            Client pcw = new Client("pcw", "PCW", "apexclaims");
            Client oty = new Client("oty", "oaktree15630", "apex13");
            Client abd = new Client("abd", "advanced10", "apex10");
            Client acy = new Client("acy", "catalano", "apex10");
            Client cvs = new Client("cvs", "completevc", "claims123");
            Client plh = new Client("plh", "plh", "Innate12");
            Client bdv = new Client("bdv", "johnbriles", "apex13");



            
            
            Medical5010 med = new Medical5010(cui);
            Medical5010 med1 = new Medical5010(zzz);
            Medical5010 med2 = new Medical5010(cgf);
            Medical5010 med3 = new Medical5010(pcw);
            Medical5010 med4 = new Medical5010(oty);
            Medical5010 med5 = new Medical5010(abd);
            Medical5010 med6 = new Medical5010(acy);
            Medical5010 med7 = new Medical5010(cvs);
            Medical5010 med8 = new Medical5010(plh);
            Medical5010 med9 = new Medical5010(bdv);

            WebForms[] array = new WebForms[] { med, med1, med2, med3, med4, med5, med6, med7, med8, med9 };

            return array;
        }







        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            AssemblyName assemblyName = new AssemblyName(args.Name);
            if (assemblyName.Name.StartsWith("Microsoft.VisualStudio.TestTools.UITest", StringComparison.Ordinal))
            {
                string path = string.Empty;
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\VisualStudio\11.0"))
                {
                    if (key != null)
                    {
                        path = key.GetValue("InstallDir") as string;
                    }
                }

                if (!string.IsNullOrWhiteSpace(path))
                {
                    string assemblyPath = Path.Combine(path, "publicAssemblies", string.Format(CultureInfo.InvariantCulture, "{0}.dll", assemblyName.Name));

                    if (!File.Exists(assemblyPath))
                    {
                        assemblyPath = Path.Combine(path, "PrivateAssemblies", string.Format(CultureInfo.InvariantCulture, "{0}.dll", assemblyName.Name));

                        if (!File.Exists(assemblyPath))
                            {
                                string commonFiles = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86);
                                if (string.IsNullOrWhiteSpace(commonFiles))
                                {
                                    commonFiles = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);
                                }

                                assemblyPath = Path.Combine(commonFiles, "Microsoft Shared", "VSIT", "11.0", string.Format(CultureInfo.InvariantCulture, "{0}.dll", assemblyName.Name));
                            }
                        }

                        if (File.Exists(assemblyPath))
                        {
                            return Assembly.LoadFrom(assemblyPath);
                        }
                    }
                }

                return null;
            
        }
    }
}
