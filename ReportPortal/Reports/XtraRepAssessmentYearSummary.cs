using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace ReportPortal.Reports
{
    public partial class XtraRepAssessmentYearSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRepAssessmentYearSummary()
        {
            InitializeComponent();
        }

        private void xrTableCell5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrTableCell5.ForeColor = Color.Blue;
        }

        private void xrTableCell5_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }
    }
}
