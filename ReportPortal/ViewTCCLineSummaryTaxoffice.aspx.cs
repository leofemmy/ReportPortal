using ReportPortal.Reports;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class ViewTCCLineSummaryTaxoffice : System.Web.UI.Page
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
            //Session["Fromyear"] = ddlyear.SelectedValue.ToString();
            //Session["Toyear"] = ddlto.SelectedValue.ToString();
            //Session["Revenueoffice"] = ddlRevenue.SelectedValue.ToString();

            var vryearfrom = Session["Fromyear"].ToString();

            var vryearto = Session["Toyear"].ToString();

            var vroffice = Session["Revenueoffice"].ToString();

            XtraRepTccLineYearSummary obj_Rpt = new XtraRepTccLineYearSummary();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT PayerName,Utin,RevenueOfficeName,SUM(Income) Income,SUM(Paid) Paid FROM dbo.ViewTccDetails WHERE TaxYear BETWEEN {0} AND {1} AND RevenueOfficeID={2} GROUP BY PayerName,Utin,RevenueOfficeName ORDER BY PayerName ASC", vryearfrom, vryearto, vroffice);

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
                obj_Rpt.xrLabel10.Visible = false;
                obj_Rpt.xrLabel11.Text = string.Format("From : {0} To: {1} ", vryearfrom, vryearto);
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }



        }

        [System.Web.Services.WebMethod]
        public static void loadchildreport(string stin)
        {
            ViewTCCLineSummaryTaxoffice vp = new ViewTCCLineSummaryTaxoffice();

            var varstin = stin;

            vp.callReport2(varstin);

        }

        void callReport2(string stin)
        {
            Session["UTIN"] = stin;

        }
    }
}