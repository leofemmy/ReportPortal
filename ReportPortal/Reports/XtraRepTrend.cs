using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ReportPortal.Reports
{
    public partial class XtraRepTrend : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRepTrend()
        {
            InitializeComponent();
            xrPivotGrid1.FieldValueDisplayText += XrPivotGrid1_FieldValueDisplayText;
        }

        private void XrPivotGrid1_FieldValueDisplayText(object sender, DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs e)
        {
            if (e.ValueType == DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal)
                if (e.DisplayText == "Grand Total")
                    e.DisplayText = "Total";
                else
                    e.DisplayText = e.DataField.SummaryType.ToString();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrPivotGrid1.BestFit();
        }
    }
}
