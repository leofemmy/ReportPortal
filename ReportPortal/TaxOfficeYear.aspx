<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.Master" AutoEventWireup="true" CodeBehind="TaxOfficeYear.aspx.cs" Inherits="ReportPortal.TaxOfficeYear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/select2.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-6 col-xs-12">
        <div class="panel panel-default card-view">
            <div class="panel-heading">
                <div class="pull-left">
                    <h6 class="panel-title txt-dark">Tax Office Year Comparative</h6>
                </div>
                <div class="clearfix"></div>
            </div>
            <div class="panel-wrapper collapse in">
                <div class="panel-body">
                    <div class="form-wrap">
                        <form class="form-horizontal" runat="server">
                            <div class="form-group">
                                <asp:Label ID="Label2" class="control-label mb-10 col-sm-2" runat="server" Text="From"></asp:Label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlyear" CssClass="form-control " runat="server"></asp:DropDownList>

                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label1" class="control-label mb-10 col-sm-2" runat="server" Text="To"></asp:Label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlto" CssClass="form-control " runat="server"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group mb-0">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <asp:Button ID="btnpreview" runat="server" Text="Preview" class="btn btn-primary btn-anim text-uppercas" OnClick="btnpreview_Click" />
                                </div>
                                <asp:Label runat="server" ID="txtiddisplay" Text="You need to enable your browser pop-Up at the top right corner to view the report" ForeColor="red" Visible="False"></asp:Label>
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

    <link href="<%: ResolveUrl("~/js/1.8/jquery-ui.css") %>" rel="stylesheet" />

    <script type="text/javascript">

        $(document).ready(function () {

            $("#<%=ddlyear.ClientID%>").select2({

                placeholder: "Select Item",

                allowClear: true

            });

            $("#<%=ddlto.ClientID%>").select2({

                placeholder: "Select Item",

                allowClear: true

            });
        });

    </script>
</asp:Content>
