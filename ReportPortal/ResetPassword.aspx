<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="ReportPortal.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Password Reset</title>
    <meta name="description" content="" />
    <meta name="keywords" content="admin, admin dashboard, admin template" />
    <meta name="author" content="SRGIT" />
    <%--  <!-- Favicon -->
    <link rel="shortcut icon" href="plugins/assets/img/favicon/favicon.png">
    <link rel="icon" href="plugins/assets/img/favicon/favicon.png" type="image/x-icon">
    <!-- Custom CSS -->
    <link href="plugins/assets/css/default.css" rel="stylesheet" type="text/css">--%>
    <!-- Favicon -->
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
                            <div class="main-subtitle-bottom smaller mt-10">Reset Password!</div>
                        </div>
                        <form class="form-horizontal form-material" id="loginform" runat="server">
                            <div class="form-group mt-20">
                                <div class="col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon b-0  bg-primary" id="basic-addon4"><i class="mdi mdi-account"></i></span>
                                        <input type="text" runat="server" id="txtemail" class="form-control" placeholder="Username/Email" autocomplete="off">
                                    </div>
                                </div>
                            </div>
                            <div class="form-group text-center mb-10">
                                <div class="col-xs-12">
                                    <%--<asp:Button ID="Button1" runat="server" Text="Sign In" class="btn btn-success btn-lg btn-block text-uppercase" OnClick="Button1_OnClick" />--%>
                                    <%--<button class="btn btn-success btn-lg btn-block text-uppercase" data-toggle="modal" data-target="#myModal" type="submit">Reset</button>--%>
                                    <asp:Button runat="server" ID="btnReset" Text="Reset" class="btn btn-success btn-lg btn-block text-uppercase" OnClick="btnReset_OnClick" />
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
    <%--   <!-- jQuery -->
    <script src="plugins/vendors/bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="plugins/vendors/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- Slimscroll JavaScript -->
    <script src="plugins/assets/js/jquery.slimscroll.js"></script>
    <!-- Fancy Dropdown JS -->
    <script src="plugins/assets/js/dropdown-bootstrap-extended.js"></script>
    <!-- Switchery JavaScript -->
    <script src="plugins/vendors/bower_components/switchery/dist/switchery.min.js"></script>
    <!-- Init JavaScript -->
    <script src="plugins/assets/js/init.js"></script>--%>

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
    <!-- Init JavaScript -->
    <script src="<%:ResolveUrl("~/plugins/assets/js/init.js") %>"></script>
</body>
</html>
