﻿namespace ReportPortal.Reports
{
    public partial class XtraRepViewDetailByYear : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepViewDetailByYear()
        {
            InitializeComponent();
        }

        private void groupHeaderBand2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            counter++;
            xrLabel5.Text = counter.ToString();
        }
    }
}
