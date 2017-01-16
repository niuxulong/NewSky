class MenuController {
    static $inject = ["$scope"];

    private selectedMenu: string = "Dashboard";

    constructor($scope) {
        $scope.menuInstance = this;
    }

    private dashboardClick() {
        this.selectedMenu = 'Dashboard';
    }

    private uiElementsClick() {
        this.selectedMenu = 'UIElements';
    }

}

export = MenuController;