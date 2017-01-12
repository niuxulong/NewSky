/// <reference path="../../typings/angular/angular.d.ts" />

import angular = require('angular');
import headerController = require("./header/headerController");
import menuController = require("./menu/menuController");

var platformModule = angular.module('app.platform', []);

platformModule.controller("headerController", headerController);
platformModule.controller("menuController", menuController);

platformModule.directive('platformHeader', function () {
    return {
        restrict: "EA",
        scope: {},
        replace: true,
        templateUrl: './platform/header/header.html',
        controller: 'headerController',
    };
});

platformModule.directive('platformMenu', function () {
    return {
        restrict: "EA",
        scope: {},
        replace: true,
        templateUrl: './platform/menu/menu.html',
        controller: 'menuController',
    };
});

export = platformModule;