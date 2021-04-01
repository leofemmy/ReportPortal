using System;

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
            txtiddisplay.Visible = true;

            if (string.IsNullOrWhiteSpace(txtsearch.Text.ToString()))
            {
                //Encodings.MsgBox("! Criteria is Empty !", this.Page, this);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Criteria is Empty !', 'error');", true);
            }
            else
            {
                Session["STIN"] = txtsearch.Text.ToString();

                var stringstin = Session["STIN"].ToString();


                string strquery = String.Format("SELECT * FROM ViewCertificateInformation WHERE MerchantCode='{0}' AND PayerUtin= '{1}'", sessions.MerchantCode.ToString(), stringstin.ToString());

                if (Encodings.IsValidUser(strquery))
                {
                    Response.Write("<script>");
                    Response.Write("window.open('ViewCertificate.aspx' ,'_blank')");
                    Response.Write("</script>");
                }
                else
                {
                    //Encodings.MsgBox("! No Record Found for the Selected Range !", this.Page, this);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', ' No Record Found for the Selected Range !', 'info');", true);
                }
            }
        }
    }
}