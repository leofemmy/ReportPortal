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
    public partial class ViewCollectSumAgency : System.Web.UI.Page
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


            CreateReports();

        }
        void CreateReports()
        {
            XtraRepCollAgency agency = new XtraRepCollAgency();

            if (sessions.MerchantCode.ToString() == "DTSS")
            {
                strheader = "DELTA STATE GOVERNMENT";

                agency.xrPictureBox1.Visible = true;

                agency.xrPictureBox2.Visible = false;

                agency.xrPictureBox3.Visible = false;

            }
            if (sessions.MerchantCode.ToString() == "OGSS")
            {
                strheader = "OGUN STATE GOVERNMENT";

                agency.xrPictureBox1.Visible = false;

                agency.xrPictureBox2.Visible = true;

                agency.xrPictureBox3.Visible = false;
            }
            if (sessions.MerchantCode.ToString() == "OYSS")
            {
                strheader = "OYO STATE GOVERNMENT";

                agency.xrPictureBox1.Visible = false;

                agency.xrPictureBox2.Visible = false;

                agency.xrPictureBox3.Visible = true;
            }

            agency.xrlborghead.Text = strheader;

            agency.xrLabel1.Text = String.Format(" From {0:dd/MM/yyyy} To {1:dd/MM/yyyy} ", Session["Startdate"].ToString(), Session["Enddate"].ToString());

            sessions = new SessionManager();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet(); string strquery = String.Empty;

            var val = Session["Values"].ToString();

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            DateTime dt = DateTime.ParseExact(startdate, "dd/mm/yyyy", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(enddate, "dd/mm/yyyy", CultureInfo.InvariantCulture);

            //Console.WriteLine(dt.ToString("yyyy-MM-dd"));

            var gb = dt.ToString("yyyy-MM-dd");
            var gb2 = dt2.ToString("yyyy-MM-dd");


            strquery = String.Format("SELECT AgencyName, AgencyCode,SUM(Amount) Amount FROM dbo.vwCollection WHERE PaymentDate BETWEEN '{0}' AND '{1}' GROUP BY AgencyName, AgencyCode ORDER BY AgencyName ASC", gb, gb2);

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
                agency.DataSource = responses;

                agency.DataMember = responses.Tables[0].TableName;

                //agency.CreateDocument();

                ASPxWebDocumentViewer1.OpenReport(agency);
            }

        }
       
        [System.Web.Services.WebMethod]
        public static void loadchildreport(string stragency)
        {
            ViewCollectSumAgency vp = new ViewCollectSumAgency();


            var varagency = stragency;

            vp.callReport2(varagency);


        }

        void callReport2(string stragencyname)
        {
            Session["AgencyName"] = stragencyname;

        }
    }
}