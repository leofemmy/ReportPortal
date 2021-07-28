<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.Master" AutoEventWireup="true" CodeBehind="Remittance.aspx.cs" Inherits="ReportPortal.Remittance" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



    <link href="<%:ResolveUrl("~/Content/css/select2.min.css" )%>" rel="stylesheet" />

    <link href="<%:ResolveUrl("~/plugins/vendors/bower_components/bootstrap-material-datetimepicker/css/bootstrap-material-datetimepicker.css") %>" rel="stylesheet">
    <!-- Page plugins css -->
    <link href="<%:ResolveUrl("~/plugins/vendors/bower_components/clockpicker/dist/jquery-clockpicker.min.css") %>" rel="stylesheet">
    <!-- Date picker plugins css -->
    <link href="<%:ResolveUrl("~/plugins/vendors/bower_components/bootstrap-datepicker/bootstrap-datepicker.min.css")%>" rel="stylesheet" type="text/css" />
    <!-- Daterange picker plugins css -->
    <link href="<%:ResolveUrl("~/plugins/vendors/bower_components/timepicker/bootstrap-timepicker.min.css") %>" rel="stylesheet">
    <link href="<%:ResolveUrl("~/plugins/vendors/bower_components/bootstrap-daterangepicker/daterangepicker.css") %>" rel="stylesheet">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <!-- Data Table Css -->
    <link rel="stylesheet" type="text/css"
        href="<%:ResolveUrl("~/plugins/vendors/bower_components/datatables.net-bs4/css/dataTables.bootstrap4.min.css")%>">
    <link rel="stylesheet" type="text/css" href="<%:ResolveUrl("~/plugins/vendors/bower_components/data-table/css/buttons.dataTables.min.css")%>">
    <link rel="stylesheet" type="text/css" href="<%:ResolveUrl("~/plugins/vendors/bower_components/datatables.net-responsive-bs4/css/responsive.bootstrap4.min.css")%>">

    <!-- DevExtreme themes -->
    <link rel="stylesheet" type="text/css" href="https://cdn3.devexpress.com/jslib/17.2.7/css/dx.common.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn3.devexpress.com/jslib/17.2.7/css/dx.light.css" />

    <!-- DevExtreme dependencies -->
    <script type="text/javascript" src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-3.1.0.min.js"></script>
    <!-- A DevExtreme library -->
    <script type="text/javascript" src="https://cdn3.devexpress.com/jslib/17.2.7/js/dx.web.js"></script>

    <script src="Scripts/dx.aspnet.data.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12 col-xs-12">
            <div class="panel panel-default card-view">
                <div class="panel-heading">
                    <div class="pull-left">
                        <h6 class="panel-title txt-dark">Collection Year Report  </h6>
                    </div>
                    <div class="clearfix"></div>
                    <br />
                    <asp:Label runat="server" ID="txtiddisplay" Text="You need to enable your browser pop-Up at the top right corner to view the report" ForeColor="red" Visible="False" Style="text-align: right;"></asp:Label>
                </div>

                <div class="panel-wrapper collapse in">
                    <div class="panel-body">
                        <form class="form-horizontal" runat="server">
                            <div class="col-sm-6 col-xs-12 form-group" style="height: 650px; width: 500px; overflow: auto; position: relative; overflow-x: hidden; overflow-y: auto;">
                                <asp:Label ID="Label1" class="control-label mb-10 col-sm-2" runat="server" Text="Select Agency" Width="200px"></asp:Label>
                                <%--<asp:GridView ID="gridOffence" runat="server" CssClass="table table-striped table-bordered nowrap" AutoGenerateColumns="false">
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
                                                <asp:Label ID="lbname" runat="server" Text='<%# Bind("TaxAgentName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TaxAgentUtin" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltin" runat="server" Text='<%# Bind("TaxAgentUtin") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>--%>
                                <table id="tblAgent" class="table table-striped table-bordered table-hover responsive" style="width: 80%">
                                    <thead>
                                        <tr>
                                            <%--<th align="left">
                                                    <input type="checkbox" id="chkAll" /></th>--%>
                                            <th>
                                                <input type="checkbox" name="select_all" value="1" id="example-select-all"></th>
                                            <th>Tax Agent Name</th>

                                        </tr>
                                    </thead>
                                </table>

                                <div id="gridContainer"></div>
                            </div>
                            <div class="col-sm-6 col-xs-12 form-group">
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
                        </form>

                    </div>
                </div>
            </div>


        </div>
    </div>
    <%--  <div class="row">
        <div class="col-sm-12 col-xs-12">
            <div class="panel panel-default card-view">
                <div class="panel-heading">
                    <div class="pull-left">
                        <h6 class="panel-title txt-dark">Tax Agent Remittance Statement</h6>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="panel-wrapper collapse in">
                    <div class="panel-body">
                        <form class="form-horizontal" runat="server">
                            <div class="col-sm-6 col-xs-12 form-group" style="height: 650px; width: 500px; overflow: auto; position: relative; overflow-x: hidden; overflow-y: auto;">
                                <asp:Label ID="Label1" class="control-label mb-10 col-sm-2" runat="server" Text="Agent List"></asp:Label>
                                <asp:GridView ID="gridOffence" runat="server" Width="50%" Height="50%" CssClass="table table-bordered mb-0" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkAlls" runat="server" onclick="checkAll(this);" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chkid" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tax Agent">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("TaxAgentName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TaxAgentUtin" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltin" runat="server" Text='<%# Bind("TaxAgentUtin") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>

                            <div class="col-sm-6 col-xs-12 form-group">
                                <div class="col-sm-3 col-xs-12 form-group">
                                    <asp:Label ID="Label16" class="control-label mb-10 col-sm-2" runat="server" Text="Start Date:"></asp:Label>

                                    <asp:TextBox ID="txtstartdate" runat="server" CausesValidation="false" autocomplete="off" ClientIDMode="Static" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton2" runat="server" ClientIDMode="Static" ImageUrl="~/images/clearimage.jpeg" OnClientClick="ClearTextboxes1();" />

                                </div>
                                <div class="col-sm-3 col-xs-12 form-group">
                                    <asp:Label ID="Label2" runat="server" class="control-label mb-10 col-sm-2" Text="End Date: "></asp:Label>

                                    <asp:TextBox ID="txtenddate" runat="server" CausesValidation="false" autocomplete="off" ClientIDMode="Static" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ClientIDMode="Static" ImageUrl="~/images/clearimage.jpeg" OnClientClick="ClearTextboxes1();" />

                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <asp:Button ID="btnpreview" runat="server" Text="Preview" class="btn btn-primary btn-anim text-uppercas" OnClick="btnpreview_OnClick" />
                                </div>
                                <asp:Label runat="server" ID="txtiddisplay" Text="You need to enable your browser pop-Up at the top right corner to view the report" ForeColor="red" Visible="False"></asp:Label>
                            </div>

                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContentHolder" runat="server">

    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>


    <%--    <link type="text/css" href="//gyrocode.github.io/jquery-datatables-checkboxes/1.2.12/css/dataTables.checkboxes.css" rel="stylesheet" />
    <script type="text/javascript" src="//gyrocode.github.io/jquery-datatables-checkboxes/1.2.12/js/dataTables.checkboxes.min.js"></script>--%>

    <%--<link href="<%: ResolveUrl("~/js/1.8/jquery-ui.css") %>" rel="stylesheet" />--%>

    <script type="text/javascript" src="<%: ResolveUrl("~/Scripts/select2.min.js")%>"></script>
    <!-- data-table js -->
    <script src="<%: ResolveUrl("~/plugins/vendors/bower_components/datatables.net/js/jquery.dataTables.min.js")%>"></script>
    <script src="<%: ResolveUrl("~/plugins/vendors/bower_components/datatables.net-buttons/js/dataTables.buttons.min.js")%>"></script>
    <script src="<%: ResolveUrl("~/plugins/vendors/bower_components/data-table/js/jszip.min.js")%>"></script>
    <script src="<%: ResolveUrl("~/plugins/vendors/bower_components/data-table/js/pdfmake.min.js")%>"></script>
    <script src="<%: ResolveUrl("~/plugins/vendors/bower_components/data-table/js/vfs_fonts.js")%>"></script>
    <script src="<%: ResolveUrl("~/plugins/vendors/bower_components/datatables.net-buttons/js/buttons.print.min.js")%>"></script>
    <script src="<%: ResolveUrl("~/plugins/vendors/bower_components/datatables.net-buttons/js/buttons.html5.min.js")%>"></script>
    <script src="<%: ResolveUrl("~/plugins/vendors/bower_components/datatables.net-bs4/js/dataTables.bootstrap4.min.js")%>"></script>
    <script src="<%: ResolveUrl("~/plugins/vendors/bower_components/datatables.net-responsive/js/dataTables.responsive.min.js")%>"></script>
    <script src="<%: ResolveUrl("~/plugins/vendors/bower_components/datatables.net-responsive-bs4/js/responsive.bootstrap4.min.js")%>"></script>
    <script src="<%: ResolveUrl("~/plugins/vendors/bower_components/data-table/js/data-table-custom.js")%>"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var rows_selected = [];
            var selectvalue = "";
            var table;

            var remoteDataLoader = DevExpress.data.AspNet.createStore({
                key: "TaxAgentUtin",
                loadUrl: "http://localhost/ReportPortal/api/Agents"
                //loadUrl: test//ConfigurationManager.AppSettings["loadUrl"] //"api/reg/agents/DTSS"
            });

            var dataGrid,
                gridOptions = {
                    dataSource: remoteDataLoader,
                    remoteOperations: {
                        paging: true,
                        filtering: true,
                        sorting: true,
                        grouping: true,
                        summary: true,
                        groupPaging: true
                    },
                    searchPanel: {
                        visible: true,
                        placeholder: "Search...",
                        width: 250
                    },
                    paging: {
                        pageSize: 20
                    },
                    pager: {
                        showNavigationButtons: true,
                        showPageSizeSelector: true,
                        allowedPageSizes: [20, 50, 100, 250],
                        showInfo: true
                    },
                    selection: {
                        mode: "multiple",
                        selectAllMode: 'page',
                        showCheckBoxesMode: 'always'
                    },
                    hoverStateEnabled: true,
                    showRowLines: true,
                    rowAlternationEnabled: true,
                    columnAutoWidth: true,
                    columns: [
                        {
                            caption: '#',
                            width: "auto",
                            allowSorting: false,
                            allowFiltering: false,
                            allowReordering: false,
                            allowHeaderFiltering: false,
                            allowGrouping: false,
                            cellTemplate: function (container, options) {
                                container.text(dataGrid.pageIndex() * dataGrid.pageSize() + (options.rowIndex + 1));
                            }
                        }, {
                            dataField: "TaxAgentName",
                            caption: "Agent Name",
                            sortIndex: 0,
                            sortOrder: 'asc'
                        }, {
                            dataField: "TaxAgentUtin",
                            caption: "Payer Reference"
                        }
                        //, {
                        //    dataField: "Address",
                        //    caption: "Address"
                        //}, {
                        //    dataField: "PhoneNo",
                        //    caption: "Phone"
                        //}
                    ]
                };

            dataGrid = $("#gridContainer").dxDataGrid(gridOptions).dxDataGrid("instance");

            $.ajax({
                type: "POST",
                url: "Remittance.aspx/GetTaxAgent",
                data: "{}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    var jsdata = $.parseJSON(data.d);

                    $('#tblAgent').dataTable().fnClearTable();
                    $('#tblAgent').dataTable().fnDraw();
                    $('#tblAgent').dataTable().fnDestroy();

                    console.log(jsdata.Table);

                    if ((jsdata.Table.length != 0)) {
                        table = $('#tblAgent').DataTable({
                            serverSide: true,
                            bLengthChange: false,
                            lengthMenu: [[10, 20, -1], [10, 20, "All"]],
                            bFilter: true,
                            bSort: false,
                            scroller: {
                                loadingIndicator: true
                            },
                            bPaginate: false,
                            data: jsdata.Table,
                            columnDefs: [
                                {
                                    targets: 0,
                                    className: 'dt - body - center',
                                    //checkboxes: {
                                    //    'selectRow': true
                                    //},
                                    render: function (data, type, full, meta) {
                                        return '<input type="checkbox" name="id[]" value="' + $('<div/>').text(data).html() + '">';
                                    }
                                }
                            ],
                            select: {
                                style: 'multi'
                            },
                            order: [[1, 'asc']],
                            columns: [
                                { 'data': 'TaxAgentUtin' },
                                { 'data': 'TaxAgentName' }

                            ]
                        });
                    }
                },
                error: function () { }
            });

            // Handle click on "Select all" control
            $('#example-select-all').on('click', function () {
                // Get all rows with search applied
                var rows = table.rows({ 'search': 'applied' }).nodes();
                // Check/uncheck checkboxes for all rows in the table
                $('input[type="checkbox"]', rows).prop('checked', this.checked);
            });

            // Handle click on checkbox to set state of "Select all" control
            $('#tblAgent tbody').on('change', 'input[type="checkbox"]', function () {
                // If checkbox is not checked
                if (!this.checked) {
                    var el = $('#example-select-all').get(0);
                    // If "Select all" control is checked and has 'indeterminate' property
                    if (el && el.checked && ('indeterminate' in el)) {
                        // Set visual state of "Select all" control
                        // as 'indeterminate'
                        el.indeterminate = true;
                    }
                }
            });

            $('#btnpreview').on('click', function () {

                if ($('#<%=txtstartdate.ClientID%>').val() == 0) {
                    swal("Report Portal", "Start Date is Empty!!", "warning");
                }
                else if ($('#<%=txtenddate.ClientID%>').val() == 0) {
                    swal("Report Portal", "End Date is Empty!!", "warning");
                } else {
                    var form = this;
                    // Iterate over all checkboxes in the table
                    table.$('input[type="checkbox"]').each(function () {
                        // If checkbox is checked
                        if (this.checked) {
                            // Create a hidden element
                            //console.log(this.value);
                            rows_selected.push(this.value);
                        }

                    });

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
                            url: "Remittance.aspx/PostPreview",
                            data: JSON.stringify(obj),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (r) {
                                //alert(r.d);
                                var jsdata = $.parseJSON(r.d);

                                if (jsdata == '1') {
                                    window.open('ViewRemittance.aspx', '_blank');
                                } else {
                                    swal("Report Portal", "No Record Found for the Selected Range !", "info");
                                }
                            }
                        });
                    }
                }
            })

            document.getElementById('txtstartdate').value = '';
            document.getElementById('txtenddate').value = '';
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
        });

        function ClearTextboxes() {
            document.getElementById('txtstartdate').value = '';
        }

        function ClearTextboxes1() {
            document.getElementById('txtenddate').value = '';
        }

        function ChangeCheckBoxState(id, checkState) {
            var cb = document.getElementById(id);
            if (cb != null)
                cb.checked = checkState;
        }

        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                //Get the Cell To find out ColumnIndex

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        //If the header checkbox is checked

                        //check all checkboxes

                        //and highlight all rows

                        //row.style.backgroundColor = "aqua";

                        inputList[i].checked = true;

                    }

                    else {

                        //If the header checkbox is checked

                        //uncheck all checkboxes

                        //and change rowcolor back to original

                        //if (row.rowIndex % 2 == 0) {

                        //    //Alternating Row Color

                        //    row.style.backgroundColor = "#C2D69B";

                        //}

                        //else {

                        //    row.style.backgroundColor = "white";

                        //}

                        inputList[i].checked = false;

                    }

                }

            }

        }

        function Check_Click(objRef) {

            //Get the Row based on checkbox

            var row = objRef.parentNode.parentNode;

            //if (objRef.checked) {

            //    //If checked change color to Aqua

            //    row.style.backgroundColor = "aqua";

            //}

            //else {

            //    //If not checked change back to original color

            //    if (row.rowIndex % 2 == 0) {

            //        //Alternating Row Color

            //        row.style.backgroundColor = "#C2D69B";

            //    }

            //    else {

            //        row.style.backgroundColor = "white";

            //    }

            //}



            //Get the reference of GridView

            var GridView = row.parentNode;



            //Get all input elements in Gridview

            var inputList = GridView.getElementsByTagName("input");



            for (var i = 0; i < inputList.length; i++) {

                //The First element is the Header Checkbox

                var headerCheckBox = inputList[0];



                //Based on all or none checkboxes

                //are checked check/uncheck Header Checkbox

                var checked = true;

                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {

                    if (!inputList[i].checked) {

                        checked = false;

                        break;

                    }

                }

            }

            headerCheckBox.checked = checked;



        }
    </script>


</asp:Content>
