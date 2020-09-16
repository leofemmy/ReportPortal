<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.Master" AutoEventWireup="true" CodeBehind="userreport.aspx.cs" Inherits="ReportPortal.userreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-6 col-xs-12">
            <div class="panel panel-default card-view">
                <div class="panel-heading">
                    <div class="pull-left">
                        <h6 class="panel-title txt-dark">User's Report</h6>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <form id="form1" runat="server">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered mb-0" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="First Name" Visible="True">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Name" Visible="True">
                                <ItemTemplate>
                                    <asp:Label ID="lbltin" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" Visible="True">
                                <ItemTemplate>
                                    <asp:Label ID="lbltin" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Create Date" Visible="True">
                                <ItemTemplate>
                                    <asp:Label ID="lbltin" runat="server" Text='<%# Bind("CreateDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </form>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContentHolder" runat="server">
</asp:Content>
