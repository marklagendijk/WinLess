angular.module('WinLess')
    .controller('ProjectModalController', function($scope, $modalInstance, project, settings, LessFile){
        $scope.project = project;
        $scope.save = save;
        $scope.cancel = cancel;

        var availableFiles = getAvailableFiles(project);
        $scope.availableFiles = {
            showIgnored: false,
            all: availableFiles,
            filtered: getFilteredAvailableFiles(availableFiles),
            ignored: getIgnoredAvailables(availableFiles)
        };


        function getAvailableFiles(project){
            return project.getAvailableFilePaths()
                .map(function(filePath){
                    return {
                        path: filePath,
                        selected: _.find(project.files, { path: filePath }) !== undefined
                    };
                });
        }

        function getFilteredAvailableFiles(files){
            return files.filter(function(file){
                return settings.values.project.ignorePatterns.filter(function(pattern){
                    return _.contains(file.path, pattern);
                }).length === 0;
            });
        }

        function getIgnoredAvailables(files){
            return files.filter(function(file){
                return settings.values.project.ignorePatterns.filter(function(pattern){
                    return _.contains(file.path, pattern);
                }).length > 0;
            });
        }

        function save(){
            project.files.splice(0, project.files.length);

            availableFiles
                .filter(function(file){
                    return file.selected;
                })
                .forEach(function(file){
                    project.files.push(new LessFile(file));
                });
            $modalInstance.close(project);
        }

        function cancel(){
            $modalInstance.dismiss('cancel');
        }
    });