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
using DevExpress.XtraReports.UI;

namespace ReportPortal
{
    public partial class ViewPay : System.Web.UI.Page
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

            ASPxDocumentViewer1.Report = CreateReport();
            ASPxDocumentViewer1.DataBind();
        }


        DataSet dts()
        {
            sessions = new SessionManager();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

            var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");



            string strquery = String.Format("SELECT * FROM ViewPaye WHERE MerchantCode='{0}' AND Datecreated BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' ORDER BY PayerName ASC", sessions.MerchantCode.ToString(), startdate, enddate);


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
            }

            return responses;
        }

        XtraReport CreateReport()
        {
            sessions = new SessionManager();

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

            var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");

            XtraRepEmployed emp = new XtraRepEmployed();

            if (sessions.MerchantCode.ToString() == "DTSS")
            {
                strheader = "DELTA STATE GOVERNMENT";

                emp.xrPictureBox1.Visible = true;
                emp.xrPictureBox2.Visible = false;
                emp.xrPictureBox3.Visible = false;
            }

            if (sessions.MerchantCode.ToString() == "OGSS")
            {
                strheader = "OGUN STATE GOVERNMENT";

                emp.xrPictureBox1.Visible = false;
                emp.xrPictureBox2.Visible = false;
                emp.xrPictureBox3.Visible = true;
            }

            if (sessions.MerchantCode.ToString() == "OYSS")
            {
                strheader = "OYO STATE GOVERNMENT";

                emp.xrPictureBox1.Visible = false;
                emp.xrPictureBox2.Visible = false;
                emp.xrPictureBox3.Visible = true;
            }



           

            emp.xrlborghead.Text = strheader;

            emp.xrlbsubHead2.Text = String.Format(" From {0:dd/MM/yyyy} To {1:dd/MM/yyyy} ", strat, end);

            emp.DataSource = dts();
            emp.DataMember = "ViewPaye";

            emp.CreateDocument();

            return emp;
        }
    }
}