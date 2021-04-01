using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class userreport : System.Web.UI.Page
    {
        SessionManager sessions = null; DataSet dsm = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (sessions.MerchantCode == null)
            {
                Response.Redirect("~/login.aspx");

            }
            else
            {
                loadgridview();
            }
        }

        void loadgridview()
        {
            sessions = new SessionManager();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet(); string strquery = String.Empty;

            strquery = String.Format("SELECT FirstName, LastName, Email, CreateDate FROM Login.[User] WHERE MerchantCode='{0}' AND FirstName IS NOT NULL ORDER BY FirstName ASC", sessions.MerchantCode.ToString());

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

            if (responses.Tables[0] != null && responses.Tables[0].Rows.Count > 01)
            {
                GridView1.DataSource = responses.Tables[0];
                GridView1.DataBind();
            }
        }
    }
}