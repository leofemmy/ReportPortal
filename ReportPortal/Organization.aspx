<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.Master" AutoEventWireup="true" CodeBehind="Organization.aspx.cs" Inherits="ReportPortal.Organization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%:ResolveUrl("~/plugins/vendors/bower_components/bootstrap-material-datetimepicker/css/bootstrap-material-datetimepicker.css") %>" rel="stylesheet">
    <!-- Page plugins css -->
    <link href="<%:ResolveUrl("~/plugins/vendors/bower_components/clockpicker/dist/jquery-clockpicker.min.css") %>" rel="stylesheet">
    <!-- Date picker plugins css -->
    <link href="<%:ResolveUrl("~/plugins/vendors/bower_components/bootstrap-datepicker/bootstrap-datepicker.min.css")%>" rel="stylesheet" type="text/css" />
    <!-- Daterange picker plugins css -->
    <link href="<%:ResolveUrl("~/plugins/vendors/bower_components/timepicker/bootstrap-timepicker.min.css") %>" rel="stylesheet">
    <link href="<%:ResolveUrl("~/plugins/vendors/bower_components/bootstrap-daterangepicker/daterangepicker.css") %>" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-6 col-xs-12">
        <div class="panel panel-default card-view">
            <div class="panel-heading">
                <div class="pull-left">
                    <h6 class="panel-title txt-dark">Summary Report</h6>
                </div>
                <div class="clearfix"></div>
            </div>
            <div class="panel-wrapper collapse in">
                <div class="panel-body">
                    <div class="form-wrap">
                        <form class="form-horizontal" runat="server">
                            <%--  <div class="form-group">
                                <asp:Label ID="Label16" class="control-label mb-10 col-sm-2" runat="server" Text="Start Date:"></asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtstartdate" runat="server" CausesValidation="false" autocomplete="off" ClientIDMode="Static" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton2" runat="server" ClientIDMode="Static" ImageUrl="~/images/clearimage.jpeg" OnClientClick="ClearTextboxes1();" />
                                </div>
                            </div>--%>
                            <div class="example">
                                <h5 class="box-title m-t-30">Start Date:</h5>
                                <div class="input-group">
                                    <input type="text" id="txtstartdate" runat="server" class="form-control mydatepicker" placeholder="dd/mm/yyyy">
                                    <div class="input-group-append">
                                        <span class="input-group-text"><i class="fa fa-calendar"></i></span>
                                    </div>
                                </div>
                            </div>
                            <%--      <div class="form-group">
                                <asp:Label ID="Label1" runat="server" class="control-label mb-10 col-sm-2" Text="End Date: "></asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtenddate" runat="server" CausesValidation="false" autocomplete="off" ClientIDMode="Static" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ClientIDMode="Static" ImageUrl="~/images/clearimage.jpeg" OnClientClick="ClearTextboxes1();" />
                                </div>
                            </div>--%>
                            <div class="example">
                                <h5 class="box-title m-t-30">End Date:</h5>
                                <div class="input-group">
                                    <input type="text" id="txtenddate" runat="server" class="form-control mydatepicker" placeholder="dd/mm/yyyy">
                                    <div class="input-group-append">
                                        <span class="input-group-text"><i class="fa fa-calendar"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group mb-0">
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
    </div>
    <!-- Card -->
    <div class="card">
        <div class="card-body">
            <div class="row">
                <div class="col-md-8">
                    <div class="example">
                        <h5 class="box-title m-t-30">Default Datedpicker</h5>
                        <p class="text-muted m-b-20">just add class <code>.mydatepicker</code> to create it.</p>
                        <div class="input-group">
                            <input type="text" class="form-control mydatepicker" placeholder="mm/dd/yyyy">
                            <div class="input-group-append">
                                <span class="input-group-text"><i class="fa fa-calendar"></i></span>
                            </div>
                        </div>
                    </div>
                    <div class="example">
                        <h5 class="box-title m-t-30">Autoclose Datedpicker</h5>
                        <p class="text-muted m-b-20">just add class <code>.complex-colorpicker</code> to create it.</p>
                        <div class="input-group">
                            <input type="text" class="form-control" id="datepicker-autoclose" placeholder="mm/dd/yyyy">
                            <div class="input-group-append">
                                <span class="input-group-text"><i class="fa fa-calendar"></i></span>
                            </div>
                        </div>
                    </div>
                    <div class="example">
                        <h5 class="box-title m-t-30">Date Range picker</h5>
                        <p class="text-muted m-b-20">just add id <code>#date-range</code> to create it.</p>
                        <div class="input-daterange input-group" id="date-range">
                            <input type="text" class="form-control" name="start" />
                            <div class="input-group-append">
                                <span class="input-group-text bg-info b-0 text-white">TO</span>
                            </div>
                            <input type="text" class="form-control" name="end" />
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="text-center">
                        <h5 class="box-title m-t-30">Datepicker Inline</h5>
                        <p class="text-muted m-b-20">You also can set the datepicker to be inline and flat.</p>
                        <center>
                            <div id="datepicker-inline"></div>
                        </center>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContentHolder" runat="server">
    <!-- data-table js -->
    <script type="text/javascript" src="plugins/vendors/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="plugins/vendors/bower_components/datatables.net-buttons/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="plugins/vendors/bower_components/data-table/js/jszip.min.js"></script>
    <script type="text/javascript" src="plugins/vendors/bower_components/data-table/js/pdfmake.min.js"></script>
    <script type="text/javascript" src="plugins/vendors/bower_components/data-table/js/vfs_fonts.js"></script>
    <script type="text/javascript" src="plugins/vendors/bower_components/datatables.net-buttons/js/buttons.print.min.js"></script>
    <script type="text/javascript" src="plugins/vendors/bower_components/datatables.net-buttons/js/buttons.html5.min.js"></script>
    <script type="text/javascript" src="plugins/vendors/bower_components/datatables.net-bs4/js/dataTables.bootstrap4.min.js"></script>
    <script type="text/javascript" src="plugins/vendors/bower_components/datatables.net-responsive/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="plugins/vendors/bower_components/datatables.net-responsive-bs4/js/responsive.bootstrap4.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
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

            // Date Picker
            jQuery('.mydatepicker, #datepicker').datepicker();
            jQuery('#datepicker-autoclose').datepicker({
                autoclose: true,
                todayHighlight: true
            });
            jQuery('#date-range').datepicker({
                toggleActive: true
            });
            jQuery('#datepicker-inline').datepicker({
                todayHighlight: true
            });
            // Daterange picker
            $('.input-daterange-datepicker').daterangepicker({
                buttonClasses: ['btn', 'btn-sm'],
                applyClass: 'btn-danger',
                cancelClass: 'btn-inverse'
            });
            $('.input-daterange-timepicker').daterangepicker({
                timePicker: true,
                format: 'DD/MM/YYYY h:mm A',
                timePickerIncrement: 30,
                timePicker12Hour: true,
                timePickerSeconds: false,
                buttonClasses: ['btn', 'btn-sm'],
                applyClass: 'btn-danger',
                cancelClass: 'btn-inverse'
            });
            $('.input-limit-datepicker').daterangepicker({
                format: 'MM/DD/YYYY',
                minDate: '06/01/2015',
                maxDate: '06/30/2015',
                buttonClasses: ['btn', 'btn-sm'],
                applyClass: 'btn-danger',
                cancelClass: 'btn-inverse',
                dateLimit: {
                    days: 6
                }
            });
        });

    </script>
    <%--    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>--%>
</asp:Content>
