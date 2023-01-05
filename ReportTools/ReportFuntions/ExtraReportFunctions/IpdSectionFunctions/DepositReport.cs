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
    internal class DepositReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\IpdSectionReports\DepositReportRpt.rpt";


        public static void DepositReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode, string firm)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

            var response = client.GetAsync(baseUrl + "/api/DepositReport/Select?init=" + initdate.ToString() + "&final=" + finaldate.ToString()
                + "&firm=" +firm.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<DepositReport_dt>>(responseString);

                cryRpt.SetDataSource(test); // from api


                CrystalRerportDocument = cryRpt;

                cryRpt = CrystalRerportDocument;

              

            }

        }


        public class DepositReport_dt
        {
            public string fy { get; set; }
            public string inv_no { get; set; }
            public int ipdno { get; set; }
            public double amount { get; set; }
            public int userid { get; set; }
            public string billtime { get; set; }
            public bool posted { get; set; }
            public int firm { get; set; }
            public DateTime ddate { get; set; }
            public string p_type { get; set; }
            public int cardid { get; set; }
            public int ac_code { get; set; }
            public string pname { get; set; }
            public string bs_date { get; set; }
            public string username { get; set; }
        }
    }
}
