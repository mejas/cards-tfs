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
        AppSettings.tfsLinkTemplate = 'http://nvitpmmtf100:8080/tfs/TFSCollection/NCA/_workItems#id={{TFSID}}&_a=edit';
        
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

    app.controller('LinkCtrl', ['$scope', 'AppSettings', function ($scope, AppSettings) {
        $scope.getLink = function (tfsId) {
            var uri = AppSettings.tfsLinkTemplate.replace('{{TFSID}}', tfsId);

            return uri;
        };
    }])
    
    app.controller('ImportTFSCtrl', ['$scope', '$rootScope', '$http', 'CardHelper', function ($scope, $rootScope, $http, CardHelper) {
        $scope.tfs = {};
        $scope.tfs.id = '';

        $scope.fetch = function (tfsId) {

            $rootScope.$broadcast('ajax_start');
            $http.get('http://localhost:3000/api/tfs/' + tfsId)
                .success(function(workItem) {
                    $scope.card.tfsID = workItem.id;
                    $scope.card.name = workItem.title;
                    $scope.card.description = workItem.description;
                    $scope.card.assignedTo = workItem.assignedTo;
                    $scope.card.labels = CardHelper.getLabels($scope.card.name);

                    $rootScope.$broadcast('ajax_end');
                });
        };
    }]);

    app.controller('MenuCtrl', ['$scope', '$rootScope', '$window', '$location', '$http', '$route', 'Session', 'AppSettings', function ($scope, $rootScope, $window, $location, $http, $route, Session, AppSettings) {

        $scope.import = function () {

            $rootScope.$broadcast('ajax_start');
            $http.post('/api/import/1?queryName=' + AppSettings.importQuery)
                .success(function (data) {
                    $rootScope.$broadcast('ajax_end');
                    $route.reload();
                });
        };

    }])
})(angular);
