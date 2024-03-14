using DevExpress.XtraReports.UI;
using System.Drawing;
using System.Windows.Forms;

namespace ReportPortal.Reports
{
    public partial class XtraRepTaxAgentlist : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRepTaxAgentlist()
        {
            InitializeComponent();
        }

        private void xrTableCell9_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            xrTableCell9.ForeColor = Color.Blue;
        }

        private void xrTableCell9_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }
    }
}
