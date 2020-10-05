using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportPortal
{
    public partial class Self : System.Web.UI.Page
    {
        SessionManager sessions = null; string strheader = String.Empty; private DateTime startdate, endate;
        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (sessions.MerchantCode == null)
            {
                Response.Redirect("~/login.aspx");

            }
        }

        protected void btnpreview_OnClick(object sender, EventArgs e)
        {
            txtiddisplay.Visible = true;

            if (string.IsNullOrWhiteSpace(txtstartdate.Text.ToString()) && string.IsNullOrWhiteSpace(txtenddate.Text.ToString()))
            {
                //Encodings.MsgBox("! Criteria is Empty !", this.Page, this);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Criteria is Empty !', 'error');", true);
            }
            else if (Convert.ToDateTime(txtenddate.Text.ToString()) < Convert.ToDateTime(txtstartdate.Text.ToString()))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! End Date Greater Than Start Date !', 'error');", true);
            }
            else
            {
                Session["Startdate"] = txtstartdate.Text.ToString();
                Session["Enddate"] = txtenddate.Text.ToString();

                SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

                var startdate = Session["Startdate"].ToString();

                var enddate = Session["Enddate"].ToString();


                DateTime dt = DateTime.ParseExact(startdate, "dd/mm/yyyy", CultureInfo.InvariantCulture);
                DateTime dt2 = DateTime.ParseExact(enddate, "dd/mm/yyyy", CultureInfo.InvariantCulture);


                var gb = dt.ToString("yyyy-MM-dd");
                var gb2 = dt2.ToString("yyyy-MM-dd");

                if (Encodings.IsValidUser(String.Format("SELECT * FROM ViewTaxPayer WHERE MerchantCode='{0}' AND Datecreated BETWEEN '{1}' AND '{2}' ORDER BY OrganizationName ASC",
                    sessions.MerchantCode.ToString(), gb, gb2)))
                {
                    Response.Write("<script>");
                    Response.Write("window.open('Viewself.aspx' ,'_blank')");
                    Response.Write("</script>");
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', ' No Record Found for the Selected Range !', 'Info');", true);
                }
            }
        }
    }
}