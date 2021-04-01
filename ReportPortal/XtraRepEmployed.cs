using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for XtraRepEmployed
/// </summary>
public class XtraRepEmployed : DevExpress.XtraReports.UI.XtraReport
{
    private TopMarginBand TopMargin;
    private BottomMarginBand BottomMargin;
    private DetailBand Detail;
    protected XRLabel xrlbsubHead;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private GroupHeaderBand GroupHeader1;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel1;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell5;
    private CalculatedField calFullname;
    private PageHeaderBand PageHeader;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell11;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource2;
    private ReportHeaderBand ReportHeader;
    public XRLabel xrlborghead;
    public XRLabel xrlbsubHead2;
    private XRLabel xrLabel6;
    private XRLabel xrLabel3;
    public XRPictureBox xrPictureBox3;
    public XRPictureBox xrPictureBox2;
    public XRPictureBox xrPictureBox1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public XtraRepEmployed()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraRepEmployed));
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.DataAccess.Sql.SelectQuery selectQuery2 = new DevExpress.DataAccess.Sql.SelectQuery();
        DevExpress.DataAccess.Sql.Column column11 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression11 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Table table2 = new DevExpress.DataAccess.Sql.Table();
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
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.xrlbsubHead = new DevExpress.XtraReports.UI.XRLabel();
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
        this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.calFullname = new DevExpress.XtraReports.UI.CalculatedField();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.sqlDataSource2 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrPictureBox3 = new DevExpress.XtraReports.UI.XRPictureBox();
        this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
        this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlborghead = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlbsubHead2 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 51.29171F;
        this.TopMargin.Name = "TopMargin";
        // 
        // xrlbsubHead
        // 
        this.xrlbsubHead.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F, System.Drawing.FontStyle.Bold);
        this.xrlbsubHead.LocationFloat = new DevExpress.Utils.PointFloat(245.9583F, 216.4999F);
        this.xrlbsubHead.Multiline = true;
        this.xrlbsubHead.Name = "xrlbsubHead";
        this.xrlbsubHead.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlbsubHead.SizeF = new System.Drawing.SizeF(597.9166F, 43.83334F);
        this.xrlbsubHead.StylePriority.UseFont = false;
        this.xrlbsubHead.StylePriority.UseTextAlignment = false;
        this.xrlbsubHead.Text = "LIST OF PAYE TAXPAYERS";
        this.xrlbsubHead.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // BottomMargin
        // 
        this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
        this.BottomMargin.HeightF = 27.45836F;
        this.BottomMargin.Name = "BottomMargin";
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(688.6667F, 4.458364F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(155.2083F, 23F);
        this.xrPageInfo1.TextFormatString = "Page {0} of {1}";
        // 
        // xrPageInfo2
        // 
        this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 0F);
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
        this.Detail.Font = new System.Drawing.Font("Arial", 8F);
        this.Detail.HeightF = 25.79165F;
        this.Detail.Name = "Detail";
        this.Detail.StylePriority.UseFont = false;
        // 
        // xrTable1
        // 
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(890F, 25F);
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
        this.xrTableCell1.Weight = 0.1937825063641152D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PayerName]")});
        this.xrTableCell4.Multiline = true;
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell4.StylePriority.UsePadding = false;
        this.xrTableCell4.StylePriority.UseTextAlignment = false;
        this.xrTableCell4.Text = "xrTableCell4";
        this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell4.Weight = 1.7759987477506145D;
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
        this.xrTableCell2.Weight = 0.8938257453146945D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OrganizationName]")});
        this.xrTableCell3.Multiline = true;
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell3.StylePriority.UseTextAlignment = false;
        this.xrTableCell3.Text = "xrTableCell3";
        this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell3.Weight = 1.2494547983233848D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PhoneNo]")});
        this.xrTableCell5.Multiline = true;
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell5.StylePriority.UsePadding = false;
        this.xrTableCell5.StylePriority.UseTextAlignment = false;
        this.xrTableCell5.Text = "xrTableCell5";
        this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell5.Weight = 0.886938202247191D;
        // 
        // sqlDataSource1
        // 
        this.sqlDataSource1.ConnectionName = "Registration2ConnectionString";
        this.sqlDataSource1.Name = "sqlDataSource1";
        columnExpression1.ColumnName = "Surname";
        table1.Name = "ViewPaye";
        columnExpression1.Table = table1;
        column1.Expression = columnExpression1;
        columnExpression2.ColumnName = "FirstName";
        columnExpression2.Table = table1;
        column2.Expression = columnExpression2;
        columnExpression3.ColumnName = "OtherName";
        columnExpression3.Table = table1;
        column3.Expression = columnExpression3;
        columnExpression4.ColumnName = "PayerUtin";
        columnExpression4.Table = table1;
        column4.Expression = columnExpression4;
        columnExpression5.ColumnName = "OrganizationName";
        columnExpression5.Table = table1;
        column5.Expression = columnExpression5;
        columnExpression6.ColumnName = "PhoneNo";
        columnExpression6.Table = table1;
        column6.Expression = columnExpression6;
        columnExpression7.ColumnName = "RevenueOfficeID";
        columnExpression7.Table = table1;
        column7.Expression = columnExpression7;
        columnExpression8.ColumnName = "RevenueOfficeName";
        columnExpression8.Table = table1;
        column8.Expression = columnExpression8;
        columnExpression9.ColumnName = "DateCreated";
        columnExpression9.Table = table1;
        column9.Expression = columnExpression9;
        columnExpression10.ColumnName = "MerchantCode";
        columnExpression10.Table = table1;
        column10.Expression = columnExpression10;
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
        selectQuery1.Name = "ViewPaye";
        selectQuery1.Tables.Add(table1);
        this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            selectQuery1});
        this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.HeightF = 0F;
        this.GroupHeader1.Level = 1;
        this.GroupHeader1.Name = "GroupHeader1";
        // 
        // groupHeaderBand1
        // 
        this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel5,
            this.xrLabel1});
        this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("RevenueOfficeName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.groupHeaderBand1.HeightF = 31.12505F;
        this.groupHeaderBand1.KeepTogether = true;
        this.groupHeaderBand1.Name = "groupHeaderBand1";
        this.groupHeaderBand1.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
        // 
        // xrLabel4
        // 
        this.xrLabel4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([MerchantCode])")});
        this.xrLabel4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(562.9583F, 5.125046F);
        this.xrLabel4.Multiline = true;
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(87.5F, 23F);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel4.Summary = xrSummary2;
        this.xrLabel4.Text = "xrLabel4";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel5
        // 
        this.xrLabel5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(428.6847F, 5.125046F);
        this.xrLabel5.Multiline = true;
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(100F, 23F);
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.StylePriority.UseTextAlignment = false;
        this.xrLabel5.Text = "Group Total";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel1
        // 
        this.xrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[RevenueOfficeName]")});
        this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8.125051F);
        this.xrLabel1.Multiline = true;
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(304.1667F, 23F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.Text = "xrLabel1";
        // 
        // calFullname
        // 
        this.calFullname.DataMember = "ViewPaye";
        this.calFullname.Expression = "[Surname] + \' \'+ [FirstName]  + \' \'+ [OtherName]";
        this.calFullname.Name = "calFullname";
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.PageHeader.HeightF = 24.74998F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable2
        // 
        this.xrTable2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
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
        this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrTableCell7.Weight = 2.9444136750481169D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Multiline = true;
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell8.StylePriority.UseTextAlignment = false;
        this.xrTableCell8.Text = "S-TIN";
        this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrTableCell8.Weight = 1.4818660450729342D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Multiline = true;
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell9.StylePriority.UsePadding = false;
        this.xrTableCell9.StylePriority.UseTextAlignment = false;
        this.xrTableCell9.Text = "Employer";
        this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrTableCell9.Weight = 2.071460780562024D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Multiline = true;
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell11.StylePriority.UsePadding = false;
        this.xrTableCell11.StylePriority.UseTextAlignment = false;
        this.xrTableCell11.Text = "Telephone";
        this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrTableCell11.Weight = 1.4704477328914734D;
        // 
        // sqlDataSource2
        // 
        this.sqlDataSource2.ConnectionName = "Registration2ConnectionString";
        this.sqlDataSource2.Name = "sqlDataSource2";
        columnExpression11.ColumnName = "PayerName";
        table2.Name = "ViewPaye";
        columnExpression11.Table = table2;
        column11.Expression = columnExpression11;
        columnExpression12.ColumnName = "PayerUtin";
        columnExpression12.Table = table2;
        column12.Expression = columnExpression12;
        columnExpression13.ColumnName = "OrganizationName";
        columnExpression13.Table = table2;
        column13.Expression = columnExpression13;
        columnExpression14.ColumnName = "PhoneNo";
        columnExpression14.Table = table2;
        column14.Expression = columnExpression14;
        columnExpression15.ColumnName = "RevenueOfficeID";
        columnExpression15.Table = table2;
        column15.Expression = columnExpression15;
        columnExpression16.ColumnName = "RevenueOfficeName";
        columnExpression16.Table = table2;
        column16.Expression = columnExpression16;
        columnExpression17.ColumnName = "DateCreated";
        columnExpression17.Table = table2;
        column17.Expression = columnExpression17;
        columnExpression18.ColumnName = "MerchantCode";
        columnExpression18.Table = table2;
        column18.Expression = columnExpression18;
        selectQuery2.Columns.Add(column11);
        selectQuery2.Columns.Add(column12);
        selectQuery2.Columns.Add(column13);
        selectQuery2.Columns.Add(column14);
        selectQuery2.Columns.Add(column15);
        selectQuery2.Columns.Add(column16);
        selectQuery2.Columns.Add(column17);
        selectQuery2.Columns.Add(column18);
        selectQuery2.Name = "ViewPaye";
        selectQuery2.Tables.Add(table2);
        this.sqlDataSource2.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            selectQuery2});
        this.sqlDataSource2.ResultSchemaSerializable = resources.GetString("sqlDataSource2.ResultSchemaSerializable");
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox3,
            this.xrPictureBox2,
            this.xrPictureBox1,
            this.xrLabel6,
            this.xrLabel3,
            this.xrlbsubHead,
            this.xrlborghead,
            this.xrlbsubHead2});
        this.ReportHeader.HeightF = 601.4999F;
        this.ReportHeader.KeepTogether = true;
        this.ReportHeader.Name = "ReportHeader";
        this.ReportHeader.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
        // 
        // xrPictureBox3
        // 
        this.xrPictureBox3.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox3.ImageSource"));
        this.xrPictureBox3.LocationFloat = new DevExpress.Utils.PointFloat(35.77F, 128.3332F);
        this.xrPictureBox3.Name = "xrPictureBox3";
        this.xrPictureBox3.SizeF = new System.Drawing.SizeF(162.5F, 132F);
        this.xrPictureBox3.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
        // 
        // xrPictureBox2
        // 
        this.xrPictureBox2.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox2.ImageSource"));
        this.xrPictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(35.77F, 128.3332F);
        this.xrPictureBox2.Name = "xrPictureBox2";
        this.xrPictureBox2.SizeF = new System.Drawing.SizeF(162.5F, 132F);
        this.xrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
        // 
        // xrPictureBox1
        // 
        this.xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox1.ImageSource"));
        this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(35.77F, 120.96F);
        this.xrPictureBox1.Name = "xrPictureBox1";
        this.xrPictureBox1.SizeF = new System.Drawing.SizeF(162.5F, 132F);
        this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(441.0001F, 327.2499F);
        this.xrLabel6.Multiline = true;
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(111F, 41.41661F);
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "TOTAL:";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel3
        // 
        this.xrLabel3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([MerchantCode])")});
        this.xrLabel3.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(552.0001F, 327.2499F);
        this.xrLabel3.Multiline = true;
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(138.9583F, 41.41661F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel3.Summary = xrSummary3;
        this.xrLabel3.Text = "xrLabel3";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrLabel3.TextFormatString = "{0:#,#}";
        // 
        // xrlborghead
        // 
        this.xrlborghead.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F, System.Drawing.FontStyle.Bold);
        this.xrlborghead.LocationFloat = new DevExpress.Utils.PointFloat(257.4167F, 138.2916F);
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
        this.xrlbsubHead2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19F, System.Drawing.FontStyle.Bold);
        this.xrlbsubHead2.LocationFloat = new DevExpress.Utils.PointFloat(245.9583F, 273.8749F);
        this.xrlbsubHead2.Multiline = true;
        this.xrlbsubHead2.Name = "xrlbsubHead2";
        this.xrlbsubHead2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlbsubHead2.SizeF = new System.Drawing.SizeF(597.9165F, 25.08334F);
        this.xrlbsubHead2.StylePriority.UseFont = false;
        this.xrlbsubHead2.StylePriority.UseTextAlignment = false;
        this.xrlbsubHead2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // XtraRepEmployed
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.GroupHeader1,
            this.groupHeaderBand1,
            this.PageHeader,
            this.ReportHeader});
        this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.calFullname});
        this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1,
            this.sqlDataSource2});
        this.DataMember = "ViewPaye";
        this.DataSource = this.sqlDataSource2;
        this.Font = new System.Drawing.Font("Arial", 9.75F);
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(100, 100, 51, 27);
        this.PageHeight = 850;
        this.PageWidth = 1100;
        this.Version = "20.2";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
