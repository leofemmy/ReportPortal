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
                    <div class="main-title on-dark text-center mb-0">
                        <a href="index.html" class="text-center db">
                            <img src="plugins/assets/img/logo-dark.png" alt="Home" /><br />
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
                                <%-- <button class="btn btn-success btn-lg btn-block text-uppercase" type="submit">Sign Up</button>--%>
                                <asp:Button ID="Button1" runat="server" Text="Sign In" class="btn btn-success btn-lg btn-block text-uppercase" OnClick="Button1_OnClick" />
                            </div>
                        </div>
                        <%--<div class="form-group m-b-0">
                            <div class="col-sm-12 text-center">
                                <p>Already have an account? <a href="login.html" class="text-danger ml-5"><b>Sign In</b></a></p>
                            </div>
                        </div>--%>
                        <%--  <div class="row">
                            <div class="col-xs-12 col-sm-12 col-md-12 mt-0 mb-20 text-center">
                                <div class="social"><a href="javascript:void(0)" class="btn pl-15 pr-15  btn-facebook" data-toggle="tooltip" title="Login with Facebook"><i aria-hidden="true" class="fa fa-facebook"></i></a><a href="javascript:void(0)" class="btn pl-15 pr-15 btn-tumblr" data-toggle="tooltip" title="Login with tumblr"><i aria-hidden="true" class="fa fa-tumblr"></i></a></div>
                            </div>
                        </div>--%>
                    </form>
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
    <!-- Init JavaScript -->
    <script src="<%:ResolveUrl("~/plugins/assets/js/init.js") %>"></script>
</body>
</html>
