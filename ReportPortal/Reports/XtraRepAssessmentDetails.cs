﻿namespace ReportPortal.Reports
{
    public partial class XtraRepAssessmentDetails : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepAssessmentDetails()
        {
            InitializeComponent();
        }

        private void groupHeaderBand1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            counter++;
            xrLabel2.Text = counter.ToString();
        }
    }
}
