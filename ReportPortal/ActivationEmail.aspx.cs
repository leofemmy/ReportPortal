using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class ActivationEmail : System.Web.UI.Page
    {
        string myDataUnencoded = string.Empty; string activationCode = string.Empty; SessionManager sessions = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (!IsPostBack)
            {
                Label1.Text = !string.IsNullOrEmpty(Request.QueryString["verify"]) ? Request.QueryString["verify"] : Guid.Empty.ToString();

                activationCode = !string.IsNullOrEmpty(Request.QueryString["verify"]) ? Request.QueryString["verify"] : Guid.Empty.ToString();

                Label1.Text = Encodings.DecodeFrom64(activationCode);

                myDataUnencoded = Encodings.DecodeFrom64(activationCode);

                var gh = myDataUnencoded.Split(';');

                sessions.Activecode = gh[0].ToString();

                sessions.Email = gh[1].ToString();

                sessions.MerchantCode = gh[2].ToString();

                txtemail.Text = gh[1].ToString();

                txtemail.Visible = false;
                //pass();
            }
        }

        void doupdate()
        {
            sessions = new SessionManager();

            if (sessions.MerchantCode == null)
            {
                Response.Redirect("~/Signup.aspx");
            }
            else
            {
                Guid userGuid = System.Guid.NewGuid();

                string hashedPassword = Security.HashSHA1(txtpassword.Text.Trim().ToString() + userGuid.ToString());

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
                    _command = new SqlCommand("doactiivatenewuser", connect) { CommandType = CommandType.StoredProcedure };
                    _command.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = txtemail.Text.ToString();

                    _command.Parameters.Add(new SqlParameter("@MerchantCode", SqlDbType.VarChar)).Value =
                        sessions.MerchantCode.ToString();
                    _command.Parameters.Add(new SqlParameter("@PasswordHas", SqlDbType.VarChar)).Value = hashedPassword;
                    _command.Parameters.Add(new SqlParameter("@UserGuid", SqlDbType.UniqueIdentifier)).Value = userGuid;
                    _command.CommandTimeout = 0;
                    response.Clear();
                    _adp = new SqlDataAdapter(_command);
                    _adp.Fill(response);

                    connect.Close();

                    if (response.Tables[0].Rows[0]["returnCode"].ToString() == "00")
                    {
                        //redirect to log in page
                        Response.Redirect("~/login.aspx");

                    }
                    else
                    {
                        //display error message
                        Response.Write("<script language='javascript'>alert('" +
                                       Server.HtmlEncode(response.Tables[0].Rows[0]["returnMessage"].ToString()) + "')</script>");
                    }
                }
            }


        }
        protected void btnsubmit_OnClick(object sender, EventArgs e)
        {
            doupdate();
        }
    }
}