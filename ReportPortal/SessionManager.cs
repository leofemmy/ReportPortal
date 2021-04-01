using System;
using System.Web;

namespace ReportPortal
{
    public class SessionManager
    {
        public string Activecode
        {
            get
            {
                return HttpContext.Current.Session["Activecode"] == null ?
                    null : HttpContext.Current.Session["Activecode"].ToString();
            }
            set
            {
                HttpContext.Current.Session["Activecode"] = value;
            }
        }

        public DateTime Startdate
        {
            get
            {
                return HttpContext.Current.Session["Startdate"] == null ?
                    DateTime.Now : Convert.ToDateTime(HttpContext.Current.Session["Startdate"]);
            }
            set
            {
                HttpContext.Current.Session["Startdate"] = value;
            }
        }

        public DateTime Enddate
        {
            get
            {
                return HttpContext.Current.Session["Enddate"] == null ?
                    DateTime.Now : Convert.ToDateTime(HttpContext.Current.Session["Enddate"]);
            }
            set
            {
                HttpContext.Current.Session["Enddate"] = value;
            }
        }

        public string Email
        {
            get
            {
                return HttpContext.Current.Session["RegEmail"] == null ?
                    null : HttpContext.Current.Session["RegEmail"].ToString();
            }
            set
            {
                HttpContext.Current.Session["RegEmail"] = value;
            }
        }
        public string fullname
        {
            get
            {
                return HttpContext.Current.Session["fullname"] == null ?
                    null : HttpContext.Current.Session["fullname"].ToString();
            }
            set
            {
                HttpContext.Current.Session["fullname"] = value;
            }
        }
        public string MerchantCode
        {
            get
            {
                return HttpContext.Current.Session["MerchantCode"] == null ?
                    null : HttpContext.Current.Session["MerchantCode"].ToString();
            }
            set
            {
                HttpContext.Current.Session["MerchantCode"] = value;
            }
        }
        public decimal Employee
        {
            get
            {
                return HttpContext.Current.Session["Employee"] != null ?
                    Convert.ToDecimal(HttpContext.Current.Session["Employee"].ToString()) : 0m;
            }
            set
            {
                HttpContext.Current.Session["Employee"] = value;

            }
        }
        public decimal Paye
        {
            get
            {
                return HttpContext.Current.Session["Paye"] != null ?
                    Convert.ToDecimal(HttpContext.Current.Session["Paye"].ToString()) : 0m;
            }
            set
            {
                HttpContext.Current.Session["Paye"] = value;

            }
        }
        public decimal Agent
        {
            get
            {
                return HttpContext.Current.Session["Agent"] != null ?
                    Convert.ToDecimal(HttpContext.Current.Session["Agent"].ToString()) : 0m;
            }
            set
            {
                HttpContext.Current.Session["Agent"] = value;

            }
        }

        public string usertype
        {
            get
            {
                return HttpContext.Current.Session["usertype"] == null ?
                    null : HttpContext.Current.Session["usertype"].ToString();
            }
            set
            {
                HttpContext.Current.Session["usertype"] = value;
            }
        }
    }
}