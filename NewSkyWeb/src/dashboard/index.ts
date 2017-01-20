/// <reference path="../../typings/angular/angular.d.ts" />
import angular = require('angular');
import dashboardController = require("./dashboardController")

var dashboardModule = angular.module('app.dashboard', []);

dashboardModule.controller("dashboardController", dashboardController);

dashboardModule.directive('dashboard', function () {
    return {
        restrict: "EA",
        scope: {},
        replace: true,
        templateUrl: './dashboard/dashboard.html',
        controller: 'dashboardController',
        controllerAs: "dashboardInstance",
        bindToController: true
    };
});

export = dashboardModule;