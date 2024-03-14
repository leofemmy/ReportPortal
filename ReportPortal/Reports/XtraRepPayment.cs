﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ReportPortal
{
    public partial class XtraRepPayment : DevExpress.XtraReports.UI.XtraReport
    {
        int counter = 0;
        public XtraRepPayment()
        {
            InitializeComponent();
        }

        private void groupHeaderBand1_BeforePrint(object sender, CancelEventArgs e)
        {
            counter++;
            xrLabel1.Text = counter.ToString();
        }
    }
}
