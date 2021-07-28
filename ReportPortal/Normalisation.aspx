<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.Master" AutoEventWireup="true" CodeBehind="Normalisation.aspx.cs" Inherits="ReportPortal.Normalisation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/select2.min.css" rel="stylesheet" />
    <link href="plugins/vendors/bower_components/datatables.net-bs4/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="plugins/vendors/bower_components/data-table/css/buttons.dataTables.min.css">
    <link rel="stylesheet" type="text/css" href="plugins/vendors/bower_components/datatables.net-responsive-bs4/css/responsive.bootstrap4.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12 col-xs-12">
            <div class="panel panel-default card-view">
                <div class="panel-heading">
                    <div class="pull-left">
                        <h6 class="panel-title txt-dark">Payment Normalisation  </h6>
                    </div>
                    <div class="clearfix"></div>
                    <br />
                    <asp:Label runat="server" ID="txtiddisplay" Text="You need to enable your browser pop-Up at the top right corner to view the report" ForeColor="red" Visible="False" Style="text-align: right;"></asp:Label>
                </div>

                <div class="panel-wrapper collapse in">
                    <div class="panel-body">
                        <br />
                        <br />
                        <form class="form-horizontal" runat="server">
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
                                    <asp:Button ID="btnpreview" runat="server" Text="Preview" class="btn btn-primary btn-anim text-uppercas" OnClick="btnpreview_OnClick" />
                                </div>


                            </div>
                        </form>

                    </div>
                </div>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />

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


    </script>

    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
</asp:Content>
