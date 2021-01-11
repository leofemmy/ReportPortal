﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReportPortal.Reports;

namespace ReportPortal
{
    public partial class ViewRemittance : System.Web.UI.Page
    {
        SessionManager sessions = null; string strheader = String.Empty; private DateTime startdate, endate;

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
            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            var strrevenue = Session["Agencylist"].ToString();

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

            var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");

            //var strrevenueofficeid = Session["RevenueofficeID"].ToString();

            //int nos = Convert.ToInt32(Session["nos"].ToString());

            XtraRepRemittance obj_Rpt = new XtraRepRemittance();

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
            obj_Rpt.xrlbsubHead.Text = string.Format("INTERNAL REVENUE SERVICE");

            string strquery = String.Format("SELECT PayerID, TaxAgentUtin, TaxAgentName,  address,  PaymentRefNumber, Amount, RevenueOfficeID, RevenueOfficeName, RevenueCode,  PaymentDate,AgencyName,BankName FROM vwRemittance WHERE PaymentDate BETWEEN '{0}' AND '{1}' AND TaxAgentUtin IN ({2}) ORDER BY TaxAgentName ASC", startdate, enddate, strrevenue);

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
                //obj_Rpt.xrLabel10.Text = string.Format("From {0:dd/MM/yyyy}  To {1:dd/MM/yyyy}", strat, end);
                //obj_Rpt.xrLabel8.Text = Session["RevenueName"].ToString();
                //obj_Rpt.xrPivotGrid1.DataSource = responses;
                //obj_Rpt.xrPivotGrid1.DataMember = responses.Tables[0].TableName;
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }



        }
    }
}