(function() {
    'use strict';

    var angularPartialsBundles = angular.module('angularPartialsBundles', [
        'controllers'
    ]);

    angularPartialsBundles.config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/home', { templateUrl: '/app/partials/home.html', controller: 'HomeCtrl' })
            .when('/another-page', { templateUrl: '/app/partials/another/another-page.html', controller: 'AnotherPageCtrl' })
            .when('/another-page/:someId', { templateUrl: '/app/partials/another/another-page-details.html', controller: 'AnotherPageDetailsCtrl' })
            .otherwise({ redirectTo: '/home' });
    }]);


})();