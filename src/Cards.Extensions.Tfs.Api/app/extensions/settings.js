(function(angular) {
    'use strict';
    
    var app = angular.module('cardsApp');
    app.config(['AppSettings', function (AppSettings) {
        AppSettings.serviceBaseUrl = 'http://localhost:3000/api/';
        AppSettings.cardTemplate = 'extensions/card-partial.html';
    }]);
})(angular);
