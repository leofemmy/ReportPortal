using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReportPortal.Class;

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

            var startdate = Session["Startdate"].ToString(); var enddate = Session["Enddate"].ToString();

            DateTime dt = DateTime.ParseExact(startdate, "dd/mm/yyyy", CultureInfo.InvariantCulture);

            DateTime dt2 = DateTime.ParseExact(enddate, "dd/mm/yyyy", CultureInfo.InvariantCulture);

            var gb = dt.ToString("yyyy-MM-dd");

            var gb2 = dt2.ToString("yyyy-MM-dd");

            if (Extension.GetRecordcounts(String.Format("SELECT * FROM ViewPaye WHERE MerchantCode='{0}' AND Datecreated BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' ORDER BY PayerName ASC", sessions.MerchantCode.ToString(), gb, gb2)))
            {
                Response.Write("<script>");
                Response.Write("window.open('ViewPay.aspx' ,'_blank')");
                Response.Write("</script>");
            }
            else
            {
                Extension.MsgBox("Record Not Found for Selected Range!", this.Page, this);
            }
        }
    }
}