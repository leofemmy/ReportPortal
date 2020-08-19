using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ReportPortal.Reports
{
    public partial class XtraRepViewdetailByTaxOffice : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepViewdetailByTaxOffice()
        {
            InitializeComponent();
        }

        private void groupHeaderBand2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            counter++;
            xrLabel3.Text = counter.ToString();
        }

        private void groupHeaderBand1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            counter = 0;
        }
    }
}
