(function(angular) {
    'use strict';
    
    var app = angular.module('cardsApp');
    app.config(['AppSettings', function (AppSettings) {
        AppSettings.serviceBaseUrl = 'http://localhost:3000/api/';
        AppSettings.cardTemplate = 'extensions/card-partial.html';
        AppSettings.cardFormTemplate = 'extensions/cardform-partial.html';
        AppSettings.menuTemplate = 'extensions/menu-partial.html';
        AppSettings.sessionTemplate = 'extensions/login-partial.html';
        AppSettings.importQuery = 'Cards';
        
    }]);

    app.run(['Session', 'AppSettings', '$http', '$rootScope', '$window', function (Session, AppSettings, $http, $rootScope, $window) {
        
        Session.checkAuthentication = function () {
            //Windows authentication, let session bar gets the currently signed in user
        };

        Session.isAuthenticated = function () {
            return true;
        };

        Session.getCurrentUser = function () {
            if (!$window.sessionStorage.user) {
                var uri = AppSettings.serviceBaseUrl + 'session';
                $window.sessionStorage.user = "Logged In";


                $http.post(uri)
                    .success(function (session) {
                        Session.create(session);
                    });
            }

            return $window.sessionStorage.user;
        };
    }]);

    app.controller('MenuCtrl', ['$scope', '$window', '$location', '$http', '$route', 'Session', 'AppSettings', function ($scope, $window, $location, $http, $route, Session, AppSettings) {

        $scope.import = function () {
            $http.post('/api/import/1?queryName=' + AppSettings.importQuery)
                .success(function(data) {
                    $route.reload();
                });
        };

    }])
})(angular);
