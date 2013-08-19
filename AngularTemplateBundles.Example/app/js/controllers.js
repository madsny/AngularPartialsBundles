(function() {

'use strict';

    angular.module('controllers', [])
        .controller('HomeCtrl', ['$scope',
            function($scope) {
            }])
        .controller('AnotherPageCtrl', ['$scope',
            function($scope) {
            }])
        .controller('AnotherPageDetailsCtrl', ['$scope', '$routeParams',
            function($scope, $routeParams) {
                $scope.someId = $routeParams.someId;
            }]);
})();