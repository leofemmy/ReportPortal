using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ReportPortal
{
    public partial class PortalSite : System.Web.UI.MasterPage
    {
        SessionManager sessions = null;
        public Label lblusertpe = new Label();
        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();
            //Page.Header.DataBind();

            if (!IsPostBack)
            {


                if (sessions.MerchantCode == null && sessions.fullname == null)
                {
                    Response.Redirect("~/login.aspx");
                }
                else
                {
                    getrecord();

                    txtuser.Text = sessions.fullname.ToString();

                    lblusertpe.Text = sessions.usertype.ToString();

                    if (lblusertpe.Text.ToString().Equals("A"))
                    {
                        liuser.Visible = true;
                        liuserreport.Visible = true;
                        pagestaxreport.Visible = false;
                        pagesreg.Visible = false;
                        pagespayemts.Visible = false;
                        pagescollection.Visible = false;
                    }
                    else
                    {
                        liuser.Visible = false;
                        liuserreport.Visible = false;
                        pagestaxreport.Visible = true;
                        pagesreg.Visible = true;
                        pagespayemts.Visible = true;
                        pagescollection.Visible = true;
                    }
                    //lbluser.Text = sessions.fullname.ToString();
                    //lblagent.Text = sessions.Agent.ToString();
                    //lblpaye.Text = sessions.Paye.ToString();
                    //lblself.Text = sessions.Employee.ToString();
                }
            }

        }

        void getrecord()
        {
            sessions = new SessionManager();

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
                _command = new SqlCommand("dogettaxInformation", connect) { CommandType = CommandType.StoredProcedure };
                _command.Parameters.Add(new SqlParameter("@MerchantCode", SqlDbType.VarChar)).Value = sessions.MerchantCode.ToString();
                _command.CommandTimeout = 0;
                response.Clear();
                _adp = new SqlDataAdapter(_command);
                _adp.Fill(response);

                connect.Close();

            }

            if (response.Tables[0] != null && response.Tables[0].Rows.Count > 0)
            {

                sessions.Agent = Convert.ToDecimal(response.Tables[0].Rows[0]["Agent"].ToString());
                sessions.Paye = Convert.ToDecimal(response.Tables[0].Rows[0]["Paye"].ToString());
                sessions.Employee = Convert.ToDecimal(response.Tables[0].Rows[0]["Employee"].ToString());
                ;
            }
        }
    }
}