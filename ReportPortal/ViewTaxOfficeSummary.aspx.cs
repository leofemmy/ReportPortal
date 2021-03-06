﻿using ReportPortal.Reports;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class ViewTaxOfficeSummary : System.Web.UI.Page
    {
        SessionManager sessions = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (sessions.MerchantCode == null)
            {
                Response.Redirect("~/login.aspx");

            }
            calReport();
        }
        void calReport()
        {

            var varyear = Session["Fromyear"].ToString();
            var varto = Session["Toyear"].ToString();
            var vtype = Session["Type"].ToString();

            if (vtype == "1")
            {
                XtraRepTaxOfficeSummary2 obj_Rpt = new XtraRepTaxOfficeSummary2();

                SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

                string strquery = String.Format("SELECT RevenueOfficeName,COALESCE(SUM(TaxPayable),0) Assessment, COALESCE(SUM(PaymentAmount),0) Payment FROM dbo.ViewPayerLedger WHERE AssessmentYear BETWEEN {0} AND {1} GROUP BY RevenueOfficeName ORDER BY RevenueOfficeName asc ", varyear, varto);

                using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString))
                {
                    connect.Open();
                    _command = new SqlCommand(strquery, connect) { CommandType = CommandType.Text };
                    _command.CommandTimeout = 0;
                    responses.Clear();
                    _adp = new SqlDataAdapter(_command);
                    _adp.Fill(responses);

                    connect.Close();

                }

                if (responses.Tables[0] != null && responses.Tables[0].Rows.Count > 0)
                {
                    // obj_Rpt.xrLabel10.Text = string.Format("From {0:dd/MM/yyyy}  To {1:dd/MM/yyyy}", strat, end);
                    obj_Rpt.xrLabel3.Text = string.Format("From: {0}  To: {1}", Session["Fromyear"].ToString(), Session["Toyear"].ToString());
                    obj_Rpt.Report.DataSource = responses;
                    obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                    ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
                }
            }
            if (vtype == "2")
            {
                XtraRepTaxOfficeSummary obj_Rpt = new XtraRepTaxOfficeSummary();

                SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

                string strquery = String.Format("SELECT AssessmentYear,RevenueOfficeName,COALESCE(SUM(TaxPayable),0) Assessment, COALESCE(SUM(PaymentAmount),0) Payment FROM dbo.ViewPayerLedger WHERE AssessmentYear BETWEEN {0} AND {1} GROUP BY AssessmentYear,RevenueOfficeName ORDER BY RevenueOfficeName asc", varyear, varto);

                using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString))
                {
                    connect.Open();
                    _command = new SqlCommand(strquery, connect) { CommandType = CommandType.Text };
                    _command.CommandTimeout = 0;
                    responses.Clear();
                    _adp = new SqlDataAdapter(_command);
                    _adp.Fill(responses);

                    connect.Close();

                }

                if (responses.Tables[0] != null && responses.Tables[0].Rows.Count > 1)
                {
                    // obj_Rpt.xrLabel10.Text = string.Format("From {0:dd/MM/yyyy}  To {1:dd/MM/yyyy}", strat, end);
                    obj_Rpt.xrLabel3.Text = string.Format("From: {0}  To: {1}", Session["Fromyear"].ToString(), Session["Toyear"].ToString());
                    obj_Rpt.Report.DataSource = responses;
                    obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                    ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
                }
            }


            //var cachedReportSource = new CachedReportSourceWeb(new XtraRepPayment());

        }
        [System.Web.Services.WebMethod]
        public static void loadchildreport(string strRevnuename)
        {
            ViewTaxOfficeSummary vp = new ViewTaxOfficeSummary();

            var revenenuename = strRevnuename;

            vp.callReport2(revenenuename);


        }

        void callReport2(string revenuename)
        {
            Session["Revenuename"] = revenuename;


        }
    }
}