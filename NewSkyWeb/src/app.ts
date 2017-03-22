/// <reference path="../typings/angular/angular.d.ts" />

import angular = require('angular');
import platformModule = require("./platform/index");
import dashboardModule = require("./dashboard/index");
import tecArticlesModule = require("./tecArticles/index");

var appModule = angular.module('app', [
    'ui.materialize',
    'ui.router',
    'LocalStorageModule',
    platformModule.name,
    dashboardModule.name,
    tecArticlesModule.name]);

export = appModule;