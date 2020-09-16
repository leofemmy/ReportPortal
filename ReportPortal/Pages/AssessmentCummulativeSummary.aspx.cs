﻿using System;
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
    public partial class AssessmentCummulativeSummary : System.Web.UI.Page
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
                loadAssementyear(); loadAssementyear2();
            }
        }
        void loadAssementyear()
        {
            //ViewAgency

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT AssessmentYear FROM [dbo].[ViewAssessmentYear]");

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
                ddlyear.DataSource = responses.Tables[0];
                ddlyear.DataValueField = "AssessmentYear";
                ddlyear.DataTextField = "AssessmentYear";
                ddlyear.DataBind();
                ddlyear.Items.Insert(0, new ListItem("--- Select Year From ---", "0"));
            }

        }
        void loadAssementyear2()
        {
            //ViewAgency

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            string strquery = String.Format("SELECT AssessmentYear FROM [dbo].[ViewAssessmentYear]");

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
                ddlto.DataSource = responses.Tables[0];
                ddlto.DataValueField = "AssessmentYear";
                ddlto.DataTextField = "AssessmentYear";
                ddlto.DataBind();
                ddlto.Items.Insert(0, new ListItem("--- Select Year To ---", "0"));
            }

        }
        protected void btnpreview_Click(object sender, EventArgs e)
        {
            Session["yearFrom"] = ddlyear.SelectedValue.ToString();
            Session["yearTo"] = ddlto.SelectedValue.ToString();

            if (Convert.ToInt32(ddlto.SelectedValue.ToString()) < Convert.ToInt32(ddlyear.SelectedValue.ToString()))
            {
                Response.Write("<script>alert('" + " Year To Can not be less than Year from" + "')</script>");
            }
            else
            {

                SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

                string strquery = String.Format("SELECT COUNT(DISTINCT a.AssessmentNo) AS Reccount, SUM(a.TaxPayable) TotalPayable,   COUNT(DISTINCT CASE  WHEN a.IncomeSourceClassifyId = 1 THEN a.AssessmentNo END  ) AS DA, COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 2 THEN a.AssessmentNo END) AS PA, COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 3 THEN  a.AssessmentNo END ) AS PN,COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 4 THEN a.AssessmentNo  END ) AS ST, COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 5 THEN a.AssessmentNo END ) AS NR, COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 6 THEN a.AssessmentNo END) AS UE,COUNT(DISTINCT CASE WHEN a.IncomeSourceClassifyId = 7 THEN a.AssessmentNo END) AS DU, COALESCE(SUM(   CASE WHEN a.IncomeSourceClassifyId = 1 THEN a.TaxPayable END), 0) DAAmount,COALESCE(SUM( CASE WHEN a.IncomeSourceClassifyId = 2 THEN a.TaxPayable END),0) PAAmount,COALESCE(SUM(   CASE WHEN a.IncomeSourceClassifyId = 3 THEN a.TaxPayable END ),  0) PNAmount,COALESCE(SUM( CASE WHEN a.IncomeSourceClassifyId = 4 THEN a.TaxPayable END   ),0  ) STAmount, COALESCE(SUM( CASE WHEN a.IncomeSourceClassifyId = 5 THEN a.TaxPayable END),0) NRAmount,COALESCE(SUM( CASE WHEN a.IncomeSourceClassifyId = 6 THEN a.TaxPayable END),0) UEAmount,COALESCE(SUM(   CASE WHEN a.IncomeSourceClassifyId = 7 THEN a.TaxPayable END),0) DUAmount FROM ViewAssessmentInfor a WHERE a.AssessmentYear BETWEEN {0} AND {1}", ddlyear.SelectedValue, ddlto.SelectedValue);

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
                    Response.Write("<script>");
                    Response.Write("window.open('ViewAssessmentCummulativeSummary.aspx' ,'_blank')");
                    Response.Write("</script>");
                }
                else
                {
                    Response.Write("<script>alert('" + " No record for the Selected Year " + "')</script>");
                }


            }


        }
    }
}