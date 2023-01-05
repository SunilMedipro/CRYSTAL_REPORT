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
    internal class ServiceGroupWiseAnalysisReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\ServiceGroupWiseAnalysisRpt.rpt";


        public static void ServiceGroupWiseAnalysisReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode, string ipd, string opd, string wardno, string dp_id, string er, string orgid)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;
            // ipd = 0 & opd = 0 & wardno = 0 & dp_id = 0 & er = false & orgid = 0
                   var response = client.GetAsync(baseUrl + "/api/ReportSection/ServiceGroupwiseAnalysisGet?init=" + initdate.ToString() + "&final=" + finaldate.ToString()
              + "&ipd=" + ipd.ToString() + "&opd=" + opd.ToString() + "&wardno=" + wardno.ToString() + "&dp_id=" + dp_id.ToString() + "&er=" + er.ToString() + "&orgid=" + orgid.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<ServiceGroupWiseAnalysis_dt>>(responseString);

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


        public class ServiceGroupWiseAnalysis_dt
        {
            public int grpid { get; set; }
            public string groupname { get; set; }
            public int cnt { get; set; }
            public double amount { get; set; }
            public double discount { get; set; }
            public double net { get; set; }
            public double vatamt { get; set; }
            public double total { get; set; }
        }
    }
}
