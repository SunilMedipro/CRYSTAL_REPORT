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
    internal class DischargeSheetReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\IpdSectionReports\DischargeSheetReportRpt.rpt";


        public static void DischargeSheetReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode, string firm)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

            var response = client.GetAsync(baseUrl + "/api/DischargeSheetReport/Select?init=" + initdate.ToString() + "&final=" + finaldate.ToString()
                + "&firm=" + firm.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<DischargeSheetReport_dt>>(responseString);

                cryRpt.SetDataSource(test); // from api


                CrystalRerportDocument = cryRpt;

                cryRpt = CrystalRerportDocument;

              

            }

        }


        public class DischargeSheetReport_dt
        {
            public DateTime ddate { get; set; }
            public string inv_no { get; set; }
            public int ipdno { get; set; }
            public int refid { get; set; }
            public DateTime admit_date { get; set; }
            public DateTime discharge_date { get; set; }
            public int userid { get; set; }
            public int firm { get; set; }
            public string fy { get; set; }
            public string billtime { get; set; }
            public string note1 { get; set; }
            public string note2 { get; set; }
            public string note3 { get; set; }
            public string note4 { get; set; }
            public string note5 { get; set; }
            public string note6 { get; set; }
            public string note7 { get; set; }
            public string note8 { get; set; }
            public string note9 { get; set; }
            public string note10 { get; set; }
            public string operation { get; set; }
            public DateTime operation_date { get; set; }
            public string note11 { get; set; }
            public string note12 { get; set; }
            public string note13 { get; set; }
            public string note14 { get; set; }
            public string note15 { get; set; }
            public string note16 { get; set; }
            public string note17 { get; set; }
            public string note18 { get; set; }
            public string note19 { get; set; }
            public int consid { get; set; }
            public DateTime cons_date { get; set; }
            public int mediid { get; set; }
            public DateTime medi_date { get; set; }
            public int consid1 { get; set; }
            public DateTime cons_date1 { get; set; }
            public string icdcode { get; set; }
            public int hospid { get; set; }
            public string pname { get; set; }
            public string address { get; set; }
            public string bedno { get; set; }
            public int ageday { get; set; }
            public string telephone { get; set; }
            public string bs_date { get; set; }
            public string sex { get; set; }
            public DateTime dob { get; set; }
            public bool member { get; set; }
            public DateTime ad_discharge_date { get; set; }
            public string bs_discharge_date { get; set; }
            public DateTime ad_admit_date { get; set; }
            public string contact { get; set; }
            public string dischargeno { get; set; }
            public string bs_admit_date { get; set; }
            public string referer { get; set; }
            public string username { get; set; }
            public string consultant { get; set; }
            public string cons_nmc { get; set; }
            public string cons_bs_date { get; set; }
            public string medical { get; set; }
            public string medi_nmc { get; set; }
            public string medi_bs_date { get; set; }
            public string consultant1 { get; set; }
            public string cons_nmc1 { get; set; }
            public string cons_bs_date1 { get; set; }
        }
    }
}
