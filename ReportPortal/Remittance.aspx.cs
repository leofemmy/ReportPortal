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
    public partial class Remittance : System.Web.UI.Page
    {
        SessionManager sessions = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            sessions = new SessionManager();

            if (sessions.MerchantCode == null)
            {
                Response.Redirect("~/login.aspx");

            }

            if (!IsPostBack)
            {
                setloadOffice();

            }
        }
        void setloadOffice()
        {
            sessions = new SessionManager();

            SqlCommand _command; SqlDataAdapter _adp; System.Data.DataSet responses = new System.Data.DataSet();

            using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString))
            {
                connect.Open();
                _command = new SqlCommand(String.Format("SELECT DISTINCT TaxAgentUtin,RTRIM(LTRIM(TaxAgentName)) TaxAgentName FROM CentralRegistration.dbo.vwTaxAgents  WHERE MerchantCode='{0}' and TaxAgentName IS NOT NULL ORDER BY TaxAgentName ASC ", sessions.MerchantCode.ToString()), connect) { CommandType = CommandType.Text };
                _command.CommandTimeout = 0;
                responses.Clear();
                _adp = new SqlDataAdapter(_command);
                _adp.Fill(responses);

                connect.Close();
            }

            if (responses.Tables[0] != null && responses.Tables[0].Rows.Count > 1)
            {
                gridOffence.DataSource = responses.Tables[0];
                gridOffence.DataBind();
            }

        }

        protected void btnpreview_OnClick(object sender, EventArgs e)
        {
            string strvalue = String.Empty; int j = 0;

            int totalCount = gridOffence.Rows.Cast<GridViewRow>()
                .Count(r => ((CheckBox)r.FindControl("Chkid")).Checked);


            foreach (GridViewRow row in gridOffence.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("Chkid");

                Label lbltin = (Label)row.FindControl("lbltin");

                if (chk != null & chk.Checked)
                {
                    strvalue += String.Format("'{0}'", lbltin.Text);

                    if (j + 1 < totalCount)
                    {
                        strvalue += ",";
                        ++j;
                    }
                }

            }

            Session["Startdate"] = txtstartdate.Text.ToString();

            Session["Enddate"] = txtenddate.Text.ToString();

            Session["startdate1"] = Convert.ToDateTime(txtstartdate.Text.ToString());

            Session["Enddate1"] = Convert.ToDateTime(txtenddate.Text.ToString());

            Session["Agencylist"] = strvalue;

            Response.Write("<script>");
            Response.Write("window.open('ViewRemittance.aspx' ,'_blank')");
            Response.Write("</script>");
        }

        protected void checkAll_OnCheckedChanged(object sender, EventArgs e)
        {
            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    CheckBox cb = (CheckBox)row.FindControl("chkCheck");
            //    if (cb != null)
            //    {
            //        if (chkBxHeader.Checked)
            //        {
            //            cb.Checked = true;
            //        }
            //        else
            //        {
            //            cb.Checked = false;
            //        }
            //    }
            foreach (GridViewRow row in gridOffence.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("Chkid");

                if (chk!= null)
                {
                   
                }
            }
        }
    }
}