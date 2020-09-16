using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReportPortal.Class;

namespace ReportPortal
{
    public partial class Cerificate : System.Web.UI.Page
    {
        SessionManager sessions = null;

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
            sessions = new SessionManager();

            Session["STIN"] = txtsearch.Text.ToString(); var stringstin = Session["STIN"].ToString();

            if (Extension.GetRecordcounts(String.Format("SELECT * FROM ViewCertificateInformation WHERE MerchantCode='{0}' AND PayerUtin= '{1}'", sessions.MerchantCode.ToString(), stringstin.ToString())))
            {
                Response.Write("<script>");
                Response.Write("window.open('ViewCertificate.aspx' ,'_blank')");
                Response.Write("</script>");

            }
            else
            {
                Extension.MsgBox("Record Not Found for Selected Range!", this.Page, this);
            }
        }
    }
}