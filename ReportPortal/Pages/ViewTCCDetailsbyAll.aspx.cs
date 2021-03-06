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
    public partial class ViewTCCDetailsbyAll : System.Web.UI.Page
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
            //var vastin = Session["UTIN"].ToString();
            var Fromyear = Session["Fromyear"].ToString(); var Toyear = Session["Toyear"].ToString();

            XtraRepTCCDetailsbyAll obj_Rpt = new XtraRepTCCDetailsbyAll();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT * FROM dbo.ViewTccDetails where TaxYear BETWEEN {0} AND {1} ORDER BY PayerName ASC, TaxYear ASC", Fromyear, Toyear);

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
                obj_Rpt.xrLabel3.Text = "Details By All";
                obj_Rpt.xrLabel10.Text = string.Format("from {0}  To: {1}", Fromyear, Toyear);
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }

        }
    }
}