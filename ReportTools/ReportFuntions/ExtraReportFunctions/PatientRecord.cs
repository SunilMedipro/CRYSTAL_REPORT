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
    internal class PatientRecordReport
    {
        public static ReportDocument CrystalRerportDocument; 

        public static string ReportFileName = @"Reports\ExtraReports\PatientRecordRpt.rpt";


        public static void PatientRecordReportCall(string baseUrl, ReportDocument cryRpt,
            string initdate, string finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode, string firm, string hospid)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

                var response = client.GetAsync(baseUrl + "/api/ReportSection/PatientRecord/MemberOpdRecSelect?init=" + initdate.ToString() + "&final=" + finaldate.ToString()
              + "&firm=" + firm.ToString() + "&hospid=" + hospid.ToString()).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<PatientRecord_dt>>(responseString);

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


        public class PatientRecord_dt
        {
            public DateTime ddate { get; set; }
            public string bs_date { get; set; }
            public string inv_no { get; set; }
            public int servid { get; set; }
            public string servname { get; set; }
            public int qty { get; set; }
            public double rate { get; set; }
            public double disc { get; set; }
            public double net { get; set; }
            public int orgid { get; set; }
            public int hospid { get; set; }
            public int dptid { get; set; }
            public string pname { get; set; }
            public string contact { get; set; }
            public string address { get; set; }
            public string sex { get; set; }
            public string relation { get; set; }
            public string telephone { get; set; }
            public DateTime exp_date { get; set; }
            public bool credit { get; set; }
            public bool locked { get; set; }
            public bool withheld { get; set; }
            public double crlimit { get; set; }
            public string p_type { get; set; }
            public string m_type { get; set; }
            public int pid { get; set; }
            public DateTime dob { get; set; }
            public string remarks { get; set; }
            public bool member { get; set; }
            public int hospid1 { get; set; }
            public int firm { get; set; }
            public int ac_code { get; set; }
            public string payfrom { get; set; }
            public string martialstatus { get; set; }
            public string occupation { get; set; }
            public string email { get; set; }
            public int dis_id { get; set; }
            public string regno { get; set; }
            public int discount_id { get; set; }
            public int nagar_vdc_id { get; set; }
            public int ethinic_code { get; set; }
            public string wardno { get; set; }
            public int member_name_id { get; set; }
            public int army_type_id { get; set; }
            public int rank_id { get; set; }
            public int pension_id { get; set; }
            public int units_id { get; set; }
            public int relation_id { get; set; }
            public string soilder { get; set; }
            public DateTime date_discharge { get; set; }
            public DateTime enlisted_date { get; set; }
            public string policyid { get; set; }
            public string patient_type { get; set; }
            public string ref_code { get; set; }
            public int claim_code { get; set; }
            public bool print_card { get; set; }
            public DateTime print_date { get; set; }
            public double rem_balance { get; set; }
            public bool baby { get; set; }
            public bool ssf { get; set; }
            public string pcode { get; set; }
        }
    }
}
