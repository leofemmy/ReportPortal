using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace ReportPortal
{
    public partial class Users : System.Web.UI.Page
    {
        SessionManager sessions = null; DataSet dsm = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (!IsPostBack)
            {
                clearform();

                if (IsLocal) return;

                var url = GetDomainNameFromRequest(Request);

                getsetting(url);

                lblerror.Visible = false;
            }
        }

        public static bool IsLocal => System.Web.HttpContext.Current.Request.Url.Authority.Contains("localhost");

        public static string GetDomainNameFromRequest(HttpRequest request)
        {
            var match = Regex.Match(request.Url.Host, "([^.]+\\.[^.]{1,3}(\\.[^.]{1,3})?)$");
            var domain = match.Groups[1].Success ? match.Groups[1].Value : null;
            return domain;
        }

        void getsetting(string strurl)
        {
            //strurl = "femsyogun.com";

            sessions = new SessionManager();

            dsm = getuserrequest(strurl);

            if (dsm != null && dsm.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in dsm.Tables[0].Rows)
                {
                    ViewState["MHost"] = item["Host"].ToString();
                    ViewState["MEnableSsls"] = Convert.ToBoolean(item["EnableSsl"].ToString());
                    ViewState["EnableSSl"] = Convert.ToBoolean(item["EnableSsl"].ToString());
                    ViewState["MMerchantCode"] = item["MerchantCode"].ToString();
                    ViewState["MPassword"] = item["Password"].ToString();
                    ViewState["MPort"] = item["Port"].ToString();
                    ViewState["MSenderDisplayName"] = item["SenderDisplayName"].ToString();
                    ViewState["MUsername"] = item["Username"].ToString();
                    ViewState["StateName"] = item["StateName"].ToString();
                    ViewState["stateid"] = item["StateID"].ToString();
                    ViewState["CountryCode"] = item["CountryCode"].ToString();
                    //idstate.Text = item["StateName"].ToString();
                    //ddlState.SelectedValue = (string)ViewState["MMerchantCode"];
                    sessions.MerchantCode = ViewState["MMerchantCode"] as string;
                    //sessions.StateName = item["StateName"].ToString();
                    // ddlState.Enabled = false;
                    //sessions.MHost = item["Host"].ToString();
                    //sessions.MEnableSsls = Convert.ToBoolean(item["EnableSsl"].ToString());
                    //EnableSSl = Convert.ToBoolean(item["EnableSsl"].ToString());
                    //sessions.MMerchantCode = item["MerchantCode"].ToString();
                    //sessions.MPassword = item["Password"].ToString();
                    //sessions.MPort = item["Port"].ToString();
                    //sessions.MSenderDisplayName = item["SenderDisplayName"].ToString();
                    //sessions.MUsername = item["Username"].ToString();
                    //sessions.StateName = item["StateName"].ToString();
                    //sessions.stateid = item["StateID"].ToString();
                    //sessions.CountryCode = item["CountryCode"].ToString();
                }
            }
        }

        void clearform()
        {
            txtemail.Value = String.Empty;
            txtfirst.Value = String.Empty; txtlast.Value = String.Empty;

        }

        protected void SendLoginMail(string sendaddress)
        {
            try
            {

                string actcode = (string)ViewState["MMerchantCode"] + Guid.NewGuid().ToString().Replace("-", string.Empty);

                string activationCode = Encodings.EncodeTo64(string.Format("{0};{1};{2}",
                    actcode, txtemail.Value.ToString(), (string)ViewState["MMerchantCode"] //ddlState.SelectedValue.ToString()
                    ));

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
                string body = "Dear <p></p><br/> " + sendaddress + ",<p></p><br/> <br/>Your account have sucessfully been created.  <p></p><br/><br><a href=" + urls + "> Activate Here </a> <br/>  <p></p><br/> Thanks you<br/><p></p><p></p>Regards,<p></p><p></p><br/><br/>Mail  Team";


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

        DataSet getuserrequest(string strrequest)
        {
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
                _command = new SqlCommand("GetMerchantMailSetting", connect) { CommandType = CommandType.StoredProcedure };
                _command.Parameters.Add(new SqlParameter("@strul", SqlDbType.VarChar)).Value = strrequest;
                _command.CommandTimeout = 0;
                response.Clear();
                _adp = new SqlDataAdapter(_command);
                _adp.Fill(response);

                connect.Close();

            }

            return response;
        }

        void douser()
        {
            DataSet dt = new DataSet();

            Guid userGuid = System.Guid.NewGuid();

            string strpass = "password";

            string hashedPassword = Security.HashSHA1(strpass.ToString() + userGuid.ToString());

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
                _command = new SqlCommand("doInsertnewuser", connect) { CommandType = CommandType.StoredProcedure };
                _command.Parameters.Add(new SqlParameter("@merchantcode", SqlDbType.VarChar)).Value =
                    (string)ViewState["MMerchantCode"];//ddlState.SelectedValue;
                _command.Parameters.Add(new SqlParameter("@LastName", SqlDbType.VarChar)).Value = txtlast.Value.Trim();
                _command.Parameters.Add(new SqlParameter("@firstname", SqlDbType.VarChar)).Value = txtfirst.Value.Trim();
                _command.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = txtemail.Value.Trim();
                _command.Parameters.Add(new SqlParameter("@PasswordHas", SqlDbType.VarChar)).Value = hashedPassword;
                _command.Parameters.Add(new SqlParameter("@UserGuid", SqlDbType.UniqueIdentifier)).Value = userGuid;
                _command.CommandTimeout = 0;
                response.Clear();
                _adp = new SqlDataAdapter(_command);
                _adp.Fill(response);

                connect.Close();

                if (response.Tables[0].Rows[0]["returnCode"].ToString() == "00")
                {
                    //send email
                    SendLoginMail(txtemail.Value.ToString());
                    //display error message
                    string strmess = "Kindly check provide mail for confirmation";

                    Response.Write("<script language='javascript'>alert('" +
                                   Server.HtmlEncode(response.Tables[0].Rows[0]["returnMessage"].ToString()) + "')</script>");

                    Response.Write("<script language='javascript'>alert('" +
                                   Server.HtmlEncode(strmess.ToString()) + "')</script>");

                    lblerror.Text = response.Tables[0].Rows[0]["returnMessage"].ToString();

                    lblerror.Visible = true;
                }
                else
                {
                    //display error message
                    Response.Write("<script language='javascript'>alert('" +
                                   Server.HtmlEncode(response.Tables[0].Rows[0]["returnMessage"].ToString()) + "')</script>");
                    lblerror.Text = response.Tables[0].Rows[0]["returnMessage"].ToString();
                    lblerror.Visible = true;
                }
            }
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            douser();
            clearform();
            Response.Redirect("~/login.aspx");
        }
    }
}