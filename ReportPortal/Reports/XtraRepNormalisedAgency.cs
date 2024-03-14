using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ReportPortal.Reports
{
    public partial class XtraRepNormalisedAgency : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRepNormalisedAgency()
        {
            InitializeComponent();
        }

        private void xrTableCell2_BeforePrint(object sender, CancelEventArgs e)
        {
            xrTableCell2.ForeColor = Color.Blue;
        }

        private void xrTableCell2_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }
    }
}
