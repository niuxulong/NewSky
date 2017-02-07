class DashboardController {
    static $inject = ["$scope", "$http"];

    private userListTest: string;

    constructor(private scope, private $http) {
        scope.dashboardInstance = this;
        this.getUserListTest();
    }

    private getUserListTest = (): void => {
        return this.$http({
            method: "GET",
            url: "http://localhost:8901/api/platform/user/get"
        }).then((response) => {
                this.userListTest = response.data;
            }, (response) => {
                this.userListTest = response.data.Message;
        });
    }
}

export = DashboardController;