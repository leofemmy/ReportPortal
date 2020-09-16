using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportPortal
{
    public partial class CollectionSummary : System.Web.UI.Page
    {
        SessionManager sessions = null; string strheader = String.Empty; 
        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (sessions.MerchantCode == null)
            {
                Response.Redirect("~/login.aspx");

            }
        }
        protected void btnpreview_Click(object sender, EventArgs e)
        {
            Session["Startdate"] = txtstartdate.Text.ToString();
            Session["Enddate"] = txtenddate.Text.ToString();
            Session["Values"] = rdbReport.SelectedValue.ToString();

            if (rdbReport.SelectedValue.ToString() == "1")//bank options
            {

                Response.Write("<script>");
                Response.Write("window.open('ViewCollectSum.aspx' ,'_blank')");
                Response.Write("</script>");
            }

            if (rdbReport.SelectedValue.ToString() == "2")// agency options
            {

                Response.Write("<script>");
                Response.Write("window.open('ViewCollectSumAgency.aspx' ,'_blank')");
                Response.Write("</script>");
            }

        }
    }
}