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