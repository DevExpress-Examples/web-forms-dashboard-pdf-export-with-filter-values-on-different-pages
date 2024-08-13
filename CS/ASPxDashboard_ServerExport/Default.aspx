<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPxDashboard_ServerExport.Default" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Dashboard.v23.1.Web.WebForms, Version=23.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My dashboard</title>
    <script type="text/javascript" src="Script/script.js"></script>

</head>
<body>
    <form id="form1" runat="server">

        <div id="buttonContainer" style="float: left;"></div>

        <dx:ASPxHiddenField ID="ASPxHiddenField1" runat="server" ClientInstanceName="hf">
        </dx:ASPxHiddenField>


        <dx:ASPxButton ID="ASPxButton1" Theme="Office365" runat="server" Text="Export different Categories to a single PDF" OnClick="ASPxButton1_Click">
            <ClientSideEvents Click="onClick" />
        </dx:ASPxButton>

        <div style="position: absolute; left: 0; right: 0; top: 50px; bottom: 0;">
            <dx:ASPxDashboard ID="ASPxDashboard1" runat="server" Width="100%" Height="100%" WorkingMode="ViewerOnly" ClientInstanceName="webDashboard">
            </dx:ASPxDashboard>
        </div>
    </form>
</body>
</html>