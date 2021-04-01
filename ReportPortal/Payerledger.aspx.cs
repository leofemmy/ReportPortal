using System;

namespace ReportPortal
{
    public partial class Payerledger : System.Web.UI.Page
    {
        SessionManager sessions = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (sessions.MerchantCode == null)
            {
                Response.Redirect("~/login.aspx");

            }
            else
            {
                // Session["Assyear"] = ddlyear.SelectedValue.ToString();

                Response.Write("<script>");
                Response.Write("window.open('viewPayerledger.aspx' ,'_blank')");
                Response.Write("</script>");
            }


        }


    }
}