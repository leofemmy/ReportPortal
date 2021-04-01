using DevExpress.XtraReports.UI;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class ViewAgent : System.Web.UI.Page
    {
        SessionManager sessions = null; string strheader = String.Empty; private DateTime startdate, endate;

        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (sessions.MerchantCode == null)
            {
                Response.Redirect("~/login.aspx");

            }

            calReport();
        }

        void calReport()
        {
            //ASPxDocumentViewer1.Report = CreateReport();
            //ASPxDocumentViewer1.DataBind();
            sessions = new SessionManager();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet(); string strquery = String.Empty;

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

            var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");

            XtraAgent agent = new XtraAgent();


            //XtraRepPayerlineSummary obj_Rpt = new XtraRepPayerlineSummary();

            if (sessions.MerchantCode.ToString() == "DTSS")
            {
                strheader = "DELTA STATE GOVERNMENT";

                agent.xrPictureBox1.Visible = true;

                agent.xrPictureBox2.Visible = false;

                agent.xrPictureBox3.Visible = false;

            }

            if (sessions.MerchantCode.ToString() == "OGSS")
            {
                strheader = "OGUN STATE GOVERNMENT";

                agent.xrPictureBox1.Visible = false;

                agent.xrPictureBox2.Visible = true;

                agent.xrPictureBox3.Visible = false;
            }

            if (sessions.MerchantCode.ToString() == "OYSS")
            {
                strheader = "OYO STATE GOVERNMENT";

                agent.xrPictureBox1.Visible = false;

                agent.xrPictureBox2.Visible = false;

                agent.xrPictureBox3.Visible = true;
            }

            strquery = String.Format("SELECT * FROM ViewTaxAgent WHERE MerchantCode='{0}' AND Datecreated BETWEEN '{1}' AND '{2}' ORDER BY OrganizationName ASC", sessions.MerchantCode.ToString(), startdate, enddate);

            using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString))
            {
                connect.Open();
                _command = new SqlCommand(strquery, connect) { CommandType = CommandType.Text };
                _command.CommandTimeout = 0;
                responses.Clear();
                _adp = new SqlDataAdapter(_command);
                _adp.Fill(responses);
                connect.Close();

            }

            if (responses.Tables[0] != null && responses.Tables[0].Rows.Count > 1)
            {
                //string.Format("From {0:dd/MM/yyyy}  To {1:dd/MM/yyyy}", strat, end)
                agent.xrlborghead.Text = strheader;

                agent.xrlbsubHead2.Text = String.Format(" From {0:dd/MM/yyyy} To {1:dd/MM/yyyy} ", strat, end);

                agent.DataSource = responses;
                agent.DataMember = responses.Tables[0].TableName;

                //agent.CreateDocument();

                //obj_Rpt.xrLabel10.Text = string.Format("From: {0}  To: {1}", Session["Fromyear"].ToString(), Session["Toyear"].ToString());
                //obj_Rpt.Report.DataSource = responses;
                //obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(agent);
            }
        }

        XtraReport CreateReport()
        {
            sessions = new SessionManager();

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

            var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");

            XtraAgent agent = new XtraAgent();


            if (sessions.MerchantCode.ToString() == "DTSS")
            {
                strheader = "DELTA STATE GOVERNMENT";

                agent.xrPictureBox1.Visible = true;

                agent.xrPictureBox2.Visible = false;

                agent.xrPictureBox3.Visible = false;

            }

            if (sessions.MerchantCode.ToString() == "OGSS")
            {
                strheader = "OGUN STATE GOVERNMENT";

                agent.xrPictureBox1.Visible = false;

                agent.xrPictureBox2.Visible = true;

                agent.xrPictureBox3.Visible = false;
            }

            if (sessions.MerchantCode.ToString() == "OYSS")
            {
                strheader = "OYO STATE GOVERNMENT";

                agent.xrPictureBox1.Visible = false;

                agent.xrPictureBox2.Visible = false;

                agent.xrPictureBox3.Visible = true;
            }

            //string.Format("From {0:dd/MM/yyyy}  To {1:dd/MM/yyyy}", strat, end)
            agent.xrlborghead.Text = strheader;

            agent.xrlbsubHead2.Text = String.Format(" From {0:dd/MM/yyyy} To {1:dd/MM/yyyy} ", strat, end);

            agent.DataSource = dts();
            agent.DataMember = "ViewTaxAgent";

            agent.CreateDocument();

            return agent;
        }

        DataSet dts()
        {
            sessions = new SessionManager();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet(); string strquery = String.Empty;

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

            var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");


            strquery = String.Format("SELECT * FROM ViewTaxAgent WHERE MerchantCode='{0}' AND Datecreated BETWEEN '{1}' AND '{2}' ORDER BY OrganizationName ASC", sessions.MerchantCode.ToString(), startdate, enddate);

            using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString))
            {
                connect.Open();
                _command = new SqlCommand(strquery, connect) { CommandType = CommandType.Text };
                _command.CommandTimeout = 0;
                responses.Clear();
                _adp = new SqlDataAdapter(_command);
                _adp.Fill(responses);
                connect.Close();

            }

            if (responses.Tables[0] != null && responses.Tables[0].Rows.Count > 1)
            {
            }

            return responses;
        }
    }
}