angular.module('WinLess')
    .factory('LessFile', function(Class, settings){
        return Class.extend({
            init: function(params){
                this.compileOptions = _.cloneDeep(settings.values.compileDefaults);
                this.path = params.path;
            }
        });
    });