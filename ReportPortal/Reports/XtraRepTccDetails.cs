namespace ReportPortal.Reports
{
    public partial class XtraRepTccDetails : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepTccDetails()
        {
            InitializeComponent();
        }

        private void groupHeaderBand1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            counter++;
            xrLabel1.Text = counter.ToString();
        }
    }
}
