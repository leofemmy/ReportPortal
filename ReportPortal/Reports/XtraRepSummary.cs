using DevExpress.XtraReports.UI;
using System.Drawing;
using System.Windows.Forms;

namespace ReportPortal.Reports
{
    public partial class XtraRepSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRepSummary()
        {
            InitializeComponent();
        }

        private void xrTableCell1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            xrTableCell1.ForeColor = Color.Blue;

        }

        private void xrTableCell1_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }

        private void xrTableCell1_PreviewClick(object sender, PreviewMouseEventArgs e)
        {

        }
    }
}
