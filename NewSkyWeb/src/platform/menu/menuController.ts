class MenuController {
    static $inject = ["$scope", "$state"];

    private isMenuOpened: boolean= true;

    constructor(private scope, private stateProvider) {
        scope.menuInstance = this;
        this.scope.$on("animateMenuEvent", this.onAnimateMenu);
    }

    private onAnimateMenu = ():void => {
        this.isMenuOpened = !this.isMenuOpened;
    }
}

export = MenuController;