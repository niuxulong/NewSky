class ContentShellController {
    static $inject = ["$scope", "$state"];

    private isMenuOpened: boolean = true;

    constructor(private scope) {
        scope.contentShellInstance = this;
        this.scope.$on("animateMenuEvent", this.onAnimateMenu);
    }

    private onAnimateMenu = ():void => {
        this.isMenuOpened = !this.isMenuOpened;
    }
}

export = ContentShellController;