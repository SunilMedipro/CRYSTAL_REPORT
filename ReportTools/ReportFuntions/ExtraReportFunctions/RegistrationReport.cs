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
    internal class RegistrationReport
    {
        public static ReportDocument CrystalRerportDocument;

        public static string ReportFileName = @"Reports\ExtraReports\Registrationrpt.rpt";


        public static void RegReportCall(string baseUrl, ReportDocument cryRpt,
            DateTime initdate, DateTime finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode,int firm)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

            var response = client.GetAsync(baseUrl + "api/ReportSection/RegistrationReportSelect?init=" + initdate.ToString() + "&final=" + finaldate.ToString() + "&type=all" + "&userid=" + userid).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<RegSelect_dt>>(responseString);

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

                //cryRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, null    , false, reportname); // for pdf

            }

        }


        public class RegSelect_dt
        {
            public int sn { get; set; }
            public string bs_date { get; set; }
            public DateTime ddate { get; set; }
            public string inv_no { get; set; }
            public int hospid { get; set; }
            public string pname { get; set; }
            public int age { get; set; }
            public string sex { get; set; }
            public string servname { get; set; }
            public string referer { get; set; }
            public string consultant { get; set; }
            public double amount { get; set; }
            public bool new1 { get; set; }
            public bool old { get; set; }
            public bool er { get; set; }
            public bool insurance { get; set; }
            public bool member { get; set; }
            public string p_type { get; set; }
            public string billmode { get; set; }
        }
    }
}
