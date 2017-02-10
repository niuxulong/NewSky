class LoginController {
    static $inject = ["$scope", 'authService', '$state'];

    private userName: string;
    private password: string;
    private message: string;

    private loginData = {
        userName: undefined,
        password: undefined,
        useRefreshToken: true
    }

    constructor(private scope, private authService, private stateProvider) {
        scope.loginInstance = this;
    }

    private login = (): void => {
        this.authService.logIn(this.loginData).then((response) => {
            if (response.error) {
                this.message = response.error.data.error_description;
            } else {
                this.stateProvider.go("dashboard");
            }
        });
    }
}

export = LoginController;