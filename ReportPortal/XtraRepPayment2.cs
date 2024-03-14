namespace ReportPortal
{
    public partial class XtraRepPayment2 : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepPayment2()
        {
            InitializeComponent();
        }

        private void groupHeaderBand1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            counter++;
            xrTableCell26.Text = counter.ToString();
        }
    }
}
