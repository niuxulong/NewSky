/// <reference path="../../typings/angular/angular.d.ts" />

import angular = require('angular');
import headerController = require("./header/headerController");
import menuController = require("./menu/menuController");
import dashboardController = require("./content/dashboardController")
import uiElementsController = require("./content/uiElementsController")
import contentShellController = require("./content/contentShellController");

var platformModule = angular.module('app.platform', []);

platformModule.controller("headerController", headerController);
platformModule.controller("menuController", menuController);
platformModule.controller("dashboardController", dashboardController);
platformModule.controller("uiElementsController", uiElementsController);
platformModule.controller("contentShellController", contentShellController);

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

platformModule.directive('dashboard', function () {
    return {
        restrict: "EA",
        scope: {},
        replace: true,
        templateUrl: './platform/content/dashboard.html',
        controller: 'dashboardController',
        controllerAs: "dashboardInstance",
        bindToController: true
    };
});

platformModule.directive('uiElements', function () {
    return {
        restrict: "EA",
        scope: {},
        replace: true,
        templateUrl: './platform/content/uiElements.html',
        controller: 'uiElementsController',
        controllerAs: "uiElementsInstance",
        bindToController: true
    };
});

platformModule.config(function ($stateProvider, $urlRouterProvider) {
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