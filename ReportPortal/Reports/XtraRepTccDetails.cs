﻿namespace ReportPortal.Reports
{
    public partial class XtraRepTccDetails : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepTccDetails()
        {
            InitializeComponent();
        }

        private void groupHeaderBand1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            counter++;
            xrLabel1.Text = counter.ToString();
        }
    }
}
