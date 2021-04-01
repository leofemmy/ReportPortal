using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class ViewAssessmentCummulativeSummary : System.Web.UI.Page
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

            XtraRepAssessmentCummulativeSummary obj_Rpt = new XtraRepAssessmentCummulativeSummary();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            if (sessions.MerchantCode.ToString() == "DTSS")
            {
                //strheader = "DELTA STATE GOVERNMENT";

                obj_Rpt.xrPictureBox1.Visible = true;

                obj_Rpt.xrPictureBox2.Visible = false;

                obj_Rpt.xrPictureBox3.Visible = false;

            }

            if (sessions.MerchantCode.ToString() == "OGSS")
            {
                //strheader = "OGUN STATE GOVERNMENT";

                obj_Rpt.xrPictureBox1.Visible = false;

                obj_Rpt.xrPictureBox2.Visible = true;

                obj_Rpt.xrPictureBox3.Visible = false;
            }

            if (sessions.MerchantCode.ToString() == "OYSS")
            {
                //strheader = "OYO STATE GOVERNMENT";

                obj_Rpt.xrPictureBox1.Visible = false;

                obj_Rpt.xrPictureBox2.Visible = false;

                obj_Rpt.xrPictureBox3.Visible = true;
            }


            string strquery = String.Format("SELECT COUNT(DISTINCT a.AssessmentNo) AS Reccount, SUM(a.TaxPayable) TotalPayable,   COUNT(DISTINCT CASE  WHEN a.IncomeSourceClassifyId = 1 THEN a.AssessmentNo END  ) AS DA, COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 2 THEN a.AssessmentNo END) AS PA, COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 3 THEN  a.AssessmentNo END ) AS PN,COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 4 THEN a.AssessmentNo  END ) AS ST, COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 5 THEN a.AssessmentNo END ) AS NR, COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 6 THEN a.AssessmentNo END) AS UE,COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 7 THEN a.AssessmentNo END) AS DU, COALESCE(SUM(   CASE WHEN a.IncomeSourceClassifyId = 1 THEN a.TaxPayable END), 0) DAAmount,COALESCE(SUM( CASE WHEN a.IncomeSourceClassifyId = 2 THEN a.TaxPayable END),0) PAAmount,COALESCE(SUM(   CASE WHEN a.IncomeSourceClassifyId = 3 THEN a.TaxPayable END ),  0) PNAmount,COALESCE(SUM( CASE WHEN a.IncomeSourceClassifyId = 4 THEN a.TaxPayable END   ),0  ) STAmount, COALESCE(SUM( CASE WHEN a.IncomeSourceClassifyId = 5 THEN a.TaxPayable END),0) NRAmount,COALESCE(SUM( CASE WHEN a.IncomeSourceClassifyId = 6 THEN a.TaxPayable END),0) UEAmount,COALESCE(SUM(   CASE WHEN a.IncomeSourceClassifyId = 7 THEN a.TaxPayable END),0) DUAmount FROM ViewAssessmentInfor a WHERE a.AssessmentYear BETWEEN {0} AND {1}", vryearfrom, vryearto);

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
                obj_Rpt.xrLabel11.Text = string.Format("From : {0} To: {1} ", vryearfrom, vryearto);
                obj_Rpt.xrTableCell1.Text = string.Format("{0} - {1}", vryearfrom, vryearto);
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }



        }

        [System.Web.Services.WebMethod]
        public static void loadchildreport(string stin)
        {
            ViewAssessmentCummulativeSummary vp = new ViewAssessmentCummulativeSummary();

            var vartaxyear = stin;

            vp.callReport2(vartaxyear);


        }

        void callReport2(string taxyear)
        {
            Session["TaxYear"] = taxyear;


        }
    }
}