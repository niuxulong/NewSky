class TecArticlesController {
    static $inject = ["$scope"];

    constructor(scope) {
        scope.tecArticlesInstance = this;
    }
}

export = TecArticlesController;