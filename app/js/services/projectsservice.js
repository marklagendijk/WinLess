angular.module('WinLess')
    .factory('projects', function(storage, Project, LessFile){
        var projects = storage.get('projects') || [];
        projects = projects.map(function(project){
            project = new Project(project);
            project.files = project.files.map(function(file){
                return new LessFile(file);
            });
            return project;
        });

        projects.save = function(){
            storage.put('projects', projects);
        };

        return projects;
    });