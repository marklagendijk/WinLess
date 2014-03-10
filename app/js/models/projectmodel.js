angular.module('WinLess')
    .factory('Project', function(Class){
        var glob = require('glob');
        var path = require('path');

        var Project = Class.extend({
            init: function(params){
                this.name = params.name;
                this.path = params.path;
                if(!this.name){
                    this.name = _.last(this.path.split('\\'));
                }
            },
            getAvailableFilePaths: function(){
                var self = this;

                return glob.sync(this.path + '/**/*.less')
                    .map(function(filePath){
                        return path.relative(self.path, filePath);
                    });
            }
        });

        return Project;
    });