using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportPortal
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clearform();

                lblerror.Visible = false;
            }
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {

        }
        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {

                return false;

            }
        }

        void clearform()
        {
            txtpassword.Value = String.Empty;

        }
        protected void SendLoginMail(string sendaddress)
        {
            try
            {

                string actcode = "DTSS" + Guid.NewGuid().ToString().Replace("-", string.Empty);

                string activationCode = Encodings.EncodeTo64(string.Format("{0};{1};{2}",
                    actcode, sendaddress.ToString(), "DTSS"));

                string url = string.Format("http://{0}{1}", Request.Url.Authority,
                    ResolveUrl("ActivationEmail.aspx"));
                string urls = string.Format("{0}{1}", url, string.Format("?verify={0}", activationCode)); Console.WriteLine(url);

                string smtpAddress = ConfigurationManager.AppSettings["SMTPHost"];
                int portNumber = int.Parse(ConfigurationManager.AppSettings["SMTPPort"]);
                bool enableSSL = true;

                string emailFrom = ConfigurationManager.AppSettings["SMTPAddress"];
                string password = ConfigurationManager.AppSettings["SMTPPassword"];
                string emailTo = sendaddress;
                string subject = ConfigurationManager.AppSettings["EmailSubject"];
                string body = "Dear <p></p><br/> " + sendaddress + ",<p></p><br/> <br/>Your password have been Reset.  <p></p><br/><br><a href=" + urls + "> Click Here for New Password </a> <br/>  <p></p><br/> Thanks you<br/><p></p><p></p>Regards,<p></p><p></p><br/><br/>Mail  Team";


                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    if (IsValidEmail(sendaddress.ToString()))
                    {
                        mail.To.Add(sendaddress);
                    }

                    mail.Subject = "Account Notification";
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    //SaveMail();

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                        //sent = true;
                    }
                }
            }
            catch (Exception ex)
            {

                //logger.Error(ex.Message, "Error occured!");
                lblerror.Text = ex.Message.ToString();
                lblerror.Visible = true;
            }
            finally
            {

            }
        }
        protected void Button1_OnClick(object sender, EventArgs e)
        {
            //send email
            SendLoginMail(txtpassword.Value.ToString());
            //display error message
            string strmess = "Kindly check provide mail for confirmation";
            //Response.Write("<script language='javascript'>alert('" +
            //               Server.HtmlEncode(response.Tables[0].Rows[0]["returnMessage"].ToString()) + "')</script>");

            Response.Write("<script language='javascript'>alert('" +
                           Server.HtmlEncode(strmess.ToString()) + "')</script>");

            clearform();
            Response.Redirect("~/login.aspx");
        }
    }
}