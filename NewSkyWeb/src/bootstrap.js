define(['require', 'angular', 'angular-materialize', 'angular-ui-router', 'app'], function (require, angular) {
    'use strict';

    require(['domReady!'], function (document) {
        angular.bootstrap(document, ['app']);
    });
});