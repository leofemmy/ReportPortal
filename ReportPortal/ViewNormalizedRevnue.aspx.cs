using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReportPortal.Reports;

namespace ReportPortal
{
    public partial class ViewNormalizedRevnue : System.Web.UI.Page
    {
        SessionManager sessions = null; string strheader = String.Empty; private DateTime startdate, endate;

        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (sessions.MerchantCode == null)
            {
                Response.Redirect("~/login.aspx");

            }
            //var vrrevenueoffice = Session["RevnueOff"].ToString();
            calReport();
        }

        [WebMethod]
        public static void LoadReport(string strrevenueoffice)
        {
            ViewNormalizedRevnue vp = new ViewNormalizedRevnue();

            var vartaxyear = strrevenueoffice;

            vp.callReport2(vartaxyear);


        }

        void callReport2(string Revenueoffice)
        {
            Session["RevnueOff"] = Revenueoffice;


        }

        void calReport()
        {
            //var vryearfrom = Session["yearFrom"].ToString();

            //var vryearto = Session["yearTo"].ToString();
            //window.localStorage.setItem("Revenueoffice", e.Brick.text());

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            //var end= Session["Enddate1"].ToString();
            var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

            //var strat = Session["startdate1"].ToString();
            var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");

            var vragencyname = Session["Agencyname"].ToString();


            XtraRepNormalisedrevnue obj_Rpt = new XtraRepNormalisedrevnue();

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


            string strquery = String.Format("SELECTRevenueCode, RevenueName, SUM(Amount) Amount FROM ViewNormalizedPayment  WHERE PaymentDate BETWEEN '{0}' AND '{1}' AND AgencyName = '{2}' GROUP BY RevenueCode, RevenueName ORDER BY  RevenueName ASC", startdate, enddate, vragencyname);

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
                obj_Rpt.xrlborghead.Text = strheader;
                obj_Rpt.xrlbsubHead.Text = String.Format("Normalised Tax office's Collection By: {0}", vragencyname);
                obj_Rpt.xrlbsubHead2.Text = string.Format("Between {0:dd/MM/yyyy}  And {1:dd/MM/yyyy}", strat, end);

                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }



        }
    }
}