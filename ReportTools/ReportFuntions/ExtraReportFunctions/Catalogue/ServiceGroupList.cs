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
    internal class ServiceGroupListReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\Catalogue\ServiceGroupListRpt.rpt";


        public static void ServiceGroupListReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

                    var response = client.GetAsync(baseUrl + "/api/servGroupGet" ).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<ServiceGroupListReport_dt>>(responseString);

                cryRpt.SetDataSource(test); // from api


                CrystalRerportDocument = cryRpt;

                cryRpt = CrystalRerportDocument;

              

            }

        }


        public class ServiceGroupListReport_dt
        {
            public int grpid { get; set; }
            public string groupname { get; set; }
            public int ac_code { get; set; }
            public double disc { get; set; }
            public int tech_code { get; set; }
            public int disc_code { get; set; }
            public double amt { get; set; }
            public double pc { get; set; }
            public bool gross { get; set; }
            public int plid { get; set; }
            public int serial { get; set; }
            public int dp_id { get; set; }
            public bool opddepart { get; set; }
            public bool referer { get; set; }
            public bool report { get; set; }
            public string reporttitle { get; set; }
            public string particular { get; set; }
            public string technical { get; set; }
            public string discount { get; set; }
            public string division { get; set; }
        }
    }
}
