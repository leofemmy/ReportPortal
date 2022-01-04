<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewNormalized.aspx.cs" Inherits="ReportPortal.ViewNormalized" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.XtraReports.Web" Assembly="DevExpress.XtraReports.v21.1.Web.WebForms, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" id="script">
        function previewClick(s, e) {
            PageMethods.LoadReport(e.Brick.text());
            console.log(e.Brick.text());
            if (e.Brick.text() != null) {
                //alert(e.Brick.text());
               
                //window.sessionStorage.setItem("RevnueOff", e.Brick.text());
            
                window.location.href = "ViewNormalizedAgency.aspx";
            }
        }
        </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
        </asp:ScriptManager>
        <div>
            <dx:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer1" runat="server">
                <ClientSideEvents PreviewClick="previewClick" />
            </dx:ASPxWebDocumentViewer>
        </div>
    </form>
</body>
</html>
