using System;

namespace ReportPortal
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtemail.Value.ToString()) || string.IsNullOrWhiteSpace(txtpassword.Value.ToString()))
            {
                Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode("Log in details Empty") + "')</script>");

            }
            else
            {
                if (Security.CheckUserLogin(txtemail.Value.Trim().ToString(), txtpassword.Value.Trim().ToString()))
                {
                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode("Error in log in details due to password failure") + "')</script>");
                }
            }
        }
    }
}