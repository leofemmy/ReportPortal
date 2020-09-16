using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ReportPortal
{
    public class Security
    {
        public static string HashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static bool CheckUserLogin(string stremail, string strpassword)
        {
            SessionManager sessions = null;

            sessions = new SessionManager();


            bool bresponse = false; SqlCommand _command;

            SqlDataAdapter _adp;

            System.Data.DataSet response = new System.Data.DataSet();

            if (string.IsNullOrWhiteSpace(stremail.ToString()) || string.IsNullOrWhiteSpace(strpassword.ToString()))
            {
                //Response.Write("<script language='javascript'>alert('" +
                //               Server.HtmlEncode("Error in log in details") + "')</script>");
                bresponse = false;
            }
            else
            {
                using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString))
                {
                    if (connect.State != ConnectionState.Closed)
                    {
                        connect.Close();
                    }

                    connect.Open();
                    _command = new SqlCommand("dogetUserInformation", connect) { CommandType = CommandType.StoredProcedure };
                    _command.Parameters.Add(new SqlParameter("@emailAddress", SqlDbType.VarChar)).Value = stremail;
                    _command.CommandTimeout = 0;
                    response.Clear();
                    _adp = new SqlDataAdapter(_command);
                    _adp.Fill(response);

                    connect.Close();

                }

                if (response.Tables[0] != null && response.Tables[0].Rows.Count > 0)
                {

                    string dbPassword = response.Tables[0].Rows[0]["PasswordHas"].ToString();

                    string dbUserGuid = response.Tables[0].Rows[0]["UserGuid"].ToString();

                    string strusertype = response.Tables[0].Rows[0]["UserType"].ToString();

                    string fullname = String.Format("{0} {1}", response.Tables[0].Rows[0]["FirstName"].ToString().ToUpper(), response.Tables[0].Rows[0]["LastName"].ToString());
                    ;
                    string MerchantCode = response.Tables[0].Rows[0]["MerchantCode"].ToString();

                    string hashedPassword = Security.HashSHA1(strpassword.ToString() + dbUserGuid);

                    if (dbPassword == hashedPassword)
                    {
                        // The password is correct
                        //userId = dbUserId;
                        sessions.fullname = fullname.ToString();

                        sessions.MerchantCode = MerchantCode.ToString();

                        sessions.usertype = strusertype.ToString();

                        bresponse = true;
                    }
                    else
                    {

                    }
                }
            }

            return bresponse;
        }
    }
}