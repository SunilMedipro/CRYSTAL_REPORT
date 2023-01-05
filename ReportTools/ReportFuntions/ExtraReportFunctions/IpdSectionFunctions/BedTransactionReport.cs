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
    internal class BedTransactionReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\IpdSectionReports\BedTransactionRpt.rpt";


        public static void BedTransactionReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode, string ipdno)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

                    var response = client.GetAsync(baseUrl + "/api/BedTransactionReport/ReportSelect?ddate=" + from_date.ToString() + "&ipdno=" + ipdno.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<BedTransactionReport_dt>>(responseString);

                cryRpt.SetDataSource(test); // from api


                CrystalRerportDocument = cryRpt;

                cryRpt = CrystalRerportDocument;

              

            }

        }


        public class BedTransactionReport_dt
        {
            public int ipdno { get; set; }
            public DateTime ddate { get; set; }
            public string bedno { get; set; }
            public string billtime { get; set; }
            public int booked { get; set; }
            public string inout { get; set; }
            public int sn { get; set; }
            public string old_bed { get; set; }
            public string old_bedno { get; set; }
            public string bs_date { get; set; }
            public string ward { get; set; }
            public string book { get; set; }
        }
    }
}
