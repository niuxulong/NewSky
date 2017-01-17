class HeaderController {
    static $inject = ["$scope"];

    private isMenuClosed: boolean = false;

    constructor(private scope) {
        scope.menuInstance = this;
    }

    private sideNavClick() {
        this.isMenuClosed = !this.isMenuClosed;
        this.scope.$emit("animateMenuEvent");
    }
}

export = HeaderController;