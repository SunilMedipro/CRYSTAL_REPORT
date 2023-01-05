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
    internal class IpdTrialReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\IpdSectionReports\IpdTrialRpt.rpt";


        public static void IpdTrialReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

            var response = client.GetAsync(baseUrl + "/api/IpdTrial/Select?userid=" + userid.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<IpdTrialReport_dt>>(responseString);

                cryRpt.SetDataSource(test); // from api


                CrystalRerportDocument = cryRpt;

                cryRpt = CrystalRerportDocument;

              

            }

        }


        public class IpdTrialReport_dt
        {
            public int serial { get; set; }
            public int sn { get; set; }
            public DateTime ddate { get; set; }
            public string bs_date { get; set; }
            public int hospid { get; set; }
            public int ipdno { get; set; }
            public string pname { get; set; }
            public int days { get; set; }
            public string telephone { get; set; }
            public string contactno { get; set; }
            public string wardno { get; set; }
            public string beno { get; set; }
            public double deposit { get; set; }
            public double amount { get; set; }
            public double due { get; set; }
            public int userid { get; set; }
        }
    }
}
