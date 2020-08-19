﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ReportPortal.Reports
{
    public partial class XtraRepTCCDetailByYear : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepTCCDetailByYear()
        {
            InitializeComponent();
        }

        private void xrLabel5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            counter++;
            xrLabel5.Text = counter.ToString();
        }
    }
}
