﻿namespace ReportPortal
{
    public partial class XtraRepPayerledge : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepPayerledge()
        {
            InitializeComponent();
        }

        private void groupHeaderBand1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            counter++;
            xrLabel5.Text = counter.ToString();
        }
    }
}
