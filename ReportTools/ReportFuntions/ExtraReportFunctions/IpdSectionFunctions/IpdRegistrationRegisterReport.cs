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
    internal class IpdRegistrationRegisterReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\IpdSectionReports\IpdRegistrationRegisterReportRpt.rpt";


        public static void IpdRegistrationRegisterReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

            var response = client.GetAsync(baseUrl + "/api/IpdRegistrationRegister/Select?init=" + initdate.ToString() + "&final=" + finaldate.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<IpdRegistrationRegisterReport_dt>>(responseString);

                cryRpt.SetDataSource(test); // from api


                CrystalRerportDocument = cryRpt;

                cryRpt = CrystalRerportDocument;

              

            }

        }


        public class IpdRegistrationRegisterReport_dt
        {
            public string ward { get; set; }
            public string bedno { get; set; }
            public DateTime ddate { get; set; }
            public int ipdno { get; set; }
            public int hospid { get; set; }
            public int fileno { get; set; }
            public string pname { get; set; }
            public string telephone { get; set; }
            public int refid { get; set; }
            public bool member { get; set; }
            public bool discharge { get; set; }
            public string referer { get; set; }
            public string bs_date { get; set; }
            public double deposit { get; set; }
        }
    }
}
