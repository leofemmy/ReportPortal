﻿using ReportPortal.Reports;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Services;

namespace ReportPortal
{
    public partial class ViewSummaryTaxAgent : System.Web.UI.Page
    {
        SessionManager sessions = null; SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet(); string strheader = String.Empty;

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
            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

            var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");

            XtraRepTaxAgentlist obj_Rpt = new XtraRepTaxAgentlist();

            if (sessions.MerchantCode.ToString() == "DTSS")
            {
                strheader = "DELTA STATE GOVERNMENT";

                obj_Rpt.xrPictureBox1.Visible = true;

                obj_Rpt.xrPictureBox2.Visible = false;

                obj_Rpt.xrPictureBox3.Visible = false;

            }

            if (sessions.MerchantCode.ToString() == "OGSS")
            {
                strheader = "OGUN STATE GOVERNMENT";

                obj_Rpt.xrPictureBox1.Visible = false;

                obj_Rpt.xrPictureBox2.Visible = true;

                obj_Rpt.xrPictureBox3.Visible = false;
            }

            if (sessions.MerchantCode.ToString() == "OYSS")
            {
                strheader = "OYO STATE GOVERNMENT";

                obj_Rpt.xrPictureBox1.Visible = false;

                obj_Rpt.xrPictureBox2.Visible = false;

                obj_Rpt.xrPictureBox3.Visible = true;
            }


            obj_Rpt.xrlborghead.Text = strheader;
            //obj_Rpt.xrlbsubHead.Text = string.Format("INTERNAL REVENUE SERVICE");
            // obj_Rpt.xrLabel3.Text = string.Format("From {0:dd/MM/yyyy}  To {1:dd/MM/yyyy}", strat, end);
            //obj_Rpt.xrlborghead.Text = strheader;
            obj_Rpt.xrLabel1.Text = string.Format("INTERNAL REVENUE SERVICE");
            obj_Rpt.xrlbsubHead2.Text = string.Format("From {0:dd/MM/yyyy}  To {1:dd/MM/yyyy}", strat, end);

            string strquery = String.Format("SELECT PayerName, UTIN, RevenueOfficeName, DateCreated,TaxAgentReferenceNumber, MerchantCode, (SELECT COUNT(*) AS Expr1 FROM Registration.Taxpayer WHERE (TaxAgentReferenceNumber = vw.TaxAgentReferenceNumber)) AS Rec_Count FROM dbo.vwPayerInfo vw WHERE PayerName IS NOT NULL AND vw.PayerName <> ' ' AND TaxAgentReferenceNumber IS NOT NULL AND DateCreated BETWEEN '{0}' AND '{1}' AND MerchantCode='{2}' AND RegTypeCode = 'AG' GROUP BY PayerName, RevenueOfficeName, UTIN,DateCreated,TaxAgentReferenceNumber, MerchantCode ORDER BY Rec_Count DESC", startdate, enddate, sessions.MerchantCode.ToString());

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
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }

        }

        [WebMethod]
        public static void Loadchildreport(string stin)
        {
            ViewSummaryTaxAgent vp = new ViewSummaryTaxAgent();

            HttpContext.Current.Session["STINAgent"] = stin;

            var vartaxyear = stin;

            vp.callReport2(vartaxyear);

        }

        void callReport2(string stin)
        {
            Session["STINAgent"] = stin;


        }
    }
}