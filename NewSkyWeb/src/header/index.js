define(['angular', './headerController'], function (angular, headerController) {
    'use strict';

    var headerModule = angular.module('app.header', []);
    headerModule.controller("headerController", headerController);
    var headerTemplate;
    headerModule.directive('platformHeader', function () {
        return {
            restrict: "EA",
            scope: {},
            replace: true,
            templateUrl: './header/header.html',
            controller: 'headerController',
        };
    });

    return headerModule;
});