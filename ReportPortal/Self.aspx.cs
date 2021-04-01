using System;

namespace ReportPortal
{
    public partial class Self : System.Web.UI.Page
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

            if (string.IsNullOrWhiteSpace(txtstartdate.Text.ToString()) || string.IsNullOrWhiteSpace(txtenddate.Text.ToString()))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Criteria is Empty !', 'error');", true);
            }
            else if (Convert.ToDateTime(txtenddate.Text.ToString()) < Convert.ToDateTime(txtstartdate.Text.ToString()))
            {
                //Encodings.MsgBox("End Date Greater Than Start Date !", this.Page, this);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! End Date Greater Than Start Date !', 'error');", true);
            }
            else
            {
                Session["Startdate"] = txtstartdate.Text.ToString();

                Session["Enddate"] = txtenddate.Text.ToString();

                Session["startdate1"] = Convert.ToDateTime(txtstartdate.Text.ToString());

                Session["Enddate1"] = Convert.ToDateTime(txtenddate.Text.ToString());


                var startdate = Session["Startdate"].ToString();

                var enddate = Session["Enddate"].ToString();

                var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

                var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");


                if (Encodings.IsValidUser(String.Format("SELECT * FROM ViewTaxPayer WHERE MerchantCode='{0}' AND Datecreated BETWEEN '{1}' AND '{2}'AND TaxAgentReferenceNumber IS NULL  ORDER BY Surname ASC",
                    sessions.MerchantCode.ToString(), startdate, enddate)))
                {
                    Response.Write("<script>");
                    Response.Write("window.open('Viewself.aspx' ,'_blank')");
                    Response.Write("</script>");
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', ' No Record Found for the Selected Range !', 'Info');", true);
                }
            }
        }
    }
}