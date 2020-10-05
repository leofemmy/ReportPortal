<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.Master" AutoEventWireup="true" CodeBehind="CollectionRanking.aspx.cs" Inherits="ReportPortal.CollectionRanking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/select2.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-12 col-xs-12">
        <div class="panel panel-default card-view">
            <div class="panel-heading">
                <div class="pull-left">
                    <h6 class="panel-title txt-dark">Tax Agent Collection Ranking</h6>
                </div>
                <div class="clearfix"></div>
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
                                <div style="height: 350px; width: 700px; overflow: auto; position: relative; overflow-x: hidden; overflow-y: auto;">
                                    <asp:GridView ID="gridOffence" runat="server" Width="50%" Height="50%" CssClass="table table-bordered mb-0" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="Chkid" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Revenue office">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblrevenue" runat="server" Text='<%# Bind("RevenueOfficeName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Office ID" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbloffice" runat="server" Text='<%# Bind("RevenueOfficeID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="form-group ">
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

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContentHolder" runat="server">
    <script type="text/javascript" src="Scripts/select2.min.js"></script>

    <link href="<%: ResolveUrl("~/js/1.8/jquery-ui.css") %>" rel="stylesheet" />


    <script type="text/javascript">

        $(document).ready(function () {


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
