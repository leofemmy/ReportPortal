﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAssessmentYearSummary.aspx.cs" Inherits="ReportPortal.ViewAssessmentYearSummary" %>

<%@ Register Assembly="DevExpress.XtraReports.v23.2.Web.WebForms, Version=23.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" id="script">
        function previewClick(s, e) {
            PageMethods.loadchildreport(e.Brick.text());
            if (e.Brick.text() != null) {
                window.location.href = "ViewAssessmentYearSummaryChild.aspx"
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <div>
            <dx:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer1" runat="server">
                <ClientSideEvents PreviewClick="previewClick" />
            </dx:ASPxWebDocumentViewer>
        </div>
    </form>
</body>
</html>
