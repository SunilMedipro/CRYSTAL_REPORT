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
    internal class DivisionPreviewReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\Catalogue\DivisionPreviewRpt.rpt";


        public static void DivisionPreviewReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode, string dp_id)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

                    var response = client.GetAsync(baseUrl + "/api/Division/Report?dp_id=" + dp_id.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<DivisionPreviewReport_dt>>(responseString);

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


        public class DivisionPreviewReport_dt
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
            public string appointment_endtime { get; set; }
            public int hospital_code { get; set; }
            public int appointment_limit { get; set; }
            public bool appointment { get; set; }
            public bool su { get; set; }
            public bool mo { get; set; }
            public bool tu { get; set; }
            public bool we { get; set; }
            public bool th { get; set; }
            public bool fr { get; set; }
            public bool sa { get; set; }
            public string particular { get; set; }
            public string technical { get; set; }
            public string discount { get; set; }
        }
    }
}
