﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.Master" AutoEventWireup="true" CodeBehind="CollectionSummary.aspx.cs" Inherits="ReportPortal.CollectionSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/select2.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-12 col-xs-12">
        <div class="panel panel-default card-view">
            <div class="panel-heading">
                <div class="pull-left">
                    <h6 class="panel-title txt-dark">Collection Summary Report</h6>
                </div>
                <div class="clearfix"></div>
            </div>
            <div class="panel-wrapper collapse in">
                <div class="panel-body">
                    <div class="form-wrap">
                        <form class="form-horizontal" runat="server">
                            <div class="form-group">
                                <asp:Label ID="Label2" class="control-label mb-10 col-sm-2" runat="server" Text="Report Options"></asp:Label>
                                <div class="radio mb-0 mr-20 inline-block radio-primary">
                                    <asp:RadioButtonList ID="rdbReport" runat="server">
                                        <asp:ListItem Value="1">Bank Report</asp:ListItem>
                                        <asp:ListItem Value="2">Agency Report</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label16" class="control-label mb-10 col-sm-2" runat="server" Text="Start Date:"></asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtstartdate" runat="server" CausesValidation="false" autocomplete="off" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton2" runat="server" ClientIDMode="Static" ImageUrl="~/images/clearimage.jpeg" OnClientClick="ClearTextboxes1();" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" class="control-label mb-10 col-sm-2" Text="End Date: "></asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtenddate" runat="server" CausesValidation="false" autocomplete="off" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ClientIDMode="Static" ImageUrl="~/images/clearimage.jpeg" OnClientClick="ClearTextboxes1();" />
                                </div>
                            </div>

                            <div class="form-group mb-0">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <asp:Button ID="btnpreview" runat="server" Text="Preview" class="btn btn-primary btn-anim text-uppercas" OnClick="btnpreview_Click" />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContentHolder" runat="server">
    <link href="<%: ResolveUrl("~/js/1.8/jquery-ui.css") %>" rel="stylesheet" />
    <script src="<%:ResolveUrl("~/js/jquery-1.11.3.min.js") %>"></script>
    <script src="<%: ResolveUrl("~/js/1.6/jquery-ui.min.js") %>"></script>
    <script src="<%:ResolveUrl("~/js/1.8/jquery-ui.min.js") %>"></script>

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
