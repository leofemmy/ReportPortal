using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace ReportPortal.Reports
{
    public partial class XtraRepTaxAgentlist : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRepTaxAgentlist()
        {
            InitializeComponent();
        }

        private void xrTableCell9_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrTableCell9.ForeColor = Color.Blue;
        }

        private void xrTableCell9_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }
    }
}
