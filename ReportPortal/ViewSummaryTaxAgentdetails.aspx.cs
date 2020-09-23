using System;
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
    public partial class ViewSummaryTaxAgentdetails : System.Web.UI.Page
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
            sessions = new SessionManager();

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

            var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");

            var stroffices = Session["STINAgent"].ToString();

            XtraRepEmployedPA obj_Rpt = new XtraRepEmployedPA();

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
            obj_Rpt.xrLabel1.Text = string.Format("INTERNAL REVENUE SERVICE");
            obj_Rpt.xrlbsubHead.Text = "Taxpayers Registered Report (Tax Agent)";
            obj_Rpt.xrlbsubHead2.Text = string.Format("From {0:dd/MM/yyyy}  To {1:dd/MM/yyyy}", strat, end);

            string strquery = String.Format("SELECT PayerName, UTIN, Address, Email,TelephoneNumber, MerchantCode,LgaId, LgaName,PayerType,StaffNumber, CACNumber, RegTypeCode,RevenueOfficeID,RevenueOfficeName, DateCreated,  TaxAgentReferenceNumber FROM vwPayerInfo WHERE PayerName <>  ' ' AND PayerName IS NOT NULL AND RegTypeCode <> 'AG' AND MerchantCode= '{0}' AND TaxAgentReferenceNumber =( SELECT TaxAgentReferenceNumber  FROM dbo.vwPayerInfo WHERE UTIN ='{1}') ORDER BY PayerName ASC, DateCreated ASC", sessions.MerchantCode.ToString(), stroffices);

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
    }
}