/// <reference path="../../../../typings/angular/angular.d.ts" />

import angular = require("angular");
import namingRegistry = require("../constants/namingRegistry");

class AuthService {
    static $inject = ["$http", "localStorageService"];

    private serviceBase: string = 'http://localhost:8901/api/platform/';

    private authentication = {
        isAuth: false,
        userName: "",
        useRefreshTokens: false
    }

    constructor(private $http, private localStorageService) {
        this.fillAuthData();
    }

    private saveRegistration(registration): angular.IPromise<{}> {
        this.logout();

        return this.$http({
            method: "POST",
            url: this.serviceBase + 'User/Register',
            data: registration
        }).then((response) => {
                if (response.status === 200) {
                    return response.data;
                } else {
                    return { "error": response.data.Message };
                }
            }, (error) => {
                return { "error": error};
        });
    }

    private logIn = (loginData): angular.IPromise<{}> => {
        var postData = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
        if (loginData.useRefreshToken) {
            postData = postData + "&client_id=" + namingRegistry.platformClientId;
        }

        return this.$http({
            method: "POST",
            url: this.serviceBase + 'token',
            data: postData,
            headers: { "Content-Type": 'application/x-www-form-urlencoded'}
        }).then((response) => {
                if (response.status === 200) {
                    if (loginData.useRefreshToken) {
                        this.localStorageService.set('authorizationData',
                            {
                                token: response.data.access_token,
                                userName: loginData.userName,
                                refreshToken: response.data.refresh_token,
                                useRefreshTokens: true
                            });
                    } else {
                        this.localStorageService.set('authorizationData',
                            {
                                token: response.data.access_token,
                                userName: loginData.userName,
                                refreshToken: "",
                                useRefreshTokens: false
                            });
                    }

                    this.authentication.isAuth = true;
                    this.authentication.userName = loginData.userName;
                    this.authentication.useRefreshTokens = loginData.useRefreshToken;
                } else {
                    this.logout();
                    return { "error": response.data.error_description };
                }
                
                return response;
            },
            (error) => {
                this.logout();
                return { "error": error };
            }
        );
    }

    private refreshToken = () => {
        var authData = this.localStorageService.get('authorizationData');
        if (authData && authData.useRefreshTokens)
        {
            var postData = "grant_type=refresh_token&refresh_token=" + authData.refreshToken + "&client_id=" + namingRegistry.platformClientId;
            this.localStorageService.remove('authorizationData');

            return this.$http({
                method: "POST",
                url: this.serviceBase + 'token',
                data: postData,
                headers: { "Content-Type": 'application/x-www-form-urlencoded' }
            }).then((response) => {
                    this.localStorageService.set('authorizationData',
                        {
                            token: response.data.access_token,
                            userName: response.userName,
                            refreshToken: response.data.refresh_token,
                            useRefreshTokens: true
                        });

                return response;
            },
            (error) => {
                this.logout();
                return { "error": error };
            }
            );
        }
    }

    private logout(): void {
        this.localStorageService.remove('authorizationData');
        this.authentication.isAuth = false;
        this.authentication.userName = "";
        this.authentication.useRefreshTokens = false;
    }

    private fillAuthData = () => {
        var authData = this.localStorageService.get('authorizationData');
        if (authData) {
            this.authentication.isAuth = true;
            this.authentication.userName = authData.userName;
            this.authentication.useRefreshTokens = authData.useRefreshTokens;
        }
    }
}

export = AuthService;