using System;

namespace ReportPortal
{
    public partial class LineSummaryAll : System.Web.UI.Page
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
                LoadAllview();

            }
        }
        void LoadAllview()
        {
            Response.Write("<script>");
            Response.Write("window.open('ViewLineSummaryAll.aspx' ,'_blank')");
            Response.Write("</script>");
        }
    }
}