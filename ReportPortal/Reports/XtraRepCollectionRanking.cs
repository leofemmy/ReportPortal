using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ReportPortal.Reports
{
    public partial class XtraRepCollectionRanking : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRepCollectionRanking()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrPivotGrid1.BestFit();
        }

        private void xrPivotGrid1_FieldValueDisplayText(object sender, DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs e)
        {
            if (e.ValueType == DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal)
                if (e.DisplayText == "Grand Total")
                    e.DisplayText = "Total";
                else
                    e.DisplayText = e.DataField.SummaryType.ToString();

            //if (!e.IsColumn && (e.Field == null || e.Field.AreaIndex == 0))
            //{
            //    e.DisplayText = string.Format("{0}. {1}", e.MinIndex, e.DisplayText);
            //}
        }
    }
}
