class AppShellController {
    static $inject = ["$scope", "localStorageService", "$state"];

    private authData: {};

    constructor(private scope, private localStorageService, private stateProvider) {
        scope.appShellInstance = this;

        this.authData = localStorageService.get("authoricationData");
    }
}

export = AppShellController;