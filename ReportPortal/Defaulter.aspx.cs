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
    public partial class Defaulter : System.Web.UI.Page
    {
        SessionManager sessions = null; string strvalue = String.Empty; int j = 0;

        private SqlCommand _command; private SqlDataAdapter adp; DataTable dt;

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

                Session["Startdate"] = txtstartdate.Text.ToString();

                Session["Enddate"] = txtenddate.Text.ToString();

                Session["startdate1"] = Convert.ToDateTime(txtstartdate.Text.ToString());

                Session["Enddate1"] = Convert.ToDateTime(txtenddate.Text.ToString());

                Session["RevenueOfficeID"] = strvalue;

                var strrevenue = Session["RevenueOfficeID"].ToString();

                var strrevennuetypecode = Session["RevenueTypecode"].ToString();

                var strrevenuename= Session["RevenueTypeName"].ToString();

                var startdate = Session["Startdate"].ToString();

                var enddate = Session["Enddate"].ToString();

                var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

                var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");

                //call Store procedure here
                using (SqlConnection connect = new SqlConnection(ConfigurationManager
                    .ConnectionStrings["Registration2ConnectionString"].ConnectionString))
                {
                    connect.Open();
                    _command = new SqlCommand("spDoGetTaxDefaulterAnalysis", connect)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _command.Parameters.Add(new SqlParameter("@date1", SqlDbType.DateTime)).Value =
                        string.Format("{0:yyyy/MM/dd 00:00:00}", startdate);
                    _command.Parameters.Add(new SqlParameter("@date2", SqlDbType.DateTime)).Value =
                        string.Format("{0:yyyy/MM/dd 23:59:59}", enddate);
                    _command.Parameters.Add(new SqlParameter("@RevenueCode", SqlDbType.VarChar)).Value = strrevennuetypecode;
                    _command.Parameters.Add(new SqlParameter("@RevenueOffice", SqlDbType.VarChar)).Value = strrevenue;
                    _command.CommandTimeout = 0;

                    using (System.Data.DataSet ds = new System.Data.DataSet())
                    {
                        ds.Clear();
                        adp = new SqlDataAdapter(_command);
                        adp.Fill(ds, "table");
                        //Dts = ds.Tables[0];
                        connect.Close();

                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            Response.Write("<script>");
                            Response.Write("window.open('ViewDefaulter.aspx' ,'_blank')");
                            Response.Write("</script>");
                        }
                        else
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', ' No Record Found for the Selected Range !', 'info');", true);
                        }


                        //if (responses.Tables[0] != null && responses.Tables[0].Rows.Count > 0)
                    }

                }
            }
        }
    }
}