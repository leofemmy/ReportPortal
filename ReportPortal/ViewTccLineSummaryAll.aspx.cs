using ReportPortal.Reports;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class ViewTccLineSummaryAll : System.Web.UI.Page
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
            //var varyear = Session["Fromyear"].ToString();
            //var varto = Session["Toyear"].ToString();

            XtraRepTccLineSummaryAll obj_Rpt = new XtraRepTccLineSummaryAll();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT Utin,PayerName,RevenueOfficeName,SUM(Income) Income,SUM(Paid) Paid FROM dbo.ViewTccDetails GROUP BY Utin,PayerName,RevenueOfficeName ORDER BY PayerName ASC");

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
                // obj_Rpt.xrLabel10.Text = string.Format("From: {0}  To: {1}", Session["Fromyear"].ToString(), Session["Toyear"].ToString());
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }
        }

        [System.Web.Services.WebMethod]
        public static void loadchildreport(string stin)
        {
            ViewTccLineSummaryAll vp = new ViewTccLineSummaryAll();

            var varstin = stin;

            vp.callReport2(varstin);


        }

        void callReport2(string stin)
        {
            //Session["Revenuename"] = stin;
            Session["UTIN"] = stin;

        }
    }
}