using DevExpress.XtraReports.UI;
using System.Drawing;
using System.Windows.Forms;

namespace ReportPortal.Reports
{
    public partial class XtraRepAssessmentCummulativeSummaryChild : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRepAssessmentCummulativeSummaryChild()
        {
            InitializeComponent();
        }

        private void xrTableCell1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrTableCell1.ForeColor = Color.Blue;
        }

        private void xrTableCell1_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }
    }
}
