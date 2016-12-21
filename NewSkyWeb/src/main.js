require.config({
    paths: {
        'domReady': './bower_components/requirejs-domready/domReady',
        'angular': './bower_components/angular/angular.min'
    },

    shim: {
        'angular': {
            exports: 'angular'
        }
    },

    deps: ['./bootstrap']

});


