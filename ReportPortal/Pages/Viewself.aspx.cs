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
    public partial class Viewself : System.Web.UI.Page
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


            DateTime dt = DateTime.ParseExact(startdate, "dd/mm/yyyy", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(enddate, "dd/mm/yyyy", CultureInfo.InvariantCulture);

            //Console.WriteLine(dt.ToString("yyyy-MM-dd"));

            var gb = dt.ToString("yyyy-MM-dd");
            var gb2 = dt2.ToString("yyyy-MM-dd");

            string strquery = String.Format("SELECT * FROM ViewTaxPayer WHERE MerchantCode='{0}' AND Datecreated BETWEEN '{1}' AND '{2}' AND TaxAgentReferenceNumber IS NULL  ORDER BY Surname ASC ", sessions.MerchantCode.ToString(), gb, gb2);


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

            XtraRepSelf self = new XtraRepSelf();


            if (sessions.MerchantCode.ToString() == "DTSS")
            {
                strheader = "DELTA STATE GOVERNMENT";

                self.xrPictureBox1.Visible = true;

                self.xrPictureBox2.Visible = false;

                self.xrPictureBox3.Visible = false;
            }
            if (sessions.MerchantCode.ToString() == "OGSS")
            {
                strheader = "OGUN STATE GOVERNMENT";

                self.xrPictureBox1.Visible = false;

                self.xrPictureBox2.Visible = true;

                self.xrPictureBox3.Visible = false;
            }
            if (sessions.MerchantCode.ToString() == "OYSS")
            {
                strheader = "OYO STATE GOVERNMENT";

                self.xrPictureBox1.Visible = false;

                self.xrPictureBox2.Visible = false;

                self.xrPictureBox3.Visible = true;
            }



            self.xrlborghead.Text = strheader;

            self.xrlbsubHead2.Text = String.Format(" From {0:dd/MM/yyyy} To {1:dd/MM/yyyy} ", Session["Startdate"].ToString(), Session["Enddate"].ToString());

            self.DataSource = dts();
            self.DataMember = "ViewTaxPayer";

            self.CreateDocument();

            return self;
        }
    }
}