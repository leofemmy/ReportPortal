using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class ViewDetailsbyAll : System.Web.UI.Page
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
            //var vastin = Session["UTIN"].ToString();
            var Fromyear = Session["Fromyear"].ToString(); var Toyear = Session["Toyear"].ToString();

            XtraRepPayerledge obj_Rpt = new XtraRepPayerledge();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT * FROM dbo.ViewPayerLedger  where  AssessmentYear BETWEEN {0} AND {1}", Fromyear, Toyear);

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
                obj_Rpt.xrLabel3.Text = "Details By All";
                obj_Rpt.xrLabel10.Text = string.Format("from {0}  To: {1}", Fromyear, Toyear);
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }

        }
    }
}