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
    internal class DepositRefundReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\IpdSectionReports\DepositRefundReportRpt.rpt";


        public static void DepositRefundReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode, string firm)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

            var response = client.GetAsync(baseUrl + "/api/DepositRefundReport/Select?init=" + initdate.ToString() + "&final=" + finaldate.ToString()
                + "&firm=" +firm.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<DepositRefundReport_dt>>(responseString);

                cryRpt.SetDataSource(test); // from api


                CrystalRerportDocument = cryRpt;

                cryRpt = CrystalRerportDocument;

              

            }

        }


        public class DepositRefundReport_dt
        {
            public DateTime ddate { get; set; }
            public string fy { get; set; }
            public string inv_no { get; set; }
            public int ipdno { get; set; }
            public float amount { get; set; }
            public int userid { get; set; }
            public string billtime { get; set; }
            public bool posted { get; set; }
            public int firm { get; set; }
            public string remarks { get; set; }
            public int ac_code { get; set; }
            public string p_type { get; set; }
            public int cardid { get; set; }
            public string pname { get; set; }
            public string bs_date { get; set; }
            public string username { get; set; }
        }
    }
}
