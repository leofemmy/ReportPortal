using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace ReportPortal
{
    public partial class Remit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string PostPreview(string[] agencylist, DateTime startdate, DateTime enddate)
        {
            
            string retvalue = String.Empty;

            string strvalue = String.Empty; int j = 0;

            int h = agencylist.Count();

            for (int i = 0; i < agencylist.Length; i++)
            {
                strvalue += String.Format("'{0}'", agencylist[i]);
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

            var startdat = string.Format("{0:yyyy-MM-dd}", HttpContext.Current.Session["Startdate"].ToString());

            var enddat = string.Format("{0:yyyy-MM-dd}", HttpContext.Current.Session["Enddate"].ToString());

            var end = Convert.ToDateTime(HttpContext.Current.Session["Enddate1"].ToString()).ToString("yyyy/MM/dd");

            var strat = Convert.ToDateTime(HttpContext.Current.Session["startdate1"].ToString()).ToString("yyyy/MM/dd");

            var strrevenue = HttpContext.Current.Session["Agencylist"].ToString();//Session["Agencylist"].ToString();

            if (Encodings.IsValidUser(String.Format("SELECT PayerID, TaxAgentUtin, TaxAgentName,  address,  PaymentRefNumber, Amount, RevenueOfficeID, RevenueOfficeName, RevenueCode,  PaymentDate,AgencyName,BankName FROM vwRemittance WHERE PaymentDate BETWEEN '{0}' AND '{1}' AND TaxAgentUtin IN ({2}) ORDER BY TaxAgentName ASC",
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
    }
}