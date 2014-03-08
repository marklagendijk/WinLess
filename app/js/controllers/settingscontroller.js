angular.module('WinLess')
    .controller('SettingsController', function($scope, settings){
        $scope.settings = settings;
        $scope.$watch('settings.values', settings.save, true);
    });