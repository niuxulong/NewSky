/// <reference path="../../../../typings/angular/angular.d.ts" />

import angular = require("angular");

class AuthInterceptorService {
    static $inject = ["localStorageService"];

    constructor(private localStorageService) {

    }

    private request = (config): void => {
        config.headers = config.headers || {};
        var authData = this.localStorageService.get('authorizationData');
        if (authData) {
            config.headers.Authorization = "Bearer " + authData.token;
        }

        return config;
    }
}

export = AuthInterceptorService;
