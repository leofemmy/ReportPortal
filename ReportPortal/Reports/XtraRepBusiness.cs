using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace ReportPortal.Reports
{
    public partial class XtraRepBusiness : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRepBusiness()
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
