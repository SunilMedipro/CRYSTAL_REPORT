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
    internal class MemberOrganizationReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\Catalogue\MemberOrganizationRpt.rpt";


        public static void MemberOrganizationReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

                    var response = client.GetAsync(baseUrl + "/api/Organiz/select").Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<MemberOrganizationReport_dt>>(responseString);

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


        public class MemberOrganizationReport_dt
        {
            public int orgid { get; set; }
            public string orgname { get; set; }
            public string address { get; set; }
            public string telephone { get; set; }
            public string fax { get; set; }
            public string email { get; set; }
            public string contact { get; set; }
            public bool locked { get; set; }
            public DateTime exp_date { get; set; }
            public int ac_code { get; set; }
            public string discount { get; set; }
            public string p_type { get; set; }
            public string org_type { get; set; }
            public double pharma_disc1 { get; set; }
            public double pharma_disc2 { get; set; }
            public bool insurance { get; set; }
            public string ref_code { get; set; }
            public bool insurance_product { get; set; }
            public bool ssf_member { get; set; }
            public string particular { get; set; }
        }
    }
}
