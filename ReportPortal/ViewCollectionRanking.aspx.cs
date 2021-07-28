using ReportPortal.Reports;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class ViewCollectionRanking : System.Web.UI.Page
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
            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            var strrevenue = Session["Revenuecode"].ToString();

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("yyyy/MM/dd");

            var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("yyyy/MM/dd");

            var strrevenueofficeid = Session["RevenueofficeID"].ToString();

            int nos = Convert.ToInt32(Session["nos"].ToString());

            XtraRepCollectionRanking obj_Rpt = new XtraRepCollectionRanking();

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


            obj_Rpt.xrlborghead.Text = strheader;
            obj_Rpt.xrlbsubHead.Text = string.Format("Top Agent Collection Ranking for Top {0} from {1}", nos, Session["RevenueName"].ToString());

            obj_Rpt.xrlbsubHead2.Text = String.Format(" From {0:dd/MM/yyyy} To {1:dd/MM/yyyy} ", Session["Startdate"].ToString(), Session["Enddate"].ToString());
            obj_Rpt.xrLabel1.Text = "Analysed by Selected Revenue(s) Office";

            string strquery = String.Format("SELECT  DISTINCT TOP {0} TaxAgentUtin,TaxAgentName,SUM(Amount) Amount,RevenueOfficeID,RevenueOfficeName,RevenueCode,RevenueName,DATEPART(MONTH, PaymentDate) AS MONTH,DATEPART(YEAR, PaymentDate) AS YEAR,CONVERT(VARCHAR, DATEPART(MONTH, PaymentDate)) + '/' + CONVERT(VARCHAR, DATEPART(YEAR, PaymentDate)) AS Period FROM vwCollectionRanking WHERE PaymentDate BETWEEN '{1}' AND '{2}' AND RevenueCode ='{3}' AND RevenueOfficeID IN ({4}) GROUP BY TaxAgentUtin, TaxAgentName, RevenueOfficeID,RevenueOfficeName,RevenueCode, RevenueName,DATEPART(MONTH, PaymentDate), DATEPART(YEAR, PaymentDate) ORDER BY TaxAgentName ASC", nos, strat, end, strrevenue, strrevenueofficeid);

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
                //obj_Rpt.xrLabel10.Text = string.Format("From {0:dd/MM/yyyy}  To {1:dd/MM/yyyy}", strat, end);
                //obj_Rpt.xrLabel8.Text = Session["RevenueName"].ToString();
                obj_Rpt.xrPivotGrid1.DataSource = responses;
                obj_Rpt.xrPivotGrid1.DataMember = responses.Tables[0].TableName;
                //obj_Rpt.Report.DataSource = responses;
                //obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }

            //var cachedReportSource = new CachedReportSourceWeb(new XtraRepPayment());

        }
    }
}