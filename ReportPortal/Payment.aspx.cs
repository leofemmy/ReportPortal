using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

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
            txtiddisplay.Visible = true;

            //  Encodings.MsgBox("You Need to Enable your Browser Pop-Up at the Top Right Corner to View the report", this.Page, "Report Not Showing?");

            if (string.IsNullOrEmpty(ddlAgency.SelectedValue.ToString()))
            {
                //Encodings.MsgBox("! Criteria is Empty !", this.Page, this);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Criteria is Empty !', 'error');", true);
                return;
            }
            else if (string.IsNullOrEmpty(ddlRevenue.SelectedValue.ToString()))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Criteria is Empty !', 'error');", true); return;
            }
            else if (string.IsNullOrWhiteSpace(txtstartdate.Text.ToString()) && string.IsNullOrWhiteSpace(txtenddate.Text.ToString()))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Criteria is Empty !', 'error');", true);
            }
            else if (Convert.ToDateTime(txtenddate.Text.ToString()) < Convert.ToDateTime(txtstartdate.Text.ToString()))
            {
                //Encodings.MsgBox("End Date Greater Than Start Date !", this.Page, this);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! End Date Greater Than Start Date !', 'error');", true);
            }
            else
            {

                Session["Agency"] = ddlAgency.SelectedValue.ToString();

                Session["Revenue"] = ddlRevenue.SelectedValue.ToString();

                Session["RevenueName"] = ddlRevenue.SelectedItem.ToString();

                var gb = Convert.ToDateTime(txtstartdate.Text.ToString());

                Session["startdate1"] = Convert.ToDateTime(txtstartdate.Text.ToString());

                Session["Enddate1"] = Convert.ToDateTime(txtenddate.Text.ToString());

                Session["Startdate"] = txtstartdate.Text.ToString();

                Session["Enddate"] = txtenddate.Text.ToString();

                var strrevenue = Session["Revenue"].ToString();

                var startdate = Session["Startdate"].ToString();

                var enddate = Session["Enddate"].ToString();

                string strquery = String.Format("SELECT * FROM ViewPayment WHERE PaymentDate BETWEEN '{0}' AND '{1}' and RevenueCode ='{2}'  ORDER BY PaymentDate ASC", startdate, enddate, strrevenue);

                if (Encodings.IsValidUser(strquery))
                {
                    Response.Write("<script>");
                    Response.Write("window.open('ViewPayment.aspx' ,'_blank')");
                    Response.Write("</script>");
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', ' No Record Found for the Selected Range !', 'info');", true);
                }
            }

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
