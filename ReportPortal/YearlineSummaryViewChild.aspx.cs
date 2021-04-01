using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class YearlineSummaryViewChild : System.Web.UI.Page
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
            var vastin = Session["UTIN"].ToString();
            var varyear = Session["yearFrom"].ToString();
            var varto = Session["yearTo"].ToString();

            //var vryearfrom = Session["yearFrom"].ToString();

            //var vryearto = Session["yearTo"].ToString();
            // var vrreveune = Session["Revenueoffice"].ToString();


            XtraRepPayerledge obj_Rpt = new XtraRepPayerledge();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT * FROM dbo.ViewPayerLedger  where PayerUtin='{0}' AND AssessmentYear BETWEEN {1} AND {2} ", vastin, varyear, varto);

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
                obj_Rpt.xrLabel10.Text = string.Format("From {0}  To: {1} ", varyear, varto);
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }

        }
    }
}