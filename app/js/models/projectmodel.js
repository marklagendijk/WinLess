angular.module('WinLess')
    .factory('Project', function(glob, path, Class){
        return Class.extend({
            init: function(params){
                this.path = params.path;
                this.name = params.name || _.last(this.path.split('\\'));
                this.files = params.files || [];
            },
            compile: function(){
                this.files.forEach(function(file){
                    file.compile();
                });
            },
            getAvailableFilePaths: function(){
                var self = this;
                return glob.sync(this.path + '/**/*.less')
                    .map(function(filePath){
                        return path.relative(self.path, filePath);
                    });
            }
        });
    });