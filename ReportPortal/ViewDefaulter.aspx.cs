using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReportPortal.Reports;

namespace ReportPortal
{
    public partial class ViewDefaulter : System.Web.UI.Page
    {
        SessionManager sessions = null; string strheader = String.Empty; private DateTime startdate, endate;

        private SqlCommand _command; private SqlDataAdapter adp; System.Data.DataTable dt;

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

            SqlCommand _command; SqlDataAdapter _adp;

            System.Data.DataSet responses = new System.Data.DataSet();

            sessions = new SessionManager();

            var strrevenue = Session["RevenueOfficeID"].ToString();

            var strrevennuetypecode = Session["RevenueTypecode"].ToString();

            var strrevenuename = Session["RevenueTypeName"].ToString();

            var startdate = Session["Startdate"].ToString();

            var enddate = Session["Enddate"].ToString();

            var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

            var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");


            XtraRepDefaulter obj_Rpt = new XtraRepDefaulter();

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
            obj_Rpt.xrLabel13.Text = string.Format("From {0:dd/MM/yyyy}  To {1:dd/MM/yyyy}", startdate, enddate);
            obj_Rpt.xrLabel11.Text = String.Format("List of {0}", strrevenuename);

            using (SqlConnection connect = new SqlConnection(ConfigurationManager
                    .ConnectionStrings["Registration2ConnectionString"].ConnectionString))
            {
                connect.Open();
                _command = new SqlCommand("spDoGetTaxDefaulterAnalysis", connect)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _command.Parameters.Add(new SqlParameter("@date1", SqlDbType.DateTime)).Value =
                    string.Format("{0:yyyy/MM/dd 00:00:00}", startdate);
                _command.Parameters.Add(new SqlParameter("@date2", SqlDbType.DateTime)).Value =
                    string.Format("{0:yyyy/MM/dd 23:59:59}", enddate);
                _command.Parameters.Add(new SqlParameter("@RevenueCode", SqlDbType.VarChar)).Value = strrevennuetypecode;
                _command.Parameters.Add(new SqlParameter("@RevenueOffice", SqlDbType.VarChar)).Value = strrevenue;
                _command.CommandTimeout = 0;

                using (System.Data.DataSet ds = new System.Data.DataSet())
                {
                    ds.Clear();
                    adp = new SqlDataAdapter(_command);
                    adp.Fill(ds, "table");
                    //Dts = ds.Tables[0];
                    connect.Close();

                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        var listres = (from DataRow row in ds.Tables[0].Rows
                                       select new DataSets.Defulter
                                       {
                                           Amount = Convert.ToDecimal(row["Amount"]),
                                           NAME = row["NAME"] as string,
                                           UTIN = row["Utin"] as string,
                                           DefultMonth = Convert.ToInt32(row["DefultMonth"]),
                                           Paymonth = Convert.ToInt32(row["Paymonth"]),
                                           PaymentDate = Convert.ToDateTime(row["LastPaymentDate"]),
                                           OfficeName = row["RevenueOfficeName"] as string,
                                           PaymentRefNumber = row["PaymentRefNumber"] as string,
                                           AddressBus = row["AddressBus"] as string,
                                           officeid = Convert.ToInt32(row["RevenueOfficeID"])
                                       }
                              ).ToList();

                        obj_Rpt.Report.DataSource = listres;
                        //obj_Rpt.Report.DataMember = responses.Tables[0].TableName;

                        ASPxWebDocumentViewer1.OpenReport(obj_Rpt);
                    }
                    else
                    {
                        //this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', ' No Record Found for the Selected Range !', 'info');", true);
                    }


                    //if (responses.Tables[0] != null && responses.Tables[0].Rows.Count > 0)
                }

            }
        }
    }
}