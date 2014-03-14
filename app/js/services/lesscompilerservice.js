angular.module('WinLess')
    .factory('lessCompiler', function(){
        return {
            log: [],
            compile: function(file){
                console.log('Fake compiled: ' + file.path + ' to: ' + file.outputPath);
            }
        };
    });