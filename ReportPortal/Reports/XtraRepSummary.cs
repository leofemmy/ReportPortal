using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace ReportPortal.Reports
{
    public partial class XtraRepSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRepSummary()
        {
            InitializeComponent();
        }

        private void xrTableCell1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrTableCell1.ForeColor=Color.Blue;
            
        }

        private void xrTableCell1_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }

        private void xrTableCell1_PreviewClick(object sender, PreviewMouseEventArgs e)
        {

        }
    }
}
