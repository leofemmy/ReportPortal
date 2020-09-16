using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ReportPortal
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        string strMerchant = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
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
        protected void SendLoginMail(string sendaddress)

        {
            try
            {

                string actcode = strMerchant.ToString() + Guid.NewGuid().ToString().Replace("-", string.Empty);

                string activationCode = Encodings.EncodeTo64(string.Format("{0};{1};{2}",
                    actcode, txtemail.Value.ToString(), strMerchant.ToString()));

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
                string body = "Dear <p></p><br/> " + sendaddress + ",<p></p><br/> <br/>Your account password reset request received sucessfully. <p>Click here, if you made a request</p><br/><br><a href=" + urls + ">  Reset Password </a> <br/>  <p>or ingore the request.</p><br/> Thanks you<br/><p></p><p></p>Regards,<p></p><p></p><br/><br/>Mail  Team";

                //< strong style = "text-decoration: none; font-size: 22px; font-weight: bold; color: #fff; outline: none" >< span style = "padding-bottom: 20px; padding-top: 20px; padding-left: 40px; padding-right: 40px; display: inline-block; background-color: #1d9092; border-radius: 50px" > Confirm Email </ span ></ strong >

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
                //lblerror.Text = ex.Message.ToString();
                //lblerror.Visible = true;
            }
            finally
            {

            }
        }
        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            try
            {
                douser();
                //send email
                SendLoginMail(txtemail.Value.ToString());
                //display error message
                string strmess = "Kindly check provide mail for confirmation";
                //Response.Write("<script language='javascript'>alert('" +
                //               Server.HtmlEncode(response.Tables[0].Rows[0]["returnMessage"].ToString()) + "')</script>");

                Response.Write("<script language='javascript'>alert('" +
                               Server.HtmlEncode(strmess.ToString()) + "')</script>");

                Response.Redirect("~/login.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }

        void douser()
        {
            DataSet dt = new DataSet();

            SqlCommand _command;

            SqlDataAdapter _adp;

            System.Data.DataSet response = new System.Data.DataSet();

            using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString))
            {
                if (connect.State != ConnectionState.Closed)
                {
                    connect.Close();
                }

                connect.Open();
                _command = new SqlCommand("dogetUserResetemail", connect) { CommandType = CommandType.StoredProcedure };
                _command.Parameters.Add(new SqlParameter("@emailaddress", SqlDbType.VarChar)).Value =
                    txtemail.Value.ToString();

                _command.CommandTimeout = 0;
                response.Clear();
                _adp = new SqlDataAdapter(_command);
                _adp.Fill(response);

                connect.Close();

                if (response.Tables[0] != null && response.Tables[0].Rows.Count > 0)
                {
                    strMerchant = response.Tables[0].Rows[0]["MerchantCode"].ToString();
                }

            }
        }
    }
}
