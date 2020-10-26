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
    public partial class TaxOfficeYear : System.Web.UI.Page
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

            if ((ddlto.SelectedValue.ToString() == "0") || (ddlyear.SelectedValue.ToString() == "0"))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Criteria is Empty !', 'error');", true);
            }
            else if (Convert.ToInt32(ddlto.SelectedValue.ToString()) < Convert.ToInt32(ddlyear.SelectedValue.ToString()))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', '! Year To Can not be less than Year from!', 'error');", true);
            }
            else
            {
                Session["yearFrom"] = ddlyear.SelectedValue.ToString();
                Session["yearTo"] = ddlto.SelectedValue.ToString();

                txtiddisplay.Visible = true;


                if (Encodings.IsValidUser(String.Format("SELECT RevenueOfficeId, RevenueOfficeName,TaxYear, COUNT( DISTINCT TccNo) Reccount,   COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 1 THEN TccNo END) AS DA, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 2 THEN TccNo END) AS PA, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 3 THEN TccNo END) AS PN, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 4 THEN TccNo END) AS ST, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 5 THEN TccNo END ) AS NR, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 6 THEN  TccNo END ) AS UE, COUNT(DISTINCT CASE WHEN IncomeSourceClassifyId = 7 THEN TccNo END) AS DU FROM dbo.ViewTccDetails WHERE YEAR(IssuedDate) BETWEEN {0} AND {1} AND AssessmentYear = YEAR(IssuedDate) - 1 GROUP BY RevenueOfficeName,RevenueOfficeId,TaxYear ORDER BY RevenueOfficeName ASC,TaxYear ASC", ddlyear.SelectedValue, ddlto.SelectedValue)))
                {
                    Response.Write("<script>");
                    Response.Write("window.open('ViewTaxOfficeYear.aspx' ,'_blank')");
                    Response.Write("</script>");
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Report!', ' No Record Found for the Selected Year !', 'info');", true);
                }


            }

        }
    }
}