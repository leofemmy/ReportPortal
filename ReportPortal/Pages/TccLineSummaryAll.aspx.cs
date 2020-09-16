using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportPortal
{
    public partial class TccLineSummaryAll : System.Web.UI.Page
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
            Response.Write("window.open('ViewTccLineSummaryAll.aspx' ,'_blank')");
            Response.Write("</script>");
        }
    }
}