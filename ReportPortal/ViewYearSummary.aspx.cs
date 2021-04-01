using ReportPortal.Reports;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class ViewYearSummary : System.Web.UI.Page
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

            XtraRepYearSummary obj_Rpt = new XtraRepYearSummary();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT AssessmentYear, COALESCE(SUM(TaxPayable), 0) Assessment, COALESCE(SUM(PaymentAmount), 0) Payment FROM dbo.ViewPayerLedger WHERE AssessmentYear BETWEEN {0} AND {1} GROUP BY AssessmentYear ", varyear, varto);

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
                obj_Rpt.xrLabel8.Text = string.Format("From: {0}  To: {1}", Session["Fromyear"].ToString(), Session["Toyear"].ToString());
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }

            //var cachedReportSource = new CachedReportSourceWeb(new XtraRepPayment());

        }

        [System.Web.Services.WebMethod]
        public static void loadchildreport(string strYear)
        {
            ViewYearSummary vp = new ViewYearSummary();

            var vrYear = strYear;

            vp.callReport2(vrYear);
        }
        void callReport2(string Year)
        {
            Session["CallYear"] = Year;
            Session["Type"] = "2";
        }
    }
}