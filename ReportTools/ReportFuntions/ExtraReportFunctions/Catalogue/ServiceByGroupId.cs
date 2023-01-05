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
    internal class ServiceListByGrpIdReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\Catalogue\ServiceByGroupIdRpt.rpt";


        public static void ServiceListByGrpIdReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode, string grpid)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

                    var response = client.GetAsync(baseUrl + "/api/Servegroup/Report?grpid=" + grpid.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<ServiceListByGrpIdReport_dt>>(responseString);

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


        public class ServiceListByGrpIdReport_dt
        {
            public string groupname { get; set; }
            public int grpid { get; set; }
            public int servid { get; set; }
            public string servname { get; set; }
            public double ratea { get; set; }
            public float rateb { get; set; }
            public float ratec { get; set; }
            public double vat { get; set; }
            public bool vatincl { get; set; }
            public bool drpc { get; set; }
            public bool tds { get; set; }
            public float disc { get; set; }
            public bool patho { get; set; }
            public bool panel { get; set; }
            public string status { get; set; }
            public int wardmin { get; set; }
            public int icumin { get; set; }
            public int opdmin { get; set; }
            public int postmin { get; set; }
            public int serial { get; set; }
            public bool formatted { get; set; }
            public int lines { get; set; }
            public string method { get; set; }
            public string remarks { get; set; }
            public int sdid { get; set; }
            public float pc { get; set; }
            public int cons_code { get; set; }
            public int md_code { get; set; }
            public double process { get; set; }
            public int gpid { get; set; }
            public string roomno { get; set; }
            public int userid { get; set; }
            public int refid { get; set; }
            public int groupid { get; set; }
            public string footnote { get; set; }
            public string samplesource { get; set; }
            public int samplesoure { get; set; }
            public string ref_code { get; set; }
            public bool registration { get; set; }
            public bool newmember { get; set; }
            public int external_code { get; set; }
            public double less_share_pc { get; set; }
            public bool er { get; set; }
            public double insurance_rate { get; set; }
            public bool insurance { get; set; }
            public bool echs { get; set; }
            public bool imageupload { get; set; }
            public string machinname { get; set; }
            public bool test_panel { get; set; }
            public string ssf_code { get; set; }
            public bool nightcharge { get; set; }
            public string lab_code { get; set; }
            public bool template { get; set; }
            public double echs_rate { get; set; }
        }
    }
}
