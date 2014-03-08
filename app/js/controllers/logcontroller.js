angular.module('WinLess')
    .controller('LogController', function($scope, lessCompiler){
        $scope.log = lessCompiler.log;
    });