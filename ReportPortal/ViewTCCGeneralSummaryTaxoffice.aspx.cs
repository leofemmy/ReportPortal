﻿using ReportPortal.Reports;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class ViewTCCGeneralSummaryTaxoffice : System.Web.UI.Page
    {
        SessionManager sessions = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //XtraRepTCCGeneralSummaryTaxoffice
            sessions = new SessionManager();

            if (sessions.MerchantCode == null)
            {
                Response.Redirect("~/login.aspx");

            }
            calReport();
        }

        void calReport()
        {
            var vryearfrom = Session["yearFrom"].ToString();

            var vryearto = Session["yearTo"].ToString();

            XtraRepTCCGeneralSummaryTaxoffice obj_Rpt = new XtraRepTCCGeneralSummaryTaxoffice();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT RevenueOfficeName,RevenueOfficeID ,COUNT(TaxYear) Reccount,SUM(Income) Income, SUM(Paid) Paid FROM dbo.ViewTccDetails  WHERE TaxYear BETWEEN {0} AND {1} GROUP BY RevenueOfficeName,RevenueOfficeID ORDER BY RevenueOfficeName asc", vryearfrom, vryearto);

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
                obj_Rpt.xrLabel11.Text = string.Format("From : {0} To: {1} ", vryearfrom, vryearto);
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }



        }

        [System.Web.Services.WebMethod]
        public static void loadchildreport(string Revenueoffice)
        {
            ViewTCCGeneralSummaryTaxoffice vp = new ViewTCCGeneralSummaryTaxoffice();

            var vartaxyear = Revenueoffice;

            vp.callReport2(vartaxyear);


        }

        void callReport2(string RevenueOfficename)
        {
            Session["RevenueOfficename"] = RevenueOfficename;


        }
    }
}