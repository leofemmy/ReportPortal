namespace ReportPortal.Reports
{
    public partial class XtraRepTCCDetailsbyAll : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepTCCDetailsbyAll()
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
