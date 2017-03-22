/// <reference path="../../typings/angular/angular.d.ts" />
import angular = require('angular');
import tecArticlesController = require("./tecArticlesController")

var tecArticlesModule = angular.module('app.tecArticles', []);

tecArticlesModule.controller("tecArticlesController", tecArticlesController);

tecArticlesModule.directive('tecArticles', function () {
    return {
        restrict: "EA",
        scope: {},
        replace: true,
        templateUrl: './tecArticles/tecArticles.html',
        controller: 'tecArticlesController',
        controllerAs: "tecArticlesInstance",
        bindToController: true
    };
});

export = tecArticlesModule;