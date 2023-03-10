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
    internal class SalesSummaryReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\SalesSummaryRpt.rpt";


        public static void SalesSummaryReportCall(string baseUrl, ReportDocument cryRpt,
            DateTime initdate, DateTime finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode,int firm)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

            var response = client.GetAsync(baseUrl + "/api/salesSummaryOpdBillGet?init=" + initdate.ToString() + "&final=" + finaldate.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<SalesSummary_dt>>(responseString);

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


        public class SalesSummary_dt
        {
            public DateTime ddate { get; set; }
            public string bs_date { get; set; }
            public string firstinv { get; set; }
            public string lastinv { get; set; }
            public int totinv { get; set; }
            public double totalamount { get; set; }
            public double totaldiscount { get; set; }
            public double taxable { get; set; }
            public double totvat { get; set; }
            public double roundoff { get; set; }
            public double net { get; set; }
        }
    }
}
