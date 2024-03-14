namespace ReportPortal
{
    public partial class XtraRepAssessment : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepAssessment()
        {
            InitializeComponent();
        }

        private void groupHeaderBand1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            counter++;
            xrLabel11.Text = counter.ToString();
        }
    }
}
