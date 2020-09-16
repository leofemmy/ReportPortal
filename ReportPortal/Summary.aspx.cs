using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportPortal
{
    public partial class Summary : System.Web.UI.Page
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

            Session["startdate1"] = Convert.ToDateTime(txtstartdate.Text.ToString());

            Session["Enddate1"] = Convert.ToDateTime(txtenddate.Text.ToString());
            

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

            var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");


            if (Encodings.IsValidUser(String.Format("SELECT RegTypeCode,  COUNT(RegTypeCode) Rec_Count, CASE WHEN RegTypeCode = 'AG' THEN 'Tax Agents' WHEN RegTypeCode = 'DA' THEN 'Self-Employed' WHEN RegTypeCode = 'PA' THEN  'Employed'  ELSE  'Adoch'  END Category FROM dbo.vwPayerInfo  WHERE PayerName IS NOT NULL AND MerchantCode='{0}' AND Datecreated BETWEEN '{1}' AND '{2}' GROUP BY RegTypeCode HAVING COUNT(RegTypeCode) > 0 ORDER BY Category asc", sessions.MerchantCode.ToString(), startdate, enddate)))
            {
                Response.Write("<script>");
                Response.Write("window.open('VwSummary.aspx' ,'_blank')");
                Response.Write("</script>");
            }
            else
            {
                Encodings.MsgBox("! No Record Found for the Selected Range !", this.Page, this);
            }
        }
    }
}