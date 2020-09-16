<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivationEmail.aspx.cs" Inherits="ReportPortal.ActivationEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Report Portal</title>
    <meta name="description" content="" />
    <meta name="keywords" content="admin, admin dashboard, admin template" />
    <meta name="author" content="SRGIT" />
    <link rel="shortcut icon" href="<%:ResolveUrl("~/plugins/assets/img/favicon/favicon.png") %>">
    <link rel="icon" href="<%:ResolveUrl("~/plugins/assets/img/favicon/favicon.png") %>" type="image/x-icon">
    <!-- Custom CSS -->
    <link href="<%:ResolveUrl("~/plugins/assets/css/default.css") %>" rel="stylesheet" type="text/css">
</head>
<body class="login-sidebar-background">
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
                    <div class="mt-40">
                        <div class="main-title on-dark text-center mb-0">
                            <a href="index.html" class="text-center db">
                                <img src="plugins/assets/img/logo-dark.png" alt="Home" /><br />
                                <span class="brand-text">[ Report<strong> P</strong>ortal ]</span> </a>
                            <div class="main-subtitle-bottom smaller mt-10">ACCOUNT VERIFICATION</div>
                        </div>
                        <br />
                        <form class="form-horizontal form-material" id="loginform" runat="server">
                            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False" ForeColor="Green"></asp:Label>
                            <br />
                            <asp:Label ID="txtemail" runat="server" Text="" ForeColor="blue"></asp:Label>
                            <br />
                            <div class="form-group ">
                                <div class="col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon b-0  bg-primary" id="basic-addon4"><i class="mdi mdi-lock"></i></span>
                                        <label for="example-tel-input" class="col-2 col-form-label">New Password</label>
                                        <span class="glyphicon form-control-feedback" aria-hidden="true"></span>
                                        <asp:TextBox ID="txtpassword" runat="server" placeholder="New Password" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="New password is required" ControlToValidate="txtpassword"></asp:RequiredFieldValidator>
                                    </div>

                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon b-0  bg-primary" id="basic-addon4"><i class="mdi mdi-lock-reset"></i></span>
                                        <label for="example-tel-input" class="col-2 col-form-label">Confirm Password</label>
                                        <asp:TextBox ID="txtconform" runat="server" placeholder="Confirm Password" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password not the same" ControlToCompare="txtpassword" ControlToValidate="txtconform"></asp:CompareValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtconform" runat="server" ErrorMessage="Confirm Password is required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group text-center mt-20">
                                <div class="col-xs-12">
                                    <%--<button class="btn btn-success btn-lg btn-block text-uppercase" type="submit">Sign Up</button>--%>
                                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn btn-success btn-lg btn-block text-uppercase" OnClick="btnsubmit_OnClick" />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </section>
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
</bod>
</html>
