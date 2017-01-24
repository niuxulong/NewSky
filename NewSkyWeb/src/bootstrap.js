define(['require', 'angular', 'angular-materialize', 'angular-ui-router', 'angular-local-storage', 'app'], function (require, angular) {
    'use strict';

    require(['domReady!'], function (document) {
        angular.bootstrap(document, ['app']);
    });
});