using System;

namespace ReportPortal
{
    public partial class CollectionSummary : System.Web.UI.Page
    {
        SessionManager sessions = null; string strheader = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (sessions.MerchantCode == null)
            {
                Response.Redirect("~/login.aspx");

            }
        }
        protected void btnpreview_Click(object sender, EventArgs e)
        {
            //Encodings.MsgBox("You Need to Enable your Browser Pop-Up at the Top Right Corner to View the report", this.Page, this);

            txtiddisplay.Visible = true;

            if (string.IsNullOrWhiteSpace(rdbReport.SelectedValue.ToString()))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', 'Report search criteria not selected', 'error');", true);
            }
            else
            {
                //Session["Startdate"] = txtstartdate.Text.ToString();
                //Session["Enddate"] = txtenddate.Text.ToString();

                Session["Values"] = rdbReport.SelectedValue.ToString();

                Session["Startdate"] = txtstartdate.Text.ToString();

                Session["Enddate"] = txtenddate.Text.ToString();

                Session["startdate1"] = Convert.ToDateTime(txtstartdate.Text.ToString());

                Session["Enddate1"] = Convert.ToDateTime(txtenddate.Text.ToString());


                var startdate = Session["Startdate"].ToString();

                var enddate = Session["Enddate"].ToString();

                var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

                var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");


                if (string.IsNullOrWhiteSpace(txtstartdate.Text.ToString()) || string.IsNullOrWhiteSpace(txtenddate.Text.ToString()))
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Criteria is Empty !', 'error');", true);
                }
                if (Convert.ToDateTime(txtenddate.Text.ToString()) < Convert.ToDateTime(txtstartdate.Text.ToString()))
                {
                    //Encodings.MsgBox("End Date Greater Than Start Date !", this.Page, this);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! End Date Greater Than Start Date !', 'error');", true);
                }

                if (rdbReport.SelectedValue.ToString() == "1")//bank options
                {

                    Response.Write("<script>");
                    Response.Write("window.open('ViewCollectSum.aspx' ,'_blank')");
                    Response.Write("</script>");
                }

                if (rdbReport.SelectedValue.ToString() == "2")// agency options
                {

                    Response.Write("<script>");
                    Response.Write("window.open('ViewCollectSumAgency.aspx' ,'_blank')");
                    Response.Write("</script>");
                }
            }



        }
    }
}