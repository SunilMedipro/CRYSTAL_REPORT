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
    internal class DeathCertificateReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\IpdSectionReports\DeathCertificateReportRpt.rpt";


        public static void DeathCertificateReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode, string firm)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

                    var response = client.GetAsync(baseUrl + "/api/IpdSection/DeathCertificateReport?init=" + initdate.ToString() + "&final=" + finaldate.ToString()
              + "&firm=" + firm.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<DeathCertificateReport_dt>>(responseString);

                cryRpt.SetDataSource(test); // from api


                CrystalRerportDocument = cryRpt;

                cryRpt = CrystalRerportDocument;

              

            }

        }


        public class DeathCertificateReport_dt
        {
            public string fy { get; set; }
            public string billtime { get; set; }
            public string inv_no { get; set; }
            public string expire_time { get; set; }
            public DateTime ddate { get; set; }
            public DateTime expire_date { get; set; }
            public int ipdno { get; set; }
            public int firm { get; set; }
            public int userid { get; set; }
            public string remarks { get; set; }
            public string note2 { get; set; }
            public string note3 { get; set; }
            public string note4 { get; set; }
            public string salute { get; set; }
            public string nominee { get; set; }
            public int refid { get; set; }
            public string note1 { get; set; }
            public string bs_date { get; set; }
            public string pname { get; set; }
            public string bs_expire_date { get; set; }
        }
    }
}
