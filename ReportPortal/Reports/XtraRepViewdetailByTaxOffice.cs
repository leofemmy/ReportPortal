namespace ReportPortal.Reports
{
    public partial class XtraRepViewdetailByTaxOffice : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepViewdetailByTaxOffice()
        {
            InitializeComponent();
        }

        private void groupHeaderBand2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            counter++;
            xrLabel3.Text = counter.ToString();
        }

        private void groupHeaderBand1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            counter = 0;
        }
    }
}
