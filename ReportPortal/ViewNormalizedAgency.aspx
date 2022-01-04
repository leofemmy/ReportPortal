<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewNormalizedAgency.aspx.cs" Inherits="ReportPortal.ViewNormalizedAgency" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.XtraReports.Web" Assembly="DevExpress.XtraReports.v21.2.Web.WebForms, Version=21.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" id="script">
        function previewClick(s, e) {
            PageMethods.loadchildreport(e.Brick.text());
            if (e.Brick.text() != null) {
                window.location.href = "ViewNormalizedRevnue.aspx";
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
