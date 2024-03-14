using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace ReportPortal
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();
        }

        private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Tag = GetCurrentRow();
        }

        private void xrLabel3_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }

        private void xrLabel3_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            // Create a new Detail Report instance.
            //DetailReport detailReport = new DetailReport();

            //// Obtain the current category's ID and Name from the e.Brick.Value property,
            //// which stores an object assigned the label's Tag property.
            //detailReport.Paramters["catId"].Value = (int)((DataRowView)e.Brick.Value).Row["CategoryID"];
            //detailReport.Paramters["catName"].Value = ((DataRowView)e.Brick.Value).Row["CategoryName"].ToString();

            //// Show the detail report in a new modal window.
            //ReportPrintTool pt = new ReportPrintTool(detailReport);
            //pt.ShowPreviewDialog();
        }
    }
}
