class HeaderController {
    static $inject = ["$scope", 'authService'];

    private isMenuClosed: boolean = false;

    constructor(private scope, private authService) {
        scope.menuInstance = this;
    }

    private sideNavClick() {
        this.isMenuClosed = !this.isMenuClosed;
        this.scope.$emit("animateMenuEvent");
    }
}

export = HeaderController;