using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportPortal
{
    public partial class Normalized : System.Web.UI.Page
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

            }
        }

        protected void btnpreview_OnClick(object sender, EventArgs e)
        {
            txtiddisplay.Visible = true;

            if (string.IsNullOrWhiteSpace(txtstartdate.Text.ToString()))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Start Date is Empty !', 'error');", true);
            }
            else if (string.IsNullOrWhiteSpace(txtenddate.Text.ToString()))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! End Date is Empty !', 'error');", true);
            }
            else if (Convert.ToDateTime(txtenddate.Text.ToString()) < Convert.ToDateTime(txtstartdate.Text.ToString()))
            {
                //Encodings.MsgBox("End Date Greater Than Start Date !", this.Page, this);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! End Date Greater Than Start Date !', 'error');", true);
            }
            else
            {
                var gb = Convert.ToDateTime(txtstartdate.Text.ToString());

                Session["startdate1"] = Convert.ToDateTime(txtstartdate.Text.ToString());

                Session["Enddate1"] = Convert.ToDateTime(txtenddate.Text.ToString());

                Session["Startdate"] = txtstartdate.Text.ToString();

                Session["Enddate"] = txtenddate.Text.ToString();

               // var strrevenue = Session["Revenue"].ToString();

                var startdate = Session["Startdate"].ToString();

                var enddate = Session["Enddate"].ToString();

                string strquery = String.Format("SELECT RevenueOfficeID, RevenueOfficeName, SUM(Amount) Amount FROM ViewNormalizedPayment WHERE RevenueOfficeID IS NOT NULL AND PaymentDate BETWEEN '{0}' AND '{1}' GROUP BY   RevenueOfficeID,  RevenueOfficeName ORDER BY RevenueOfficeName ASC", startdate, enddate);

                if (Encodings.IsValidUser(strquery))
                {
                    Response.Write("<script>");
                    Response.Write("window.open('ViewNormalized.aspx' ,'_blank')");
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