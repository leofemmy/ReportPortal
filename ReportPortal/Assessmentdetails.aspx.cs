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
    public partial class Assessmentdetails : System.Web.UI.Page
    {
        SessionManager sessions = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (!IsPostBack)
            {
                if (sessions.MerchantCode == null)
                {
                    Response.Redirect("~/login.aspx");

                }
                //loadAssementyear(); loadAssementyear2();
            }
        }

        protected void btnpreview_Click(object sender, EventArgs e)
        {
            //Session["yearFrom"] = ddlyear.SelectedValue.ToString();

            //Session["yearTo"] = ddlto.SelectedValue.ToString();

            if (string.IsNullOrWhiteSpace(txtstartdate.Text.ToString()) || string.IsNullOrWhiteSpace(txtenddate.Text.ToString()))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Criteria is Empty !', 'error');", true);
            }
            else if (Convert.ToDateTime(txtenddate.Text.ToString()) < Convert.ToDateTime(txtstartdate.Text.ToString()))
            {
                //Encodings.MsgBox("End Date Greater Than Start Date !", this.Page, this);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! End Date Greater Than Start Date !', 'error');", true);
            }
            else
            {
                txtiddisplay.Visible = true;
                Session["Startdate"] = txtstartdate.Text.ToString();

                Session["Enddate"] = txtenddate.Text.ToString();

                Session["startdate1"] = Convert.ToDateTime(txtstartdate.Text.ToString());

                Session["Enddate1"] = Convert.ToDateTime(txtenddate.Text.ToString());


                var startdate = Session["Startdate"].ToString();

                var enddate = Session["Enddate"].ToString();

                var end = Convert.ToDateTime(Session["Enddate1"].ToString()).ToString("dd/MM/yyyy");

                var strat = Convert.ToDateTime(Session["startdate1"].ToString()).ToString("dd/MM/yyyy");

                SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

                string strquery = String.Format("SELECT * FROM ViewAssessmentInfor a WHERE a.AssessmentDate BETWEEN '{0}' AND '{1}' order by  GrossIncome desc", startdate, enddate);

                if (Encodings.IsValidUser(strquery))
                {
                    Response.Write("<script>");
                    Response.Write("window.open('ViewAssessmentdetials.aspx' ,'_blank')");
                    Response.Write("</script>");
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '!  No record for the Selected Year !', 'error');", true);
                }


            }
        }

        //void loadAssementyear()
        //{
        //    //ViewAgency

        //    SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

        //    string strquery = String.Format("SELECT AssessmentYear FROM [dbo].[ViewAssessmentYear]");

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

        //    if (responses.Tables[0] != null && responses.Tables[0].Rows.Count > 1)
        //    {
        //        ddlyear.DataSource = responses.Tables[0];
        //        ddlyear.DataValueField = "AssessmentYear";
        //        ddlyear.DataTextField = "AssessmentYear";
        //        ddlyear.DataBind();
        //        ddlyear.Items.Insert(0, new ListItem("--- Select Year From ---", "0"));
        //    }

        //}

        //void loadAssementyear2()
        //{
        //    //ViewAgency

        //    SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

        //    string strquery = String.Format("SELECT AssessmentYear FROM [dbo].[ViewAssessmentYear]");

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

        //    if (responses.Tables[0] != null && responses.Tables[0].Rows.Count > 1)
        //    {
        //        ddlto.DataSource = responses.Tables[0];
        //        ddlto.DataValueField = "AssessmentYear";
        //        ddlto.DataTextField = "AssessmentYear";
        //        ddlto.DataBind();
        //        ddlto.Items.Insert(0, new ListItem("--- Select Year To ---", "0"));
        //    }

        //}
    }
}