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
    internal class GeneralHealthScreenReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\GeneralHealthScreenReportRpt.rpt";


        public static void GeneralHealthScreenReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

                   var response = client.GetAsync(baseUrl + "/api/ReportSection/GeneralHealthScreenReprotSelect?init=" + initdate.ToString() + "&final=" + finaldate.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<GeneralHealthScreenReport_dt>>(responseString);

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


        public class GeneralHealthScreenReport_dt
        {
            public string sn { get; set; }
            public string inv_no { get; set; }
            public string fy { get; set; }
            public int firm { get; set; }
            public string past_history { get; set; }
            public string tb { get; set; }
            public string diabetes { get; set; }
            public string allergy { get; set; }
            public string height { get; set; }
            public string weight { get; set; }
            public string pulse { get; set; }
            public string temp { get; set; }
            public string bp { get; set; }
            public int userid { get; set; }
            public string billtime { get; set; }
            public DateTime ddate { get; set; }
            public string note2 { get; set; }
            public string bmi { get; set; }
            public string pname { get; set; }
            public string bs_date { get; set; }
        }
    }
}
