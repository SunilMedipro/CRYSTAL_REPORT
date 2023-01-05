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
    internal class OpdServiceCashDetailReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\OpdServiceCashDetailRpt.rpt";


        public static void OpdServiceCashDetailReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

            var response = client.GetAsync(baseUrl + "/api/ReportSection/OpdServiceCashDetailSelect?userid=" + userid.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<OpdServiceCashDetail_dt>>(responseString);

                cryRpt.SetDataSource(test); // from api


                CrystalRerportDocument = cryRpt;

                cryRpt = CrystalRerportDocument;
                TextObject final = (TextObject)cryRpt.ReportDefinition.Sections[0].ReportObjects["from_date"] as TextObject;
                final.Text = from_date;

                TextObject adate = (TextObject)cryRpt.ReportDefinition.Sections[0].ReportObjects["adate"] as TextObject;
                adate.Text = ADATE;

                TextObject bdate = (TextObject)cryRpt.ReportDefinition.Sections[0].ReportObjects["bdate"] as TextObject;
                bdate.Text = BDATE;

                TextObject company = (TextObject)cryRpt.ReportDefinition.Sections[0].ReportObjects["company1"] as TextObject;
                company.Text = company1;

                TextObject address = (TextObject)cryRpt.ReportDefinition.Sections[0].ReportObjects["address"] as TextObject;
                address.Text = address1;


            }

        }


        public class OpdServiceCashDetail_dt
        {
            public int sn { get; set; }
            public int dp_id { get; set; }
            public string division { get; set; }
            public bool detail { get; set; }
            public int grpid { get; set; }
            public string groupname { get; set; }
            public int hosqty { get; set; }
            public int qty { get; set; }
            public double amt { get; set; }
            public double cashpaid { get; set; }
            public double dueamt { get; set; }
            public double duepaid { get; set; }
            public double cash { get; set; }
        }
    }
}
