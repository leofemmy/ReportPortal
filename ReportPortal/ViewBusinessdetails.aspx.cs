using ReportPortal.Reports;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportPortal
{
    public partial class ViewBusinessdetails : System.Web.UI.Page
    {
        SessionManager sessions = null; SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet(); string strheader = String.Empty;

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
            sessions = new SessionManager();

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            //var tinagent = Session["STINAgent"].ToString();

            var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

            var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");

            var stroffices = Session["STINAgent"].ToString();

            XtraRepBusinessdetails obj_Rpt = new XtraRepBusinessdetails();

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
            obj_Rpt.xrlbsubHead.Text = string.Format("INTERNAL REVENUE SERVICE");
            //obj_Rpt.xrlbsubHead.Text = "Taxpayers Registered Report (Tax Agent)";
            obj_Rpt.xrLabel1.Text = string.Format("Analysed by {0} Sector(s)", stroffices);
            obj_Rpt.xrLabel3.Text = string.Format("From {0:dd/MM/yyyy}  To {1:dd/MM/yyyy}", strat, end);

            string strquery = String.Format("SELECT BusinessTypeId, BusinessTypeName, PayerName, PayerID, TaxAgentUtin,   SUM(Amount) Amount, FORMAT(PaymentDate, 'dd-MM-yyyy') PaymentDate, MerchantCode FROM dbo.vwBusinessSectorsdetails WHERE MerchantCode= '{0}' AND BusinessTypeName ='{1}' AND PaymentDate BETWEEN '{2}' AND '{3}' GROUP BY BusinessTypeId, BusinessTypeName, PayerName, PayerID, TaxAgentUtin, MerchantCode, FORMAT(PaymentDate, 'dd-MM-yyyy') ORDER BY PayerName ASC ", sessions.MerchantCode.ToString(), stroffices, startdate, enddate);

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