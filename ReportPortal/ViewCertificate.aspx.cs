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
    public partial class ViewCertificate : System.Web.UI.Page
    {
        SessionManager sessions = null; string strheader = String.Empty;

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

        XtraReport CreateReport()
        {
            sessions = new SessionManager();

            XtraRepCertifi certifi = new XtraRepCertifi();

            if (sessions.MerchantCode.ToString() == "DTSS")
            {
                strheader = "DELTA STATE GOVERNMENT";

                certifi.xrPictureBox2.Visible = true;

                certifi.xrPictureBox3.Visible = false;

                certifi.xrPictureBox4.Visible = false;

            }
            if (sessions.MerchantCode.ToString() == "OGSS")
            {
                strheader = "OGUN STATE GOVERNMENT";

                certifi.xrPictureBox2.Visible = false;

                certifi.xrPictureBox3.Visible = true;

                certifi.xrPictureBox4.Visible = false;
            }
            if (sessions.MerchantCode.ToString() == "OYSS")
            {
                strheader = "OYO STATE GOVERNMENT";

                certifi.xrPictureBox2.Visible = false;

                certifi.xrPictureBox2.Visible = false;

                certifi.xrPictureBox4.Visible = true;
            }



           

            //self.xrlborghead.Text = strheader;

            //self.xrlbsubHead2.Text = String.Format(" From {0:dd/MM/yyyy} To {1:dd/MM/yyyy} ", Session["Startdate"].ToString(), Session["Enddate"].ToString());
            certifi.xrLabel16.Text = strheader;
            certifi.DataSource = dts();
            certifi.DataMember = "ViewCertificateInformation";

            certifi.CreateDocument();

            return certifi;
        }

        DataSet dts()
        {
            sessions = new SessionManager();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            var stringstin = Session["STIN"].ToString();

        
            string strquery = String.Format("SELECT * FROM ViewCertificateInformation WHERE MerchantCode='{0}' AND PayerUtin= '{1}'", sessions.MerchantCode.ToString(), stringstin.ToString());


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
    }
}