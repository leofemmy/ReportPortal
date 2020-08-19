using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.Web;

namespace ReportPortal
{
    public partial class Payment : System.Web.UI.Page
    {
        SessionManager sessions = null; string strheader = String.Empty; private DateTime startdate, endate;
        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (!IsPostBack)
            {
                if (sessions.MerchantCode == null)
                {
                    Response.Redirect("~/login.aspx");

                }
                loadAgency();
            }


        }

        protected void btnpreview_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlAgency.SelectedValue.ToString())) return;

            if (string.IsNullOrEmpty(ddlRevenue.SelectedValue.ToString())) return;

            Session["Agency"] = ddlAgency.SelectedValue.ToString();

            Session["Revenue"] = ddlRevenue.SelectedValue.ToString();

            Session["RevenueName"] = ddlRevenue.SelectedItem.ToString();

            var gb = Convert.ToDateTime(txtstartdate.Text.ToString());

            Session["startdate1"] = Convert.ToDateTime(txtstartdate.Text.ToString());

            Session["Enddate1"] = Convert.ToDateTime(txtenddate.Text.ToString());

            //DateTime date = DateTime.ParseExact(Convert.ToDateTime(txtstartdate.Text.ToString()), "dd/MM/yyyy", null);

            // DateTime date = DateTime.ParseExact(txtstartdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Session["Startdate"] = txtstartdate.Text.ToString();

            Session["Enddate"] = txtenddate.Text.ToString();

            Response.Write("<script>");
            Response.Write("window.open('ViewPayment.aspx' ,'_blank')");
            Response.Write("</script>");

        }

        void loadRevenue()
        {
            //ViewRevenue
            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT  RevenueCode, RevenueName FROM ViewRevenue WHERE AgencyId ='{0}' ", ddlAgency.SelectedValue.ToString());

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
                ddlRevenue.DataValueField = "RevenueCode";
                ddlRevenue.DataTextField = "RevenueName";
                ddlRevenue.DataBind();
                ddlRevenue.Items.Insert(0, new ListItem("--- Select Revenue Name ---", "0"));
            }
        }
        void loadAgency()
        {
            //ViewAgency

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT  AgencyId, AgencyName FROM ViewAgency WHERE MerchantCode ='{0}' ", sessions.MerchantCode.ToString());

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
                ddlAgency.DataSource = responses.Tables[0];
                ddlAgency.DataValueField = "AgencyId";
                ddlAgency.DataTextField = "AgencyName";
                ddlAgency.DataBind();
                ddlAgency.Items.Insert(0, new ListItem("--- Select Agency Name ---", "0"));
            }

        }

        protected void ddlAgency_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlAgency.SelectedValue.ToString())) return;

            loadRevenue();
        }
    }
}
