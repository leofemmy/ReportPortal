using DevExpress.XtraReports.UI;
using System.Drawing;
using System.Windows.Forms;

namespace ReportPortal.Reports
{
    public partial class XtraRepYearLineSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRepYearLineSummary()
        {
            InitializeComponent();
        }

        private void xrTableCell4_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            xrTableCell4.ForeColor = Color.Blue;
        }

        private void xrTableCell4_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }
    }
}
