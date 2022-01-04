using DevExpress.XtraReports.UI;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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
            //var vryearfrom = Session["yearFrom"].ToString();

            //var vryearto = Session["yearTo"].ToString();
            //window.localStorage.setItem("Revenueoffice", e.Brick.text());

            //var startdate = Session["Startdate"].ToString();

            //var enddate = Session["Enddate"].ToString();

            ////var end= Session["Enddate1"].ToString();
            //var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

            ////var strat = Session["startdate1"].ToString();
            //var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");

            //var vragencyname = Session["Agencyname"].ToString();


            sessions = new SessionManager();

            string value = ConfigurationManager.AppSettings["Doperations"].ToString();

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

            if (responses.Tables[0] != null && responses.Tables[0].Rows.Count >= 1)
            {
                certifi.xrLabel16.Text = strheader;
                certifi.DataSource = dts();
                certifi.DataMember = "ViewCertificateInformation";

                certifi.xrLabel19.Text = value;
                
                ASPxWebDocumentViewer1.OpenReport(certifi);
            }

            //string strquery = String.Format("SELECT RevenueCode, RevenueName, SUM(Amount) Amount FROM ViewNormalizedPayment  WHERE PaymentDate BETWEEN '{0}' AND '{1}' AND AgencyName = '{2}' GROUP BY RevenueCode, RevenueName ORDER BY  RevenueName ASC", startdate, enddate, vragencyname);

            //using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString))
            //{
            //    connect.Open();
            //    _command = new SqlCommand(strquery, connect) { CommandType = CommandType.Text };
            //    _command.CommandTimeout = 0;
            //    responses.Clear();
            //    _adp = new SqlDataAdapter(_command);
            //    _adp.Fill(responses);

            //    connect.Close();

            //}

            //if (responses.Tables[0] != null && responses.Tables[0].Rows.Count > 0)
            //{
            //    obj_Rpt.xrlborghead.Text = strheader;
            //    obj_Rpt.xrlbsubHead.Text = String.Format("Normalised Tax office's Collection By: {0}", vragencyname);
            //    obj_Rpt.xrlbsubHead2.Text = string.Format("Between {0:dd/MM/yyyy}  And {1:dd/MM/yyyy}", strat, end);

            //    obj_Rpt.Report.DataSource = responses;
            //    obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

            //    ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            //}



        }
        //void calReport()
        //{
        //    ASPxDocumentViewer1.Report = CreateReport();
        //    ASPxDocumentViewer1.DataBind();
        //}

        XtraReport CreateReport()
        {
            sessions = new SessionManager();

            string value = ConfigurationManager.AppSettings["Doperations"].ToString();

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

            certifi.xrLabel19.Text = value;

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