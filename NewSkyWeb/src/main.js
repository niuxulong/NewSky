require.config({
    paths: {
        'domReady': './vendor/requirejs-domready/domReady',
        'angular': './vendor/angular/angular.min',
        'angular-materialize': './assets/angular-materialize/js/angular-materialize.min',
        'angular-ui-router': './vendor/angular-ui-router/angular-ui-router.min',
        'angular-local-storage': './vendor/angular-local-storage/angular-local-storage'
    },

    shim: {
        'angular': {
            exports: 'angular'
        }
    },

    deps: ['./bootstrap']
});


