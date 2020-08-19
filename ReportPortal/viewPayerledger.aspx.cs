using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportPortal
{
    public partial class viewPayerledger : System.Web.UI.Page
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

            XtraRepSummaryLedger obj_Rpt = new XtraRepSummaryLedger();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT PayerUtin, PayerName, RevenueOfficeID,RevenueOfficeName,COALESCE(SUM(TaxPayable), 0) Assessment,  COALESCE(SUM(PaymentAmount), 0) Payment, COALESCE(SUM(TaxPayable), 0) - COALESCE(SUM(PaymentAmount), 0) Differences FROM dbo.ViewPayerLedger  GROUP BY PayerUtin, PayerName, RevenueOfficeID,RevenueOfficeName  ORDER BY RevenueOfficeName asc");

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
                // obj_Rpt.xrLabel10.Text = string.Format("As At: {0:dddd, d MMMM,yyyy} ", DateTime.Now);
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }

        }

        [System.Web.Services.WebMethod]
        public static void loadchildreport(string struit)
        {
            viewPayerledger vp = new viewPayerledger();

            var vastin = struit;

            //Session["UTIN"] = strSTin;

            vp.callReport2(vastin);


        }

        void callReport2(string strSTin)
        {


            Session["UTIN"] = strSTin;

            //Response.Redirect("~/ViewChildledge.aspx");

            // Response.RedirectLocation="ViewChildledge.aspx";
        }
    }
}