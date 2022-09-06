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
        SessionManager sessions = null; string strvalue = String.Empty; int j = 0;

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

        protected void btnpreview_OnClick(object sender, EventArgs e)
        {
            int totalCount = gridOffence.Rows.Cast<GridViewRow>()
                .Count(r => ((CheckBox)r.FindControl("CheckBox1")).Checked);

            if (string.IsNullOrWhiteSpace(txtstartdate.Text.ToString()) || string.IsNullOrWhiteSpace(txtenddate.Text.ToString()))
            {
                //Encodings.MsgBox("! Criteria is Empty !", this.Page, this);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Criteria is Empty !', 'error');", true);
            }
            else if (Convert.ToDateTime(txtenddate.Text.ToString()) < Convert.ToDateTime(txtstartdate.Text.ToString()))
            {
                //Encodings.MsgBox("End Date Greater Than Start Date !", this.Page, this);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! End Date Greater Than Start Date !', 'error');", true);
            }
            else if (ddlRevenue.Items.Count == 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Select Revenue Type !', 'error');", true);
            }
            else
            {
                var str = ddlRevenue.SelectedItem.ToString();

                foreach (GridViewRow row in gridOffence.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("CheckBox1");

                    Label lbltin = (Label)row.FindControl("lbltin");

                    if (chk != null & chk.Checked)
                    {
                        strvalue += String.Format("{0}", lbltin.Text);

                        if (j + 1 < totalCount)
                        {
                            strvalue += ",";
                            ++j;
                        }
                    }

                }

                txtiddisplay.Visible = true;

                Session["RevenueTypecode"] = ddlRevenue.Text.ToString();

                Session["RevenueTypeName"] = ddlRevenue.SelectedItem.ToString();

                Session["Startdate"] = Convert.ToDateTime(txtstartdate.Text).ToString("yyyy-MM-dd 00:00:00");// txtstartdate.Text.ToString();

                Session["Enddate"] = Convert.ToDateTime(txtenddate.Text).ToString("yyyy-MM-dd 23:59:59");//txtenddate.Text.ToString();

                Session["startdate1"] = Convert.ToDateTime(txtstartdate.Text.ToString());

                Session["Enddate1"] = Convert.ToDateTime(txtenddate.Text.ToString());

                Session["RevenueOfficeID"] = strvalue;

                var strrevenue = Session["RevenueOfficeID"].ToString();

                var strrevennuetypecode = Session["RevenueTypecode"].ToString();

                var startdate = Session["Startdate"].ToString();

                var enddate = Session["Enddate"].ToString();

                var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

                var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");

                if (Encodings.IsValidUser(String.Format(
                    "SELECT OrganizationName,TaxAgentTIN,RevenueOfficeID,RevenueOfficeName, Months, SUM(Amount) Amount FROM  vwTrend WHERE PaymentDate BETWEEN '{0}' AND '{1}' AND RevenueOfficeID IN ({2}) AND RevenueCode= '{3}' GROUP BY OrganizationName, TaxAgentTIN, RevenueOfficeID,RevenueOfficeName, Months ORDER BY OrganizationName ASC",
                    startdate, enddate, strrevenue, strrevennuetypecode)))
                {
                    Response.Write("<script>");
                    Response.Write("window.open('ViewTrend.aspx' ,'_blank')");
                    Response.Write("</script>");
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', ' No Record Found for the Selected Range !', 'info');", true);
                }


            }
        }
    }
}