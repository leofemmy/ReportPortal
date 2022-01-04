<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.Master" AutoEventWireup="true" CodeBehind="CollectionRanking.aspx.cs" Inherits="ReportPortal.CollectionRanking" %>

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

    <!-- Data Table Css -->
    <link rel="stylesheet" type="text/css"
        href="<%:ResolveUrl("~/plugins/vendors/bower_components/datatables.net-bs4/css/dataTables.bootstrap4.min.css")%>">
    <link rel="stylesheet" type="text/css" href="<%:ResolveUrl("~/plugins/vendors/bower_components/data-table/css/buttons.dataTables.min.css")%>">
    <link rel="stylesheet" type="text/css" href="<%:ResolveUrl("~/plugins/vendors/bower_components/datatables.net-responsive-bs4/css/responsive.bootstrap4.min.css")%>">

    <link rel="stylesheet" type="text/css" href="<%:ResolveUrl("~/devexpress/styles.css") %>" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-12 col-xs-12">
        <div class="panel panel-default card-view">
            <div class="panel-heading">
                <div class="pull-left">
                    <h6 class="panel-title txt-dark">Tax Agent Collection Ranking</h6>
                </div>
                <div class="clearfix"></div>
                <br />
                <asp:Label runat="server" ID="txtiddisplay" Text="You need to enable your browser pop-Up at the top right corner to view the report" ForeColor="red" Visible="False"></asp:Label>
            </div>
            <div class="panel-wrapper collapse in">
                <div class="panel-body">
                    <div class="form-wrap">
                        <form class="form-horizontal" runat="server">
                            <div class="form-group">
                                <asp:Label ID="Label2" class="control-label mb-10 col-sm-2" runat="server" Text="Revenue Type"></asp:Label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlRevenue" CssClass="form-control " runat="server"></asp:DropDownList>
                                </div>
                                <asp:Label ID="Label3" class="control-label mb-10 col-sm-2" runat="server" Text="Top Nos."></asp:Label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtno" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label16" class="control-label mb-10 col-sm-2" runat="server" Text="Start Date:"></asp:Label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtstartdate" runat="server" CausesValidation="false" autocomplete="off" ClientIDMode="Static" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton2" runat="server" ClientIDMode="Static" ImageUrl="~/images/clearimage.jpeg" OnClientClick="ClearTextboxes1();" />
                                </div>
                                <asp:Label ID="Label4" runat="server" class="control-label mb-10 col-sm-2" Text="End Date: "></asp:Label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtenddate" runat="server" CausesValidation="false" autocomplete="off" ClientIDMode="Static" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ClientIDMode="Static" ImageUrl="~/images/clearimage.jpeg" OnClientClick="ClearTextboxes1();" />
                                </div>
                            </div>
                            <div>
                                <asp:Label ID="Label1" class="control-label mb-10 col-sm-2" runat="server" Text="Revenue Office"></asp:Label>
                                <div style="height: 350px; width: 500px; overflow: auto; position: relative; overflow-x: hidden; overflow-y: auto;">
                                    <div id="gridContainer"></div>
                                </div>
                            </div>
                            <div class="form-group ">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <br />
                                    <%--    <asp:Button ID="btnpreview" runat="server" Text="Preview" class="btn btn-primary btn-anim text-uppercas" OnClick="btnpreview_OnClick" />--%>
                                    <button type="button" id="btnpreviews" class="btn btn-primary btn-anim"><i class="fa fa-paper-plane"></i><span class="btn-text text-uppercase">Preview</span></button>
                                </div>

                            </div>

                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContentHolder" runat="server">

    <%--   <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>--%>


    <script type="text/javascript" src="<%: ResolveUrl("~/Scripts/select2.min.js")%>"></script>


    <script type="text/javascript">
        var dataGrid;
        var rows_selected = [];

        var url = '<%=ConfigurationManager.AppSettings["Revnueoffice"] %>';
        console.log(url);

        var dataGrid = $("#gridContainer").dxDataGrid({
            dataSource: url,
            keyExpr: "RevenueOfficeID",
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
            },
            selection: {
                mode: "multiple"
            },
            columns: [
                //Enter the respective field names that is comimg from the API data  
                {
                    dataField: "RevenueOfficeID",
                    width: 100,
                    caption: "Office ID"
                    /*visible: true,*/
                },
                {
                    dataField: "RevenueOfficeName",
                    caption: "Revenue Office Name"
                }
            ]

        }).dxDataGrid("instance");


        $("#select-all-mode").dxSelectBox({
            dataSource: ["allPages", "page"],
            value: "allPages",
            onValueChanged: function (data) {
                dataGrid.option("selection.selectAllMode", data.value);
            }
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var rows_selected = [];
            var selectvalue = "";
            var table;
            $.ajax({
                type: "POST",
                url: "CollectionRanking.aspx/GetRevenueType",
                data: "{}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    console.log(data.d);
                    var jsdata = $.parseJSON(data.d);
                    var s = '<option value="-1">Please Select a Department</option>';
                    $('#<%=ddlRevenue.ClientID %>').empty().append('<option selected="selected" value="0">Please select</option>');
                    var datas = jsdata.Table;
                    console.log(datas);
                    for (var i = 0; i < datas.length; i++) {
                        console.log(datas[i].RevenueCode);
                        console.log(datas[i].RevenueName);

                        //s += '<option value="' + datas[i].RevenueCode + '">' + datas[i].RevenueName + '</option>';
                        $('#<%=ddlRevenue.ClientID %>').append($("<option></option>").val(datas[i].RevenueCode).html(datas[i].RevenueName));
                    }
                    /*   $("#ddlRevenue").html(s);*/
                }
            });

            //$.ajax({
            //    type: "POST",
            //    url: "CollectionRanking.aspx/GetOffices",
            //    data: "{}",
            //    dataType: "json",
            //    contentType: "application/json; charset=utf-8",
            //    success: function (data) {

            //        var jsdata = $.parseJSON(data.d);

            //        $('#tblofficerevenue').dataTable().fnClearTable();
            //        $('#tblofficerevenue').dataTable().fnDraw();
            //        $('#tblofficerevenue').dataTable().fnDestroy();

            //        console.log(jsdata.Table);

            //        if ((jsdata.Table.length != 0)) {
            //            table = $('#tblofficerevenue').DataTable({
            //                bLengthChange: false,
            //                lengthMenu: [[10, 20, -1], [10, 20, "All"]],
            //                bFilter: true,
            //                bSort: false,
            //                bPaginate: false,
            //                data: jsdata.Table,
            //                columnDefs: [
            //                    {
            //                        targets: 0,
            //                        className: 'dt - body - center',
            //                        //checkboxes: {
            //                        //    'selectRow': true
            //                        //},
            //                        render: function (data, type, full, meta) {
            //                            return '<input type="checkbox" name="id[]" value="' + $('<div/>').text(data).html() + '">';
            //                        }
            //                    }
            //                ],
            //                select: {
            //                    style: 'multi'
            //                },
            //                order: [[1, 'asc']],
            //                columns: [
            //                    { 'data': 'RevenueOfficeID' },
            //                    { 'data': 'RevenueOfficeName' }

            //                ]
            //            });
            //        }
            //    },
            //    error: function () { }
            //});


            // Handle click on "Select all" control
            $('#example-select-all').on('click', function () {
                // Get all rows with search applied
                var rows = table.rows({ 'search': 'applied' }).nodes();
                // Check/uncheck checkboxes for all rows in the table
                $('input[type="checkbox"]', rows).prop('checked', this.checked);
            });

            // Handle click on checkbox to set state of "Select all" control
            $('#tblofficerevenue tbody').on('change', 'input[type="checkbox"]', function () {
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


            $('#btnpreviews').on('click', function () {

                var vRevenue = $('#<%=ddlRevenue.ClientID%>').val();
                console.log($('#<%=txtno.ClientID%>').val());

                if ((vRevenue.length == 0) || (vRevenue == 0)) {

                    swal("Report Portal", "Revenue Type Empty!!", "warning");
                } else if ($('#<%=txtno.ClientID%>').val() == 0) {
                    swal("Report Portal", "Tops Number is Empty!!", "warning");
                }
                else if ($('#<%=txtstartdate.ClientID%>').val() == 0) {
                    swal("Report Portal", "Start Date is Empty!!", "warning");
                }
                else if ($('#<%=txtenddate.ClientID%>').val() == 0) {
                    swal("Report Portal", "End Date is Empty!!", "warning");
                }
                else {
                    var form = this;

                    var dataGrid = $("#gridContainer").dxDataGrid("instance");

                    var keys = dataGrid.getSelectedRowKeys();

                    //// Iterate over all checkboxes in the table
                    //table.$('input[type="checkbox"]').each(function () {
                    //    // If checkbox is checked
                    //    if (this.checked) {
                    //        // Create a hidden element
                    //        console.log(this.value);
                    //        rows_selected.push(this.value);
                    //    }

                    //});
                    /* console.log(rows_selected);*/

                    if (!keys || keys.length <= 0) {
                        return;
                    } else {
                        console.log(keys.length);
                        for (var i = 0; i < keys.length; i++) {
                            rows_selected.push(keys[i].RevenueOfficeID);
                        }

                    }
                    console.log(rows_selected);


                    if (rows_selected == "") {
                        swal("Report Portal", "Revenue Office Not Selected!!", "info");
                    } else {
                        var obj = {};
                        obj.Revenuetype = $.trim($('#<%=ddlRevenue.ClientID%>').val());
                        obj.nums = $.trim($('#<%=txtno.ClientID%>').val());
                        obj.startdate = $.trim($('#<%=txtstartdate.ClientID%>').val());
                        obj.enddate = $.trim($('#<%=txtenddate.ClientID%>').val());
                        obj.reveuneofficeid = rows_selected;
                        obj.RevenueName = $.trim($('#<%=ddlRevenue.ClientID %> option:selected').text());


                        $.ajax({
                            type: "POST",
                            url: "CollectionRanking.aspx/PostPreview",
                            data: JSON.stringify(obj),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (r) {
                                //alert(r.d);
                                var jsdata = $.parseJSON(r.d);

                                if (jsdata == '1') {
                                    window.open('ViewCollectionRanking.aspx', '_blank');
                                } else {
                                    swal("Report Portal", "No Record Found for the Selected Range !", "info");
                                }
                            }
                        });
                    }
                }



            })

            //document.getElementById('txtstartdate').value = '';
            //document.getElementById('txtenddate').value = '';

            //$("[id$=txtstartdate]").datepicker({
            //    dateFormat: "dd/mm/yy",
            //    changeMonth: true,
            //    changeYear: true

            //});

            //$("[id$=txtenddate]").datepicker({
            //    dateFormat: "dd/mm/yy",
            //    changeMonth: true,
            //    changeYear: true
            //});
        });




        //function ClearTextboxes() {
        //    document.getElementById('txtstartdate').value = '';
        //}

        //function ClearTextboxes1() {
        //    document.getElementById('txtenddate').value = '';
        //}

        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                //Get the Cell To find out ColumnIndex

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        inputList[i].checked = true;

                    }

                    else {

                        inputList[i].checked = false;

                    }

                }

            }

        }

        function Check_Click(objRef) {

            //Get the Row based on checkbox

            var row = objRef.parentNode.parentNode;

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

    <script type="text/javascript">

        $(document).ready(function () {



            $("#<%=ddlRevenue.ClientID%>").select2({

                placeholder: "Select Item",

                allowClear: true

            });



        });

    </script>
    <%--    <script type="text/javascript">  $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "CollectionRanking.aspx/GetOffices",
                data: "{}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) { console.log(data); },
                error: function () { }
            });
        });

    </script>--%>
</asp:Content>
