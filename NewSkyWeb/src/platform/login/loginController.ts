class LoginController {
    static $inject = ["$scope", 'authService', '$state'];

    private isLoginMode: boolean = true;
    private linkText: string = "Sign Up";
    private buttonText: string = "Login"

    private userName: string;
    private password: string;
    private message: string;

    private loginData = {
        userName: undefined,
        password: undefined,
        useRefreshToken: true,
        confirmPassword: undefined
    }

    constructor(private scope, private authService, private stateProvider) {
        scope.loginInstance = this;
    }

    private loginOrSignUp = (): void => {
        if (this.isLoginMode) {
            this.authService.logIn(this.loginData).then((response) => {
                if (response.error) {
                    this.message = response.error;
                } else {
                    this.stateProvider.go("dashboard");
                }
            });
        } else {
            var registerData = {
                UserName: this.loginData.userName,
                Password: this.loginData.password,
                ConfirmPassword: this.loginData.confirmPassword
            }
            this.authService.saveRegistration(registerData).then((response) => {
                if (response.error) {
                    this.message = response.error;
                } else {
                    this.message = "Register new user successfully."
                }
            });
        }
    }

    private signupLickClick = (): void => {
        this.isLoginMode = !this.isLoginMode;
        if (this.isLoginMode) {
            this.linkText = "Sign Up";
            this.buttonText = "Login";
        } else {
            this.linkText = "Back to login page";
            this.buttonText = "Sign Up"
        }
    }
}

export = LoginController;