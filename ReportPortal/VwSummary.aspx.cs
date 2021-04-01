using ReportPortal.Reports;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class VwSummary : System.Web.UI.Page
    {
        SessionManager sessions = null; string strheader = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            Session["RegisterTyped"] = string.Empty;

            if (sessions.MerchantCode == null)
            {
                Response.Redirect("~/login.aspx");

            }
            calReport();
        }

        void calReport()
        {

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            sessions = new SessionManager();

            //var strrevenue = Session["Agencylist"].ToString();

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

            var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");



            XtraRepSummary obj_Rpt = new XtraRepSummary();

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
            obj_Rpt.xrLabel1.Text = string.Format("INTERNAL REVENUE SERVICE");
            obj_Rpt.xrlbsubHead2.Text = string.Format("From {0:dd/MM/yyyy}  To {1:dd/MM/yyyy}", strat, end);

            using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString))
            {
                connect.Open();
                _command = new SqlCommand(String.Format("SELECT RegTypeCode,  COUNT(RegTypeCode) Rec_Count, CASE WHEN RegTypeCode = 'AG' THEN 'Tax Agents' WHEN RegTypeCode = 'DA' THEN 'Self-Employed' WHEN RegTypeCode = 'PA' THEN  'Employed'  ELSE  'Adoch'  END Category FROM dbo.vwPayerInfo  WHERE PayerName IS NOT NULL AND MerchantCode='{0}' AND Datecreated BETWEEN '{1}' AND '{2}' GROUP BY RegTypeCode HAVING COUNT(RegTypeCode) > 0 ORDER BY Category asc", sessions.MerchantCode.ToString(), startdate, enddate), connect) { CommandType = CommandType.Text };
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

        [System.Web.Services.WebMethod]
        public static void loadchildreport(string stin)
        {
            VwSummary vp = new VwSummary();

            var vartaxyear = stin;

            vp.callReport2(vartaxyear);

        }

        void callReport2(string taxyear)
        {
            //var gf = hdvalue.Value.ToString();
            // var gf = hdvalue.Value;
            Session["RegisterTyped"] = taxyear;


        }
    }
}