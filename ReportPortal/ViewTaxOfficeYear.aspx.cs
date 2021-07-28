using ReportPortal.Reports;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class ViewTaxOfficeYear : System.Web.UI.Page
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
            var vryearfrom = Session["yearFrom"].ToString();

            var vryearto = Session["yearTo"].ToString();

            XtraRepTaxOfficeYear obj_Rpt = new XtraRepTaxOfficeYear();

            string strheader=String.Empty;

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

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


            string strquery = String.Format("SELECT RevenueOfficeId, RevenueOfficeName,TaxYear, COUNT( DISTINCT TccNo) Reccount,   COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 1 THEN TccNo END) AS DA, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 2 THEN TccNo END) AS PA, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 3 THEN TccNo END) AS PN, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 4 THEN TccNo END) AS ST, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 5 THEN TccNo END ) AS NR, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 6 THEN  TccNo END ) AS UE, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 7 THEN TccNo END) AS DU FROM dbo.ViewTccDetails WHERE YEAR(IssuedDate) BETWEEN {0} AND {1} AND AssessmentYear = YEAR(IssuedDate) - 1 GROUP BY RevenueOfficeName,RevenueOfficeId,TaxYear ORDER BY RevenueOfficeName ASC,TaxYear ASC", vryearfrom, vryearto);

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
                obj_Rpt.xrlborghead.Text = strheader;
                obj_Rpt.xrLabel11.Text = string.Format("From : {0} To: {1} ", vryearfrom, vryearto);
                //obj_Rpt.xrTableCell1.Text = string.Format("{0} - {1}", vryearfrom, vryearto);
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }



        }

        [System.Web.Services.WebMethod]
        public static void loadchildreport(string Revenueoffice)
        {
            ViewTaxOfficeYear vp = new ViewTaxOfficeYear();

            var varRevenueoffice = Revenueoffice;

            vp.callReport2(varRevenueoffice);


        }

        void callReport2(string revenueoffice)
        {
            Session["Revenueoffice"] = revenueoffice;

        }
    }
}