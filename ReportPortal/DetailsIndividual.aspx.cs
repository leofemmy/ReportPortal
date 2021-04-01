using System;

namespace ReportPortal
{
    public partial class DetailsIndividual : System.Web.UI.Page
    {
        SessionManager sessions = null;
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

        protected void btnpreview_Click(object sender, EventArgs e)
        {
            Session["Search"] = txtsearch.Text.Trim().ToString();


            Response.Write("<script>");
            Response.Write("window.open('ViewDetailsByIndividual.aspx' ,'_blank')");
            Response.Write("</script>");
        }
    }
}