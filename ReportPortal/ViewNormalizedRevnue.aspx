﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewNormalizedRevnue.aspx.cs" Inherits="ReportPortal.ViewNormalizedRevnue" %>

<%@ Register Assembly="DevExpress.XtraReports.v20.2.Web.WebForms, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" id="script">
        function previewClick(s, e) {
            PageMethods.LoadReport(e.Brick.text());
            console.log(e.Brick.text());
            if (e.Brick.text() != null) {
                window.location.href = "ViewNormalizeddetails.aspx";
            }
        }
    </script>
</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
        </asp:ScriptManager>
        <div>
            <dx:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer1" runat="server"></dx:ASPxWebDocumentViewer>
        </div>
    </form>
</body>
</html>