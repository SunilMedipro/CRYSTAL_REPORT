using CrystalDecisions.CrystalReports.Engine;
using ReportTools.ReportFuntions.ExtraReportFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace ReportTools.Funtions.ExtraFuntions
{
    class ReportObjectLinksExtra
    { 
        public static ReportDocument CrystalRerportDocument;

        public static string ReportFileName(string reportname)
        {
            string result = "";

    

            if (reportname == "opdsalesregister")
            {
                result = OPDSalesRegisterReport.ReportFileName;
            }


            if (reportname == "accodelist")
            {
                result = AcCodeReport.ReportFileName;
            }


            if (reportname == "divisionlist")
            {
                result = DivisionReport.ReportFileName;
            }
            if (reportname == "registrationreport")
            {
                result = RegistrationReport.ReportFileName;
            }

            if (reportname == "salessummary")
            {
                result = SalesSummaryReport.ReportFileName;
            }

            if (reportname == "referersummary")
            {
                result = RefererSummaryReport.ReportFileName;
            }
            if (reportname == "refereranalysis")
            {
                result = RefererAnalysisReport.ReportFileName;
            }
            if (reportname == "patienthistory")
            {
                result = PatientHistoryReport.ReportFileName;
            }

            //start of organization member section
            if (reportname == "organizationstatementsummary")
            {
                result = OrganizationStatementSummaryReport.ReportFileName;
            }
            if (reportname == "organizationdepartmentsummary")
            {
                result = OrganizationDepartmentSummaryReport.ReportFileName;
            }
            if (reportname == "organizationmemberstatement")
            {
                result = OrganizationMemberStatementReport.ReportFileName;
            }
            if (reportname == "memberstatement")
            {
                result = MemberStatementReport.ReportFileName;
            }
            if (reportname == "servicecenterreport")
            {
                result = ServiceCenterReport.ReportFileName;
            }
            //end of organization member section

            if (reportname == "generalhealthscreenreport")
            {
                result = GeneralHealthScreenReport.ReportFileName;
            }
            if (reportname == "membersalesregister")
            {
                result = MemberSalesRegisterReport.ReportFileName;
            }
            if (reportname == "cashregistersummary")
            {
                result = CashRegisterSummaryReport.ReportFileName;
            }
            if (reportname == "discountreport")
            {
                result = DiscountReport.ReportFileName;
            }
            if (reportname == "servicegroupwiseanalysis")
            {
                result = ServiceGroupWiseAnalysisReport.ReportFileName;
            }
            if (reportname == "opdservicecashdetail")
            {
                result = OpdServiceCashDetailReport.ReportFileName;
            }
            if (reportname == "patientrecord")
            {
                result = PatientRecordReport.ReportFileName;
            }
            //end of report section
            //start of ipd section
            if (reportname == "deathcertificatereport")
            {
                result = DeathCertificateReport.ReportFileName;
            }
            if (reportname == "ipdregistrationregisterreport")
            {
                result = IpdRegistrationRegisterReport.ReportFileName;
            }
            if (reportname == "depositreport")
            {
                result = DepositReport.ReportFileName;
            }
            if (reportname == "depositrefundreport")
            {
                result = DepositRefundReport.ReportFileName;
            }
            if (reportname == "ipdtrial")
            {
                result = IpdTrialReport.ReportFileName;
            }
            if (reportname == "dischargesheetreport")
            {
                result = DischargeSheetReport.ReportFileName;
            }
            if (reportname == "dischargereport")
            {
                result = DischargeReport.ReportFileName;
            }
            if (reportname == "bedtransactionreport")
            {
                result = BedTransactionReport.ReportFileName;
            }
            //end of ipd section

            //catalogue
            if (reportname == "servicegrouplistreport")
            {
                result = ServiceGroupListReport.ReportFileName;
            }
            if (reportname == "hospitalwardsetupreport")
            {
                result = HospitalWardSetupReport.ReportFileName;
            }
            if (reportname == "memberorganizationreport")
            {
                result = MemberOrganizationReport.ReportFileName;
            }
            if (reportname == "conultantclassreport")
            {
                result = ConsultantClassSetupReport.ReportFileName;
            }
            if (reportname == "specialityreport")
            {
                result = SpecialitySetupReport.ReportFileName;
            }
            if (reportname == "schemediscountexcelreport")
            {
                result = SchemeDiscountExcelReport.ReportFileName;
            }
            if (reportname == "divisionexcelreport")
            {
                result = DivisionExcelReport.ReportFileName;
            }
            if (reportname == "divisionpreviewreport")
            {
                result = DivisionPreviewReport.ReportFileName;
            }
            if (reportname == "servicelistbygrpidreport")
            {
                result = ServiceListByGrpIdReport.ReportFileName;
            }
            if (reportname == "servicepanelreport")
            {
                result = ServicePanelReport.ReportFileName;
            }
            if (reportname == "servicepanelinclusionreport")
            {
                result = ServicePanelInclusionReport.ReportFileName;
            }
            if (reportname == "addservicepanelreport")
            {
                result = AddServicePanelReport.ReportFileName;
            }
            return result;



        

        
           

            
        }


public static void ReportObjectLinksExtraSetup(string baseUrl, string reportname, ReportDocument cryRpt

        , string init
        , string final
        , string adate
        , string bdate
        , string firm
        , string inv_no
        , string company
        , string address
        , string pan
        , string pt_code
        , string caption
        , string from_date

        , string userid
        , string username
        , string password
        , string token

        , string email_to
        , string email_cc
        , string email_subject
        , string email_body

        , string refid
        , string ipd
        , string val
        , string insurance
        , string search
        , string hospid
        , string orgid
        , string dptid
        , string grpid
        , string due
        , string scheme
        , string opd
        , string wardno
        , string dp_id
        , string er
        , string discharge_type
            )
        {
    
            if (reportname == "opdsalesregister")
            {
                OPDSalesRegisterReport.OPDSalesRegisterReportCall(baseUrl, cryRpt,
                    Convert.ToDateTime(init), Convert.ToDateTime(final), adate, bdate,
                    from_date, company, address, userid, 0, firm);

                cryRpt = OPDSalesRegisterReport.CrystalRerportDocument;
            }
            if (reportname == "accodelist")
            {
                AcCodeReport.AcCodeReportCall(baseUrl, cryRpt,
                    Convert.ToDateTime(init), Convert.ToDateTime(final), adate, bdate,
                    from_date, company, address, userid, 0,0 );

                cryRpt = AcCodeReport.CrystalRerportDocument;
            }

            if (reportname == "divisionlist")
            {
                DivisionReport.DivisionReportCall(baseUrl, cryRpt,
                    Convert.ToDateTime(init), Convert.ToDateTime(final), adate, bdate,
                    from_date, company, address, userid, 0, 0);

                cryRpt = DivisionReport.CrystalRerportDocument;
            }

            if (reportname == "registrationreport")
            {
                RegistrationReport.RegReportCall(baseUrl, cryRpt,
                    Convert.ToDateTime(init), Convert.ToDateTime(final), adate, bdate,
                    from_date, company, address, userid, 0, 0);

                cryRpt = RegistrationReport.CrystalRerportDocument;
            }
            if (reportname == "salessummary")
            {
                SalesSummaryReport.SalesSummaryReportCall(baseUrl, cryRpt,
                    Convert.ToDateTime(init), Convert.ToDateTime(final), adate, bdate,
                    from_date, company, address, userid, 0, 0);

                cryRpt = SalesSummaryReport.CrystalRerportDocument;
            }


            if (reportname == "referersummary")
            {
                RefererSummaryReport.RefererSummaryReportCall(baseUrl, cryRpt,
                    Convert.ToDateTime(init), Convert.ToDateTime(final), adate, bdate,
                    from_date, company, address, userid , 0,firm ,refid);

                cryRpt = RefererSummaryReport.CrystalRerportDocument;
            }


            if (reportname == "refereranalysis")
            {
                RefererAnalysisReport.RefererAnalysisCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, firm, ipd,val,insurance);

                cryRpt = RefererAnalysisReport.CrystalRerportDocument;
            }
            if (reportname == "patienthistory")
            {
                PatientHistoryReport.PatientHistoryReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, firm, hospid);

                cryRpt = PatientHistoryReport.CrystalRerportDocument;
            }

            //start of organization member section
            if (reportname == "organizationstatementsummary")
            {
                OrganizationStatementSummaryReport.OrganizationStatementSummaryReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, orgid);

                cryRpt = OrganizationStatementSummaryReport.CrystalRerportDocument;
            }
            if (reportname == "organizationdepartmentsummary")
            {
                OrganizationDepartmentSummaryReport.OrganizationDepartmentSummaryReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, orgid, dptid);

                cryRpt = OrganizationDepartmentSummaryReport.CrystalRerportDocument;
            }
            if (reportname == "organizationmemberstatement")
            {
                OrganizationMemberStatementReport.OrganizationMemberStatementReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, orgid);

                cryRpt = OrganizationMemberStatementReport.CrystalRerportDocument;
            }
            if (reportname == "memberstatement")
            {
                MemberStatementReport.MemberStatementReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, hospid);

                cryRpt = MemberStatementReport.CrystalRerportDocument;
            }
            if (reportname == "servicecenterreport")
            {
                ServiceCenterReport.ServiceCenterReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, grpid);

                cryRpt = ServiceCenterReport.CrystalRerportDocument;
            }
            //end of organization member section

            if (reportname == "generalhealthscreenreport")
            {
                GeneralHealthScreenReport.GeneralHealthScreenReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0);

                cryRpt = GeneralHealthScreenReport.CrystalRerportDocument;
            }
            if (reportname == "membersalesregister")
            {
                MemberSalesRegisterReport.MemberSalesRegisterReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, firm);

                cryRpt = MemberSalesRegisterReport.CrystalRerportDocument;
            }
            if (reportname == "cashregistersummary")
            {
                CashRegisterSummaryReport.CashRegisterSummaryReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, firm, ipd, due, search);

                cryRpt = CashRegisterSummaryReport.CrystalRerportDocument;
            }
            if (reportname == "discountreport")
            {
                DiscountReport.DiscountReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, firm, scheme, hospid);

                cryRpt = DiscountReport.CrystalRerportDocument;
            }
            if (reportname == "servicegroupwiseanalysis")
            {
                ServiceGroupWiseAnalysisReport.ServiceGroupWiseAnalysisReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, ipd,opd,wardno,dp_id,er,orgid);

                cryRpt = ServiceGroupWiseAnalysisReport.CrystalRerportDocument;
            }
            if (reportname == "opdservicecashdetail")
            {
                OpdServiceCashDetailReport.OpdServiceCashDetailReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0);

                cryRpt = OpdServiceCashDetailReport.CrystalRerportDocument;
            }
            if (reportname == "patientrecord")
            {
                PatientRecordReport.PatientRecordReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, firm, hospid);

                cryRpt = PatientRecordReport.CrystalRerportDocument;
            }
            //end of reportsection

            //start of ipd section 
            if (reportname == "deathcertificatereport")
            {
                DeathCertificateReport.DeathCertificateReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, firm);

                cryRpt = DeathCertificateReport.CrystalRerportDocument;
            }
            if (reportname == "ipdregistrationregisterreport")
            {
                IpdRegistrationRegisterReport.IpdRegistrationRegisterReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0);

                cryRpt = IpdRegistrationRegisterReport.CrystalRerportDocument;
            }
            if (reportname == "depositreport")
            {
                DepositReport.DepositReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, firm);

                cryRpt = DepositReport.CrystalRerportDocument;
            }
            if (reportname == "depositrefundreport")
            {
                DepositRefundReport.DepositRefundReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, firm);

                cryRpt = DepositRefundReport.CrystalRerportDocument;
            }
            if (reportname == "ipdtrial")
            {
                IpdTrialReport.IpdTrialReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0);

                cryRpt = IpdTrialReport.CrystalRerportDocument;
            }
            if (reportname == "dischargesheetreport")
            {
                DischargeSheetReport.DischargeSheetReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, firm);

                cryRpt = DischargeSheetReport.CrystalRerportDocument;
            }
            if (reportname == "dischargereport")
            {
                DischargeReport.DischargeReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, firm, discharge_type);

                cryRpt = DischargeSheetReport.CrystalRerportDocument;
            }
            if (reportname == "bedtransactionreport")
            {
                BedTransactionReport.BedTransactionReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, ipd );

                cryRpt = BedTransactionReport.CrystalRerportDocument;
            }
            //end of ipd section

            //catalogue

            if (reportname == "servicegrouplistreport")
            {
                ServiceGroupListReport.ServiceGroupListReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0);

                cryRpt = ServiceGroupListReport.CrystalRerportDocument;
            }
            if (reportname == "hospitalwardsetupreport")
            {
                HospitalWardSetupReport.HospitalWardSetupReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0);

                cryRpt = HospitalWardSetupReport.CrystalRerportDocument;
            }
            if (reportname == "memberorganizationreport")
            {
                MemberOrganizationReport.MemberOrganizationReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0);

                cryRpt = MemberOrganizationReport.CrystalRerportDocument;
            }
            if (reportname == "conultantclassreport")
            {
                ConsultantClassSetupReport.ConsultantClassSetupReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0);

                cryRpt = ConsultantClassSetupReport.CrystalRerportDocument;
            }
            if (reportname == "specialityreport")
            {
                SpecialitySetupReport.SpecialitySetupReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0);

                cryRpt = SpecialitySetupReport.CrystalRerportDocument;
            }
            if (reportname == "schemediscountexcelreport")
            {
                SchemeDiscountExcelReport.SchemeDiscountExcelReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0);

                cryRpt = SchemeDiscountExcelReport.CrystalRerportDocument;
            }
            if (reportname == "divisionexcelreport")
            {
                DivisionExcelReport.DivisionExcelReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0);

                cryRpt = DivisionExcelReport.CrystalRerportDocument;
            }
            if (reportname == "divisionpreviewreport")
            {
                DivisionPreviewReport.DivisionPreviewReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, dp_id);

                cryRpt = DivisionPreviewReport.CrystalRerportDocument;
            }
            if (reportname == "servicelistbygrpidreport")
            {
                ServiceListByGrpIdReport.ServiceListByGrpIdReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0, grpid);

                cryRpt = ServiceListByGrpIdReport.CrystalRerportDocument;
            }
            if (reportname == "servicepanelreport")
            {
                ServicePanelReport.ServicePanelReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0);

                cryRpt = ServicePanelReport.CrystalRerportDocument;
            }
            if (reportname == "servicepanelinclusionreport")
            {
                ServicePanelInclusionReport.ServicePanelInclusionReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0);

                cryRpt = ServicePanelInclusionReport.CrystalRerportDocument;
            }
            if (reportname == "addservicepanelreport")
            {
                AddServicePanelReport.AddServicePanelReportCall(baseUrl, cryRpt,
                    init, final, adate, bdate,
                    from_date, company, address, userid, 0);

                cryRpt = AddServicePanelReport.CrystalRerportDocument;
            }

        }
    }
}
