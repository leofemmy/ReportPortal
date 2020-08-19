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
    public partial class ViewTaxofficeLinesummary : System.Web.UI.Page
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
            var revenuename = Session["Revenuename"].ToString();

            XtraRepSummaryLedger obj_Rpt = new XtraRepSummaryLedger();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT PayerUtin, PayerName, RevenueOfficeID,RevenueOfficeName,COALESCE(SUM(TaxPayable), 0) Assessment,  COALESCE(SUM(PaymentAmount), 0) Payment, COALESCE(SUM(TaxPayable), 0) - COALESCE(SUM(PaymentAmount), 0) Differences FROM dbo.ViewPayerLedger WHERE RevenueOfficeName='{0}' AND AssessmentYear BETWEEN {1} AND {2} GROUP BY PayerUtin, PayerName, RevenueOfficeID,RevenueOfficeName  ORDER BY RevenueOfficeName asc", revenuename, varyear, varto);

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
                obj_Rpt.xrLabel9.Text = string.Format("Tax Assessments & Payments");
                obj_Rpt.xrLabel10.Text = string.Format("Tax Office - Taxpayers Summary ");
                //xrLabel11
                obj_Rpt.xrLabel11.Text = string.Format("From: {0}   To: {1}", varyear, varto);
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }

        }
    }
}