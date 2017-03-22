class DashboardController {
    static $inject = ["$scope", "$http"];

    private userListTest: string;

    constructor(private scope, private $http) {
        scope.dashboardInstance = this;
    }
}

export = DashboardController;