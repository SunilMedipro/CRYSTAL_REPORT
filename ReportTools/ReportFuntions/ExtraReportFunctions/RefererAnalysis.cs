using CrystalDecisions.CrystalReports.Engine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReportTools.ReportFuntions.ExtraReportFunctions
{
    internal class RefererAnalysisReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\RefererAnalysisRpt.rpt";


        public static void RefererAnalysisCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode,string firm,string ipd,
            string val, string insurance)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

            /// api / RefererAnalysis ? 
            //init = 2022 - 11 - 01 & 
            //final = 2022 - 11 - 27 & 
            //firm = 1 & 
            //ipd = 2 &
            //insurance = 2 
            //& val = 1 & 
            //userid = 1

            var response = client.GetAsync(baseUrl + "api/RefererAnalysis?init=" + initdate.ToString() +
                "&final=" + finaldate.ToString()+
                "&firm=" + firm.ToString()+"&ipd=" +
                ipd.ToString()+"&insurance=" +
                insurance.ToString() +
                "&val=" + val.ToString() +
                "&userid=" + userid.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<RefererAnalysis_dt>>(responseString);

                cryRpt.SetDataSource(test); // from api


                CrystalRerportDocument = cryRpt;

                cryRpt = CrystalRerportDocument;

              

            }

        }


        public class RefererAnalysis_dt
        {
            public int refid { get; set; }
            public string referer { get; set; }
            public int nob { get; set; }
            public double disc { get; set; }
            public double namt { get; set; }
        }
    }
}
