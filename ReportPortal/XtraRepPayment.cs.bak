namespace ReportPortal
{
    public partial class XtraRepPayment : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepPayment()
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
