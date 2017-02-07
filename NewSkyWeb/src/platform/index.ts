/// <reference path="../../typings/angular/angular.d.ts" />

import angular = require('angular');
import headerController = require("./header/headerController");
import menuController = require("./menu/menuController");
import contentShellController = require("./content/contentShellController");
import appShellController = require("./appShell/AppShellController");
import loginController = require("./login/loginController");

import authService = require("./common/services/authService");
import authInterceptorService = require("./common/services/authInterceptorService");

var platformModule = angular.module('app.platform', []);

platformModule.controller("headerController", headerController);
platformModule.controller("menuController", menuController);
platformModule.controller("contentShellController", contentShellController);
platformModule.controller("appShellController", appShellController);
platformModule.controller("loginController", loginController);

platformModule.directive('platformAppShell', function () {
    return {
        restrict: "EA",
        replace: true,
        templateUrl: './platform/appShell/appShell.html',
        controller: 'appShellController',
        controllerAs: "appShellInstance",
        bindToController: true
    };
});

platformModule.directive('platformLogin', function () {
    return {
        restrict: "EA",
        replace: true,
        templateUrl: './platform/login/login.html',
        controller: 'loginController',
        controllerAs: "loginInstance",
        bindToController: true
    };
});

platformModule.directive('platformHeader', function () {
    return {
        restrict: "EA",
        replace: true,
        templateUrl: './platform/header/header.html',
        controller: 'headerController',
        controllerAs: "headerInstance",
        bindToController: true
    };
});

platformModule.directive('platformMenu', function () {
    return {
        restrict: "EA",
        replace: true,
        templateUrl: './platform/menu/menu.html',
        controller: 'menuController',
        controllerAs: "menuInstance",
        bindToController: true
    };
});

platformModule.directive('platformContent', function () {
    return {
        restrict: "EA",
        replace: true,
        templateUrl: './platform/content/contentShell.html',
        controller: 'contentShellController',
        controllerAs: "contentShellInstance",
        bindToController: true
    };
});

platformModule.service('authService', authService);
platformModule.service('authInterceptorService', authInterceptorService);

platformModule.config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');

    $urlRouterProvider.otherwise('/');

    $stateProvider
    .state('dashboard', {
        url: '/dashboard',
        views: {
            'content@': {
                template: '<dashboard/>'
            }
        }
    })

    .state('uiElements', {
        url: '/uiElements',
        views: {
            'content@': {
                template: '<ui-elements/>'
            }
        }
    })
});

export = platformModule;