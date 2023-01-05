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
    internal class DischargeReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\IpdSectionReports\DischargeReportRpt.rpt";


        public static void DischargeReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode, string firm, string discharge_type)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

            var response = client.GetAsync(baseUrl + "api/DischargeReport/Select?init=" + initdate.ToString() + "&final=" + finaldate.ToString()
                + "&firm=" + firm.ToString() + "&discharge_type=" + discharge_type.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<DischargeReport_dt>>(responseString);

                cryRpt.SetDataSource(test); // from api


                CrystalRerportDocument = cryRpt;

                cryRpt = CrystalRerportDocument;

              

            }

        }


        public class DischargeReport_dt
        {
            public string dischargeno { get; set; }
            public DateTime ddate { get; set; }
            public int ipdno { get; set; }
            public int ac_code { get; set; }
            public int firm { get; set; }
            public int userid { get; set; }
            public double amount { get; set; }
            public double paid { get; set; }
            public double deposit { get; set; }
            public double tender { get; set; }
            public bool member { get; set; }
            public string p_type { get; set; }
            public string billtime { get; set; }
            public int refid { get; set; }
            public string fy { get; set; }
            public bool posted { get; set; }
            public bool canceled { get; set; }
            public string remarks { get; set; }
            public string refund_no { get; set; }
            public string discharge_type { get; set; }
            public double discount { get; set; }
            public double paid_amount { get; set; }
            public double ledgerpc { get; set; }
            public double insurance_amount { get; set; }
            public double insurance_due_amount { get; set; }
            public bool insurance { get; set; }
            public bool ssf { get; set; }
            public int cardid { get; set; }
            public string bs_date { get; set; }
            public string pname { get; set; }
            public double net { get; set; }
            public double due { get; set; }
            public DateTime admit_date { get; set; }
            public string bs_admit_date { get; set; }
            public int days { get; set; }
            public string icdcode { get; set; }
        }
    }
}
