using ReportPortal.Reports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportPortal
{
    public partial class ViewTccYearSummaryChildDetails : System.Web.UI.Page
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
            //var vryearfrom = Session["yearFrom"].ToString();

            //var vryearto = Session["yearTo"].ToString();

            //var varofficename = Session["Revenueoffice"].ToString();
            var varofficename = Session["RevenueOfficename"].ToString();

            var varyear = Session["TaxYear"].ToString();

            //var varyear = Session["TaxYear"].ToString();

            XtraRepTccDetails2 obj_Rpt = new XtraRepTccDetails2();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT * FROM dbo.ViewTccDetailsInfors WHERE YEAR(IssuedDate) BETWEEN {0} AND {0} AND RevenueOfficeName='{1}' ORDER BY PayerName ASC, TccNo ASC, TaxYear DESC", varyear, varofficename);


            //string strquery = String.Format("SELECT * FROM dbo.ViewTccDetails WHERE YEAR(IssuedDate) BETWEEN {0} AND {1} AND RevenueOfficeName='{2}' AND AssessmentYear = YEAR(IssuedDate) - 1 ORDER BY PayerName ASC", vryearfrom, vryearto, varofficename);

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
                //obj_Rpt.xrLabel10.Text = string.Format("From {0}  to {1}", vryearfrom, vryearto);
                //obj_Rpt.xrLabel11.Text = string.Format("{0} ", varofficename);
                obj_Rpt.xrLabel10.Text = string.Format("{0} ", varyear);
                obj_Rpt.xrLabel11.Text = string.Format("{0} ", varofficename);
                obj_Rpt.Report.DataSource = responses;
                obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
            }

        }
        //void calReport()
        //{

        //    var varofficename = Session["RevenueOfficename"].ToString();

        //    var varyear = Session["TaxYear"].ToString();

        //    XtraRepTccDetails obj_Rpt = new XtraRepTccDetails();

        //    SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

        //    string strquery = String.Format("SELECT * FROM dbo.ViewTccDetails WHERE YEAR(IssuedDate) BETWEEN {0} AND {0} AND RevenueOfficeName='{1}' AND AssessmentYear = YEAR(IssuedDate) - 1 ORDER BY PayerName ASC", varyear, varofficename);

        //    using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString))
        //    {
        //        connect.Open();
        //        _command = new SqlCommand(strquery, connect) { CommandType = CommandType.Text };
        //        _command.CommandTimeout = 0;
        //        responses.Clear();
        //        _adp = new SqlDataAdapter(_command);
        //        _adp.Fill(responses);

        //        connect.Close();

        //    }

        //    if (responses.Tables[0] != null && responses.Tables[0].Rows.Count > 0)
        //    {
        //        obj_Rpt.xrLabel10.Text = string.Format("{0} ", varyear);
        //        obj_Rpt.xrLabel11.Text = string.Format("{0} ", varofficename);
        //        obj_Rpt.Report.DataSource = responses;
        //        obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

        //        ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
        //    }

        //}

        //[System.Web.Services.WebMethod]
        //public static void loadchildreport(string stin)
        //{
        //    ViewCummulativeSummary vp = new ViewCummulativeSummary();

        //    var vartaxyear = stin;

        //    vp.callReport2(vartaxyear);


        //}

        //void callReport2(string taxyear)
        //{
        //    Session["TaxYear"] = taxyear;


        //}
    }
}