class AppShellController {
    static $inject = ["$scope", "authService", "$state", "$timeout"];

    private isAuth: boolean = false;

    constructor(private scope, private authService, private stateProvider, private timeout) {
        scope.appShellInstance = this;

        scope.$watch('appShellInstance.authService.authentication.isAuth', () => {
            timeout(() => {
                this.isAuth = authService.authentication.isAuth;
            }, 10);
        });
    }
}

export = AppShellController;