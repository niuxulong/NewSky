define(['angular', './header/headerController', './menu/menuController'], function (angular, headerController, menuController) {
    'use strict';

    var platformModule = angular.module('app.platform', []);
    platformModule.controller("headerController", headerController);
    platformModule.directive('platformHeader', function () {
        return {
            restrict: "EA",
            scope: {},
            replace: true,
            templateUrl: './platform/header/header.html',
            controller: 'headerController',
        };
    });
    platformModule.controller("menuController", headerController);
    platformModule.directive('platformMenu', function () {
        return {
            restrict: "EA",
            scope: {},
            replace: true,
            templateUrl: './platform/menu/menu.html',
            controller: 'menuController',
        };
    });


    return platformModule;
});