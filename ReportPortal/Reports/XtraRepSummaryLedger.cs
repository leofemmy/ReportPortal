using DevExpress.XtraReports.UI;
using System.Drawing;
using System.Windows.Forms;

namespace ReportPortal
{
    public partial class XtraRepSummaryLedger : DevExpress.XtraReports.UI.XtraReport
    {
        string strutin; private string strname, strcode;

        private void xrLabel4_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            xrLabel4.ForeColor = Color.MediumPurple;
        }

        private void xrLabel4_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            var stin = e.Brick.Value;
        }

        private void xrLabel4_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }

        public XtraRepSummaryLedger()
        {
            InitializeComponent();

        }


    }
}
