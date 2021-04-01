using ReportPortal.Reports;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class ViewAssessmentYear : System.Web.UI.Page
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
        [System.Web.Services.WebMethod]
        public static void loadchildreport(string stin)
        {
            ViewAssessmentYear vp = new ViewAssessmentYear();

            var varstin = stin;

            vp.callReport2(varstin);


        }

        void callReport2(string stin)
        {
            Session["UTIN"] = stin;


        }
        void calReport()
        {

            var vryearfrom = Session["yearFrom"].ToString();

            var vryearto = Session["yearTo"].ToString();

            XtraRepYearLineSummary obj_Rpt = new XtraRepYearLineSummary();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT PayerUtin, PayerName,RevenueOfficeID,RevenueOfficeName, COALESCE(SUM(TaxPayable), 0) Assessment,COALESCE(SUM(PaymentAmount), 0) Payment, COALESCE(SUM(TaxPayable), 0) - COALESCE(SUM(PaymentAmount), 0) Differences, AssessmentYear FROM dbo.ViewPayerLedger WHERE AssessmentYear BETWEEN {0} AND {1} GROUP BY PayerUtin, PayerName, RevenueOfficeID, RevenueOfficeName, AssessmentYear", vryearfrom, vryearto);

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
                obj_Rpt.xrLabel2.Text = string.Format("From : {0} To: {1} ", vryearfrom, vryearto);
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }



        }
    }
}