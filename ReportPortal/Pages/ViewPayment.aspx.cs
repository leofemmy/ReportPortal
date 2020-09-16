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
using DevExpress.XtraReports.Web;

namespace ReportPortal
{
    public partial class ViewPayment : System.Web.UI.Page
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

            var strrevenue = Session["Revenue"].ToString();

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            //var end= Session["Enddate1"].ToString();
            var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

            //var strat = Session["startdate1"].ToString();
            var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");

            //DateTime dt = DateTime.ParseExact(startdate, "dd/mm/yyyy", CultureInfo.InvariantCulture);
            //DateTime dt2 = DateTime.ParseExact(enddate, "dd/mm/yyyy", CultureInfo.InvariantCulture);

            //Console.WriteLine(dt.ToString("yyyy-MM-dd"));

            //var gb = dt.ToString("yyyy-MM-dd");
            //var gb2 = dt2.ToString("yyyy-MM-dd");

            //XtraRepPayment obj_Rpt = new XtraRepPayment();

            XtraRepPayment2 obj_Rpt = new XtraRepPayment2();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT * FROM ViewPayment WHERE PaymentDate BETWEEN '{0}' AND '{1}' and RevenueCode ='{2}' ORDER BY PaymentDate ASC", startdate, enddate, strrevenue);

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
                obj_Rpt.xrLabel10.Text = string.Format("From {0:dd/MM/yyyy}  To {1:dd/MM/yyyy}", strat, end);
                obj_Rpt.xrLabel8.Text = Session["RevenueName"].ToString();
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }

            //var cachedReportSource = new CachedReportSourceWeb(new XtraRepPayment());

        }

    }
}