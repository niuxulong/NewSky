require.config({
    // alias libraries paths
    paths: {
        'domReady': './bower_components/requirejs-domready/domReady',
        'angular': './bower_components/angular/angular.min',
        'angular-materialize': './assets/angular-materialize/js/angular-materialize.min'
    },

    shim: {
        'angular': {
            exports: 'angular'
        }
    },
    
    deps: ['./bootstrap']
});


