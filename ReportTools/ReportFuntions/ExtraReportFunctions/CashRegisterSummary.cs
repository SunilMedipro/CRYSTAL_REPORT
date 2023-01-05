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
    internal class CashRegisterSummaryReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\CashRegisterSummaryRpt.rpt";


        public static void CashRegisterSummaryReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode, string firm, string ipd, string due, string search)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

                    var response = client.GetAsync(baseUrl + "/api/CashRegisterSummary?init=" + initdate.ToString() + "&final=" + finaldate.ToString()
              + "&firm=" + firm.ToString() + "&ipd=" + ipd.ToString() + "&due=" + due.ToString() + "&search=" + search.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<CashRegisterSummaryReport_dt>>(responseString);

                cryRpt.SetDataSource(test); // from api


                CrystalRerportDocument = cryRpt;

                cryRpt = CrystalRerportDocument;

              

            }

        }


        public class CashRegisterSummaryReport_dt
        {
            public DateTime ddate { get; set; }
            public string bs_date { get; set; }
            public string r_no { get; set; }
            public string pname { get; set; }
            public double amount { get; set; }
            public double rebate { get; set; }
            public string due { get; set; }
            public string username { get; set; }
            public string billtime { get; set; }
            public bool ipd { get; set; }
            public string inv_no { get; set; }
        }
    }
}
