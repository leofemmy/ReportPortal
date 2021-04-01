using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ReportPortal
{
    public partial class LineSummaryTaxOffice : System.Web.UI.Page
    {
        SessionManager sessions = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (!IsPostBack)
            {
                if (sessions.MerchantCode == null)
                {
                    Response.Redirect("~/login.aspx");

                }
                loadAssementyear(); loadAssementyearto(); loadRevenueoffice();
            }

        }
        void loadAssementyear()
        {
            //ViewAgency

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT AssessmentYear FROM [dbo].[ViewAssessmentYear]");

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
                ddlyear.DataSource = responses.Tables[0];
                ddlyear.DataValueField = "AssessmentYear";
                ddlyear.DataTextField = "AssessmentYear";
                ddlyear.DataBind();
                ddlyear.Items.Insert(0, new ListItem("--- Select Year From ---", "0"));
            }

        }

        void loadRevenueoffice()
        {
            //Revenue office

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("  SELECT RevenueOfficeID,RTRIM(LTRIM(RevenueOfficeName)) RevenueOfficeName FROM Setting.RevenueOffice ORDER BY RevenueOfficeName asc");

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
                ddlRevenue.DataSource = responses.Tables[0];
                ddlRevenue.DataValueField = "RevenueOfficeID";
                ddlRevenue.DataTextField = "RevenueOfficeName";
                ddlRevenue.DataBind();
                ddlRevenue.Items.Insert(0, new ListItem("--- Select Revenue Office ---", "0"));
            }
        }
        void loadAssementyearto()
        {
            //ViewAgency

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT AssessmentYear FROM [dbo].[ViewAssessmentYear]");

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
                ddlto.DataSource = responses.Tables[0];
                ddlto.DataValueField = "AssessmentYear";
                ddlto.DataTextField = "AssessmentYear";
                ddlto.DataBind();
                ddlto.Items.Insert(0, new ListItem("--- Select Year To ---", "0"));
            }

        }

        protected void btnpreview_Click(object sender, EventArgs e)
        {
            Session["Fromyear"] = ddlyear.SelectedValue.ToString();
            Session["Toyear"] = ddlto.SelectedValue.ToString();
            Session["Revenueoffice"] = ddlRevenue.SelectedValue.ToString();


            Response.Write("<script>");
            Response.Write("window.open('LineSummaryTaxOfficeView.aspx' ,'_blank')");
            Response.Write("</script>");
        }
    }
}