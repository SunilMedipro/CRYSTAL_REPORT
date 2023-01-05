using CrystalDecisions.CrystalReports.Engine;
using ReportTools.Funtions.ExtraFuntions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string baseUrl = System.Configuration.ConfigurationManager.AppSettings["baseUrl"];

            string reportname = "memberorganizationreport"; // Request.QueryString["reportname"];

            string userid = "1" ; //Request.QueryString["userid"];
            string username = "" ; //Request.QueryString["username"];
            string password = "" ; //Request.QueryString["password"];
            string token = "" ; //Request.QueryString["token"];

            string report_code = "" ;
            //Request.QueryString["report_code"];

            // var "" ; //RequestTag = "" ; //Request.Headers[""" ; //RequestTag"];




            string init = "2021/12/16"; //Request.QueryString["init"];
            string final = "2022/12/23"; //Request.QueryString["final"];
            string adate = "2022-09-01"; //Request.QueryString["adate"];
            string bdate = "2022-11-29"; //Request.QueryString["bdate"];
            string firm = "1" ; //Request.QueryString["firm"];
            string inv_no = "" ; //Request.QueryString["inv_no"];
            string company = "BlueCross Hospital" ; //Request.QueryString["company"];
            string address = "Thapathali. Kathmandu" ; //Request.QueryString["address"];
            string pan = "" ; //Request.QueryString["pan"];
            string pt_code = "" ; //Request.QueryString["pt_code"];
            string caption = "" ; //Request.QueryString["caption"];
            string from_date = "2022-11-29"; //Request.QueryString["from_date"];

            string email_to = "" ; //Request.QueryString["email_to"];
            string email_cc = "" ; //Request.QueryString["email_cc"];
            string email_subject = "" ; //Request.QueryString["email_subject"];
            string email_body = "" ; //Request.QueryString["email_body"];

               
            string refid= "527"; //Request.QueryString["param1"];
            string ipd = "2" ; //Request.QueryString["param2"];
            string val = "1" ; //Request.QueryString["param3"];
            string insurance = "2" ; //Request.QueryString["param4"];
            string search = "a" ; //Request.QueryString["param5"];
            string hospid = "0"; //Request.QueryString["param6"];
            string orgid = "0" ; //Request.QueryString["param7"];
            string dptid = "0" ; //Request.QueryString["param8"];
            string grpid = "101"; //Request.QueryString["param9"];
            string due = "all" ; //Request.QueryString["param10"];
            string scheme = "0" ; //Request.QueryString["param11"];
            string odp = "0"; //Request.QueryString["param12"];
            string wardno = "0"; //Request.QueryString["param13"];
            string dp_id = "158"; //Request.QueryString["param14"];
            string er = "false"; //Request.QueryString["param15"];
            string discharge_type = "recovered"; //Request.QueryString["param16"];


       

            ReportDocument cryRpt = new ReportDocument();
            string path = @"C:\MEDICOM\ReportTools\ReportTools\" + ReportObjectLinksExtra.ReportFileName( reportname);
            //cryRpt
            cryRpt.Load( (path));


            ReportObjectLinksExtra.ReportObjectLinksExtraSetup(baseUrl, reportname, cryRpt

                , init
                , final
                , adate
                , bdate
                , firm
                , inv_no
                , company
                , address
                , pan
                , pt_code
                , caption
                , from_date


                , userid
                , username
                , password
                , token

                , email_to
                , email_cc
                , email_subject
                , email_body

                , refid
                , ipd
                , val
                , insurance
                , search
                , hospid
                , orgid
                , dptid
                , grpid
                , due
                , scheme
                ,odp
                ,wardno
                ,dp_id
                , er
                , discharge_type

                    );



            crystalReportViewer1.ReportSource = cryRpt;
            //CrystalReportViewer1.DataBind();
            crystalReportViewer1.ReuseParameterValuesOnRefresh = true;
            crystalReportViewer1.RefreshReport();



        }
    }
}
