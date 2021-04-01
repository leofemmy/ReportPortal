<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.Master" AutoEventWireup="true" CodeBehind="TrendAnalysis.aspx.cs" Inherits="ReportPortal.TrendAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/select2.min.css" rel="stylesheet" />
    <link href="plugins/vendors/bower_components/datatables.net-bs4/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="plugins/vendors/bower_components/data-table/css/buttons.dataTables.min.css">
    <link rel="stylesheet" type="text/css" href="plugins/vendors/bower_components/datatables.net-responsive-bs4/css/responsive.bootstrap4.min.css">

    <link href="Content/css/select2.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12 col-xs-12">
            <div class="panel panel-default card-view">
                <div class="panel-heading">
                    <div class="pull-left">
                        <h6 class="panel-title txt-dark">Trend Analysis Report  </h6>
                    </div>
                    <div class="clearfix"></div>
                    <br />
                    <asp:Label runat="server" ID="txtiddisplay" Text="You need to enable your browser pop-Up at the top right corner to view the report" ForeColor="red" Visible="False"></asp:Label>
                </div>
            </div>
            <%--contect herer--%>
            <div class="panel-wrapper collapse in">
                <div class="panel-body">
                    <form class="form-horizontal" runat="server">
                        <div class="form-group">
                            <asp:Label ID="Label2" class="control-label mb-10 col-sm-2" runat="server" Text="Revenue Type"></asp:Label>
                            <div class="col-sm-2">
                                <asp:DropDownList ID="ddlRevenue" CssClass="form-control " runat="server"></asp:DropDownList>
                            </div>
                            <asp:Label ID="Label16" class="control-label mb-10 col-sm-2" runat="server" Text="Start Date:"></asp:Label>
                            <div class="col-sm-2">
                                <asp:TextBox ID="txtstartdate" runat="server" CausesValidation="false" autocomplete="off" ClientIDMode="Static" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton2" runat="server" ClientIDMode="Static" ImageUrl="~/images/clearimage.jpeg" OnClientClick="ClearTextboxes1();" />
                            </div>
                            <asp:Label ID="Label4" runat="server" class="control-label mb-10 col-sm-2" Text="End Date: "></asp:Label>
                            <div class="col-sm-2">
                                <asp:TextBox ID="txtenddate" runat="server" CausesValidation="false" autocomplete="off" ClientIDMode="Static" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton1" runat="server" ClientIDMode="Static" ImageUrl="~/images/clearimage.jpeg" OnClientClick="ClearTextboxes1();" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-6 col-xs-12 form-group" style="height: 650px; width: 500px; overflow: auto; position: relative; overflow-x: hidden; overflow-y: auto;">
                                <asp:Label ID="Label1" class="control-label mb-10 col-sm-2" runat="server" Text="Check Revenue Office" Width="200px"></asp:Label>
                                <asp:GridView ID="gridOffence" runat="server" CssClass="table table-striped table-bordered nowrap" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" onclick="Check_Click(this)" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agency Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbname" runat="server" Text='<%# Bind("RevenueOfficeName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TaxAgentUtin" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltin" runat="server" Text='<%# Bind("RevenueOfficeID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>

                        </div>
                        <div class="form-group ">
                            <div class="col-sm-offset-2 col-sm-6">
                                <asp:Button ID="btnpreview" runat="server" Text="Preview" class="btn btn-primary btn-anim text-uppercas" />
                            </div>
                        </div>


                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContentHolder" runat="server">
    <!-- data-table js -->
    <script src="plugins/vendors/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="plugins/vendors/bower_components/datatables.net-buttons/js/dataTables.buttons.min.js"></script>
    <script src="plugins/vendors/bower_components/data-table/js/jszip.min.js"></script>
    <script src="plugins/vendors/bower_components/data-table/js/pdfmake.min.js"></script>
    <script src="plugins/vendors/bower_components/data-table/js/vfs_fonts.js"></script>
    <script src="plugins/vendors/bower_components/datatables.net-buttons/js/buttons.print.min.js"></script>
    <script src="plugins/vendors/bower_components/datatables.net-buttons/js/buttons.html5.min.js"></script>
    <script src="plugins/vendors/bower_components/datatables.net-bs4/js/dataTables.bootstrap4.min.js"></script>
    <script src="plugins/vendors/bower_components/datatables.net-responsive/js/dataTables.responsive.min.js"></script>
    <script src="plugins/vendors/bower_components/datatables.net-responsive-bs4/js/responsive.bootstrap4.min.js"></script>

    <script type="text/javascript" src="Scripts/select2.min.js"></script>

    <link href="<%: ResolveUrl("~/js/1.8/jquery-ui.css") %>" rel="stylesheet" />
    <script type="text/javascript">

        $(document).ready(function () {

            document.getElementById('txtstartdate').value = '';

            document.getElementById('txtenddate').value = '';

            $("#<%=ddlRevenue.ClientID%>").select2({

                placeholder: "Select Item",

                allowClear: true

            });


            $("[id$=txtstartdate]").datepicker({
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true

            });

            $("[id$=txtenddate]").datepicker({
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true
            });


            function ClearTextboxes() {
                document.getElementById('txtstartdate').value = '';
            }

            function ClearTextboxes1() {
                document.getElementById('txtenddate').value = '';
            }
        });

    </script>
</asp:Content>
