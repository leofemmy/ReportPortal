using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ReportPortal
{
    public partial class XtraRepAssessment : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepAssessment()
        {
            InitializeComponent();
        }

        private void groupHeaderBand1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            counter++;
            xrLabel11.Text = counter.ToString();
        }
    }
}
