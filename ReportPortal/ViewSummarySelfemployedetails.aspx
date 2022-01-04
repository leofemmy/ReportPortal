<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSummarySelfemployedetails.aspx.cs" Inherits="ReportPortal.ViewSummarySelfemployedetails" %>

<%@ Register Assembly="DevExpress.XtraReports.v21.2.Web.WebForms, Version=21.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" id="script">
        $("#lblid").val(sessionStorage.getItem("STINAgent"));

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="lblid" Text="ddddd"></asp:Label>
            <dx:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer1" runat="server"></dx:ASPxWebDocumentViewer>
        </div>
    </form>
</body>
</html>
