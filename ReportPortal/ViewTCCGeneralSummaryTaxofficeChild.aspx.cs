﻿using ReportPortal.Reports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportPortal
{
    public partial class ViewTCCGeneralSummaryTaxofficeChild : System.Web.UI.Page
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

            var varofficename = Session["RevenueOfficename"].ToString();

            var vryearfrom = Session["yearFrom"].ToString();

            var vryearto = Session["yearTo"].ToString();

            XtraRepTCCGeneralSummaryTaxofficeChild obj_Rpt = new XtraRepTCCGeneralSummaryTaxofficeChild();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT RevenueOfficeName,PayerName, Utin, SUM(Income) Income, SUM(Paid) Paid FROM dbo.ViewTccDetails WHERE TaxYear BETWEEN {0} AND {1} AND RevenueOfficeName='{2}' GROUP BY RevenueOfficeName,PayerName,  Utin ORDER BY PayerName ASC", vryearfrom, vryearto, varofficename);

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
                obj_Rpt.xrLabel11.Text = string.Format("From {0} to {1}", vryearfrom, vryearto);
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }

        }
    }
}