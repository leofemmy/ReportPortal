<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="ReportPortal.Payment" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.XtraReports.Web" Assembly="DevExpress.XtraReports.v20.1.Web.WebForms, Version=20.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/select2.min.css" rel="stylesheet" />
    <!-- Date picker plugins css -->
    <%--    <link href="plugins/vendors/bower_components/bootstrap-datepicker/bootstrap-datepicker.min.css" rel="stylesheet" type="text/css" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-6 col-xs-12">
        <div class="panel panel-default card-view">
            <div class="panel-heading">
                <div class="pull-left">
                    <h6 class="panel-title txt-dark">Payment Report</h6>
                </div>
                <div class="clearfix"></div>
            </div>
            <div class="panel-wrapper collapse in">
                <div class="panel-body">
                    <div class="form-wrap">
                        <form class="form-horizontal" runat="server">
                            <div class="form-group">
                                <asp:Label ID="Label2" class="control-label mb-10 col-sm-2" runat="server" Text="Agency Name"></asp:Label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlAgency" CssClass="form-control " runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAgency_OnSelectedIndexChanged"></asp:DropDownList>

                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label3" class="control-label mb-10 col-sm-2" runat="server" Text="Revenue Name"></asp:Label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlRevenue" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="Label16" class="control-label mb-10 col-sm-2" runat="server" Text="Start Date:"></asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtstartdate" runat="server" CausesValidation="false" autocomplete="off" ClientIDMode="Static" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton2" runat="server" ClientIDMode="Static" ImageUrl="~/images/clearimage.jpeg" OnClientClick="ClearTextboxes1();" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" class="control-label mb-10 col-sm-2" Text="End Date: "></asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtenddate" runat="server" CausesValidation="false" autocomplete="off" ClientIDMode="Static" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ClientIDMode="Static" ImageUrl="~/images/clearimage.jpeg" OnClientClick="ClearTextboxes1();" />
                                </div>
                            </div>

                            <div class="form-group mb-0">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <asp:Button ID="btnpreview" runat="server" Text="Preview" class="btn btn-primary btn-anim text-uppercas" OnClick="btnpreview_OnClick" />
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

    <script type="text/javascript" src="Scripts/select2.min.js"></script>
    -  
    <%--<script type="text/javascript" src="<%:ResolveUrl("~/js/jquery-1.11.3.min.js") %>"></script>--%>
    <%--<script type="text/javascript" src="<%: ResolveUrl("~/js/1.6/jquery-ui.min.js") %>"></script>--%>
    <%-- <script type="text/javascript" src="<%:ResolveUrl("~/js/1.8/jquery-ui.min.js") %>"></script>--%>
    <!-- Date Picker Plugin JavaScript -->
    <%--    <script src="plugins/vendors/bower_components/bootstrap-datepicker/bootstrap-datepicker.min.js"></script>--%>
    <link href="<%: ResolveUrl("~/js/1.8/jquery-ui.css") %>" rel="stylesheet" />

    <script type="text/javascript">

        $(document).ready(function () {

            $("#<%=ddlAgency.ClientID%>").select2({

                placeholder: "Select Item",

                allowClear: true

            });

            $("#<%=ddlRevenue.ClientID%>").select2({

                placeholder: "Select Item",

                allowClear: true

            });

        });

    </script>

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
</asp:Content>
