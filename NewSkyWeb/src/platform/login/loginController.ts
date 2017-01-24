class LoginController {
    static $inject = ["$scope", 'authService'];

    constructor(private scope, private authService) {
        scope.loginInstance = this;
    }
}

export = LoginController;