/// <reference path="../typings/angular.d.ts" />

import angular = require('angular');
import platformModule = require("./platform/index");

var appModule = angular.module('app', ['ui.materialize', platformModule.name]);

export = appModule;