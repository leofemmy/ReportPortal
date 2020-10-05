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
    public partial class CollectionRanking : System.Web.UI.Page
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

        protected void btnpreview_OnClick(object sender, EventArgs e)
        {

            txtiddisplay.Visible = true;

            string strvalue = String.Empty; int j = 0;

            if (string.IsNullOrWhiteSpace(txtstartdate.Text.ToString()) || string.IsNullOrWhiteSpace(txtenddate.Text.ToString()))
            {
                //Encodings.MsgBox("! Criteria is Empty !", this.Page, this);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Criteria is Empty !', 'error');", true);
                return;
            }
            if (Convert.ToDateTime(txtenddate.Text.ToString()) < Convert.ToDateTime(txtstartdate.Text.ToString()))
            {
                //Encodings.MsgBox("End Date Greater Than Start Date !", this.Page, this);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! End Date Greater Than Start Date !', 'error');", true); return;
            }

            if (string.IsNullOrEmpty(ddlRevenue.SelectedValue.ToString())) return;

            if (string.IsNullOrEmpty(txtno.Text.ToString())) return;

            Session["nos"] = txtno.Text.ToString();

            Session["Startdate"] = txtstartdate.Text.ToString();

            Session["Enddate"] = txtenddate.Text.ToString();

            Session["Revenuecode"] = ddlRevenue.SelectedValue.ToString();

            Session["RevenueName"] = ddlRevenue.SelectedItem.ToString();

            Session["startdate1"] = Convert.ToDateTime(txtstartdate.Text.ToString());

            Session["Enddate1"] = Convert.ToDateTime(txtenddate.Text.ToString());

            int totalCount = gridOffence.Rows.Cast<GridViewRow>()
                .Count(r => ((CheckBox)r.FindControl("Chkid")).Checked);

            foreach (GridViewRow row in gridOffence.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("Chkid");

                Label lbloffic = (Label)row.FindControl("lbloffice");

                if (chk != null & chk.Checked)
                {
                    strvalue += String.Format("{0}", lbloffic.Text);

                    if (j + 1 < totalCount)
                    {
                        strvalue += ",";
                        ++j;
                    }
                }

            }

            Session["RevenueofficeID"] = strvalue;

            var strrevenue = Session["Revenuecode"].ToString();

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

            var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");

            var strrevenueofficeid = Session["RevenueofficeID"].ToString();

            int nos = Convert.ToInt32(Session["nos"].ToString());

            string strquery = String.Format(
                "SELECT  DISTINCT TOP {0} TaxAgentUtin,TaxAgentName,SUM(Amount) Amount,RevenueOfficeID,RevenueOfficeName,RevenueCode,RevenueName,DATEPART(MONTH, PaymentDate) AS MONTH,DATEPART(YEAR, PaymentDate) AS YEAR,CONVERT(VARCHAR, DATEPART(MONTH, PaymentDate)) + '/' + CONVERT(VARCHAR, DATEPART(YEAR, PaymentDate)) AS Period FROM vwCollectionRanking WHERE PaymentDate BETWEEN '{1}' AND '{2}' AND RevenueCode ='{3}' AND RevenueOfficeID IN ({4}) GROUP BY TaxAgentUtin, TaxAgentName, RevenueOfficeID,RevenueOfficeName,RevenueCode, RevenueName,DATEPART(MONTH, PaymentDate), DATEPART(YEAR, PaymentDate) ORDER BY TaxAgentName ASC",
                nos, startdate, enddate, strrevenue, strrevenueofficeid);

            if (Encodings.IsValidUser(strquery))
            {
                Response.Write("<script>");
                Response.Write("window.open('ViewCollectionRanking.aspx' ,'_blank')");
                Response.Write("</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', ' No Record Found for the Selected Range !', 'info');", true);
            }


        }
    }
}