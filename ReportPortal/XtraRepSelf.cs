using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for XtraRepSelf
/// </summary>
public class XtraRepSelf : DevExpress.XtraReports.UI.XtraReport
{
    private TopMarginBand TopMargin;
    private BottomMarginBand BottomMargin;
    private DetailBand Detail;
    private PageHeaderBand PageHeader;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell11;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell5;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel2;
    private CalculatedField calfull;
    private XRLabel xrLabel5;
    private XRLabel xrLabel3;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel6;
    private XRLabel xrLabel4;
    public XRLabel xrlborghead;
    public XRLabel xrlbsubHead2;
    protected XRLabel xrlbsubHead;
    public XRPictureBox xrPictureBox1;
    public XRPictureBox xrPictureBox2;
    public XRPictureBox xrPictureBox3;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public XtraRepSelf()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.DataAccess.Sql.SelectQuery selectQuery1 = new DevExpress.DataAccess.Sql.SelectQuery();
        DevExpress.DataAccess.Sql.Column column1 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression1 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Table table1 = new DevExpress.DataAccess.Sql.Table();
        DevExpress.DataAccess.Sql.Column column2 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression2 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column3 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression3 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column4 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression4 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column5 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression5 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column6 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression6 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column7 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression7 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column8 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression8 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column9 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression9 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column10 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression10 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column11 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression11 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column12 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression12 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column13 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression13 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column14 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression14 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column15 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression15 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column16 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression16 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column17 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression17 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column18 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression18 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column19 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression19 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column20 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression20 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column21 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression21 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column22 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression22 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column23 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression23 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column24 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression24 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column25 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression25 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column26 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression26 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column27 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression27 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column28 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression28 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column29 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression29 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column30 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression30 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column31 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression31 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column32 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression32 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column33 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression33 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column34 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression34 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column35 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression35 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column36 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression36 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column37 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression37 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column38 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression38 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column39 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression39 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column40 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression40 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column41 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression41 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column42 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression42 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column43 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression43 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column44 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression44 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column45 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression45 = new DevExpress.DataAccess.Sql.ColumnExpression();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraRepSelf));
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
        this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.calfull = new DevExpress.XtraReports.UI.CalculatedField();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrlbsubHead = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlborghead = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlbsubHead2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
        this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
        this.xrPictureBox3 = new DevExpress.XtraReports.UI.XRPictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 129.4167F;
        this.TopMargin.Name = "TopMargin";
        // 
        // BottomMargin
        // 
        this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
        this.BottomMargin.HeightF = 36.70832F;
        this.BottomMargin.Name = "BottomMargin";
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(716.1666F, 1.999982F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(129.1666F, 23F);
        this.xrPageInfo1.TextFormatString = "Page {0} of {1}";
        // 
        // xrPageInfo2
        // 
        this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 2.00001F);
        this.xrPageInfo2.Name = "xrPageInfo2";
        this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
        this.xrPageInfo2.SizeF = new System.Drawing.SizeF(176.0417F, 23F);
        this.xrPageInfo2.TextFormatString = "{0:d MMMM, yyyy}";
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.Detail.HeightF = 27.74998F;
        this.Detail.Name = "Detail";
        // 
        // xrTable1
        // 
        this.xrTable1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1.000007F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(900F, 25F);
        this.xrTable1.StylePriority.UseFont = false;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell4,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell5});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRecordNumber([MerchantCode])")});
        this.xrTableCell1.Multiline = true;
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell1.StylePriority.UseTextAlignment = false;
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell1.Summary = xrSummary1;
        this.xrTableCell1.Text = "xrTableCell1";
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell1.Weight = 0.25304241310993719D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[calfull]")});
        this.xrTableCell4.Multiline = true;
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell4.StylePriority.UsePadding = false;
        this.xrTableCell4.StylePriority.UseTextAlignment = false;
        this.xrTableCell4.Text = "xrTableCell4";
        this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell4.Weight = 1.7978829718035987D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PayerUtin]")});
        this.xrTableCell2.Multiline = true;
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell2.StylePriority.UseTextAlignment = false;
        this.xrTableCell2.Text = "xrTableCell2";
        this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell2.Weight = 0.70934221256931751D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Occupation]")});
        this.xrTableCell3.Multiline = true;
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell3.StylePriority.UseTextAlignment = false;
        this.xrTableCell3.Text = "xrTableCell3";
        this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell3.Weight = 1.3582155445263859D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PhoneNo1]")});
        this.xrTableCell5.Multiline = true;
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell5.StylePriority.UsePadding = false;
        this.xrTableCell5.StylePriority.UseTextAlignment = false;
        this.xrTableCell5.Text = "xrTableCell5";
        this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell5.Weight = 1D;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.PageHeader.HeightF = 23.95833F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable2
        // 
        this.xrTable2.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(890F, 23.95833F);
        this.xrTable2.StylePriority.UseFont = false;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell11});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.StylePriority.UseTextAlignment = false;
        this.xrTableRow2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Multiline = true;
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell6.Text = "S/N";
        this.xrTableCell6.Weight = 0.32127048894576732D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Multiline = true;
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell7.StylePriority.UseTextAlignment = false;
        this.xrTableCell7.Text = "Name";
        this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell7.Weight = 2.9444136750481169D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Multiline = true;
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell8.StylePriority.UseTextAlignment = false;
        this.xrTableCell8.Text = "S-TIN\r\n\r\n";
        this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell8.Weight = 1.3751444713097216D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Multiline = true;
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell9.StylePriority.UsePadding = false;
        this.xrTableCell9.StylePriority.UseTextAlignment = false;
        this.xrTableCell9.Text = "Type of Business";
        this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell9.Weight = 2.0574892142337218D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Multiline = true;
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell11.StylePriority.UsePadding = false;
        this.xrTableCell11.StylePriority.UseTextAlignment = false;
        this.xrTableCell11.Text = "Telephone";
        this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell11.Weight = 1.5911408729829879D;
        // 
        // sqlDataSource1
        // 
        this.sqlDataSource1.ConnectionName = "Registration2ConnectionString";
        this.sqlDataSource1.Name = "sqlDataSource1";
        columnExpression1.ColumnName = "TaxPayerReferenceNumber";
        table1.Name = "ViewTaxPayer";
        columnExpression1.Table = table1;
        column1.Expression = columnExpression1;
        columnExpression2.ColumnName = "PayerUtin";
        columnExpression2.Table = table1;
        column2.Expression = columnExpression2;
        columnExpression3.ColumnName = "Surname";
        columnExpression3.Table = table1;
        column3.Expression = columnExpression3;
        columnExpression4.ColumnName = "FirstName";
        columnExpression4.Table = table1;
        column4.Expression = columnExpression4;
        columnExpression5.ColumnName = "OtherName";
        columnExpression5.Table = table1;
        column5.Expression = columnExpression5;
        columnExpression6.ColumnName = "DateofBirth";
        columnExpression6.Table = table1;
        column6.Expression = columnExpression6;
        columnExpression7.ColumnName = "Email";
        columnExpression7.Table = table1;
        column7.Expression = columnExpression7;
        columnExpression8.ColumnName = "Occupation";
        columnExpression8.Table = table1;
        column8.Expression = columnExpression8;
        columnExpression9.ColumnName = "DateCreated";
        columnExpression9.Table = table1;
        column9.Expression = columnExpression9;
        columnExpression10.ColumnName = "Address1";
        columnExpression10.Table = table1;
        column10.Expression = columnExpression10;
        columnExpression11.ColumnName = "Address2";
        columnExpression11.Table = table1;
        column11.Expression = columnExpression11;
        columnExpression12.ColumnName = "City";
        columnExpression12.Table = table1;
        column12.Expression = columnExpression12;
        columnExpression13.ColumnName = "LgaId";
        columnExpression13.Table = table1;
        column13.Expression = columnExpression13;
        columnExpression14.ColumnName = "LgaName";
        columnExpression14.Table = table1;
        column14.Expression = columnExpression14;
        columnExpression15.ColumnName = "Photograph";
        columnExpression15.Table = table1;
        column15.Expression = columnExpression15;
        columnExpression16.ColumnName = "ContentType";
        columnExpression16.Table = table1;
        column16.Expression = columnExpression16;
        columnExpression17.ColumnName = "FileName";
        columnExpression17.Table = table1;
        column17.Expression = columnExpression17;
        columnExpression18.ColumnName = "Signature";
        columnExpression18.Table = table1;
        column18.Expression = columnExpression18;
        columnExpression19.ColumnName = "CourtesyTitle";
        columnExpression19.Table = table1;
        column19.Expression = columnExpression19;
        columnExpression20.ColumnName = "CountryCode";
        columnExpression20.Table = table1;
        column20.Expression = columnExpression20;
        columnExpression21.ColumnName = "CountryName";
        columnExpression21.Table = table1;
        column21.Expression = columnExpression21;
        columnExpression22.ColumnName = "Capital";
        columnExpression22.Table = table1;
        column22.Expression = columnExpression22;
        columnExpression23.ColumnName = "ChannelCode";
        columnExpression23.Table = table1;
        column23.Expression = columnExpression23;
        columnExpression24.ColumnName = "ChannelName";
        columnExpression24.Table = table1;
        column24.Expression = columnExpression24;
        columnExpression25.ColumnName = "StateCode";
        columnExpression25.Table = table1;
        column25.Expression = columnExpression25;
        columnExpression26.ColumnName = "StateName";
        columnExpression26.Table = table1;
        column26.Expression = columnExpression26;
        columnExpression27.ColumnName = "MerchantCode";
        columnExpression27.Table = table1;
        column27.Expression = columnExpression27;
        columnExpression28.ColumnName = "GenderId";
        columnExpression28.Table = table1;
        column28.Expression = columnExpression28;
        columnExpression29.ColumnName = "GenderType";
        columnExpression29.Table = table1;
        column29.Expression = columnExpression29;
        columnExpression30.ColumnName = "MaritalStatusId";
        columnExpression30.Table = table1;
        column30.Expression = columnExpression30;
        columnExpression31.ColumnName = "MaritalStatusType";
        columnExpression31.Table = table1;
        column31.Expression = columnExpression31;
        columnExpression32.ColumnName = "PhoneNo1";
        columnExpression32.Table = table1;
        column32.Expression = columnExpression32;
        columnExpression33.ColumnName = "PhoneNo2";
        columnExpression33.Table = table1;
        column33.Expression = columnExpression33;
        columnExpression34.ColumnName = "PhoneNo3";
        columnExpression34.Table = table1;
        column34.Expression = columnExpression34;
        columnExpression35.ColumnName = "StateId";
        columnExpression35.Table = table1;
        column35.Expression = columnExpression35;
        columnExpression36.ColumnName = "JTBTin";
        columnExpression36.Table = table1;
        column36.Expression = columnExpression36;
        columnExpression37.ColumnName = "EmployeeName";
        columnExpression37.Table = table1;
        column37.Expression = columnExpression37;
        columnExpression38.ColumnName = "EmploymentAddress";
        columnExpression38.Table = table1;
        column38.Expression = columnExpression38;
        columnExpression39.ColumnName = "EmploymentType";
        columnExpression39.Table = table1;
        column39.Expression = columnExpression39;
        columnExpression40.ColumnName = "BusinessTypeId";
        columnExpression40.Table = table1;
        column40.Expression = columnExpression40;
        columnExpression41.ColumnName = "TaxAgentReferenceNumber";
        columnExpression41.Table = table1;
        column41.Expression = columnExpression41;
        columnExpression42.ColumnName = "Description";
        columnExpression42.Table = table1;
        column42.Expression = columnExpression42;
        columnExpression43.ColumnName = "RegTypeCode";
        columnExpression43.Table = table1;
        column43.Expression = columnExpression43;
        columnExpression44.ColumnName = "RevenueOfficeID";
        columnExpression44.Table = table1;
        column44.Expression = columnExpression44;
        columnExpression45.ColumnName = "RevenueOfficeName";
        columnExpression45.Table = table1;
        column45.Expression = columnExpression45;
        selectQuery1.Columns.Add(column1);
        selectQuery1.Columns.Add(column2);
        selectQuery1.Columns.Add(column3);
        selectQuery1.Columns.Add(column4);
        selectQuery1.Columns.Add(column5);
        selectQuery1.Columns.Add(column6);
        selectQuery1.Columns.Add(column7);
        selectQuery1.Columns.Add(column8);
        selectQuery1.Columns.Add(column9);
        selectQuery1.Columns.Add(column10);
        selectQuery1.Columns.Add(column11);
        selectQuery1.Columns.Add(column12);
        selectQuery1.Columns.Add(column13);
        selectQuery1.Columns.Add(column14);
        selectQuery1.Columns.Add(column15);
        selectQuery1.Columns.Add(column16);
        selectQuery1.Columns.Add(column17);
        selectQuery1.Columns.Add(column18);
        selectQuery1.Columns.Add(column19);
        selectQuery1.Columns.Add(column20);
        selectQuery1.Columns.Add(column21);
        selectQuery1.Columns.Add(column22);
        selectQuery1.Columns.Add(column23);
        selectQuery1.Columns.Add(column24);
        selectQuery1.Columns.Add(column25);
        selectQuery1.Columns.Add(column26);
        selectQuery1.Columns.Add(column27);
        selectQuery1.Columns.Add(column28);
        selectQuery1.Columns.Add(column29);
        selectQuery1.Columns.Add(column30);
        selectQuery1.Columns.Add(column31);
        selectQuery1.Columns.Add(column32);
        selectQuery1.Columns.Add(column33);
        selectQuery1.Columns.Add(column34);
        selectQuery1.Columns.Add(column35);
        selectQuery1.Columns.Add(column36);
        selectQuery1.Columns.Add(column37);
        selectQuery1.Columns.Add(column38);
        selectQuery1.Columns.Add(column39);
        selectQuery1.Columns.Add(column40);
        selectQuery1.Columns.Add(column41);
        selectQuery1.Columns.Add(column42);
        selectQuery1.Columns.Add(column43);
        selectQuery1.Columns.Add(column44);
        selectQuery1.Columns.Add(column45);
        selectQuery1.Name = "ViewTaxPayer";
        selectQuery1.Tables.Add(table1);
        this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            selectQuery1});
        this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
        // 
        // groupHeaderBand1
        // 
        this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLabel5,
            this.xrLabel2});
        this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("RevenueOfficeName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.groupHeaderBand1.HeightF = 27.99999F;
        this.groupHeaderBand1.KeepTogether = true;
        this.groupHeaderBand1.Name = "groupHeaderBand1";
        this.groupHeaderBand1.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
        // 
        // xrLabel3
        // 
        this.xrLabel3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([MerchantCode])")});
        this.xrLabel3.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(532.607F, 0F);
        this.xrLabel3.Multiline = true;
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(83.33331F, 23F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel3.Summary = xrSummary2;
        this.xrLabel3.Text = "xrLabel3";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel5
        // 
        this.xrLabel5.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(399.375F, 0F);
        this.xrLabel5.Multiline = true;
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(100F, 23F);
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.StylePriority.UseTextAlignment = false;
        this.xrLabel5.Text = "Group Total";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel2
        // 
        this.xrLabel2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[RevenueOfficeName]")});
        this.xrLabel2.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0.8987109F, 4.874929F);
        this.xrLabel2.Multiline = true;
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(289.5833F, 23F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.Text = "xrLabel2";
        // 
        // calfull
        // 
        this.calfull.DataMember = "ViewTaxPayer";
        this.calfull.Expression = "[Surname] + \' \' +[FirstName] + \' \' + [OtherName]";
        this.calfull.Name = "calfull";
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox3,
            this.xrPictureBox2,
            this.xrPictureBox1,
            this.xrlbsubHead,
            this.xrLabel6,
            this.xrLabel4,
            this.xrlborghead,
            this.xrlbsubHead2});
        this.ReportHeader.HeightF = 446.4164F;
        this.ReportHeader.KeepTogether = true;
        this.ReportHeader.Name = "ReportHeader";
        this.ReportHeader.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
        // 
        // xrlbsubHead
        // 
        this.xrlbsubHead.Font = new DevExpress.Drawing.DXFont("Arial Rounded MT Bold", 20F, DevExpress.Drawing.DXFontStyle.Bold);
        this.xrlbsubHead.LocationFloat = new DevExpress.Utils.PointFloat(236.5F, 212.3333F);
        this.xrlbsubHead.Multiline = true;
        this.xrlbsubHead.Name = "xrlbsubHead";
        this.xrlbsubHead.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlbsubHead.SizeF = new System.Drawing.SizeF(597.9166F, 25.08334F);
        this.xrlbsubHead.StylePriority.UseFont = false;
        this.xrlbsubHead.StylePriority.UseTextAlignment = false;
        this.xrlbsubHead.Text = "LIST OF SELF EMPLOYED TAXPAYERS ";
        this.xrlbsubHead.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Font = new DevExpress.Drawing.DXFont("Arial", 15F, DevExpress.Drawing.DXFontStyle.Bold);
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(384.875F, 303.2918F);
        this.xrLabel6.Multiline = true;
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(114.5834F, 35.49989F);
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "TOTAL:";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel4
        // 
        this.xrLabel4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([MerchantCode])")});
        this.xrLabel4.Font = new DevExpress.Drawing.DXFont("Arial", 15F, DevExpress.Drawing.DXFontStyle.Bold);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(523.375F, 303.2918F);
        this.xrLabel4.Multiline = true;
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(150F, 35.49989F);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel4.Summary = xrSummary3;
        this.xrLabel4.Text = "xrLabel4";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrLabel4.TextFormatString = "{0:#,#}";
        // 
        // xrlborghead
        // 
        this.xrlborghead.Font = new DevExpress.Drawing.DXFont("Arial Rounded MT Bold", 25F, DevExpress.Drawing.DXFontStyle.Bold);
        this.xrlborghead.LocationFloat = new DevExpress.Utils.PointFloat(242.9584F, 147.6666F);
        this.xrlborghead.Multiline = true;
        this.xrlborghead.Name = "xrlborghead";
        this.xrlborghead.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlborghead.SizeF = new System.Drawing.SizeF(586.4583F, 48.00002F);
        this.xrlborghead.StylePriority.UseFont = false;
        this.xrlborghead.StylePriority.UseTextAlignment = false;
        this.xrlborghead.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrlbsubHead2
        // 
        this.xrlbsubHead2.Font = new DevExpress.Drawing.DXFont("Arial Rounded MT Bold", 19F, DevExpress.Drawing.DXFontStyle.Bold);
        this.xrlbsubHead2.LocationFloat = new DevExpress.Utils.PointFloat(231.5001F, 255.1249F);
        this.xrlbsubHead2.Multiline = true;
        this.xrlbsubHead2.Name = "xrlbsubHead2";
        this.xrlbsubHead2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlbsubHead2.SizeF = new System.Drawing.SizeF(597.9165F, 25.08334F);
        this.xrlbsubHead2.StylePriority.UseFont = false;
        this.xrlbsubHead2.StylePriority.UseTextAlignment = false;
        this.xrlbsubHead2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrPictureBox1
        // 
        this.xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox1.ImageSource"));
        this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(35.77F, 120.96F);
        this.xrPictureBox1.Name = "xrPictureBox1";
        this.xrPictureBox1.SizeF = new System.Drawing.SizeF(162.5F, 132F);
        this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
        // 
        // xrPictureBox2
        // 
        this.xrPictureBox2.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox2.ImageSource"));
        this.xrPictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(35.77F, 120.96F);
        this.xrPictureBox2.Name = "xrPictureBox2";
        this.xrPictureBox2.SizeF = new System.Drawing.SizeF(162.5F, 132F);
        this.xrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
        // 
        // xrPictureBox3
        // 
        this.xrPictureBox3.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox3.ImageSource"));
        this.xrPictureBox3.LocationFloat = new DevExpress.Utils.PointFloat(35.77F, 120.96F);
        this.xrPictureBox3.Name = "xrPictureBox3";
        this.xrPictureBox3.SizeF = new System.Drawing.SizeF(162.5F, 132F);
        this.xrPictureBox3.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
        // 
        // XtraRepSelf
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.PageHeader,
            this.groupHeaderBand1,
            this.ReportHeader});
        this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.calfull});
        this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
        this.DataMember = "ViewTaxPayer";
        this.DataSource = this.sqlDataSource1;
        this.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F);
        this.Landscape = true;
        this.Margins = new DevExpress.Drawing.DXMargins(100, 100, 129, 37);
        this.PageHeight = 850;
        this.PageWidth = 1100;
        this.Version = "19.2";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
