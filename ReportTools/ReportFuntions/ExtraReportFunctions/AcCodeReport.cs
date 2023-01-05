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
    internal class AcCodeReport
    {
        public static ReportDocument CrystalRerportDocument;

        public static string ReportFileName = @"Reports\ExtraReports\CrystalReport1.rpt";


        public static void AcCodeReportCall(string baseUrl, ReportDocument cryRpt,
            DateTime initdate, DateTime finaldate, string ADATE, string BDATE, string from_date,
            string company1, string address1, string userid, int paymode,int firm)
        {
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseUrl + "api/salesRegisterOpdBillGetbyDate?initdate=" + 
            //  initdate+ "&finaldate="+finaldate+"&userid="+userid+"&paymode="+paymode).Result;

            var response = client.GetAsync(baseUrl + "api/AccodeSelectAllbyfirm?firm="+firm.ToString() ).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode == true)
            {
                var test = JsonConvert.DeserializeObject<List<accode_dt>>(responseString);

                cryRpt.SetDataSource(test); // from api


                CrystalRerportDocument = cryRpt;

                cryRpt = CrystalRerportDocument;

                //TextObject final = (TextObject)cryRpt.ReportDefinition.Sections[0].ReportObjects["from_date"] as TextObject;
                //final.Text = from_date;

                //TextObject adate = (TextObject)cryRpt.ReportDefinition.Sections[0].ReportObjects["adate"] as TextObject;
                //adate.Text = ADATE;

                //TextObject bdate = (TextObject)cryRpt.ReportDefinition.Sections[0].ReportObjects["bdate"] as TextObject;
                //bdate.Text = BDATE;

                //TextObject company = (TextObject)cryRpt.ReportDefinition.Sections[0].ReportObjects["company1"] as TextObject;
                //company.Text = company1;

                //TextObject address = (TextObject)cryRpt.ReportDefinition.Sections[0].ReportObjects["address"] as TextObject;
                //address.Text = address1;

                //cryRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, null    , false, reportname); // for pdf

            }

        }


        public class accode_dt
        {
            public string sbname { get; set; }
            public bool details { get; set; }
            //public double depriciation { get; set; }
            public int snsb { get; set; }
            public string grname { get; set; }
            public string ac_type { get; set; }
            public int sngr { get; set; }
            public int snac { get; set; }
            public string billmodee { get; set; }
            public string groupname { get; set; }
            public string groups { get; set; }
            public string groupdetail { get; set; }
            public string grdetail { get; set; }
            public bool sbdetail { get; set; }
            public int ac_code { get; set; }
            public string ref_code { get; set; }
            public int gr_code { get; set; }
            public int sb_code { get; set; }
            public int firm { get; set; }
            public string particular { get; set; }
            public string c_person { get; set; }
            public string reg_no { get; set; }
            public string address { get; set; }
            public string telephone { get; set; }
            public double cr_limit { get; set; }
            public int sect_code { get; set; }
            public bool locked { get; set; }
            public bool withheld { get; set; }
            public bool FIXED { get; set; }
            public bool boss { get; set; }
            public int cr_days { get; set; }
            public int tds_code { get; set; }
            public int dep_code { get; set; }
            public int main_code { get; set; }
            public int serial { get; set; }
            public string inactive { get; set; }
            public int dp_id { get; set; }
            public double tds { get; set; }
            public double disc { get; set; }
            public int bank_code { get; set; }
            public string bankno { get; set; }
            public string paymode { get; set; }
            public string u_category { get; set; }
            public int category { get; set; }
            public bool debtor { get; set; }
            public bool supplier { get; set; }
            public string shortname { get; set; }
            public bool bank { get; set; }
            public bool crcard { get; set; }
            public DateTime print_date { get; set; }
            public int term { get; set; }
            public string mobileno { get; set; }
            public int pan { get; set; }
            public string dda { get; set; }
            public string ncda { get; set; }
            public bool subledger { get; set; }
            public string email { get; set; }
            public string email1 { get; set; }
            public string mobile1 { get; set; }
            public int sect_code1 { get; set; }
        }
    }
}
