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
    public partial class AssessmentTaxoffice : System.Web.UI.Page
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
                loadAssementyear();

                loadAssementTaxofice();
            }
        }
        void loadAssementTaxofice()
        {
            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT RevenueOfficeID,RTRIM(LTRIM(RevenueOfficeName)) RevenueOfficeName FROM Setting.RevenueOffice ORDER BY RTRIM(LTRIM(RevenueOfficeName)) ASC");

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
                ddlRevenue.Items.Insert(0, new ListItem("--- Select Revenue / Tax Office ---", "0"));
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
                ddlyear.Items.Insert(0, new ListItem("--- Select Assessment Year ---", "0"));
            }

        }
        protected void btnpreview_Click(object sender, EventArgs e)
        {
            Session["Assyear"] = ddlyear.SelectedValue.ToString();
            Session["AssOffice"] = ddlRevenue.SelectedValue.ToString();
            Session["AssOfficeText"] = ddlRevenue.SelectedItem.Text.ToString();

            Response.Write("<script>");
            Response.Write("window.open('ViewAssessmentTaxoffice.aspx' ,'_blank')");
            Response.Write("</script>");
        }
    }
}