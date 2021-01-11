<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSummaryTaxAgent.aspx.cs" Inherits="ReportPortal.ViewSummaryTaxAgent" %>

<%@ Register Assembly="DevExpress.XtraReports.v20.2.Web.WebForms, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" id="script">
        function previewClick(s, e) {
           // e.Brick && alert(e.GetBrickText())
          
            sessionStorage.setItem("STINAgent", e.Brick.text());

            if (e.Brick.text() != null) {
                PageMethods.Loadchildreport(e.Brick.text(), onSuccess, onFailure);
                window.location.href = "ViewSummaryTaxAgentdetails.aspx"
            }
        }
        function onSuccess(result, usercontext, methodname) {
            alert(result)
        }

        function onFailure(error, usercontext, methodname) { alert("failed: " + error.get_message()); }
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
