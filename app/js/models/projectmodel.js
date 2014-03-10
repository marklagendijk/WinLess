angular.module('WinLess')
    .factory('Project', function(glob, path, Class){
        return Class.extend({
            init: function(params){
                this.name = params.name;
                this.path = params.path;
                this.files = [];

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
    });