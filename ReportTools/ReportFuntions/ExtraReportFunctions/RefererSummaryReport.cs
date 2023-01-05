﻿using CrystalDecisions.CrystalReports.Engine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReportTools.ReportFuntions.ExtraReportFunctions
{
    internal class RefererSummaryReport 
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\RefererSummaryRpt.rpt";


        public static void RefererSummaryReportCall(string baseUrl, ReportDocument cryRpt,
            DateTime initdate, DateTime finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode,string firm, string refid)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

            var response = client.GetAsync(baseUrl + "/api/RefererSummary?init=" + initdate.ToString() + "&final=" + 
                finaldate.ToString() 
                +"&refid="+ refid.ToString()
                +"&firm="+ firm.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<RefererSummary_dt>>(responseString);

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


        public class RefererSummary_dt
        {
            public string inv_no { get; set; }
            public double amount { get; set; }
            public int qty { get; set; }
            public double discount { get; set; }
            public double vat { get; set; }
            public string referer { get; set; }
            public string bs_date { get; set; }
            public DateTime ddate { get; set; }
            public string pname { get; set; }
            public string servname { get; set; }
        }
    }
}
