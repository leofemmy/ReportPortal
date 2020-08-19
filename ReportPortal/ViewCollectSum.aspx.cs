using DevExpress.XtraReports.UI;
using ReportPortal.Reports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportPortal
{
    public partial class ViewCollectSum : System.Web.UI.Page
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
            var val = Session["Values"].ToString();

            if (val == "1")
            {
                CreateReport();
            }
        }


        void CreateReport()
        {
            sessions = new SessionManager();

            //XtraAgent agent = new XtraAgent();
            RepCollBank collBank = new RepCollBank();

            if (sessions.MerchantCode.ToString() == "DTSS")
            {
                strheader = "DELTA STATE GOVERNMENT";

                collBank.xrPictureBox1.Visible = true;

                collBank.xrPictureBox2.Visible = false;

                collBank.xrPictureBox3.Visible = false;

            }
            if (sessions.MerchantCode.ToString() == "OGSS")
            {
                strheader = "OGUN STATE GOVERNMENT";

                collBank.xrPictureBox1.Visible = false;

                collBank.xrPictureBox2.Visible = true;

                collBank.xrPictureBox3.Visible = false;
            }
            if (sessions.MerchantCode.ToString() == "OYSS")
            {
                strheader = "OYO STATE GOVERNMENT";

                collBank.xrPictureBox1.Visible = false;

                collBank.xrPictureBox2.Visible = false;

                collBank.xrPictureBox3.Visible = true;
            }


            collBank.xrlborghead.Text = strheader;

            collBank.xrLabel1.Text = String.Format(" From {0:dd/MM/yyyy} To {1:dd/MM/yyyy} ", Session["Startdate"].ToString(), Session["Enddate"].ToString());

            sessions = new SessionManager();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet(); string strquery = String.Empty;

            //Session["Values"] = rdbReport.SelectedValue.ToString();

            var val = Session["Values"].ToString();

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            DateTime dt = DateTime.ParseExact(startdate, "dd/mm/yyyy", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(enddate, "dd/mm/yyyy", CultureInfo.InvariantCulture);

            //Console.WriteLine(dt.ToString("yyyy-MM-dd"));

            var gb = dt.ToString("yyyy-MM-dd");
            var gb2 = dt2.ToString("yyyy-MM-dd");

            strquery = String.Format("SELECT BankName,BankCode,SUM(Amount) Amount FROM dbo.vwCollection WHERE PaymentDate BETWEEN '{0}' AND '{1}' GROUP BY BankName,  BankCode ORDER BY BankName ASC", gb, gb2);


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
                collBank.DataSource = responses;
                collBank.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(collBank);
            }


        }
        DataSet dts()
        {
            sessions = new SessionManager();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet(); string strquery = String.Empty;

            //Session["Values"] = rdbReport.SelectedValue.ToString();

            var val = Session["Values"].ToString();

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            DateTime dt = DateTime.ParseExact(startdate, "dd/mm/yyyy", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(enddate, "dd/mm/yyyy", CultureInfo.InvariantCulture);

            //Console.WriteLine(dt.ToString("yyyy-MM-dd"));

            var gb = dt.ToString("yyyy-MM-dd");
            var gb2 = dt2.ToString("yyyy-MM-dd");

            if (val == "1")// banks options
            {
                strquery = String.Format("SELECT BankName,BankCode,SUM(Amount) Amount FROM dbo.vwCollection WHERE PaymentDate BETWEEN '{0}' AND '{1}' GROUP BY BankName,  BankCode ORDER BY BankName ASC", gb, gb2);
            }
            else // agency options
            {
                strquery = String.Format("SELECT AgencyName, AgencyCode,SUM(Amount) Amount FROM dbo.vwCollection WHERE PaymentDate BETWEEN '{0}' AND '{1}' GROUP BY AgencyName, AgencyCode ORDER BY AgencyName ASC", gb, gb2);
            }


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


        [System.Web.Services.WebMethod]
        public static void loadchildreport(string stragency)
        {
            ViewCollectSum vp = new ViewCollectSum();

            var varagency = stragency;

            vp.callReport2(varagency);


        }

        void callReport2(string stragencyname)
        {
            Session["AgencyName"] = stragencyname;

        }
    }
}