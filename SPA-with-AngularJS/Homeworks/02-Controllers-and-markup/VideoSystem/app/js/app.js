/* App Module */

var videoSystemApp = angular.module('videoSystemApp', [
    'ngSanitize',
    'ngRoute',
    'videoAppControllers',
    'videoFilters'
]);

videoSystemApp.config(['$routeProvider',
    function($routeProvider) {
        $routeProvider.
        when('/videos', {
            templateUrl: 'partials/videoList.html',
            controller: 'videoController'
        }).
        when('/add-new-video', {
            templateUrl: 'partials/newVideoForm.html',
            controller: 'newVideoController'
        }).
        otherwise({
            redirectTo: '/videos'
        });
    }
]);