<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.Master" AutoEventWireup="true" CodeBehind="Remit.aspx.cs" Inherits="ReportPortal.Remit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="https://cdn3.devexpress.com/jslib/20.1.3/css/dx.common.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn3.devexpress.com/jslib/20.1.3/css/dx.material.teal.light.compact.css" />
    <script src="https://cdn3.devexpress.com/jslib/20.1.3/js/dx.all.js"></script>

    <link href="<%:ResolveUrl("~/Content/css/select2.min.css" )%>" rel="stylesheet" />

    <link href="<%:ResolveUrl("~/plugins/vendors/bower_components/bootstrap-material-datetimepicker/css/bootstrap-material-datetimepicker.css") %>" rel="stylesheet">
    <!-- Page plugins css -->
    <link href="<%:ResolveUrl("~/plugins/vendors/bower_components/clockpicker/dist/jquery-clockpicker.min.css") %>" rel="stylesheet">
    <!-- Date picker plugins css -->
    <link href="<%:ResolveUrl("~/plugins/vendors/bower_components/bootstrap-datepicker/bootstrap-datepicker.min.css")%>" rel="stylesheet" type="text/css" />
    <!-- Daterange picker plugins css -->
    <link href="<%:ResolveUrl("~/plugins/vendors/bower_components/timepicker/bootstrap-timepicker.min.css") %>" rel="stylesheet">
    <link href="<%:ResolveUrl("~/plugins/vendors/bower_components/bootstrap-daterangepicker/daterangepicker.css") %>" rel="stylesheet">

    <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>--%>
    <!-- Data Table Css -->
    <link rel="stylesheet" type="text/css"
        href="<%:ResolveUrl("~/plugins/vendors/bower_components/datatables.net-bs4/css/dataTables.bootstrap4.min.css")%>">
    <link rel="stylesheet" type="text/css" href="<%:ResolveUrl("~/plugins/vendors/bower_components/data-table/css/buttons.dataTables.min.css")%>">
    <link rel="stylesheet" type="text/css" href="<%:ResolveUrl("~/plugins/vendors/bower_components/datatables.net-responsive-bs4/css/responsive.bootstrap4.min.css")%>">
    <%--    <link href="<%:ResolveUrl("~/devexpress/styles.css)%>" rel="stylesheet" />--%>
    <link rel="stylesheet" type="text/css" href="<%:ResolveUrl("~/devexpress/styles.css") %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12 col-xs-12">
                <div class="panel panel-default card-view">
                    <div class="panel-heading">
                        <div class="pull-left">
                            <h6 class="panel-title txt-dark">Agent Remittance Statement  </h6>
                        </div>
                        <div class="clearfix"></div>
                        <br />
                        <asp:Label runat="server" ID="txtiddisplay" Text="You need to enable your browser pop-Up at the top right corner to view the report" ForeColor="red" Visible="False" Style="text-align: right;"></asp:Label>
                    </div>


                    <form id="form1" runat="server">
                        <div class="col-sm-6 col-xs-12">
                            <div class="panel-collapse collapse in">
                                <div class="panel-body">
                                    <div>
                                        <div id="gridContainer"></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6 col-xs-12">
                            <div class="panel-wrapper collapse in">
                                <div class="panel-body">
                                    <asp:Label ID="Label16" class="control-label col-sm-3" runat="server" Text="Start Date:"></asp:Label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtstartdate" runat="server" CausesValidation="false" autocomplete="off" ClientIDMode="Static" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        <asp:ImageButton ID="ImageButton2" runat="server" ClientIDMode="Static" ImageUrl="~/images/clearimage.jpeg" OnClientClick="ClearTextboxes1();" />
                                    </div>
                                    <asp:Label ID="Label4" runat="server" class="control-label col-sm-3" Text="End Date: "></asp:Label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtenddate" runat="server" CausesValidation="false" autocomplete="off" ClientIDMode="Static" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ClientIDMode="Static" ImageUrl="~/images/clearimage.jpeg" OnClientClick="ClearTextboxes1();" />
                                    </div>
                                    <div class="col-sm-3"></div>
                                    <div class="col-sm-3">
                                        <button type="button" id="btnpreview" class="btn btn-primary btn-anim"><i class="fa fa-paper-plane"></i><span class="btn-text text-uppercase">Preview</span></button>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </form>

                </div>
            </div>

        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContentHolder" runat="server">

    <script type="text/javascript" src="<%: ResolveUrl("~/Scripts/select2.min.js")%>"></script>

    <script>  
        $(document).ready(function () {

            var dataGrid;
            var rows_selected = [];

            var url = '<%=ConfigurationManager.AppSettings["AgentUrl"] %>';
            console.log(url);

            var dataGrid = $("#gridContainer").dxDataGrid({
                dataSource: url,
                /*   keyExpr: "TaxAgentUtin",*/
                //remoteOperations: {
                //    paging: true,
                //    filtering: true,
                //    sorting: true,
                //    grouping: true,
                //    summary: true,
                //    groupPaging: true
                //},
                showBorders: true,
                filterRow: {
                    visible: true
                },
                searchPanel: {
                    visible: true,
                    placeholder: "Search...",
                    width: 250
                },
                headerFilter: {
                    visible: false
                },
                hoverStateEnabled: true,
                showRowLines: true,
                rowAlternationEnabled: true,
                columnAutoWidth: true,
                paging: {
                    pageSize: 20
                },
                pager: {
                    showNavigationButtons: true,
                    showPageSizeSelector: true,
                    allowedPageSizes: [20, 50, 100, 250],
                    showInfo: true
                    /*       infoText: "Page #{0}. Total: {1} ({2} items)"*/
                },
                selection: {
                    mode: "multiple"
                    //selectAllMode: 'page',
                    //showCheckBoxesMode: 'always'
                },
                columns: [
                    //Enter the respective field names that is comimg from the API data  
                    {
                        dataField: "TaxAgentUtin",
                        width: 150,
                        caption: "Agent STIN"
                    },
                    {
                        dataField: "TaxAgentName",
                        caption: "Agent Name"
                    }
                ]

            }).dxDataGrid("instance");
            /*dataGridContainer(uri2);*/

            $("#select-all-mode").dxSelectBox({
                dataSource: ["allPages", "page"],
                value: "allPages",
                onValueChanged: function (data) {
                    dataGrid.option("selection.selectAllMode", data.value);
                }
            });

            $('#btnpreview').on('click',
                function () {
                   <%-- document.getElementById('<%= txtiddisplay.ClientID %>').style.display = "block";--%>

                   <%-- var objLbl = $('#<%=txtiddisplay.ClientID%>');
                    objLbl.style.display = "";--%>

                    if ($('#<%=txtstartdate.ClientID%>').val() == 0) {
                        swal("Report Portal", "Start Date is Empty!!", "warning");
                    } else if ($('#<%=txtenddate.ClientID%>').val() == 0) {
                        swal("Report Portal", "End Date is Empty!!", "warning");
                    } else {
                        var dataGrid = $("#gridContainer").dxDataGrid("instance");

                        var keys = dataGrid.getSelectedRowKeys();

                        if (!keys || keys.length <= 0) {
                            return;
                        } else {
                            console.log(keys.length);
                            for (var i = 0; i < keys.length; i++) {
                                rows_selected.push(keys[i].TaxAgentUtin);
                            }

                        }
                        console.log(rows_selected);
                        if (rows_selected == "") {
                            swal("Report Portal", "Tax Agent Name Not Selected!!", "info");
                        } else {

                            var obj = {};
                            obj.startdate = $.trim($('#<%=txtstartdate.ClientID%>').val());
                            obj.enddate = $.trim($('#<%=txtenddate.ClientID%>').val());
                            obj.agencylist = rows_selected;

                            $.ajax({
                                type: "POST",
                                url: "Remit.aspx/PostPreview",
                                data: JSON.stringify(obj),
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (r) {
                                    //alert(r.d);
                                    console.log(r);
                                    var jsdata = $.parseJSON(r.d);
                                    console.log(jsdata);
                                    if (jsdata == '1') {
                                        window.open('ViewRemittance.aspx', '_blank');
                                    } else {
                                        swal("Report Portal", "No Record Found for the Selected Range !", "info");
                                    }
                                }
                            });
                        }

                    }
                });
        });
    </script>
</asp:Content>
