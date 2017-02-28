/// <reference path="../../../../typings/angular/angular.d.ts" />

import angular = require("angular");

class AuthInterceptorService {
    static $inject = ["localStorageService", "$injector"];

    constructor(private localStorageService, private $injector) {

    }

    private request = (config) => {
        config.headers = config.headers || {};
        var authData = this.localStorageService.get('authorizationData');
        if (authData) {
            config.headers.Authorization = "Bearer " + authData.token;
        }

        return config;
    }

    private responseError = (rejection) => {
        // 401 is Unauthorized error, if didn't set to use refresh token to re-get access-token, then need to re-login.
        if (rejection.status === 401) {
            var authData = this.localStorageService.get('authorizationData');
            var authService = this.$injector.get('authService');
            if (authData && authData.useRefreshTokens) {
                //todo: goto somethere to refresh tokens
                if (confirm("your token expired, do you want to refresh token?")) {
                    authService.refreshToken();
                } else {
                    authService.logout();
                }
            } else {
                authService.logout();
            }
        } else {
            return rejection;
        }
    }
}

export = AuthInterceptorService;
