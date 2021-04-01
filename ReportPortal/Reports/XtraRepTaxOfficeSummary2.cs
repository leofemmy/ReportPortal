﻿using DevExpress.XtraReports.UI;
using System.Drawing;
using System.Windows.Forms;

namespace ReportPortal.Reports
{
    public partial class XtraRepTaxOfficeSummary2 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRepTaxOfficeSummary2()
        {
            InitializeComponent();
        }

        private void xrTableCell1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrTableCell1.ForeColor = Color.Blue;
        }

        private void xrTableCell1_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Cross;
        }
    }
}
