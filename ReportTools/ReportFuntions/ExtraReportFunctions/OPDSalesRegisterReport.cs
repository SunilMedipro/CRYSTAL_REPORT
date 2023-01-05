using CrystalDecisions.CrystalReports.Engine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ReportTools.ReportFuntions.ExtraReportFunctions
{
    public static class OPDSalesRegisterReport
    {
        public static ReportDocument CrystalRerportDocument;

        public static string ReportFileName =@"Reports\ExtraReports\OPDSalesRegisterrpt.rpt" ;


        public static void OPDSalesRegisterReportCall(string baseUrl, ReportDocument cryRpt,  
            DateTime initdate, DateTime finaldate, string ADATE, string BDATE, string from_date, 
            string company1, string address1, string userid, int paymode, string firm )
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

            var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?init="+initdate+"&final="+finaldate+"&firm="+firm+"&ipdsave=1&ipd=2&val=1&refid=0&initbilltime=0&finalbilltime=0&er=0&discount=0&canceled=0&insurance=0&salesbill=0&returnbill=0&paymode=0&billmode=0&morbidity=0&userid=1").Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<OPDSalesRegisterReport_dt>>(responseString);

                cryRpt.SetDataSource(test); // from api
                

                CrystalRerportDocument = cryRpt;

                cryRpt = OPDSalesRegisterReport.CrystalRerportDocument;

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


    }


    public class OPDSalesRegisterReport_dt
    {
        public string note1 { get; set; }
        public string note2 { get; set; }
        public int refid { get; set; }
        public string username { get; set; }
        public bool insurance { get; set; }
        public bool canceled { get; set; }
        public string note { get; set; }
        public int hospid { get; set; }
        public string bs_date { get; set; }
        public DateTime ddate { get; set; }
        public string inv_no { get; set; }
        public string pname { get; set; }
        public string address { get; set; }
        public string telephone { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
        public double amount { get; set; }
        public double discount { get; set; }
        public double vat { get; set; }
        public double roundoff { get; set; }
        public double net { get; set; }
        public bool ipd { get; set; }
        public bool reg { get; set; }
        public string lcdcode { get; set; }
        public string referer { get; set; }
        public string appby { get; set; }
        public string reqby { get; set; }
        public string telno { get; set; }
        public string consultant { get; set; }
        public double taxable { get; set; }
        public double nontaxable { get; set; }
        public string patient_type { get; set; }
        public string branch_center { get; set; }
        public double disc_pc { get; set; }
    }
}