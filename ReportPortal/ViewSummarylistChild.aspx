<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSummarylistChild.aspx.cs" Inherits="ReportPortal.ViewSummarylistChild" %>

<%@ Register Assembly="DevExpress.XtraReports.v20.1.Web.WebForms, Version=20.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" id="script">
        function previewClick(s, e) {
            e.Brick && alert(e.GetBrickText())
            PageMethods.loadchildreport(e.Brick.text());
            if (e.Brick.text() != null) {
                $("#hdvalue").val(e.Brick.text())
                window.location.href = "ViewSummarylistChild.aspx"
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <div>
            <dx:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer1" runat="server"></dx:ASPxWebDocumentViewer>
        </div>
    </form>
</body>
</html>
