angular.module('WinLess')
    .controller('ProjectsController', function($scope, $modal, open, projects, Project){
        $scope.projects = projects;
        $scope.selected = {
            project: null,
            file: null
        };

        $scope.foldersDropped = foldersDropped;
        $scope.folderSelected = folderSelected;
        $scope.editProject = editProject;
        $scope.openProjectFolder = openProjectFolder;
        $scope.removeProject = removeProject;
        $scope.$watchCollection('projects', selectProject);
        $scope.$watch('selected.project', selectFile);


        function foldersDropped(event){
            createOrEditProject(event.value[0]);
        }

        function folderSelected(event){
            createOrEditProject(event.value);
        }

        function createOrEditProject(path){
            var existingProject = _.find(projects, { path: path });
            if(existingProject){
                editProject(existingProject);
            }
            else{
                createProject(path);
            }
        }

        function createProject(path){
            if(path){
                $modal.open({
                    templateUrl: 'views/projectmodal.html',
                    windowClass: 'project-modal',
                    controller: 'ProjectModalController',
                    resolve: {
                        project: function(){
                            return new Project({
                                path: path
                            });
                        }
                    }
                }).result
                    .then(function(project){
                        projects.push(project);
                        projects.save();
                        $scope.selected.project = project;
                    });
            }
        }

        function editProject(project){
            if(project){
                $modal.open({
                    templateUrl: 'views/projectmodal.html',
                    windowClass: 'project-modal',
                    controller: 'ProjectModalController',
                    resolve: {
                        project: function(){
                            return new Project(_.cloneDeep(project));
                        }
                    }
                }).result
                    .then(function(editedProject){
                        _.extend(project, editedProject);
                        projects.save();
                    });
            }
        }

        function openProjectFolder(project){
            open(project.path);
        }

        function removeProject(project){
            _.remove(projects, project);
            projects.save();
            $scope.selected.project = null;
        }

        function selectProject(projects){
            if(!$scope.selected.project){
                $scope.selected.project = projects[0];
            }
        }

        function selectFile(project){
            if(project){
                $scope.selected.file = project.files[0];
            }
            else{
                $scope.selected.file = null;
            }
        }
    });