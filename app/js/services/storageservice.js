angular.module('WinLess')
    .factory('storage', function(){
        return {
            get: function(name){
                if(localStorage[name]){
                    return JSON.parse(localStorage[name]);
                }
                return undefined;
            },
            put: function(name, value){
                localStorage[name] = JSON.stringify(value);
            },
            remove: function(name){
                delete localStorage[name];
            }
        };
    });