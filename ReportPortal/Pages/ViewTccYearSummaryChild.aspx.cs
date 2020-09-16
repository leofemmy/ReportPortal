using ReportPortal.Reports;
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
    public partial class ViewTccYearSummaryChild : System.Web.UI.Page
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

            XtraRepTccYearSummaryChild obj_Rpt = new XtraRepTccYearSummaryChild();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT RevenueOfficeId, RevenueOfficeName, COUNT( DISTINCT TccNo) Reccount,   COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 1 THEN TccNo END) AS DA, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 2 THEN TccNo END) AS PA, COUNT( DISTINCT CASE WHEN IncomeSourceClassifyId = 3 THEN TccNo END) AS PN, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 4 THEN TccNo END) AS ST, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 5 THEN TccNo END ) AS NR, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 6 THEN  TccNo END ) AS UE, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 7 THEN TccNo END) AS DU FROM dbo.ViewTccDetails WHERE YEAR(IssuedDate)='{0}' AND AssessmentYear = YEAR(IssuedDate) - 1 GROUP BY RevenueOfficeId,  RevenueOfficeName", varyear);

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
            ViewTccYearSummaryChild vp = new ViewTccYearSummaryChild();

            var varRevenueoffice = strRevenuename;

            vp.callReport2(varRevenueoffice);

        }

        void callReport2(string RevenueOffice)
        {
            Session["RevenueOfficename"] = RevenueOffice;

        }
    }
}