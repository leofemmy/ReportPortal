using ReportPortal.Reports;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class ViewAssessmentYearSummaryChild : System.Web.UI.Page
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

            var varyear = Session["TaxYear"].ToString();

            XtraRepAssessmentYearSummaryChild obj_Rpt = new XtraRepAssessmentYearSummaryChild();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT a.AssessmentYear, a.RevenueOfficeName,a.RevenueOfficeId, COUNT(DISTINCT a.AssessmentNo) AS Reccount, SUM(a.TaxPayable) TotalPayable, COUNT(DISTINCT CASE  WHEN a.IncomeSourceClassifyId = 1 THEN a.AssessmentNo END ) AS DA, COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 2 THEN a.AssessmentNo END) AS PA, COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 3 THEN  a.AssessmentNo END ) AS PN,COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 4 THEN a.AssessmentNo  END ) AS ST, COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 5 THEN a.AssessmentNo END ) AS NR, COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 6 THEN a.AssessmentNo END) AS UE,COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 7 THEN a.AssessmentNo END) AS DU, COALESCE(SUM( CASE WHEN a.IncomeSourceClassifyId = 1 THEN a.TaxPayable END), 0) DAAmount,COALESCE(SUM(CASE WHEN a.IncomeSourceClassifyId = 2 THEN a.TaxPayable END),0) PAAmount,COALESCE(SUM(CASE WHEN a.IncomeSourceClassifyId = 3 THEN a.TaxPayable END ), 0) PNAmount,COALESCE(SUM( CASE WHEN a.IncomeSourceClassifyId = 4 THEN a.TaxPayable END ),0 ) STAmount, COALESCE(SUM(CASE WHEN a.IncomeSourceClassifyId = 5 THEN a.TaxPayable END),0) NRAmount,COALESCE(SUM( CASE WHEN a.IncomeSourceClassifyId = 6 THEN a.TaxPayable END),0) UEAmount,COALESCE(SUM( CASE WHEN a.IncomeSourceClassifyId = 7 THEN a.TaxPayable END),0) DUAmount FROM ViewAssessmentInfor a WHERE a.AssessmentYear = {0}  GROUP BY  a.AssessmentYear, a.RevenueOfficeName,a.RevenueOfficeId ORDER BY a.RevenueOfficeName asc", varyear);

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
                obj_Rpt.xrLabel11.Text = string.Format("{0}", varyear);
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }

        }
        [System.Web.Services.WebMethod]
        public static void loadchildreport(string strRevenuename)
        {
            ViewAssessmentYearSummaryChild vp = new ViewAssessmentYearSummaryChild();

            var varRevenueoffice = strRevenuename;

            vp.callReport2(varRevenueoffice);

        }

        void callReport2(string RevenueOffice)
        {
            Session["RevenueOfficename"] = RevenueOffice;

        }
    }
}