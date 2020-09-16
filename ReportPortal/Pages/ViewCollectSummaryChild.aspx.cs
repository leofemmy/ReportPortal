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
    public partial class ViewCollectSummaryChild : System.Web.UI.Page
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

            XtraRepRevenue obj_Rpt = new XtraRepRevenue();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT RevenueName,RevenueCode,SUM(Amount) Amount FROM dbo.vwCollection WHERE PaymentDate BETWEEN '{0}' AND '{1}' GROUP BY RevenueName,RevenueCode ORDER BY RevenueName ASC", gb, gb2);

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
                // obj_Rpt.xrLabel10.Text = string.Format("From {0:dd/MM/yyyy}  To {1:dd/MM/yyyy}", strat, end);
                //obj_Rpt.xrLabel11.Text = string.Format("From : {0} To: {1} ", vryearfrom, vryearto);
                //obj_Rpt.xrTableCell1.Text = string.Format("{0} - {1}", vryearfrom, vryearto);
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }



        }
    }
}