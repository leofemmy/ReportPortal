using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportPortal
{
    public partial class Agent : System.Web.UI.Page
    {
        SessionManager sessions = null; string strheader = String.Empty; private DateTime startdate, endate;

        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (sessions.MerchantCode == null)
            {
                Response.Redirect("~/login.aspx");

            }

            //this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report Not Showing!', 'You Need to Enable your Browser Pop-Up at the Top Right Corner to View the report', 'info');", true);
        }

        protected void btnpreview_OnClick(object sender, EventArgs e)
        {

            //Encodings.MsgBox("You Need to Enable your Browser Pop-Up at the Top Right Corner to View the report", this.Page, this);

            txtiddisplay.Visible = true;

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
                Session["Startdate"] = txtstartdate.Text.ToString();

                Session["Enddate"] = txtenddate.Text.ToString();

                var startdate = Session["Startdate"].ToString();

                var enddate = Session["Enddate"].ToString();

                DateTime dt = DateTime.ParseExact(startdate, "dd/mm/yyyy", CultureInfo.InvariantCulture);

                DateTime dt2 = DateTime.ParseExact(enddate, "dd/mm/yyyy", CultureInfo.InvariantCulture);

                //Console.WriteLine(dt.ToString("yyyy-MM-dd"));

                var gb = dt.ToString("yyyy-MM-dd");
                var gb2 = dt2.ToString("yyyy-MM-dd");

                if (Encodings.IsValidUser(String.Format(
                    "SELECT * FROM ViewTaxAgent WHERE MerchantCode='{0}' AND Datecreated BETWEEN '{1}' AND '{2}' ORDER BY OrganizationName ASC",
                    sessions.MerchantCode.ToString(), gb, gb2)))
                {
                    Response.Write("<script>");
                    Response.Write("window.open('ViewAgent.aspx' ,'_blank')");
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