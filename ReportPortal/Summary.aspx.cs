﻿using System;

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
            txtiddisplay.Visible = true;

            if (string.IsNullOrWhiteSpace(txtstartdate.Text.ToString()))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Start Date is Empty !', 'error');", true);
            }
            else if (string.IsNullOrWhiteSpace(txtenddate.Text.ToString()))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! End Date is Empty !', 'error');", true);
            }
            else if (Convert.ToDateTime(txtenddate.Text.ToString()) < Convert.ToDateTime(txtstartdate.Text.ToString()))
            {
                //Encodings.MsgBox("End Date Greater Than Start Date !", this.Page, this);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! End Date Greater Than Start Date !', 'error');", true);
            }

            else
            {
                Session["Startdate"] = Convert.ToDateTime(txtstartdate.Text).ToString("yyyy-MM-dd 00:00:00");//txtstartdate.Text.ToString();

                Session["Enddate"] = Convert.ToDateTime(txtenddate.Text).ToString("yyyy-MM-dd 23:59:59");//txtenddate.Text.ToString();

                Session["startdate1"] = Convert.ToDateTime(txtstartdate.Text.ToString());

                Session["Enddate1"] = Convert.ToDateTime(txtenddate.Text.ToString());


                var startdate = Session["Startdate"].ToString();

                var enddate = Session["Enddate"].ToString();

                var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

                var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");


                if (Encodings.IsValidUser(String.Format(
                    "SELECT RegTypeCode,  COUNT(RegTypeCode) Rec_Count, CASE WHEN RegTypeCode = 'AG' THEN 'Tax Agents' WHEN RegTypeCode = 'DA' THEN 'Self-Employed' WHEN RegTypeCode = 'PA' THEN  'Employed'  ELSE  'Adoch'  END Category FROM dbo.vwPayerInfo  WHERE PayerName IS NOT NULL AND MerchantCode='{0}' AND Datecreated BETWEEN '{1}' AND '{2}' GROUP BY RegTypeCode HAVING COUNT(RegTypeCode) > 0 ORDER BY Category asc",
                    sessions.MerchantCode.ToString(), startdate, enddate)))
                {
                    Response.Write("<script>");
                    Response.Write("window.open('VwSummary.aspx' ,'_blank')");
                    Response.Write("</script>");
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', ' No Record Found for the Selected Range !', 'info');", true);
                }
            }
        }
    }
}