class MenuController {
    static $inject = ["$scope", "$state"];

    private selectedMenu: string= "Dashboard";
    private isMenuOpened: boolean= true;

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

    private onAnimateMenu = ():void => {
        this.isMenuOpened = !this.isMenuOpened;
    }
}

export = MenuController;