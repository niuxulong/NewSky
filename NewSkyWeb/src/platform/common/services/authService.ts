/// <reference path="../../../../typings/angular/angular.d.ts" />

import angular = require("angular");

class AuthService {
    static $inject = ["$http", "localStorageService"];

    private serviceBase: string = 'http://localhost:8901/api/platform/';

    private authentication = {
        isAuth: false,
        userName: ""
    }

    constructor(private $http, private localStorageService) {
        this.fillAuthData();
    }

    private saveRegistration(registration): angular.IPromise<{}> {
        this.logout();

        return this.$http({
            method: "POST",
            url: this.serviceBase + 'api/platform/register',
            data: registration
        }).then(function (response) {
                return response.data;
        });
    }

    private logIn = (loginData): angular.IPromise<{}> => {
        return this.$http({
            method: "POST",
            url: this.serviceBase + 'token',
            data: "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password,
            headers: { "Content-Type": 'application/x-www-form-urlencoded'}
        }).then((response) => {
                this.localStorageService.set('authorizationData',
                    {
                        token: response.data.access_token,
                        userName: loginData.userName
                    });
                this.authentication.isAuth = true;
                this.authentication.userName = loginData.userName;
                return response;
            },
            (response) => {
                this.logout();
                return { "error": response };
            }
        );
    }

    private logout(): void {
        this.localStorageService.remove('authorizationData');
        this.authentication.isAuth = false;
        this.authentication.userName = "";
    }

    private fillAuthData = () => {
        var authData = this.localStorageService.get('authorizationData');
        if (authData) {
            this.authentication.isAuth = true;
            this.authentication.userName = authData.userName;
        }
    }
}

export = AuthService;