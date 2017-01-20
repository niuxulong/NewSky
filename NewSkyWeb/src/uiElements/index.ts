/// <reference path="../../typings/angular/angular.d.ts" />
import angular = require('angular');
import uiElementsController = require("./uiElementsController")

var uiElementsModule = angular.module('app.uiElements', []);

uiElementsModule.controller("uiElementsController", uiElementsController);

uiElementsModule.directive('uiElements', function () {
    return {
        restrict: "EA",
        scope: {},
        replace: true,
        templateUrl: './uiElements/uiElements.html',
        controller: 'uiElementsController',
        controllerAs: "uiElementsInstance",
        bindToController: true
    };
});

export = uiElementsModule;