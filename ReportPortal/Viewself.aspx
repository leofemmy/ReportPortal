﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Viewself.aspx.cs" Inherits="ReportPortal.Viewself" %>

<%@ Register Assembly="DevExpress.XtraReports.v22.1.Web.WebForms, Version=22.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <%-- <dx:ASPxDocumentViewer ID="ASPxDocumentViewer1" runat="server" Height="1100px" Width="100%">
            </dx:ASPxDocumentViewer>--%>
            <dx:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer1" runat="server"></dx:ASPxWebDocumentViewer>
        </div>
    </form>
</body>
</html>
