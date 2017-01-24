/// <reference path="../../../../typings/angular/angular.d.ts" />

import angular = require("angular");

class AuthService {
    static $inject = ["$http", "localStorageService"];

    private serviceBase: string = 'http://localhost:8901/';

    private authentication = {
        isAuth: false,
        userName: ""
    }

    constructor(private $http, private $q, private localStorageService) {

    }

    private saveRegistration(registration): angular.IPromise<{}> {
        this.logOut();

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
        }).then(function (response) {
                this.localStorageService.set('authoricationData',
                    {
                        token: response.access_token,
                        userName: loginData.userName
                    });
                this.authentication.isAuth = true;
                this.authentication.userName = loginData.userName;
                return response;
            }, function (response) {
                this.logOut();
            return { "error": response };
        });
    }

    private logOut(): void {
        this.localStorageService.remove('authoricationData');
        this.authentication.isAuth = false;
        this.authentication.userName = "";
    }

    private fillAuthData = () => {
        var authData = this.localStorageService.get('authoricationData');
        if (authData) {
            this.authentication.isAuth = true;
            this.authentication.userName = authData.userName;
        }
    }
}

export = AuthService;