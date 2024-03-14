using DevExpress.XtraReports.UI;
using System.Drawing;
using System.Windows.Forms;

namespace ReportPortal.Reports
{
    public partial class XtraRepSelfEmployed : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRepSelfEmployed()
        {
            InitializeComponent();
        }

        private void xrTableCell2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            xrTableCell2.ForeColor = Color.Blue;
        }

        private void xrTableCell2_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }
    }
}
