<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="ReportPortal.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Preloader -->
    <div class="preloader-it">
        <div class="preloader">
            <div class="circles-1">
                <div class="circles-1-center"></div>
                <div class="circles-1"></div>
                <div class="circles-1"></div>
                <div class="circles-1"></div>
                <div class="circles-1"></div>
                <div class="circles-1"></div>
                <div class="circles-1"></div>
            </div>
        </div>
    </div>
    <!-- //Preloader -->
    <section id="wrapper" class="login-register login-sidebar">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-5 text-center parallax-fade-top subscribe-bg">
                    <br />
                    <p>
                        <asp:Label ID="lblerror" runat="server" Text="" ForeColor="red"></asp:Label>
                    </p>
                    <div class="mt-40">
                        <div class="main-title on-dark text-center mb-0">
                            <a href="index.html" class="text-center db">
                                <img src="plugins/assets/img/logo-dark.png" alt="Home" /><br />
                                <span class="brand-text">[ Report<strong> P</strong>ortal ]</span> </a>
                            <div class="main-subtitle-bottom smaller mt-10">Register Now!</div>
                        </div>
                        <form class="form-horizontal form-material" id="loginform" runat="server">
                            <div class="form-group mt-20">
                                <div class="col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon b-0  bg-primary" id="basic-addon4"><i class="mdi mdi-account"></i></span>
                                        <input type="text" runat="server" id="txtfirst" class="form-control" autocomplete="off" placeholder="First Name" required data-validation-required-message="This field is required">
                                    </div>
                                </div>
                            </div>
                            <div class="form-group ">
                                <div class="col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon b-0  bg-primary" id="basic-addon4"><i class="mdi mdi-email"></i></span>
                                        <input type="text" runat="server" id="txtlast" class="form-control" autocomplete="off" placeholder="Last Name" required data-validation-required-message="This field is required">
                                    </div>
                                </div>
                            </div>
                            <div class="form-group ">
                                <div class="col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon b-0  bg-primary" id="basic-addon4"><i class="mdi mdi-email"></i></span>
                                        <input type="email" runat="server" id="txtemail" class="form-control" autocomplete="off" placeholder="Email" required data-validation-required-message="This field is required">
                                    </div>
                                </div>
                            </div>
                            <%-- <div class="form-group ">
                                <div class="col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon b-0  bg-primary" id="basic-addon4"><i class="mdi mdi-email"></i></span>
                                        <asp:DropDownList ID="ddlState" runat="server" class="form-control" required data-validation-required-message="This field is required">
                                            <asp:ListItem>Choose State</asp:ListItem>
                                            <asp:ListItem Value="OGSS" Selected="True">Ogun State</asp:ListItem>
                                            <asp:ListItem Value="DTSS">Delta State</asp:ListItem>
                                            <asp:ListItem Value="OYSS">Oyo State</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>--%>
                            <div class="form-group text-center mt-20">
                                <div class="col-xs-12">
                                    <%--<button class="btn btn-success btn-lg btn-block text-uppercase" type="submit">Sign Up</button>--%>
                                    <asp:Button ID="Button1" runat="server" Text="Sign Up" class="btn btn-success btn-lg btn-block text-uppercase" OnClick="Button1_OnClick" />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContentHolder" runat="server">
    <!-- /Main Content -->
    <!-- /#wrapper -->
    <!-- JavaScript -->
    <!-- jQuery -->
    <script src="<%: ResolveUrl("~/plugins/vendors/bower_components/jquery/dist/jquery.min.js") %>"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="<%:ResolveUrl("~/plugins/vendors/bower_components/bootstrap/dist/js/bootstrap.min.js") %>"></script>
    <!-- Slimscroll JavaScript -->
    <script src="<%:ResolveUrl("~/plugins/assets/js/jquery.slimscroll.js") %>"></script>
    <!-- Fancy Dropdown JS -->
    <script src="<%:ResolveUrl("~/plugins/assets/js/dropdown-bootstrap-extended.js") %>"></script>
    <!-- Switchery JavaScript -->
    <script src="<%:ResolveUrl("~/plugins/vendors/bower_components/switchery/dist/switchery.min.js") %>"></script>
    <script src="<%:ResolveUrl("~/plugins/assets/validation.js") %>"></script>
    <script src="<%:ResolveUrl("~/plugins/assets/js/validate.js") %>"></script>
    <!-- Init JavaScript -->
    <script src="<%:ResolveUrl("~/plugins/assets/js/init.js") %>"></script>
</asp:Content>
