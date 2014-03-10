angular.module('WinLess')
    .controller('ProjectsController', function($scope, $modal, projects, Project){
        $scope.projects = projects;
        $scope.selected = {
            project: null,
            file: null
        };

        $scope.foldersDropped = foldersDropped;
        $scope.folderSelected = folderSelected;
        $scope.editProject = editProject;
        $scope.removeProject = removeProject;


        function foldersDropped(event)
        {
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

        function removeProject(project){
            _.remove(projects, project);
            projects.save();
            $scope.selected.project = null;
        }
    });