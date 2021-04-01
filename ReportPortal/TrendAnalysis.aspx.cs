using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace ReportPortal
{
    public partial class TrendAnalysis : System.Web.UI.Page
    {
        SessionManager sessions = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (sessions.MerchantCode == null)
            {
                Response.Redirect("~/login.aspx");

            }

            if (!IsPostBack)
            {
                setloadOffice();

                setload();
            }
        }

        void setload()
        {
            string strvalue = String.Empty;

            string value = ConfigurationManager.AppSettings["IsRevenueProvider"].ToString();

            string[] val = value.Split(',');

            int j = 0;

            foreach (var words in val)
            {
                strvalue += String.Format("'{0}'", words);

                if (j + 1 < val.Count())
                {
                    strvalue += ",";
                    ++j;
                }

            }

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString))
            {
                connect.Open();
                _command = new SqlCommand(String.Format("SELECT RevenueCode,RevenueName FROM vwCollectionRevenue WHERE RevenueCode IN ({0}) ORDER BY RevenueName ASC", strvalue), connect) { CommandType = CommandType.Text };
                _command.CommandTimeout = 0;
                responses.Clear();
                _adp = new SqlDataAdapter(_command);
                _adp.Fill(responses);

                connect.Close();

            }
            if (responses.Tables[0] != null && responses.Tables[0].Rows.Count > 1)
            {
                ddlRevenue.DataSource = responses.Tables[0];
                ddlRevenue.DataValueField = "RevenueCode";
                ddlRevenue.DataTextField = "RevenueName";
                ddlRevenue.DataBind();
                ddlRevenue.Items.Insert(0, new ListItem("--- Select Revenue Type ---", "0"));
            }
        }

        void setloadOffice()
        {
            sessions = new SessionManager();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString))
            {
                connect.Open();
                _command = new SqlCommand(String.Format("SELECT  LTRIM(RTRIM(RevenueOfficeName)) RevenueOfficeName,RevenueOfficeID FROM Setting.RevenueOffice WHERE MerchantCode='{0}' ORDER BY  LTRIM(RTRIM(RevenueOfficeName)) ASC ", sessions.MerchantCode.ToString()), connect) { CommandType = CommandType.Text };
                _command.CommandTimeout = 0;
                responses.Clear();
                _adp = new SqlDataAdapter(_command);
                _adp.Fill(responses);

                connect.Close();
            }

            if (responses.Tables[0] != null && responses.Tables[0].Rows.Count > 1)
            {
                gridOffence.DataSource = responses.Tables[0];
                gridOffence.DataBind();
            }

        }
    }
}