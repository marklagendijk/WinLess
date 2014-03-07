window._ = require('lodash');

angular.module('WinLess', ['ui.router', 'ui.bootstrap', 'ui.utils', 'angularMoment', 'ngGrid', 'Class'])
    .config(function($stateProvider, $locationProvider){
        $locationProvider.html5Mode(true);
        $stateProvider.state('root', {
            templateUrl: 'views/layout.html',
            controller: 'ApplicationController'
        });
    })
    .run(function($state){
        $state.go('root');
    });