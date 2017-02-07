class LoginController {
    static $inject = ["$scope", 'authService', '$state'];

    private userName: string;
    private password: string;
    private message: string;

    constructor(private scope, private authService, private stateProvider) {
        scope.loginInstance = this;
    }

    private login = (): void => {
        var loginData = {
            userName: this.userName,
            password: this.password
        };
        this.authService.logIn(loginData).then((response) => {
            if (response.error) {
                this.message = response.error.data.error_description;
            } else {
                this.stateProvider.go("dashboard");
            }
        });
    }
}

export = LoginController;