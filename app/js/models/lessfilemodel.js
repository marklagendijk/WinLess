angular.module('WinLess')
    .factory('LessFile', function(Class){
        return Class.extend({
            init: function(params){
                _.extend(this, params);
                if(!this.name){
                    this.name = _.last(this.path.split('\\'));
                }
            }
        });
    });