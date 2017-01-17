class MenuController {
    static $inject = ["$scope", "$state"];

    private selectedMenu: string = "Dashboard";

    constructor(private scope, private stateProvider) {
        scope.menuInstance = this;

        this.stateProvider.go("dashboard");
        this.scope.$on("animateMenuEvent", this.onAnimateMenu);
    }

    private dashboardClick() {
        this.selectedMenu = 'Dashboard';
    }

    private uiElementsClick() {
        this.selectedMenu = 'UIElements';
    }

    private onAnimateMenu() {
        alert("djfjkdjksdfjkd");
    }
}

export = MenuController;