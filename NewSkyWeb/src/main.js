require.config({
    // alias libraries paths
    paths: {
        'domReady': './vendor/requirejs-domready/domReady',
        'angular': './vendor/angular/angular.min',
        'angular-materialize': './assets/angular-materialize/js/angular-materialize.min',
        'angular-ui-router': './vendor/angular-ui-router/angular-ui-router.min'
    },

    shim: {
        'angular': {
            exports: 'angular'
        }
    },

    deps: ['./bootstrap']
});


