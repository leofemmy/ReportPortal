using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ReportPortal
{
    public partial class XtraRepPayment2 : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepPayment2()
        {
            InitializeComponent();
        }

        private void groupHeaderBand1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            counter++;
            xrTableCell26.Text = counter.ToString();
        }
    }
}
