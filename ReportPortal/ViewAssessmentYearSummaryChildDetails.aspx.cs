using ReportPortal.Reports;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class ViewAssessmentYearSummaryChildDetails : System.Web.UI.Page
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
            var varofficename = Session["RevenueOfficename"].ToString();

            var varyear = Session["TaxYear"].ToString();

            XtraRepAssessmentDetails obj_Rpt = new XtraRepAssessmentDetails();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT * FROM ViewAssessmentInfor WHERE AssessmentYear BETWEEN {0} AND {0} AND RevenueOfficeName='{1}' ORDER BY PayerName asc", varyear, varofficename);


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
                //obj_Rpt.xrLabel10.Text = string.Format("From {0}  to {1}", vryearfrom, vryearto);
                //obj_Rpt.xrLabel11.Text = string.Format("{0} ", varofficename);
                obj_Rpt.xrLabel10.Text = string.Format("{0} ", varyear);
                obj_Rpt.xrLabel11.Text = string.Format("{0} ", varofficename);
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }

        }
    }
}