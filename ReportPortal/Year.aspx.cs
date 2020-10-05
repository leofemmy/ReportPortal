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
    public partial class Year : System.Web.UI.Page
    {
        SessionManager sessions = null; string strvalue = String.Empty; int j = 0;

        private string constr = ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString;

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
            }
        }

        void setloadOffice()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT AgencyCode,AgencyName FROM ViewAgency ORDER BY AgencyName ASC "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gridOffence.DataSource = dt;
                            gridOffence.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnpreview_Click(object sender, EventArgs e)
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
                foreach (GridViewRow row in gridOffence.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("CheckBox1");

                    Label lbltin = (Label)row.FindControl("lbltin");

                    if (chk != null & chk.Checked)
                    {
                        strvalue += String.Format("'{0}'", lbltin.Text);

                        if (j + 1 < totalCount)
                        {
                            strvalue += ",";
                            ++j;
                        }
                    }

                }

                txtiddisplay.Visible = true;

                Session["Startdate"] = txtstartdate.Text.ToString();

                Session["Enddate"] = txtenddate.Text.ToString();

                Session["startdate1"] = Convert.ToDateTime(txtstartdate.Text.ToString());

                Session["Enddate1"] = Convert.ToDateTime(txtenddate.Text.ToString());

                Session["Agencylist"] = strvalue;

                var strrevenue = Session["Agencylist"].ToString();

                var startdate = Session["Startdate"].ToString();

                var enddate = Session["Enddate"].ToString();

                var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

                var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");

                if (Encodings.IsValidUser(String.Format(
                    "SELECT AgencyName,AgencyCode,SUM(Amount) Amount,DATEPART(YEAR,PaymentDate) Year FROM vwCollectionRaw WHERE PaymentDate BETWEEN '{0}' AND '{1}' AND AgencyCode IN ({2}) GROUP BY AgencyName,AgencyCode,DATEPART(YEAR,PaymentDate) ORDER BY AgencyName ASC",
                    startdate, enddate, strrevenue)))
                {
                    Response.Write("<script>");
                    Response.Write("window.open('ViewYear.aspx' ,'_blank')");
                    Response.Write("</script>");
                }
                else
                {
                    //Encodings.MsgBox("! No Record Found for the Selected Range !", this.Page, this);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', ' No Record Found for the Selected Range !', 'info');", true);
                }
            }
        }
    }
}