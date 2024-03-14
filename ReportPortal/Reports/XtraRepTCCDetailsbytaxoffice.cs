namespace ReportPortal.Reports
{
    public partial class XtraRepTCCDetailsbytaxoffice : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepTCCDetailsbytaxoffice()
        {
            InitializeComponent();
        }

        private void groupHeaderBand2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            counter++;
            xrLabel6.Text = counter.ToString();
        }

        private void groupHeaderBand1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            counter = 0;
        }
    }
}
