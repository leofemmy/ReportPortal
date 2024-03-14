<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VwSummary.aspx.cs" Inherits="ReportPortal.VwSummary" %>

<%@ Register Assembly="DevExpress.XtraReports.v22.1.Web.WebForms, Version=22.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" id="script">
        function previewClick(s, e) {
            //$("#hdvalue").val(e.Brick.text())
            //document.getElementById("<=hdvalue.ClientID >").value = e.GetBrickText();
            //e.Brick && alert(e.GetBrickText())

            //PageMethods.loadchildreport(e.Brick.text());

            if (e.Brick.text() != null) {
                if (e.Brick.text() == "Tax Agents") {
                    window.location.href = "ViewSummaryTaxAgent.aspx"
                }
                if (e.Brick.text() == "Self-Employed") {
                    window.location.href = "ViewSummarySelfemploye.aspx"
                }
                if (e.Brick.text() == "Employed") {
                    window.location.href = "ViewSummarylistChild.aspx"
                }
                $("#hdvalue").val(e.Brick.text())

            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hdvalue" ClientIDMode="Static" />
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
