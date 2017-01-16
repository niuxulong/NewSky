class MenuController {
    static $inject = ["$scope", "$state"];

    private selectedMenu: string = "Dashboard";

    constructor(private $scope, private stateProvider) {
        $scope.menuInstance = this;

        this.stateProvider.go("dashboard");
    }

    private dashboardClick() {
        this.selectedMenu = 'Dashboard';
    }

    private uiElementsClick() {
        this.selectedMenu = 'UIElements';
    }

}

export = MenuController;