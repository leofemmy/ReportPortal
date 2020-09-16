using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReportPortal.Class;

namespace ReportPortal
{
    public partial class Business : System.Web.UI.Page
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
                setloadOffice();
            }
        }

        void setloadOffice()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT BusinessTypeId,  BusinessTypeName FROM Setting.BusinessType ORDER BY BusinessTypeName asc"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gridOffence.DataSource = dt;
                            gridOffence.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnpreview_Click(object sender, EventArgs e)
        {
            int totalCount = gridOffence.Rows.Cast<GridViewRow>()
                           .Count(r => ((CheckBox)r.FindControl("CheckBox1")).Checked);


            Session["Startdate"] = txtstartdate.Text.ToString();

            Session["Enddate"] = txtenddate.Text.ToString();

            Session["startdate1"] = Convert.ToDateTime(txtstartdate.Text.ToString());

            Session["Enddate1"] = Convert.ToDateTime(txtenddate.Text.ToString());

            foreach (GridViewRow row in gridOffence.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("CheckBox1");

                Label lbltin = (Label)row.FindControl("lbltin");

                if (chk != null & chk.Checked)
                {
                    strvalue += String.Format("{0}", lbltin.Text);

                    if (j + 1 < totalCount)
                    {
                        strvalue += ",";
                        ++j;
                    }
                }

            }

            //var strrevenue = Session["Agencylist"].ToString();

            var startdate = Session["Startdate"].ToString(); var enddate = Session["Enddate"].ToString();


            Session["Agencylist"] = strvalue;

            if (Extension.GetRecordcounts(String.Format("SELECT BusinessTypeID, BusinessTypeName, SUM(Amount) AS Amount FROM dbo.vwBusinessSectors WHERE PaymentDate BETWEEN '{0}' AND '{1}' AND BusinessTypeID IN ({2}) GROUP BY BusinessTypeID, BusinessTypeName ORDER BY BusinessTypeName ASC", startdate, enddate, strvalue)))
            {
                Response.Write("<script>");
                Response.Write("window.open('ViewBusiness.aspx' ,'_blank')");
                Response.Write("</script>");
            }
            else
            {
                Extension.MsgBox("Record Not Found for Selected Range!", this.Page, this);
            }


        }
    }
}