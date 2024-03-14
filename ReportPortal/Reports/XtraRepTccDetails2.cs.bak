namespace ReportPortal.Reports
{
    public partial class XtraRepTccDetails2 : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepTccDetails2()
        {
            InitializeComponent();
        }

        private void groupHeaderBand1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void groupHeaderBand1_BeforePrint_1(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            counter++;
            xrLabel1.Text = counter.ToString();
        }
    }
}
