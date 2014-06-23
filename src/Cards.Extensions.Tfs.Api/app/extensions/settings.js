(function(angular) {
    'use strict';
    
    var app = angular.module('cardsApp');
    app.config(['AppSettings', function (AppSettings) {
        AppSettings.serviceBaseUrl = 'http://localhost:3000/api/';
        AppSettings.cardTemplate = 'extensions/card-partial.html';
        AppSettings.menuTemplate = 'extensions/menu-partial.html'
    }]);

    app.controller('MenuCtrl', ['$scope', '$location', function ($scope, $location) {

        $scope.import = function () {
            console.log('import invoked.');
            $location.path('/areas');
        };

    }])
})(angular);
