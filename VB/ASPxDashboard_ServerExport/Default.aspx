<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="ASPxDashboard_ServerExport.Default" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.17.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Dashboard.v17.1.Web, Version=17.1.17.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        function onClick(s, e) {
            var availableValues = webDashboard.GetAvailableFilterValues("comboBoxDashboardItem1");
            var filterItems = [];
            availableValues.forEach(function (entry) {
                filterItems.push(entry.GetAxisPoint().GetValue());
            });
            hf.Set('dashboardState', webDashboard.GetDashboardState());
            hf.Set('filterItems', filterItems.join("|"));
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">

        <div id="buttonContainer" style="float: left;"></div>

        <dx:ASPxHiddenField ID="ASPxHiddenField1" runat="server" ClientInstanceName="hf">
        </dx:ASPxHiddenField>

        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Export different Categories to a single PDF" OnClick="ASPxButton1_Click">
            <ClientSideEvents Click="onClick" />
        </dx:ASPxButton>

        <div style="position: absolute; left: 0; right: 0; top: 50px; bottom: 0;">
            <dx:ASPxDashboard ID="ASPxDashboard1" runat="server" Width="100%" Height="100%" WorkingMode="Viewer" ClientInstanceName="webDashboard">
            </dx:ASPxDashboard>
        </div>
    </form>
</body>
</html>