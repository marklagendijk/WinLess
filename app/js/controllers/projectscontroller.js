angular.module('WinLess')
    .controller('ProjectsController', function($scope, projects){
        $scope.projects = projects;

        $scope.foldersDropped = function(event){
            event.value.forEach(createProject);
        };

        $scope.folderSelected = function(event){
            createProject(event.value);
        };

        function createProject(folderPath){
            projects.push({
                name: _.last(folderPath.split('\\')),
                path: folderPath
            });
        }
    });