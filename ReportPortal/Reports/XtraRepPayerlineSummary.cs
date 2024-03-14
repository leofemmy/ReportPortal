using DevExpress.XtraReports.UI;
using System.Drawing;
using System.Windows.Forms;

namespace ReportPortal.Reports
{
    public partial class XtraRepPayerlineSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRepPayerlineSummary()
        {
            InitializeComponent();
        }

        private void xrTableCell2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            xrTableCell2.ForeColor = Color.Blue;
        }

        private void xrTableCell2_PreviewMouseUp(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }
    }
}
