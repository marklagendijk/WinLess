angular.module('WinLess')
    .factory('openExternal', function(exec){
        return {
            folder: function(path){
                return exec('explorer.exe "' + path + '"');
            }
        };
    });