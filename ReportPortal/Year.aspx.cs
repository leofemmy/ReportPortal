﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace ReportPortal
{
    public partial class Year : System.Web.UI.Page
    {
        SessionManager sessions = null; string strvalue = String.Empty; int j = 0;

        private string constr = ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (sessions.MerchantCode == null)
            {
                Response.Redirect("~/login.aspx");

            }

            if (!IsPostBack)
            {
                //setloadOffice();
            }
        }

        void setloadOffice()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT AgencyCode,AgencyName FROM ViewAgency ORDER BY AgencyName ASC "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            //gridOffence.DataSource = dt;
                            //gridOffence.DataBind();
                        }
                    }
                }
            }
        }

        [WebMethod]
        public static string GetAgency()
        {
            SessionManager sessions = null;

            sessions = new SessionManager(); String daresult = null;

            CollectionRanking bn = new CollectionRanking();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString))
            {
                connect.Open();
                _command = new SqlCommand(String.Format("SELECT AgencyCode,AgencyName FROM ViewAgency ORDER BY AgencyName ASC "), connect) { CommandType = CommandType.Text };
                _command.CommandTimeout = 0;
                responses.Clear();
                _adp = new SqlDataAdapter(_command);
                _adp.Fill(responses);

                connect.Close();
            }

            return JsonConvert.SerializeObject(responses);
        }

        [WebMethod]
        public static string PostPreview(DateTime startdate, DateTime enddate,
            string[] agencyid)
        {
            string strvalue = String.Empty; int j = 0; string retvalue = String.Empty;

            int h = agencyid.Count();

            for (int i = 0; i < agencyid.Length; i++)
            {
                strvalue += String.Format("'{0}'", agencyid[i]);
                if (j + 1 < h)
                {
                    strvalue += ",";
                    ++j;
                }
            }


            HttpContext.Current.Session["Agencylist"] = strvalue;

            HttpContext.Current.Session["Startdate"] = Convert.ToDateTime(startdate);

            HttpContext.Current.Session["startdate1"] = Convert.ToDateTime(startdate);

            HttpContext.Current.Session["Enddate"] = Convert.ToDateTime(enddate);

            HttpContext.Current.Session["Enddate1"] = Convert.ToDateTime(enddate);

            var strrevenue = HttpContext.Current.Session["Agencylist"].ToString();

            var startdat = string.Format("{0:yyyy-MM-dd}", HttpContext.Current.Session["Startdate"].ToString());

            var enddat = string.Format("{0:yyyy-MM-dd}", HttpContext.Current.Session["Enddate"].ToString());

            var end = Convert.ToDateTime(HttpContext.Current.Session["Enddate1"].ToString()).ToString("yyyy/MM/dd");

            var strat = Convert.ToDateTime(HttpContext.Current.Session["startdate1"].ToString()).ToString("yyyy/MM/dd");

            if (Encodings.IsValidUser(String.Format(
                "SELECT AgencyName,AgencyCode,SUM(Amount) Amount,DATEPART(YEAR,PaymentDate) Year FROM vwCollectionRaw WHERE PaymentDate BETWEEN '{0}' AND '{1}' AND AgencyCode IN ({2}) GROUP BY AgencyName,AgencyCode,DATEPART(YEAR,PaymentDate) ORDER BY AgencyName ASC",
                strat, end, strrevenue)))
            {
                retvalue = "1";
            }
            else
            {
                retvalue = "0";
            }

            return JsonConvert.SerializeObject(retvalue);
        }
        protected void btnpreview_Click(object sender, EventArgs e)
        {
            //int totalCount = gridOffence.Rows.Cast<GridViewRow>()
            //              .Count(r => ((CheckBox)r.FindControl("CheckBox1")).Checked);

            if (string.IsNullOrWhiteSpace(txtstartdate.Text.ToString()) || string.IsNullOrWhiteSpace(txtenddate.Text.ToString()))
            {
                //Encodings.MsgBox("! Criteria is Empty !", this.Page, this);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Criteria is Empty !', 'error');", true);
            }
            else if (Convert.ToDateTime(txtenddate.Text.ToString()) < Convert.ToDateTime(txtstartdate.Text.ToString()))
            {
                //Encodings.MsgBox("End Date Greater Than Start Date !", this.Page, this);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! End Date Greater Than Start Date !', 'error');", true);
            }
            else
            {
                //foreach (GridViewRow row in gridOffence.Rows)
                //{
                //    CheckBox chk = (CheckBox)row.FindControl("CheckBox1");

                //    Label lbltin = (Label)row.FindControl("lbltin");

                //    if (chk != null & chk.Checked)
                //    {
                //        strvalue += String.Format("'{0}'", lbltin.Text);

                //        if (j + 1 < totalCount)
                //        {
                //            strvalue += ",";
                //            ++j;
                //        }
                //    }

                //}

                txtiddisplay.Visible = true;

                Session["Startdate"] = Convert.ToDateTime(txtstartdate.Text).ToString("yyyy-MM-dd 00:00:00");// txtstartdate.Text.ToString();

                Session["Enddate"] = Convert.ToDateTime(txtenddate.Text).ToString("yyyy-MM-dd 23:59:59");//txtenddate.Text.ToString();

                Session["startdate1"] = Convert.ToDateTime(txtstartdate.Text.ToString());

                Session["Enddate1"] = Convert.ToDateTime(txtenddate.Text.ToString());

                Session["Agencylist"] = strvalue;

                var strrevenue = Session["Agencylist"].ToString();

                var startdate = Session["Startdate"].ToString();

                var enddate = Session["Enddate"].ToString();

                var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

                var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");

                if (string.IsNullOrWhiteSpace(strvalue.ToString()))
                {
                    //Encodings.MsgBox("End Date Greater Than Start Date !", this.Page, this);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Agency List Empty !', 'error');", true); return;
                }
                else
                {

                    if (Encodings.IsValidUser(String.Format(
                        "SELECT AgencyName,AgencyCode,SUM(Amount) Amount,DATEPART(YEAR,PaymentDate) Year FROM vwCollectionRaw WHERE PaymentDate BETWEEN '{0}' AND '{1}' AND AgencyCode IN ({2}) GROUP BY AgencyName,AgencyCode,DATEPART(YEAR,PaymentDate) ORDER BY AgencyName ASC",
                        startdate, enddate, strrevenue)))
                    {
                        Response.Write("<script>");
                        Response.Write("window.open('ViewYear.aspx' ,'_blank')");
                        Response.Write("</script>");
                    }
                    else
                    {
                        //Encodings.MsgBox("! No Record Found for the Selected Range !", this.Page, this);
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert",
                            "swal('Report!', ' No Record Found for the Selected Range !', 'info');", true);
                    }
                }
            }
        }
    }
}