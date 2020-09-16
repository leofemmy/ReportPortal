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
    public partial class ViewCollectSummaryAgencyChild : System.Web.UI.Page
    {
        SessionManager sessions = null;
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


            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();


            var valagencyname = Session["AgencyName"].ToString();

            DateTime dt = DateTime.ParseExact(startdate, "dd/mm/yyyy", CultureInfo.InvariantCulture);

            DateTime dt2 = DateTime.ParseExact(enddate, "dd/mm/yyyy", CultureInfo.InvariantCulture);

            //Console.WriteLine(dt.ToString("yyyy-MM-dd"));

            var gb = dt.ToString("yyyy-MM-dd");
            var gb2 = dt2.ToString("yyyy-MM-dd");


            //strquery = String.Format("SELECT AgencyName, AgencyCode,SUM(Amount) Amount FROM dbo.vwCollection WHERE PaymentDate BETWEEN '{0}' AND '{1}' GROUP BY AgencyName, AgencyCode ORDER BY AgencyName ASC", gb, gb2);
            string strheader = String.Empty;

            XtraRepRevenue obj_Rpt = new XtraRepRevenue();


            if (sessions.MerchantCode.ToString() == "DTSS")
            {
                strheader = "DELTA STATE GOVERNMENT";

                obj_Rpt.xrPictureBox1.Visible = true;

                obj_Rpt.xrPictureBox2.Visible = false;

                obj_Rpt.xrPictureBox3.Visible = false;

            }
            if (sessions.MerchantCode.ToString() == "OGSS")
            {
                strheader = "OGUN STATE GOVERNMENT";

                obj_Rpt.xrPictureBox1.Visible = false;

                obj_Rpt.xrPictureBox2.Visible = true;

                obj_Rpt.xrPictureBox3.Visible = false;
            }
            if (sessions.MerchantCode.ToString() == "OYSS")
            {
                strheader = "OYO STATE GOVERNMENT";

                obj_Rpt.xrPictureBox1.Visible = false;

                obj_Rpt.xrPictureBox2.Visible = false;

                obj_Rpt.xrPictureBox3.Visible = true;
            }
            obj_Rpt.xrlborghead.Text = strheader; obj_Rpt.xrlbsubHead.Text = String.Format("Revenue Collection Analysed by {0}", Session["AgencyName"].ToString());

            obj_Rpt.xrLabel1.Text = String.Format(" From {0:dd/MM/yyyy} To {1:dd/MM/yyyy} ", Session["Startdate"].ToString(), Session["Enddate"].ToString());

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery =
                String.Format(
                    "SELECT RevenueName,RevenueCode,SUM(Amount) Amount FROM dbo.vwCollection WHERE PaymentDate BETWEEN '{0}' AND '{1}'AND AgencyName='{2}' GROUP BY RevenueName,RevenueCode ORDER BY RevenueName ASC",
                    gb, gb2, Session["AgencyName"].ToString());

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


            if (responses.Tables[0] != null && responses.Tables[0].Rows.Count > 0)
            {
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }



        }
    }
}