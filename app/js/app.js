angular.module('WinLess', ['ui.router', 'ui.bootstrap', 'ui.utils', 'angularMoment', 'ngGrid', 'Class'])
    .config(function($stateProvider){
        $stateProvider
            .state('application', {
                abstract: true,
                templateUrl: 'views/application.html',
                controller: 'ApplicationController'
            })
            .state('application.projects', {
                templateUrl: 'views/projects.html',
                controller: 'ProjectsController'
            })
            .state('application.log', {
                templateUrl: 'views/log.html',
                controller: 'LogController'
            })
            .state('application.settings', {
                templateUrl: 'views/settings.html',
                controller: 'SettingsController'
            })
            .state('application.about', {
                templateUrl: 'views/about.html'
            });
    })
    .run(function($state){
        $state.go('application.projects');
    });