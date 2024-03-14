<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ReportPortal.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Report Portal</title>
    <meta name="description" content="" />
    <meta name="keywords" content="admin, admin dashboard, admin template" />
    <meta name="author" content="SRGIT" />
    <%--  <!-- Favicon -->
    <link rel="shortcut icon" href="<%:ResolveUrl("~/plugins/assets/img/favicon/favicon.png") %>">
    <link rel="icon" href="<%:ResolveUrl("~/plugins/assets/img/favicon/favicon.png") %>" type="image/x-icon">
    <!-- Custom CSS -->
    <link href="<%:ResolveUrl("~/plugins/assets/css/default.css") %>" rel="stylesheet" type="text/css">--%>
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="<%:ResolveUrl("~/assets/images/favicon.png") %>" />

    <!-- Bootstrap Core CSS -->
    <link href="assets/vendors/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- page css -->
    <link href="css/pages/login-register-lock.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="css/master-stylesheet.css" rel="stylesheet" />

    <!-- You can change the theme colors from here -->
    <link href="css/colors/blue-dark.css" rel="stylesheet" />

</head>
<body class="card-no-border">
    <!-- ============================================================== -->
    <!-- Preloader - style you can find in spinners.css -->
    <!-- ============================================================== -->
    <div class="preloader">
        <div class="loader">
            <div class="lds-roller">
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
            </div>
        </div>
    </div>
    <!-- ============================================================== -->
    <!-- Main wrapper - style you can find in pages.scss -->
    <!-- ============================================================== -->
    <section id="wrapper">
        <div class="login-register" style="background-image: url(../assets/images/background/login-register.jpg);">
            <div class="row justify-content-center">
                <div class="col-md-5 text-center parallax-fade-top subscribe-bg">
                    <div class="main-title on-dark text-center mb-0">
                        <a href="index.html" class="text-center db">
                            <%--<img src="assets/images/background/login-register.jpg" alt="Home" />--%>
                            <br />
                            <span class="brand-text">[ Report<strong> P</strong>ortal ]</span> </a>
                        <div class="main-subtitle-bottom smaller mt-10">Welcome back!</div>
                    </div>
                    <form class="form-horizontal form-material" id="loginform" runat="server">
                        <div class="form-group mt-20">
                            <div class="col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon b-0  bg-primary" id="basic-addon4"><i class="mdi mdi-account"></i></span>
                                    <input type="text" runat="server" id="txtemail" class="form-control" autocomplete="off" placeholder="Username/Email">
                                </div>
                            </div>
                        </div>
                        <div class="form-group ">
                            <div class="col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon b-0  bg-primary" id="basic-addon4"><i class="mdi mdi-lock"></i></span>
                                    <input type="password" runat="server" id="txtpassword" class="form-control" autocomplete="off" placeholder="Password">
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="checkbox checkbox-primary">
                                    <%-- New ?
                                    <a href="<%:ResolveUrl("~/Signup.aspx") %>" class="to_register">Create New User </a>--%>
                                    <a href="<%:ResolveUrl("~/ResetPassword.aspx") %>" class="pull-right"><i class="mdi mdi-lock"></i>Forgot your Password?</a>
                                </div>
                            </div>
                        </div>
                        <div class="form-group text-center mt-20">
                            <div class="col-xs-12">

                                <asp:Button ID="Button1" runat="server" Text="Sign In" class="btn btn-success btn-lg btn-block text-uppercase" OnClick="Button1_OnClick" />
                            </div>
                        </div>

                    </form>
                </div>
            </div>
        </div>

    </section>
    <!-- /Main Content -->
    <!-- /#wrapper -->
    <!-- JavaScript -->
    <!-- jQuery -->
    <%--<script src="<%: ResolveUrl("~/plugins/vendors/bower_components/jquery/dist/jquery.min.js") %>"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="<%:ResolveUrl("~/plugins/vendors/bower_components/bootstrap/dist/js/bootstrap.min.js") %>"></script>
    <!-- Slimscroll JavaScript -->
    <script src="<%:ResolveUrl("~/plugins/assets/js/jquery.slimscroll.js") %>"></script>
    <!-- Fancy Dropdown JS -->
    <script src="<%:ResolveUrl("~/plugins/assets/js/dropdown-bootstrap-extended.js") %>"></script>
    <!-- Switchery JavaScript -->
    <script src="<%:ResolveUrl("~/plugins/vendors/bower_components/switchery/dist/switchery.min.js") %>"></script>
    <!-- Init JavaScript -->
    <script src="<%:ResolveUrl("~/plugins/assets/js/init.js") %>"></script>--%>

    <script src="<%: ResolveUrl("/assets/vendors/jquery/jquery.min.js") %>"></script>
    <!-- Bootstrap tether Core JavaScript -->
    <script src="<%: ResolveUrl("/assets/vendors/bootstrap/js/popper.min.js") %>"></script>
    <script src="<%: ResolveUrl("/assets/vendors/bootstrap/js/bootstrap.min.js") %>"></script>

    <!--Custom JavaScript -->
    <script type="text/javascript">
        $(function () {
            $(".preloader").fadeOut();
        });
        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        });
        // ============================================================== 
        // Login and Recover Password 
        // ============================================================== 
        $('#to-recover').on("click", function () {
            $("#loginform").slideUp();
            $("#recoverform").fadeIn();
        });
    </script>
</body>
</html>
