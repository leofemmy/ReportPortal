using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportPortal
{
    public partial class Payer : System.Web.UI.Page
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
            Session["Startdate"] = txtstartdate.Text.ToString();
            Session["Enddate"] = txtenddate.Text.ToString();

            Response.Write("<script>");
            Response.Write("window.open('ViewPay.aspx' ,'_blank')");
            Response.Write("</script>");
        }
    }
}