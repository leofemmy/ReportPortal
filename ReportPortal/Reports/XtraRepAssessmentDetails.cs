namespace ReportPortal.Reports
{
    public partial class XtraRepAssessmentDetails : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepAssessmentDetails()
        {
            InitializeComponent();
        }

        private void groupHeaderBand1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            counter++;
            xrLabel2.Text = counter.ToString();
        }
    }
}
