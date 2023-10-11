function onClick(s, e) {
    var dashboardControl = webDashboard.GetDashboardControl()
    var viewerApiExtenion = dashboardControl.findExtension("viewerApi");
    var availableValues = viewerApiExtenion.getAvailableFilterValues("comboBoxDashboardItem1");
    var filterItems = [];
    availableValues.forEach(function (entry) {
        filterItems.push(entry.getAxisPoint().getValue());
    });
    hf.Set('dashboardState', dashboardControl.getDashboardState());
    hf.Set('filterItems', filterItems.join("|"));
}