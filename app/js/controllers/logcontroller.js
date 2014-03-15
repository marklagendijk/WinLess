angular.module('WinLess')
    .controller('LogController', function($scope, lessCompiler){
        $scope.compilerLog = lessCompiler.log;
    });