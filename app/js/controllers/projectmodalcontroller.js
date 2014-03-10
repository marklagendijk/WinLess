angular.module('WinLess')
    .controller('ProjectModalController', function($scope, $modalInstance, project, settings){
        $scope.modal = $modalInstance;
        $scope.project = project;

        var availableFilePaths = project.getAvailableFilePaths();
        $scope.availableFilePaths = {
            showIgnored: false,
            all: availableFilePaths,
            filtered: getFilteredAvailableFilePaths(availableFilePaths),
            ignored: getIgnoredAvailableFilePaths(availableFilePaths)
        };

        function getFilteredAvailableFilePaths(paths){
            return paths.filter(function(path){
                    return settings.values.project.ignorePatterns.filter(function(pattern){
                        return _.contains(path, pattern);
                    }).length === 0;
                });
        }

        function getIgnoredAvailableFilePaths(paths){
            return paths.filter(function(path){
                    return settings.values.project.ignorePatterns.filter(function(pattern){
                        return _.contains(path, pattern);
                    }).length > 0;
                });
        }
    });