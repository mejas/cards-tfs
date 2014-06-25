(function(angular) {
    'use strict';
    
    var app = angular.module('cardsApp');
    app.config(['AppSettings', function (AppSettings) {
        AppSettings.serviceBaseUrl = 'http://localhost:3000/api/';
        AppSettings.cardTemplate = 'extensions/card-partial.html';
        AppSettings.menuTemplate = 'extensions/menu-partial.html';
        AppSettings.importQuery = 'Cards';
    }]);

    app.controller('MenuCtrl', ['$scope', '$location', '$http', '$route', 'AppSettings', function ($scope, $location, $http, $route, AppSettings) {

        $scope.import = function () {
            $http.post('/api/import/1?queryName=' + AppSettings.importQuery)
                .success(function(data) {
                    $route.reload();
                });
        };

    }])
})(angular);
