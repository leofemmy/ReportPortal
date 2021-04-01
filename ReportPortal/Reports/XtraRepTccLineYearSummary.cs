using DevExpress.XtraReports.UI;
using System.Drawing;
using System.Windows.Forms;

namespace ReportPortal.Reports
{
    public partial class XtraRepTccLineYearSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRepTccLineYearSummary()
        {
            InitializeComponent();
        }

        private void xrTableCell2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrTableCell2.ForeColor = Color.Blue;
        }

        private void xrTableCell2_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }
    }
}
