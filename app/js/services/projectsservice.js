angular.module('WinLess')
    .factory('projects', function(storage){
        var projects = storage.get('projects') || [];
        projects.save = function(){
            storage.put('projects', projects);
        };

        return projects;
    });