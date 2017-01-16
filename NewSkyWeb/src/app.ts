/// <reference path="../typings/angular/angular.d.ts" />

import angular = require('angular');
import platformModule = require("./platform/index");

var appModule = angular.module('app', ['ui.materialize', 'ui.router', platformModule.name]);

export = appModule;